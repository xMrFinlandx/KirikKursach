using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SchoolKursach.Scripts;

namespace SchoolKursach.Forms
{
    public partial class Director : Form
    {
        private List<string[]> _comboBoxContent = new List<string[]>();
        private List<string[]> _additionalComboBoxContent = new List<string[]>();

        private int _tableId = 0;

        public Director()
        {
            InitializeComponent();
        }

        private void Director_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = $"Здравствуйте, {Person.Fio}";
            TableNameLabel.Text = "Ученики";
            
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = false;

            SearchGroupBox.Text = "Поиск по ученику";

            var request = "select фио from Пользователи where [id должности] = 3 order by фио";

            _comboBoxContent = DataFill.RequestToList(request);

            DataFill.UpdateComboBox(SearchComboBox, _comboBoxContent, 0);

            request = "SELECT u.ФИО as Ученик, k.Буква, k.Класс, p.Предмет as Экзамен, o.Оценка, Четверть " +
                "FROM Пользователи u " +
                "JOIN Ученики uc ON u.ID = uc.[ID Пользователя] " +
                "JOIN Оценки o ON uc.ID = o.[ID Ученика] and o.Экзамен = 1 " +
                "JOIN План e ON o.[ID Плана] = e.[ID] " +
                "JOIN Предметы p ON e.[ID предмета] = p.Id " +
                "JOIN Классы k ON uc.[ID Класса] = k.ID";

            DataFill.UpdateDataGrid(DataTableView, request);
        }
        
        private void ShowData()
        {
            SubjectNameTextBox.Text = "";

            var tableRequest = "";
            var comboBoxRequest = "";

            if (_tableId < 0)
                _tableId = 4;

            if (_tableId > 4)
                _tableId = 0;

            switch (_tableId)
            {
                case 0:
                    ShowStudents(out tableRequest, out comboBoxRequest);
                    break;
                case 1:
                    ShowTeachers(out tableRequest, out comboBoxRequest);
                    break;
                case 2:
                    ShowClasses();
                    return;
                case 3:
                    ShowResults();
                    return;
                case 4:
                    ShowSubjects();
                    return;
            }

            DataFill.UpdateDataGrid(DataTableView, tableRequest);

            _comboBoxContent = DataFill.RequestToList(comboBoxRequest);

            DataFill.UpdateComboBox(SearchComboBox, _comboBoxContent, 0);
        }

