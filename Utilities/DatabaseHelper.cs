using MySql.Data.MySqlClient;

namespace TruSwap.Automation.Tests.Utilities
{
    public class DatabaseHelper
    {
        private string connectionString = "server=localhost;user=root;database=truswap_db;port=3306;password=YOUR_PASSWORD;";

        public bool DoesUserExist(string email)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}