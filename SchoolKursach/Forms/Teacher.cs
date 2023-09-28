using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach.Forms
{
    public partial class Teacher : Form
    {
        private List<string[]> _subjectComboBoxContent = new List<string[]>();
        private List<string[]> _letterComboBoxContent = new List<string[]>();
        private List<string[]> _numberComboBoxContent = new List<string[]>();
        private List<string[]> _studentComboBoxContent = new List<string[]>();

        private string _teacherFio;

        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            AssessmentTextBox.MaxLength = 1;
            NewAssessmentTextBox.MaxLength = 1;

            _teacherFio = Person.Fio;
            
            WelcomeLabel.Text = $"Здравствуйте, {_teacherFio}";

            UpdateComboBoxData();

            UpdateData();
        }

        #region Utilities
        
        private void UpdateData(bool updateStudentsComboBox = true)
        {
            var letter = DataFill.GetComboBoxValue(LetterComboBox, _letterComboBoxContent, 0);
            var number = DataFill.GetComboBoxValue(NumberComboBox, _numberComboBoxContent, 0); 
            var subject = DataFill.GetComboBoxValue(SubjectComboBox, _subjectComboBoxContent, 0);
            var student = DataFill.GetComboBoxValue(StudentComboBox, _studentComboBoxContent, 0);
            var quarter = QuarterComboBox.SelectedItem?.ToString();

            var exam = ExamsCheckBox.Checked;
            
            var letterFilter = letter != null ? $"Классы.Буква = '{letter}'" : "1=1";
            var numberFilter = number != null ? $"Классы.Класс = {number}" : "1=1";
            var subjectFilter = subject != null ? $"Предметы.Предмет = '{subject}'" : "1=1";
            var studentFilter = student != null ? $"Пользователи.ФИО = '{student}'" : "1=1";
            var quarterFilter = quarter != null ? $"Оценки.Четверть = '{quarter}'" : "1=1";

            if (updateStudentsComboBox)
            {
                var studentsComboBoxRequest = $"select distinct Пользователи.фио from Пользователи " +
                    $"join Ученики on Ученики.[ID Пользователя] = Пользователи.ID " +
                    $"join Классы on Ученики.[ID Класса] = Классы.Id " +
                    $"join План on План.[ID Класса] = Классы.Id " +
                    $"join Предметы on План.[ID Предмета] = Предметы.Id " +
                    $"where [id должности] = 3 " +
                    $"and {letterFilter} " +
                    $"and {numberFilter} " +
                    $"and {subjectFilter} " +
                    $"order by Пользователи.фио";

                _studentComboBoxContent = DataFill.RequestToList(studentsComboBoxRequest);
                DataFill.UpdateComboBox(StudentComboBox, _studentComboBoxContent, 0);
            }
            
            var request = $"select distinct Оценки.Id, Пользователи.ФИО as Ученики, Предметы.Предмет, Оценка, " +
                 $"Классы.Буква, Классы.Класс, Оценки.Экзамен, Оценки.Четверть " +
                 $"from Оценки " +
                 $"join Ученики on Оценки.[ID Ученика] = Ученики.ID " +
                 $"join Пользователи on Ученики.[ID Пользователя] = Пользователи.ID " +
                 $"join План on Оценки.[ID Плана] = План.ID " +
                 $"join Классы on План.[ID Класса] = Классы.ID " +
                 $"join Предметы on План.[ID Предмета] = Предметы.ID " +
                 $"where {letterFilter} and {numberFilter} " +
                 $"and {subjectFilter} " +
                 $"and {studentFilter} " +
                 $"and {quarterFilter} " +
                 $"and План.[ID Учителя] = (select id from Пользователи where ФИО = '{_teacherFio}') " +
                 $"and Оценки.Экзамен = '{exam}'";

            try
            {
                DataFill.UpdateDataGrid(DataTableView, request);
            }
            catch (Exception)
            {
                DataTableView.Columns.Clear();
            }
        }

        private void UpdateComboBoxData()
        {
            var studentsComboBoxRequest = "select фио from Пользователи where [id должности] = 3 order by фио";
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";
            var subjectComboBoxRequest = $"SELECT distinct Предмет FROM Предметы, План " +
                $"WHERE Предметы.ID = План.[ID Предмета] " +
                $"and План.[ID Учителя] = (select id from Пользователи where ФИО = '{_teacherFio}') ";
            
            _studentComboBoxContent = DataFill.RequestToList(studentsComboBoxRequest);
            _letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            _numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);
            _subjectComboBoxContent = DataFill.RequestToList(subjectComboBoxRequest);
            
            DataFill.UpdateComboBox(StudentComboBox, _studentComboBoxContent, 0);
            DataFill.UpdateComboBox(LetterComboBox, _letterComboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, _numberComboBoxContent, 0);
            DataFill.UpdateComboBox(SubjectComboBox, _subjectComboBoxContent, 0);

            try
            {
                DataFill.UpdateDataGrid(DataTableView, studentsComboBoxRequest);
            }
            catch (Exception ex)
            {
                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private static void CheckDigits(KeyPressEventArgs e, bool isIdTextBox = false)
        {
            var number = e.KeyChar;

            if (number == (char)Keys.Back)
                return;

            if (isIdTextBox && char.IsDigit(number))
                return;
            
            if (number >= '2' && number <= '5')
                return;
            
            e.Handled = true;
        }

        #endregion

        #region Buttons
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                var assessment = NewAssessmentTextBox.Text;
                var id = IDTextBox.Text;

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(assessment))
                    throw new Exception("Поле Id и Оценка должно быть заполнено");

                var request = $"update Оценки set Оценка = {assessment} where id = '{id}'";

                DataFill.ApplyRequest(request);

                MessageBox.Show("Запись обновлена", "Уведомление");

                UpdateData(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var id = IDTextBox.Text;

                if (string.IsNullOrEmpty(id))
                    throw new Exception("Поле Id должно быть заполнено");

                var request = $"delete from Оценки where id = '{id}'";

                DataFill.ApplyRequest(request);

                MessageBox.Show("Запись удалена", "Уведомление");

                UpdateData(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var subject = DataFill.GetComboBoxValue(SubjectComboBox, _subjectComboBoxContent, 0);
                var student = DataFill.GetComboBoxValue(StudentComboBox, _studentComboBoxContent, 0);
                var quarter = QuarterComboBox.SelectedItem?.ToString();

                var exam = ExamsCheckBox.Checked;
                var assessment = AssessmentTextBox.Text;
                
                if (string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(assessment) 
                    || string.IsNullOrEmpty(student) || string.IsNullOrEmpty(quarter))
                {
                    throw new Exception("Для добавления оценки, обязательно должны быть выбраны " +
                          "предмет, четверть, ученик и указана оценка. Класс ученика необязателен и " +
                          "будет определен автоматически");
                }

                var request = $"INSERT INTO Оценки ([ID Плана], [ID Ученика], Оценка, Экзамен, Четверть) " +
                    $"SELECT План.ID, Ученики.id, {assessment}, '{exam}', {quarter} " +
                    $"FROM Пользователи " +
                    $"JOIN Ученики ON Ученики.[ID Пользователя] = Пользователи.ID " +
                    $"JOIN План ON Ученики.[ID Класса] = План.[ID Класса] AND План.[ID Предмета] = " +
                    $"(SELECT ID FROM Предметы WHERE Предмет = '{subject}') " +
                    $"JOIN Классы ON Ученики.[ID Класса] = Классы.ID AND Классы.Id = План.[ID Класса] " +
                    $"WHERE Пользователи.ФИО = '{student}' ";

                DataFill.ApplyRequest(request);

                MessageBox.Show("Оценка добавлена", "Уведомление");

                UpdateData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var form = new Auth();
            form.Show();
            Hide();
        }

        #endregion

        #region Events
        
        private void LetterComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void NumberComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void SubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void StudentComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData(false);

        private void QuarterComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData(false);

        private void ExamsCheckBox_Click(object sender, EventArgs e) => UpdateData(false);

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            LetterComboBox.SelectedItem = null;
            NumberComboBox.SelectedItem = null;
            SubjectComboBox.SelectedItem = null;
            StudentComboBox.SelectedItem = null;
            QuarterComboBox.SelectedItem = null;

            ExamsCheckBox.Checked = false;

            UpdateData();
        }
        
        private void AssessmentTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private void NewAssessmentTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private void IDTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e, true);

        #endregion
    }
}
