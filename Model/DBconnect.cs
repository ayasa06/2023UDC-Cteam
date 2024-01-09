using System;
using Microsoft.Data.SqlClient;
using System.Text;

public class DBconnect
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                    builder.DataSource = "wiz-azure-dbserver-22310184.database.windows.net";
                    builder.UserID = "zeal22310184";
                    builder.Password = "Naruto3205";
                    builder.InitialCatalog = "wiz-azure-db-22310184";

                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        Console.WriteLine("\nQuery data example:");
                        Console.WriteLine("=========================================\n");

                        String sql = "SELECT * FROM dbo.Stops";

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            connection.Open();
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine("{0} {1}", reader.GetInt32(0), reader.GetString(1));
                                }
                            }
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.ToString());
                }
                Console.ReadLine();
            }
        }
    }
