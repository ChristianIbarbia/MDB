using System.Data.SqlClient;
using MDBModels;
namespace DL
{
    public class Sqldbdata
    {
          private string connectionString = "Data Source= DESKTOP-N5OCNK2\\SQLEXPRESS; Initial Catalog=MenuMcdollibee; Integrated Security=True;";
       
        public bool CreateMenu(menu menu)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("INSERT INTO Menu (ItemName, Category, Code) VALUES (@ItemName, @Category, @Code)", connection);
                    command.Parameters.AddWithValue("@ItemName", menu.ItemName);
                    command.Parameters.AddWithValue("@Category", menu.Category);
                    command.Parameters.AddWithValue("@Code", menu.Code);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;


                }
            }
            catch (SqlException ex)
            {
                // Log exception (ex)
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool UpdateMenu(menu menu)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("UPDATE Menu SET Code = @Code WHERE ItemName = @ItemName", connection);
                    command.Parameters.AddWithValue("@ItemName", menu.ItemName);
                    command.Parameters.AddWithValue("@Code", menu.Code);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                // Log exception (ex)
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool DeleteMenu(string code)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("DELETE FROM Menu WHERE Code = @Code", connection);
                    command.Parameters.AddWithValue("@Code", code);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                // Log exception (ex)
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public List<menu> GetAllMenus()
        {
            var menus = new List<menu>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("SELECT ItemName, Category, Code FROM Menu", connection);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var menu = new menu
                            {
                                ItemName = reader["ItemName"].ToString(),
                                Category = reader["Category"].ToString(),
                                Code = reader["Code"].ToString()
                            };
                            menus.Add(menu);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log exception (ex)
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Log exception (ex)
                Console.WriteLine($"Error: {ex.Message}");
            }
            return menus;
        }
    }
}
    