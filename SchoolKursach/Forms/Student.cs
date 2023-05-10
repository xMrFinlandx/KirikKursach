using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach.Forms
{
    public partial class Student : Form
    {
        List<string[]> comboBoxContent = new List<string[]>();
        string studentFio;

        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, System.EventArgs e)
        {
            studentFio = Person.fio;

            // вывод приветствия пользователю
            WelcomeLabel.Text = $"Здравствуйте, {studentFio}";

            var request = "select предмет from предметы";
            comboBoxContent = DataFill.RequestToList(request);

            DataFill.UpdateComboBox(SubjectComboBox, comboBoxContent, 0);

            UpdateData();
        }

        private void UpdateData()
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = SubjectComboBox.SelectedItem != null ? comboBoxContent[SubjectComboBox.SelectedIndex][0] : null;
            var exam = ExamCheckBox.Checked;

            // на основе значений переменных, при помощи тернарного оператора cоздаются фильтры 
            var letterFilter = letter != null ? $"and Предметы.Предмет = '{letter}'" : "";

            var request = $"SELECT Предметы.Предмет, Оценка, Четверть, Экзамен " +
             $"FROM Оценки " +
             $"JOIN Ученики ON Ученики.ID = Оценки.[ID Ученика] " +
             $"JOIN Пользователи ON Ученики.[ID Пользователя] = Пользователи.ID " +
             $"JOIN План ON Оценки.[ID Плана] = План.ID " +
             $"JOIN Предметы ON План.[ID Предмета] = Предметы.ID " +
             $"WHERE Пользователи.ФИО = '{studentFio}' AND Оценки.Экзамен = '{exam}' {letterFilter}";

            try
            {
                DataFill.UpdateDataGrid(DataTableView, request);
            }
            catch (Exception ex)
            {
                DataTableView.Columns.Clear();

                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        // вызов метода для выборки данных при изменении выбранного элемента в комбобоксе или чекбоксе
        private void SubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void ExamCheckBox_Click(object sender, EventArgs e) => UpdateData();

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            ExamCheckBox.Checked = false;
            SubjectComboBox.SelectedItem = null;

            UpdateData();
        }

        // выход с формы
        private void ExitButton_Click(object sender, EventArgs e)
        {
            var form = new Auth();
            form.Show();
            Hide();
        }
    }
}
