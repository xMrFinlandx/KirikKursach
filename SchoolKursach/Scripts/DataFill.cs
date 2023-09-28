using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolKursach.Scripts
{
    public static class DataFill
    {
        public static void UpdateComboBox(ComboBox box, List<string[]> data, int index)
        {
            box.Items.Clear();

            foreach (var row in data)
            {
                box.Items.Add(row[index]);
            }
        }
        
        public static List<string[]> RequestToList(string request)
        {
            Connection.OpenConnection();
            
            var command = new SqlCommand(request, Connection.GetSqlConnection());

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
                            tempList.Add(Convert.ToString(reader.GetValue(i)));
                        
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
        
        public static int ApplyRequestAndGetID(string request)
        {
            var command = new SqlCommand(request, Connection.GetSqlConnection());
            
            Connection.OpenConnection();
            var id = (int) command.ExecuteScalar();
            Connection.CloseConnection();

            return id;
        }
        
        public static void UpdateDataGrid(DataGridView dataGridView, string request)
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
        }

        public static string GetComboBoxValue(ComboBox comboBox, List<string[]> data, int index)
        {
            return comboBox.SelectedItem != null ? data[comboBox.SelectedIndex][index] : null;
        }
    }
}
