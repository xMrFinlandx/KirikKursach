using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SchoolKursach.Scripts
{
    static class DataFill
    {

        // метод, принимающий в себя комбобокс, список массивов и индекс столбца в запросе
        public static void UpdateComboBox(ComboBox box, List<string[]> data, int index)
        {
            box.Items.Clear();

            for (int i = 0; i < data.Count; i++)
            {
                box.Items.Add(data[i][index]);
            }
        }

        // метод, принимающий запрос и возвращаюший список массивов,
        // где каждый элемент списка представляет строку из результатов запроса,
        // а каждый элемент этой строки - это значение поля из запроса.
        public static List<string[]> RequestToList(string request)
        {
            Connection.OpenConnection();

            // создаем новую команду SqlCommand, используя запрос и соединение
            var command = new SqlCommand(request, Connection.GetSqlConnection());

            var tempList = new List<string>();
            var result = new List<string[]>();

            // получение данных из запроса
            using (var reader = command.ExecuteReader())
            {
                // если в полученных данных есть строки
                if (reader.HasRows)
                {
                    // проходимся по всем строкам
                    while (reader.Read())
                    {
                        // очищаем временный список
                        tempList.Clear();

                        // проходимся по всем столбцам в текущей строке и добавляем их во временный список
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tempList.Add(Convert.ToString(reader.GetValue(i)));
                        }

                        // создаем новый массив строк для хранения текущей строки и копируем данные из временного списка
                        var tempArray = new string[tempList.Count];
                        tempList.CopyTo(tempArray);

                        // добавляем новый массив строк в список результирующих строк
                        result.Add(tempArray);
                    }
                }
            }
            Connection.CloseConnection();

            return result;
        }

        // метод, выполняющий запрос добавления/изменения/удаления
        public static void ApplyRequest(string request)
        {
            // создаем новую команду SqlCommand, используя запрос и соединение
            var command = new SqlCommand(request, Connection.GetSqlConnection());

            // открытие соединения
            Connection.OpenConnection();
            // выполнение запроса
            command.ExecuteNonQuery();
            //закрытие соединения
            Connection.CloseConnection();
        }

        // метод, выполняющий запрос и возвращающий ID добавленой/измененной/удаленной записи
        public static int ApplyRequestAndGetID(string request)
        {
            // создаем новую команду SqlCommand, используя запрос и соединение
            var command = new SqlCommand(request, Connection.GetSqlConnection());

            // открытие соединения
            Connection.OpenConnection();
            // выполнение запроса и получение ID добавленной записи с преобразованием в int
            var id = (int) command.ExecuteScalar();
            //закрытие соединения
            Connection.CloseConnection();

            return id;
        }

        // Метод принимает DataGridView, который нужно обновить, и строку запроса request.
        public static DataGridView UpdateDataGrid(DataGridView dataGridView, string request)
        {
            // создаем новую команду SqlCommand, используя запрос и соединение
            var command = new SqlCommand(request, Connection.GetSqlConnection());

            Connection.OpenConnection();

            // получение данных из запроса
            using (var reader = command.ExecuteReader())
            {
                // если в полученных данных нет строк
                if (!reader.HasRows)
                {
                    reader.Close();
                    throw new Exception("Данные по запросу не найдены");
                }

                // Создание новой таблицы данных
                var dataTable = new DataTable();
                // Загрузка полученных данных в таблицу
                dataTable.Load(reader);
                // Установка источника данных для DataGridView
                dataGridView.DataSource = dataTable;
            }
            Connection.CloseConnection();

            return dataGridView;
        }
    }
}
