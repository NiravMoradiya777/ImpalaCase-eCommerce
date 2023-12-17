using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImpalaCase_eCommerce.DataBaseManager
{
    public class LoginManager
    {
        private string connectionString;

        public LoginManager()
        {
            // Load connection string from web.config
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public LoginModule ValidateCredentials(string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Login WHERE Email = @Email AND Password = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            LoginModule loginModule = new LoginModule(Int32.Parse(reader["Id"].ToString()), reader["Email"].ToString(), reader["Password"].ToString(), reader["UserType"].ToString());
                            return loginModule;
                        }
                        else
                        {
                            return null; // No matching user found
                        }
                    }
                }
            }
        }


        public bool CreateUser(string email, string password, string usertype)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO login (Email, Password, UserType) VALUES (@Email, @Password, @UserType)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@UserType", usertype);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdatePassword(string email, string currentPassword, string newPassword)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Perform authentication before updating the password
                if (ValidateCredentials(email, currentPassword) == null)
                {
                    return false;
                }

                string query = "UPDATE login SET Password = @Password WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", newPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }

    }
}