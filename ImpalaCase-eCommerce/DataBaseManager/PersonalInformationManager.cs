using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.DataBaseManager
{
    public class PersonalInformationManager
    {
        private string connectionString;

        public PersonalInformationManager()
        {
            // Load connection string from web.config
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public UserDetailsModule GetUserDetails(int loginId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM userdetails WHERE Login_Id = @LoginId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoginId", loginId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserDetailsModule userDetails = new UserDetailsModule(
                                Convert.ToInt32(reader["Id"]),
                                Convert.ToInt32(reader["Login_Id"]),
                                reader["F_Name"].ToString(),
                                reader["M_Name"].ToString(),
                                reader["L_Name"].ToString(),
                                Convert.ToDateTime(reader["DOB"]),
                                reader["Address"].ToString()
                            );

                            return userDetails;
                        }
                    }
                }
            }

            return null;
        }

        public bool InsertUserDetails(UserDetailsModule userDetails)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO userdetails (Login_Id, F_Name, M_Name, L_Name, DOB, Address) " +
                           "VALUES (@LoginId, @FName, @MName, @LName, @DOB, @Address)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LoginId", userDetails.LoginId);
                    command.Parameters.AddWithValue("@FName", userDetails.FirstName);
                    command.Parameters.AddWithValue("@MName", userDetails.MiddleName);
                    command.Parameters.AddWithValue("@LName", userDetails.LastName);
                    command.Parameters.AddWithValue("@DOB", userDetails.DateOfBirth);
                    command.Parameters.AddWithValue("@Address", userDetails.Address);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateUserDetails(UserDetailsModule userDetails)
        {
            string query = "UPDATE userdetails " +
                           "SET F_Name = @FName, M_Name = @MName, L_Name = @LName, " +
                           "DOB = @DOB, Address = @Address " +
                           "WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", userDetails.Id);
                    command.Parameters.AddWithValue("@FName", userDetails.FirstName);
                    command.Parameters.AddWithValue("@MName", userDetails.MiddleName);
                    command.Parameters.AddWithValue("@LName", userDetails.LastName);
                    command.Parameters.AddWithValue("@DOB", userDetails.DateOfBirth);
                    command.Parameters.AddWithValue("@Address", userDetails.Address);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }

}