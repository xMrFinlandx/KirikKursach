using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolKursach.Scripts
{
    static class DataFill
    {
        public static void UpdateComboBox(ComboBox box, List<string[]> data, int index)
        {
            box.Items.Clear();

            for (int i = 0; i < data.Count; i++)
            {
                box.Items.Add(data[i][index]);
            }
        }

        public static List<string[]> RequestToList(string request)
        {
            Connection.OpenConnection();

            var command = new SqlCommand(String.Format(request), Connection.GetSqlConnection());

            var tempList = new List<string>();
            var result = new List<string[]>();

            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tempList.Clear();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempList.Add(Convert.ToString(reader.GetValue(i)));
                        }

                        var tempArray = new string[tempList.Count];
                        tempList.CopyTo(tempArray);
                        result.Add(tempArray);
                    }
                }
            }
            Connection.CloseConnection();

            return result;
        }

        public static void ApplyRequest(string request)
        {
            var command = new SqlCommand(request, Connection.GetSqlConnection());

            Connection.OpenConnection();
            command.ExecuteNonQuery();
            Connection.CloseConnection();
        }

        public static DataGridView UpdateDataGrid(DataGridView dataGridView, string request)
        {
            var command = new SqlCommand(request, Connection.GetSqlConnection());

            Connection.OpenConnection();

            using (var reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    reader.Close();
                    throw new Exception("Данные по запросу не найдены");
                }

                var dataTable = new DataTable();
                dataTable.Load(reader);
                dataGridView.DataSource = dataTable;
               
            }
            Connection.CloseConnection();

            return dataGridView;
        }
    }
}
