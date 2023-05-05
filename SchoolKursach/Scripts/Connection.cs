using System.Data.SqlClient;

namespace SchoolKursach.Scripts
{
    public static class Connection
    {
        static SqlConnection connection =
          new SqlConnection("Data Source = DESKTOP-QRTRTU4; Initial catalog = Школа; Integrated Security = True");

        // открывает соединение
        public static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        // закрывает соединение
        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        // возвращает строку подключения
        public static SqlConnection GetSqlConnection()
        {
            return connection;
        }
    }
}
