using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach.Forms
{
    public partial class Student : Form
    {
        private List<string[]> _comboBoxContent = new List<string[]>();
        private string _studentFio;

        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            _studentFio = Person.Fio;
            WelcomeLabel.Text = $"Здравствуйте, {_studentFio}";

            var request = "select предмет from предметы";
            _comboBoxContent = DataFill.RequestToList(request);

            DataFill.UpdateComboBox(SubjectComboBox, _comboBoxContent, 0);

            UpdateData();
        }

        private void UpdateData()
        {
            var letter = DataFill.GetComboBoxValue(SubjectComboBox, _comboBoxContent, 0);
            var exam = ExamCheckBox.Checked;
            
            var letterFilter = letter != null ? $"and Предметы.Предмет = '{letter}'" : "";

            var request = $"SELECT Предметы.Предмет, Оценка, Четверть, Экзамен " +
             $"FROM Оценки " +
             $"JOIN Ученики ON Ученики.ID = Оценки.[ID Ученика] " +
             $"JOIN Пользователи ON Ученики.[ID Пользователя] = Пользователи.ID " +
             $"JOIN План ON Оценки.[ID Плана] = План.ID " +
             $"JOIN Предметы ON План.[ID Предмета] = Предметы.ID " +
             $"WHERE Пользователи.ФИО = '{_studentFio}' AND Оценки.Экзамен = '{exam}' {letterFilter}";

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
        
        private void SubjectComboBox_SelectedIndexChanged(object sender, EventArgs e) => UpdateData();

        private void ExamCheckBox_Click(object sender, EventArgs e) => UpdateData();

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            ExamCheckBox.Checked = false;
            SubjectComboBox.SelectedItem = null;

            UpdateData();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            var form = new Auth();
            form.Show();
            Hide();
        }
    }
}