        private void ShowDataByFilter()
        {
            var tableRequest = "";

            if (_tableId == 0)
                tableRequest = ShowStudentsByFilter();
            else if (_tableId == 1)
                tableRequest = ShowTeachersByFilter();
            else if (_tableId == 2)
                tableRequest = ShowClassesByFilter();
            else if (_tableId == 3)
                tableRequest = ShowResultsByFilter();
            else if (_tableId == 4)
                tableRequest = ShowSubjectsByFilter();

            try
            {
                DataFill.UpdateDataGrid(DataTableView, tableRequest);
            }
            catch (Exception ex)
            {
                if (_tableId == 4)
                    return;

                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        #region Show Table

        private void ShowTeachers(out string tableRequest, out string comboBoxRequest)
        {
            TableNameLabel.Text = "Учителя";
            
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = false;
            SearchGroupBox.Visible = true;

            SearchGroupBox.Text = "Поиск по преподавателю";
            
            tableRequest = "select Пользователи.ФИО as Преподаватель, Предметы.Предмет, Классы.Буква, Классы.Класс " +
                "from Пользователи, Предметы, Классы, План " +
                "where Пользователи.[ID Должности] = 2 and План.[ID Учителя] = Пользователи.ID " +
                "and План.[ID Предмета] = Предметы.ID and План.[ID Класса] = Классы.ID";
            
            comboBoxRequest = "select фио from Пользователи where [id должности] = 2 order by фио";
        }

        private void ShowStudents(out string tableRequest, out string comboBoxRequest)
        {
            TableNameLabel.Text = "Ученики";
            
            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = false;
            SearchGroupBox.Visible = true;

            SearchGroupBox.Text = "Поиск по ученику";
            
            tableRequest = "select u.фио as Ученик, k.Буква, k.Класс, p.Предмет  as Экзамен, o.Оценка, Четверть " +
                "from Пользователи u " +
                "join Ученики uc on u.ID = uc.[ID Пользователя] " +
                "join Оценки o on uc.ID = o.[ID Ученика] " +
                "join План e on o.[ID Плана] = e.[ID] and o.Экзамен = 1 " +
                "join Предметы p on e.[ID предмета] = p.Id " +
                "join Классы k on uc.[ID Класса] = k.ID";
            
            comboBoxRequest = "select фио from Пользователи where [id должности] = 3 order by фио";
        }

        private void ShowClasses()
        {
            TableNameLabel.Text = "Классы";
            
            SubjectSearchGroupBox.Visible= false;
            ClassSearchGroupBox.Visible = true;
            SearchGroupBox.Visible = false;

            var tableRequest = "select distinct Пользователи.фио as Ученик, Классы.Буква, Классы.Класс " +
                "from Пользователи, Классы, Ученики " +
                "where Пользователи.ID = Ученики.[ID Пользователя] and Ученики.[ID Класса] = Классы.ID";

            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            _comboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            _additionalComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(LetterComboBox, _comboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, _additionalComboBoxContent, 0);

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        private void ShowResults()
        {
            TableNameLabel.Text = "Экзамен и средний балл";

            SubjectSearchGroupBox.Visible = false;
            ClassSearchGroupBox.Visible = true;
            SearchGroupBox.Visible = false;

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

            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            _comboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            _additionalComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(LetterComboBox, _comboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, _additionalComboBoxContent, 0);

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        private void ShowSubjects()
        {
            TableNameLabel.Text = "Предметы";

            SubjectSearchGroupBox.Visible = true;
            ClassSearchGroupBox.Visible = false;
            SearchGroupBox.Visible = false;

            SearchGroupBox.Text = "Поиск по преподавателю";

            var tableRequest = $"SELECT Предмет, [Количество часов] FROM Предметы ";

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        #endregion

        #region Show By Filter

        private string ShowStudentsByFilter()
        {
            var fio = _comboBoxContent[SearchComboBox.SelectedIndex][0];

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
            var number =  DataFill.GetComboBoxValue(NumberComboBox, _additionalComboBoxContent, 0);
            var letter = DataFill.GetComboBoxValue(LetterComboBox, _comboBoxContent, 0);
            
            var letterFilter = letter != null ? $"Классы.Буква = '{letter}'" : "1=1";
            var numberFilter = number != null ? $"Классы.Класс = {number}" : "1=1";

            var tableRequest = $"select distinct Пользователи.Фио, Классы.Буква, Классы.Класс from Пользователи, Классы, Ученики " +
                $"where Пользователи.ID = Ученики.[ID Пользователя] and Ученики.[ID Класса] = Классы.ID and " +
                $"{letterFilter} and {numberFilter}";

            return tableRequest;
        }

        private string ShowResultsByFilter()
        {
            var letter = DataFill.GetComboBoxValue(LetterComboBox, _comboBoxContent, 0);
            var number = DataFill.GetComboBoxValue(NumberComboBox, _additionalComboBoxContent, 0); 

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
            var fio = _comboBoxContent[SearchComboBox.SelectedIndex][0];

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
        
        private void LetterComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowDataByFilter();
        private void NumberComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowDataByFilter();
        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e) => ShowDataByFilter();

        private void SubjectNameTextBox_KeyPress(object sender, KeyPressEventArgs e) => ShowDataByFilter();
        
        private void ClearFilterButton_Click(object sender, EventArgs e) => ShowData();
        
        private void NextTableButton_Click(object sender, EventArgs e)
        {
            _tableId++;
            ShowData();
        }

        private void PreviousTableButton_Click(object sender, EventArgs e)
        {
            _tableId--;
            ShowData();
        }
        
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
