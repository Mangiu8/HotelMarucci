using System.Data.SqlClient;

namespace MarucciHotel.Models
{
    public class ConnectionClass
    {
        public static SqlConnection GetConnectionDB()
        {
            string connectionString = "Data Source=DESKTOP-3VJGK5G;Initial Catalog=MarucciHotel;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public static SqlCommand GetCommand(string query, SqlConnection connection)
        {
            SqlCommand command = new SqlCommand(query, connection);
            return command;
        }
    }
}
