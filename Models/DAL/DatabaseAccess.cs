using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Data;
using System.Data.SqlClient;

namespace PBL3.Models.DAL
{
    public class SqlConnectionData
    {
        public static SqlConnection Connect()
        {
            string strcon = @"Data Source=LAPTOP-LDVPSN8L\SQLEXPRESS;Initial Catalog=dbPBL3;Integrated Security=True";
            SqlConnection con = new SqlConnection(strcon);
            return con;
        }
    }
    public class DatabaseAccess
    {
            public Account GetUserByUsername(string username)
            {
                Account user = null;
                using (SqlConnection connection = SqlConnectionData.Connect())
                {
                    string query = "SELECT * FROM Account WHERE Username = @Username";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
    
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            user = new Account()
                            {
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString()
                            };
                        }
                    }
                    catch (Exception ex)
                    {
                         Console.WriteLine(ex.Message);
                    }
                }
                    return user;
            }


        }
            
        

    }
