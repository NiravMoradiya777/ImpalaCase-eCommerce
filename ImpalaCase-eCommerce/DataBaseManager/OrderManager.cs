using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.DataBaseManager
{
    public class OrderManager
    {
        private string connectionString;

        public OrderManager()
        {
            // Load connection string from web.config
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public bool CreateOrder(OrderBundleModule bundle)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO orderbundle (Login_Id, Full_Name, Contact_Number, Address, City, ZIP, Discount, ShippingPrice, OrderDate, Status, Total) VALUES (@LoginId, @FullName, @ContactNumber, @Address, @City, @ZIP, @Discount, @ShippingPrice, @OrderDate, @Status, @Total) SELECT SCOPE_IDENTITY();";
                    int insertedBundleId;
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@LoginId", bundle.LoginId);
                        command.Parameters.AddWithValue("@FullName", bundle.FullName);
                        command.Parameters.AddWithValue("@ContactNumber", bundle.ContactNumber);
                        command.Parameters.AddWithValue("@Address", bundle.Address);
                        command.Parameters.AddWithValue("@City", bundle.City);
                        command.Parameters.AddWithValue("@ZIP", bundle.ZIP);
                        command.Parameters.AddWithValue("@Discount", bundle.Discount);
                        command.Parameters.AddWithValue("@ShippingPrice", bundle.ShippingPrice);
                        command.Parameters.AddWithValue("@OrderDate", bundle.OrderDate);
                        command.Parameters.AddWithValue("@Status", bundle.Status);
                        command.Parameters.AddWithValue("@Total", bundle.Total);

                        insertedBundleId = Convert.ToInt32(command.ExecuteScalar());
                    }
                    InsertCartItemsAsOrders(connection, insertedBundleId, bundle.LoginId);
                    DeleteCartItemUsingUser(connection, bundle.LoginId);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void InsertCartItemsAsOrders(SqlConnection connection, int bundleId, int loginId)
        {
            string selectQuery = "SELECT C.*, Ca.Title, Ca.Price, Ca.Image FROM Cart C INNER JOIN phone_case Ca ON C.Case_Id = Ca.Id WHERE Login_Id = @LoginId";

            using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
            {
                selectCommand.Parameters.AddWithValue("@LoginId", loginId);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int caseId = Convert.ToInt32(reader["Case_Id"]);
                        int quantity = Convert.ToInt32(reader["Qty"]);
                        decimal unitPrice = Convert.ToDecimal(reader["Price"]);

                        OrdersModule order = new OrdersModule(
                            id: 0, // This will be assigned by the database
                            bundleId: bundleId,
                            caseId: caseId,
                            quantity: quantity,
                            unitPrice: unitPrice
                        );

                        InsertOrder(connection, order);
                    }
                }
            }
        }

        public static void InsertOrder(SqlConnection connection, OrdersModule order)
        {
            string insertQuery = "INSERT INTO orders (Bundle_Id, Case_Id, Qty, UnitPrice) VALUES (@BundleId, @CaseId, @Qty, @UnitPrice);";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@BundleId", order.BundleId);
                command.Parameters.AddWithValue("@CaseId", order.CaseId);
                command.Parameters.AddWithValue("@Qty", order.Quantity);
                command.Parameters.AddWithValue("@UnitPrice", order.UnitPrice);

                command.ExecuteNonQuery();
            }
        }

        // Delete a cart using user
        public bool DeleteCartItemUsingUser(SqlConnection connection, int loginId)
        {
            string query = "DELETE FROM cart WHERE Login_Id = @LoginId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LoginId", loginId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public OrderBundleModule GetMainOrder(int bundleId)
        {
            OrderBundleModule mainOrder = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM orderbundle WHERE Id = @BundleId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BundleId", bundleId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            mainOrder = new OrderBundleModule(
                                Convert.ToInt32(reader["Id"]),
                                Convert.ToInt32(reader["Login_Id"]),
                                reader["Full_Name"].ToString(),
                                reader["Contact_Number"].ToString(),
                                reader["Address"].ToString(),
                                reader["City"].ToString(),
                                reader["ZIP"].ToString(),
                                Convert.ToDecimal(reader["Discount"]),
                                Convert.ToDecimal(reader["ShippingPrice"]),
                                Convert.ToDateTime(reader["OrderDate"]),
                                reader["Status"].ToString(),
                                Convert.ToDecimal(reader["Total"])
                            );
                        }
                    }
                }
            }

            return mainOrder;
        }

        public List<OrdersWithTitleModule> GetSubOrders(int bundleId)
        {
            List<OrdersWithTitleModule> subOrders = new List<OrdersWithTitleModule>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT o.Id, pc.Title,  o.Case_Id, o.Qty, o.UnitPrice, pc.Image
                        FROM orders o
                        INNER JOIN phone_case pc ON o.Case_Id = pc.Id
                        WHERE o.Bundle_Id = @BundleId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BundleId", bundleId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrdersWithTitleModule subOrder = new OrdersWithTitleModule(
                                Convert.ToInt32(reader["Id"]),
                                bundleId,
                                Convert.ToInt32(reader["Case_Id"]),
                                Convert.ToDecimal(reader["Qty"]),
                                Convert.ToDecimal(reader["UnitPrice"]),
                                reader["Title"].ToString(),
                                reader["Image"].ToString()
                            );
                            subOrders.Add(subOrder);
                        }
                    }
                }
            }

            return subOrders;
        }

        public void UpdateOrderBundleStatus(int bundleId, string newStatus)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE orderbundle SET Status = @NewStatus WHERE Id = @BundleId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewStatus", newStatus);
                    command.Parameters.AddWithValue("@BundleId", bundleId);

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}