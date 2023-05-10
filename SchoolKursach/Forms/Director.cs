using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolKursach.Scripts;

namespace SchoolKursach.Forms
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
            // вывод приветствия пользователю
            WelcomeLabel.Text = $"Здравствуйте, {Person.fio}";

            // изменение заголовка
            TableNameLabel.Text = "Ученики";

            // выключение поисковых груп боксов
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = false;

            SearchGroupBox.Text = "Поиск по ученику";

            // запрос на получение данных для комбобокса
            var request = "select фио from Пользователи where [id должности] = 3 order by фио";

            comboBoxContent = DataFill.RequestToList(request);

            DataFill.UpdateComboBox(SearchComboBox, comboBoxContent, 0);

            // запрос на получение данных для вывода таблицы
            request = "SELECT u.ФИО as Ученик, k.Буква, k.Класс, p.Предмет as Экзамен, o.Оценка, Четверть " +
                "FROM Пользователи u " +
                "JOIN Ученики uc ON u.ID = uc.[ID Пользователя] " +
                "JOIN Оценки o ON uc.ID = o.[ID Ученика] and o.Экзамен = 1 " +
                "JOIN План e ON o.[ID Плана] = e.[ID] " +
                "JOIN Предметы p ON e.[ID предмета] = p.Id " +
                "JOIN Классы k ON uc.[ID Класса] = k.ID";

            DataFill.UpdateDataGrid(DataTableView, request);
        }

        // вывод таблицы на основе значения tableId
        private void ShowData()
        {
            SubjectNameTextBox.Text = "";

            var tableRequest = "";
            var comboBoxRequest = "";

            if (tableId < 0)
                tableId = 4;

            if (tableId > 4)
                tableId = 0;

            if (tableId == 0)
            {
                // метод, возвращающий запрос для таблицы и для комбобокса
                ShowStudents(out tableRequest, out comboBoxRequest);
            }
            else if (tableId == 1)
            {
                // метод, возвращающий запрос для таблицы и для комбобокса
                ShowTeachers(out tableRequest, out comboBoxRequest);
            }
            else if (tableId == 2)
            {
                ShowClasses();
                return;
            }
            else if (tableId == 3)
            {
                ShowResults();
                return;
            }
            else if (tableId == 4)
            {
                ShowSubjects();
                return;
            }

            DataFill.UpdateDataGrid(DataTableView, tableRequest);

            comboBoxContent = DataFill.RequestToList(comboBoxRequest);

            DataFill.UpdateComboBox(SearchComboBox, comboBoxContent, 0);
        }

        private void ShowDataByFilter()
        {
            var tableRequest = "";

            if (tableId == 0)
                tableRequest = ShowStudentsByFilter();
            else if (tableId == 1)
                tableRequest = ShowTeachersByFilter();
            else if (tableId == 2)
                tableRequest = ShowClassesByFilter();
            else if (tableId == 3)
                tableRequest = ShowResultsByFilter();
            else if (tableId == 4)
                tableRequest = ShowSubjectsByFilter();

            try
            {
                DataFill.UpdateDataGrid(DataTableView, tableRequest);
            }
            catch (Exception ex)
            {
                if (tableId == 4)
                    return;

                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        #region Show Table

        private void ShowTeachers(out string tableRequest, out string comboBoxRequest)
        {
            // изменение заголовка
            TableNameLabel.Text = "Учителя";

            // переключение элементов управления
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = false;
            SearchGroupBox.Visible = true;

            SearchGroupBox.Text = "Поиск по преподавателю";

            // запрос для таблицы
            tableRequest = "select Пользователи.ФИО as Преподаватель, Предметы.Предмет, Классы.Буква, Классы.Класс " +
                "from Пользователи, Предметы, Классы, План " +
                "where Пользователи.[ID Должности] = 2 and План.[ID Учителя] = Пользователи.ID " +
                "and План.[ID Предмета] = Предметы.ID and План.[ID Класса] = Классы.ID";

            // запрос для комбобокса
            comboBoxRequest = "select фио from Пользователи where [id должности] = 2 order by фио";
        }

        private void ShowStudents(out string tableRequest, out string comboBoxRequest)
        {
            // изменение заголовка
            TableNameLabel.Text = "Ученики";

            // переключение элементов управления
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = false;
            SearchGroupBox.Visible = true;

            SearchGroupBox.Text = "Поиск по ученику";

            // запрос для таблицы
            tableRequest = "select u.фио as Ученик, k.Буква, k.Класс, p.Предмет  as Экзамен, o.Оценка, Четверть " +
                "from Пользователи u " +
                "join Ученики uc on u.ID = uc.[ID Пользователя] " +
                "join Оценки o on uc.ID = o.[ID Ученика] " +
                "join План e on o.[ID Плана] = e.[ID] and o.Экзамен = 1 " +
                "join Предметы p on e.[ID предмета] = p.Id " +
                "join Классы k on uc.[ID Класса] = k.ID";

            // запрос для комбобокса
            comboBoxRequest = "select фио from Пользователи where [id должности] = 3 order by фио";
        }

        private void ShowClasses()
        {
            // изменение заголовка
            TableNameLabel.Text = "Классы";

            // переключение элементов управления
            SubjectSearchGroupBox.Visible= false;
            ClassSearchGroupBox.Visible = true;
            SearchGroupBox.Visible = false;

            // запрос для таблицы
            var tableRequest = "select distinct Пользователи.фио as Ученик, Классы.Буква, Классы.Класс " +
                "from Пользователи, Классы, Ученики " +
                "where Пользователи.ID = Ученики.[ID Пользователя] and Ученики.[ID Класса] = Классы.ID";

            // запросы для комбобоксов
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            comboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            additionalComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(LetterComboBox, comboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, additionalComboBoxContent, 0);

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        private void ShowResults()
        {
            // изменение заголовка
            TableNameLabel.Text = "Экзамен и средний балл";

            // переключение элементов управления
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = true;
            SearchGroupBox.Visible = false;

            // запрос для таблицы
            var tableRequest = "SELECT Пользователи.ФИО as 'Ученик', Предметы.Предмет, Буква, Класс," +
                "AVG(CASE WHEN Экзамен = 1 THEN Оценка ELSE NULL END) AS 'Средний балл по экзамену', " +
                "AVG(CASE WHEN Экзамен = 0 THEN Оценка ELSE NULL END) AS 'Средний балл за четверть' " +
                "FROM Оценки " +
                "JOIN Ученики ON Оценки.[ID Ученика] = Ученики.ID " +
                "JOIN Пользователи ON Ученики.[ID Пользователя] = Пользователи.ID " +
                "JOIN План ON Оценки.[ID Плана] = План.ID " +
                "JOIN Предметы ON План.[ID предмета] = Предметы.ID " +
                "JOIN Классы ON Ученики.[ID Класса] = Классы.ID " +
                "GROUP BY Ученики.ID, Пользователи.ФИО, Предметы.Предмет, Класс, Буква";

            // запросы для комбобоксов
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            comboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            additionalComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(LetterComboBox, comboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, additionalComboBoxContent, 0);

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        private void ShowSubjects()
        {
            // изменение заголовка
            TableNameLabel.Text = "Предметы";

            // переключение элементов управления
            SubjectSearchGroupBox.Visible = true;
            ClassSearchGroupBox.Visible = false;
            SearchGroupBox.Visible = false;

            SearchGroupBox.Text = "Поиск по преподавателю";

            // запрос для таблицы
            var tableRequest = $"SELECT Предмет, [Количество часов] FROM Предметы ";

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        #endregion

        #region Show By Filter

        private string ShowStudentsByFilter()
        {
            // получение выбранной записи из комбобокса
            var fio = comboBoxContent[SearchComboBox.SelectedIndex][0];

            var request = $"SELECT u.ФИО as Ученик, k.Буква, k.Класс, p.Предмет as Экзамен, o.Оценка, Четверть " +
                $"FROM Пользователи u " +
                $"JOIN Ученики uc ON u.ID = uc.[ID Пользователя] " +
                $"JOIN Оценки o ON uc.ID = o.[ID Ученика] " +
                $"JOIN План e ON o.[ID Плана] = e.[ID] and o.Экзамен = 1 " +
                $"JOIN Предметы p ON e.[ID предмета] = p.Id " +
                $"JOIN Классы k ON uc.[ID Класса] = k.ID " +
                $"WHERE u.ФИО = '{fio}'";

            return request;
        }

        private string ShowClassesByFilter()
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = LetterComboBox.SelectedItem != null ? comboBoxContent[LetterComboBox.SelectedIndex][0] : null;
            var number = NumberComboBox.SelectedItem != null ? additionalComboBoxContent[NumberComboBox.SelectedIndex][0] : null;

            // на основе значений переменных, при помощи тернарного оператора cоздаются фильтры 
            var letterFilter = letter != null ? $"Классы.Буква = '{letter}'" : "1=1";
            var numberFilter = number != null ? $"Классы.Класс = {number}" : "1=1";

            var tableRequest = $"select distinct Пользователи.Фио, Классы.Буква, Классы.Класс from Пользователи, Классы, Ученики " +
                $"where Пользователи.ID = Ученики.[ID Пользователя] and Ученики.[ID Класса] = Классы.ID and " +
                $"{letterFilter} and {numberFilter}";

            return tableRequest;
        }

        private string ShowResultsByFilter()
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = LetterComboBox.SelectedItem != null ? comboBoxContent[LetterComboBox.SelectedIndex][0] : null;
            var number = NumberComboBox.SelectedItem != null ? additionalComboBoxContent[NumberComboBox.SelectedIndex][0] : null;

            // на основе значений переменных, при помощи тернарного оператора cоздаются фильтры 
            var letterFilter = letter != null ? $"Классы.Буква = '{letter}'" : "1=1";
            var numberFilter = number != null ? $"Классы.Класс = {number}" : "1=1";

            var tableRequest = $"SELECT Пользователи.ФИО AS 'Ученик', Предметы.Предмет, Класс, Буква, " +
                $"AVG(CASE WHEN Экзамен = 1 THEN Оценка ELSE NULL END) AS 'Средний балл по экзамену', " +
                $"AVG(CASE WHEN Экзамен = 0 THEN Оценка ELSE NULL END) AS 'Средний балл за четверть' " +
                $"FROM Оценки " +
                $"JOIN Ученики ON Оценки.[ID Ученика] = Ученики.ID " +
                $"JOIN Пользователи ON Ученики.[ID Пользователя] = Пользователи.ID " +
                $"JOIN План ON Оценки.[ID Плана] = План.ID " +
                $"JOIN Предметы ON План.[ID предмета] = Предметы.ID " +
                $"JOIN Классы ON Ученики.[ID Класса] = Классы.ID " +
                $"WHERE {numberFilter} AND {letterFilter} " +
                $"GROUP BY Ученики.ID, Пользователи.ФИО, Предметы.Предмет, Класс, Буква ";

            return tableRequest;
        }

        private string ShowTeachersByFilter()
        {
            // получение выбранной записи из комбобокса
            var fio = comboBoxContent[SearchComboBox.SelectedIndex][0];

            var request = "select Пользователи.ФИО as Преподаватель, Предметы.Предмет, Классы.Буква, Классы.Класс " +
                "from Пользователи, Предметы, Классы, План " +
                "where Пользователи.[ID Должности] = 2 and План.[ID Учителя] = Пользователи.ID " +
                $"and План.[ID Предмета] = Предметы.ID and План.[ID Класса] = Классы.ID and Пользователи.фио = '{fio}'";

            return request;
        }

        private string ShowSubjectsByFilter()
        {
            var searchQuery = SubjectNameTextBox.Text;

            var request = $"SELECT Предмет, [Количество часов] FROM Предметы WHERE Предмет LIKE '%{searchQuery}%'";

            return request;
        }

        #endregion

        // вызов метода для выборки данных при изменении выбранного элемента в комбобоксах
        private void LetterComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowDataByFilter();
        private void NumberComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowDataByFilter();
        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowDataByFilter();

        private void SubjectNameTextBox_KeyPress(object sender, KeyPressEventArgs e) => ShowDataByFilter();

        // вывод таблицы без фильтров
        private void ClearFilterButton_Click(object sender, EventArgs e) => ShowData();

        // предыдущая таблица
        private void NextTableButton_Click(object sender, EventArgs e)
        {
            tableId++;
            ShowData();
        }
        
        // следующая таблица
        private void PreviousTableButton_Click(object sender, EventArgs e)
        {
            tableId--;
            ShowData();
        }

        // выход с формы
        private void ExitButton_Click(object sender, EventArgs e)
        {
            var form = new Auth();
            form.Show();
            Hide();
        }

        private void AddChangesButton_Click(object sender, EventArgs e)
        {
            var form = new AddChanges();
            form.Show();
            Hide();
        }
    }
}
