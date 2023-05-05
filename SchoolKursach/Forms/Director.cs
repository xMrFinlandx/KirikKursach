using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach
{
    public partial class Director : Form
    {
        List<string[]> comboBoxContent = new List<string[]>();
        List<string[]> additionalComboBoxContent = new List<string[]>();

        // номер таблицы
        int tableId = 0;

        public Director()
        {
            InitializeComponent();
        }

        private void Director_Load(object sender, EventArgs e)
        {
            ClassSearchGroupBox.Enabled = false;
            SearchByLabel.Text = "Поиск по ученику";

            // запрос на получение данных для комбобокса
            var request = "select фио from Пользователи where [id должности] = 3";

            comboBoxContent = DataFill.RequestToList(request);

            DataFill.UpdateComboBox(SearchComboBox, comboBoxContent, 0);

            // запрос на получение данных для вывода таблицы
            request = "SELECT u.ФИО as Ученик, k.Буква, k.Класс, p.Предмет, o.Оценка " +
                "FROM Пользователи u " +
                "JOIN Ученики uc ON u.ID = uc.[ID Пользователя] " +
                "JOIN Оценки o ON uc.ID = o.[ID Ученика] " +
                "JOIN Экзамены e ON o.[ID Экзамена] = e.[ID] " +
                "JOIN Предметы p ON e.[ID предмета] = p.Id " +
                "JOIN Классы k ON uc.[ID Класса] = k.ID";

            DataFill.UpdateDataGrid(DataTableView, request);
        }

        private void NextTableButton_Click(object sender, EventArgs e)
        {
            tableId++;

            UpdateTable();
        }

        private void PreviousTableButton_Click(object sender, EventArgs e)
        {
            tableId--;

            UpdateTable();
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        // вывод таблицы на основе значения tableId
        private void UpdateTable()
        {
            var tableRequest = "";
            var comboBoxRequest = "";

            if (tableId < 0)
            {
                tableId = 2;
            }

            if (tableId > 2)
            {
                tableId = 0;
            }

            if (tableId == 0)
            {
                ShowStudents(out tableRequest, out comboBoxRequest);
            }
            else if (tableId == 1)
            {
                ShowClasses();
                return;
            }
            else if (tableId == 2)
            {
                ShowTeachers(out tableRequest, out comboBoxRequest);
            }

            DataFill.UpdateDataGrid(DataTableView, tableRequest);

            comboBoxContent = DataFill.RequestToList(comboBoxRequest);

            DataFill.UpdateComboBox(SearchComboBox, comboBoxContent, 0);
        }

        // вызов метода для выборки данных при изменении выбранного элемента в текстбоксах
        private void LetterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableRequest = ShowClassesByFilter();

            try
            {
                DataFill.UpdateDataGrid(DataTableView, tableRequest);
            }
            catch (Exception ex)
            {
                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void NumberComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableRequest = ShowClassesByFilter();

            try
            {
                DataFill.UpdateDataGrid(DataTableView, tableRequest);
            }
            catch (Exception ex)
            {
                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tableRequest = "";

            if (tableId == 0)
                tableRequest = ShowStudentsByFilter();
            if (tableId == 2)
                tableRequest = ShowTeachersByFilter();

            try
            {
                DataFill.UpdateDataGrid(DataTableView, tableRequest);
            }
            catch (Exception ex)
            {
                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        #region Show Table

        private void ShowTeachers(out string tableRequest, out string comboBoxRequest)
        {
            ClassSearchGroupBox.Enabled = false;
            SearchGroupBox.Enabled = true;

            SearchByLabel.Text = "Поиск по преподавателю";

            tableRequest = "select Пользователи.ФИО as Преподаватель, Предметы.Предмет, Классы.Буква, Классы.Класс " +
                "from Пользователи, Предметы, Классы, Экзамены " +
                "where Пользователи.[ID Должности] = 2 and Экзамены.[ID Учителя] = Пользователи.ID " +
                "and Экзамены.[ID Предмета] = Предметы.ID and Экзамены.[ID Класса] = Классы.ID";

            comboBoxRequest = "select фио from Пользователи where [id должности] = 2";
        }

        private void ShowStudents(out string tableRequest, out string comboBoxRequest)
        {
            ClassSearchGroupBox.Enabled = false;
            SearchGroupBox.Enabled = true;

            SearchByLabel.Text = "Поиск по ученику";

            tableRequest = "select u.фио as Ученик, k.Буква, k.Класс, p.Предмет, o.Оценка " +
                "from Пользователи u " +
                "join Ученики uc on u.ID = uc.[ID Пользователя] " +
                "join Оценки o on uc.ID = o.[ID Ученика] " +
                "join Экзамены e on o.[ID Экзамена] = e.[ID] " +
                "join Предметы p on e.[ID предмета] = p.Id " +
                "join Классы k on uc.[ID Класса] = k.ID";

            comboBoxRequest = "select фио from Пользователи where [id должности] = 3";
        }

        private void ShowClasses()
        {
            ClassSearchGroupBox.Enabled = true;
            SearchGroupBox.Enabled = false;

            var tableRequest = "select distinct Пользователи.фио as Ученик, Классы.Буква, Классы.Класс " +
                "from Пользователи, Классы, Ученики " +
                "where Пользователи.ID = Ученики.[ID Пользователя] and Ученики.[ID Класса] = Классы.ID";

            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            comboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            additionalComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(LetterComboBox, comboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, additionalComboBoxContent, 0);

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        #endregion

        #region Show By Filter

        private string ShowStudentsByFilter()
        {
            var request = $"SELECT u.ФИО as Ученик, k.Буква, k.Класс, p.Предмет, o.Оценка " +
                $"FROM Пользователи u " +
                $"JOIN Ученики uc ON u.ID = uc.[ID Пользователя] " +
                $"JOIN Оценки o ON uc.ID = o.[ID Ученика] " +
                $"JOIN Экзамены e ON o.[ID Экзамена] = e.[ID] " +
                $"JOIN Предметы p ON e.[ID предмета] = p.Id " +
                $"JOIN Классы k ON uc.[ID Класса] = k.ID " +
                $"WHERE u.ФИО = '{comboBoxContent[SearchComboBox.SelectedIndex][0]}'";

            return request;
        }

        private string ShowClassesByFilter()
        {

            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = LetterComboBox.SelectedItem != null ? comboBoxContent[LetterComboBox.SelectedIndex][0] : null;
            var number = NumberComboBox.SelectedItem != null ? additionalComboBoxContent[NumberComboBox.SelectedIndex][0] : null;

            // на основе значений переменных, при помощи тернарного оператора изменяется запрос 
            var tableRequest = $"select distinct Пользователи.Фио, Классы.Буква, Классы.Класс from Пользователи, Классы, Ученики " +
                $"where Пользователи.ID = Ученики.[ID Пользователя] and Ученики.[ID Класса] = Классы.ID " +
                $"{(letter != null ? $"and Классы.Буква = '{letter}'" : "")} " +
                $"{(number != null ? $"and Классы.Класс = {number}" : "")}";

            return tableRequest;
        }

        private string ShowTeachersByFilter()
        {
            var fio = comboBoxContent[SearchComboBox.SelectedIndex][0];

            var request = "select Пользователи.ФИО as Преподаватель, Предметы.Предмет, Классы.Буква, Классы.Класс " +
                "from Пользователи, Предметы, Классы, Экзамены " +
                "where Пользователи.[ID Должности] = 2 and Экзамены.[ID Учителя] = Пользователи.ID " +
                $"and Экзамены.[ID Предмета] = Предметы.ID and Экзамены.[ID Класса] = Классы.ID and Пользователи.фио = '{fio}'";

            return request;
        }

        #endregion
    }
}
