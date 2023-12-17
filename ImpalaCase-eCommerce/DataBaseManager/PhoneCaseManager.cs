using ImpalaCase_eCommerce.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;

namespace ImpalaCase_eCommerce.DataBaseManager
{

    public class PhoneCaseManager
    {
        private string connectionString;

        public PhoneCaseManager()
        {
            // Load connection string from web.config
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public PhoneCaseModule GetCaseById(int id)
        {
            // Connection string from Web.config
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Title,Image, Short_Description, Long_Description, About, Weight, Dimensions, Color, Compatible_Phone_Models, Material, Price, IsActive FROM phone_case WHERE Id = @CaseId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CaseId", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Create a CaseModule instance and populate its properties
                            PhoneCaseModule caseModule = new PhoneCaseModule(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetString(3),
                                reader.GetString(4),
                                reader.GetString(5),
                                reader.GetDecimal(6),
                                reader.GetString(7),
                                reader.GetString(8),
                                reader.GetString(9),
                                reader.GetString(10),
                                reader.GetDecimal(11),
                                reader.GetBoolean(12)
                            );

                            return caseModule;
                        }
                    }
                }
            }

            return null;
        }

        public bool AddCase(PhoneCaseModule caseModule)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO phone_case (Title,Image, Short_Description, Long_Description, About, Weight, Dimensions, Color, Compatible_phone_models, Material, Price) " +
                                     "VALUES (@Title, @Image, @ShortDescription, @LongDescription, @About, @Weight, @Dimensions, @Color, @Model, @Material, @Price)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Title", caseModule.Title);
                    command.Parameters.AddWithValue("@Image", caseModule.Image);
                    command.Parameters.AddWithValue("@ShortDescription", caseModule.ShortDescription);
                    command.Parameters.AddWithValue("@LongDescription", caseModule.LongDescription);
                    command.Parameters.AddWithValue("@About", caseModule.About);
                    command.Parameters.AddWithValue("@Weight", caseModule.Weight);
                    command.Parameters.AddWithValue("@Dimensions", caseModule.Dimensions);
                    command.Parameters.AddWithValue("@Color", caseModule.Color);
                    command.Parameters.AddWithValue("@Model", caseModule.CompatiblePhoneModels);
                    command.Parameters.AddWithValue("@Material", caseModule.Material);
                    command.Parameters.AddWithValue("@Price", caseModule.Price);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateCase(PhoneCaseModule caseModule)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"UPDATE phone_case SET 
                        Title = @Title,
                        Short_Description = @ShortDescription,
                        Long_Description = @LongDescription,
                        About = @About,
                        Weight = @Weight,
                        Dimensions = @Dimensions,
                        Color = @Color,
                        Compatible_Phone_Models = @CompatiblePhoneModels,
                        Material = @Material,
                        Price = @Price,
                        IsActive = @IsActive
                        WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", caseModule.Title);
                    command.Parameters.AddWithValue("@ShortDescription", caseModule.ShortDescription);
                    command.Parameters.AddWithValue("@LongDescription", caseModule.LongDescription);
                    command.Parameters.AddWithValue("@About", caseModule.About);
                    command.Parameters.AddWithValue("@Weight", caseModule.Weight);
                    command.Parameters.AddWithValue("@Dimensions", caseModule.Dimensions);
                    command.Parameters.AddWithValue("@Color", caseModule.Color);
                    command.Parameters.AddWithValue("@CompatiblePhoneModels", caseModule.CompatiblePhoneModels);
                    command.Parameters.AddWithValue("@Material", caseModule.Material);
                    command.Parameters.AddWithValue("@Price", caseModule.Price);
                    command.Parameters.AddWithValue("@IsActive", caseModule.IsActive);
                    command.Parameters.AddWithValue("@Id", caseModule.Id);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0; // Return true if any rows were updated
                }
            }
        }

    }
}