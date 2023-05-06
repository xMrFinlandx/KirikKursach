using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach.Forms
{
    public partial class Teacher : Form
    {
        List<string[]> subjectComboBoxContent = new List<string[]>();
        List<string[]> letterComboBoxContent = new List<string[]>();
        List<string[]> numberComboBoxContent = new List<string[]>();
        List<string[]> studentComboBoxContent = new List<string[]>();

        string teacherFio;

        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            teacherFio = Person.fio;

            // вывод приветствия пользователю
            WelcomeLabel.Text = $"Здравствуйте, {teacherFio}";

            UpdateComboBoxData();
            UpdateData();
        }

        // значение по умолчанию для обновления комбобокса с именами студентов
        private void UpdateData(bool updateStudentsComboBox = true)
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = LetterComboBox.SelectedItem != null ? letterComboBoxContent[LetterComboBox.SelectedIndex][0] : null;
            var number = NumberComboBox.SelectedItem != null ? numberComboBoxContent[NumberComboBox.SelectedIndex][0] : null;
            var subject = SubjectComboBox.SelectedItem != null ? subjectComboBoxContent[SubjectComboBox.SelectedIndex][0] : null;
            var student = StudentComboBox.SelectedItem != null ? studentComboBoxContent[StudentComboBox.SelectedIndex][0] : null;
            var exam = ExamsCheckBox.Checked;

            // на основе значений переменных, при помощи тернарного оператора cоздаются фильтры 
            var letterFilter = letter != null ? $"Классы.Буква = '{letter}'" : "1=1";
            var numberFilter = number != null ? $"Классы.Класс = {number}" : "1=1";
            var subjectFilter = subject != null ? $"Предметы.Предмет = '{subject}'" : "1=1";
            var studentFilter = student != null ? $" Пользователи.ФИО = '{student}'" : "1=1";

            if (updateStudentsComboBox)
            {
                // запрос для обновления комбобокса учеников
                var studentsComboBoxRequest = $"select фио from Пользователи, Классы, Ученики " +
                    $"where[id должности] = 3 " +
                    $"and Ученики.[ID Пользователя] = Пользователи.ID " +
                    $"and Ученики.[ID Класса] = Классы.Id " +
                    $"and {letterFilter}" +
                    $"and {numberFilter} " +
                    $"order by фио";

                studentComboBoxContent = DataFill.RequestToList(studentsComboBoxRequest);
                DataFill.UpdateComboBox(StudentComboBox, studentComboBoxContent, 0);
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
                 $"and План.[ID Учителя] = (select id from Пользователи where ФИО = '{teacherFio}') " +
                 $"and Оценки.Экзамен = '{exam}'";

            try
            {
                DataFill.UpdateDataGrid(DataTableView, request);
            }
            catch (Exception ex)
            {
                DataTableView.Columns.Clear();

                //MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void UpdateComboBoxData()
        {
            var studentsComboBoxRequest = "select фио from Пользователи where [id должности] = 3 order by фио";
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";
            var subjectComboBoxRequest = $"SELECT distinct Предмет FROM Предметы, План " +
                $"WHERE Предметы.ID = План.[ID Предмета] " +
                $"and План.[ID Учителя] = (select id from Пользователи where ФИО = '{teacherFio}') ";

            studentComboBoxContent = DataFill.RequestToList(studentsComboBoxRequest);
            letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);
            subjectComboBoxContent = DataFill.RequestToList(subjectComboBoxRequest);

            DataFill.UpdateComboBox(StudentComboBox, studentComboBoxContent, 0);
            DataFill.UpdateComboBox(LetterComboBox, letterComboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, numberComboBoxContent, 0);
            DataFill.UpdateComboBox(SubjectComboBox, subjectComboBoxContent, 0);

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
        // вызов метода для обновления данных при изменении выбранного элемента в комбобоксе или чекбоксе
        private void LetterComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void NumberComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void SubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData(false);

        private void StudentComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData(false);

        private void ExamsCheckBox_Click(object sender, EventArgs e) => UpdateData();

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            LetterComboBox.SelectedItem = null;
            NumberComboBox.SelectedItem = null;
            SubjectComboBox.SelectedItem = null;
            StudentComboBox.SelectedItem = null;

            ExamsCheckBox.Checked = false;

            UpdateData();
        }
    }
}
