using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.DataBaseManager
{
    public class CartManager
    {
        private string connectionString;

        public CartManager()
        {
            // Load connection string from web.config
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        // Get a cart item by its Id
        public CartModule GetCartItemById(int cartItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM cart WHERE Id = @CartItemId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CartItemId", cartItemId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int loginId = (int)reader["Login_Id"];
                            int caseId = (int)reader["Case_Id"];
                            int quantity = (int)reader["Qty"];

                            return new CartModule(cartItemId, loginId, caseId, quantity);
                        }
                    }
                }
            }

            return null; // If the cart item doesn't exist
        }

        // Get the cart items for a specific case by its CaseId and LoginId
        public List<CartModule> GetCartByCaseIdAndLoginId(int caseId, int loginId)
        {
            List<CartModule> cartItems = new List<CartModule>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM cart WHERE Case_Id = @CaseId AND Login_Id = @LoginId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CaseId", caseId);
                    command.Parameters.AddWithValue("@LoginId", loginId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            int quantity = (int)reader["Qty"];

                            CartModule cartItem = new CartModule(id, loginId, caseId, quantity);
                            cartItems.Add(cartItem);
                        }
                    }
                }
            }

            return cartItems;
        }

        // Get the cart items for a specific user by their login ID
        public List<CartModule> GetCartByLoginId(int loginId)
        {
            List<CartModule> cartItems = new List<CartModule>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM cart WHERE Login_Id = @LoginId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoginId", loginId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = (int)reader["Id"];
                            int caseId = (int)reader["Case_Id"];
                            int quantity = (int)reader["Qty"];

                            CartModule cartItem = new CartModule(id, loginId, caseId, quantity);
                            cartItems.Add(cartItem);
                        }
                    }
                }
            }

            return cartItems;
        }

        // Update the quantity of an item in the cart
        public bool UpdateCartQty(int cartItemId, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE cart SET Qty += @NewQuantity WHERE Id = @CartItemId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    command.Parameters.AddWithValue("@CartItemId", cartItemId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Delete a cart item by its ID
        public bool DeleteCartItem(int cartItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM cart WHERE Id = @CartItemId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CartItemId", cartItemId);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // Add an item to the cart
        public bool AddToCart(CartModule cart)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO cart (Login_Id, Case_Id, Qty) VALUES (@LoginId, @CaseId, @Quantity)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoginId", cart.LoginId);
                    command.Parameters.AddWithValue("@CaseId", cart.CaseId);
                    command.Parameters.AddWithValue("@Quantity", cart.Quantity);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }
}