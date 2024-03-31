using PBL3.Models;
using PBL3.Models.DAL;
using System.Data.SqlClient;
namespace PBL3.Areas.Admin.Models.DAL
{
    public class RoleDAL
    {

        public List<Role> GetAllRoles()
        {
            List<Role> roles = new List<Role>();
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                string query = "SELECT * FROM Role";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Role role = new Role
                        {
                            RoleID = Convert.ToInt32(reader["RoleID"]),
                            RoleName = reader["RoleName"].ToString()
                        };
                        roles.Add(role);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return roles;
        }
        public void AddRole(Role role)
        {
            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                string querry = "INSERT INTO ROLE (RoleName) VALUES (@name)";
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.AddWithValue("@name", role.RoleName);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void DeleteRole(int id)
        {

            using (SqlConnection connection = SqlConnectionData.Connect())
            {
                string query = "DELETE FROM Role WHERE RoleID = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void EditRole(Role role)
        {
            using(SqlConnection connection = SqlConnectionData.Connect())
            {
                string querry = "UPDATE Role SET RoleName = @name WHERE RoleID = @id;";
                SqlCommand command = new SqlCommand(querry, connection);
                command.Parameters.AddWithValue("@id", role.RoleID);
                command.Parameters.AddWithValue("@name", role.RoleName.ToString());
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}"); 
                }
            }
        }
    }
}
