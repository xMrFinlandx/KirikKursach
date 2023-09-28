using System.Data.SqlClient;

namespace SchoolKursach.Scripts
{
    public static class Connection
    {
        private static readonly SqlConnection _connection =
          new SqlConnection("Data Source = DESKTOP-QRTRTU4; Initial catalog = Школа; Integrated Security = True");
        
        public static void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }
        
        public static void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        public static SqlConnection GetSqlConnection()
        {
            return _connection;
        }
    }
}
