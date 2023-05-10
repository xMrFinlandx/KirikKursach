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
            // установка максимального количества символов для текстбокса
            AssessmentTextBox.MaxLength = 1;
            NewAssessmentTextBox.MaxLength = 1;

            teacherFio = Person.fio;

            // вывод приветствия пользователю
            WelcomeLabel.Text = $"Здравствуйте, {teacherFio}";

            // вызово метода обновления комбобоксов
            UpdateComboBoxData();

            // вызов метода обновления таблицы
            UpdateData();
        }

        #region Utilities

        // значение по умолчанию для обновления комбобокса с именами студентов
        private void UpdateData(bool updateStudentsComboBox = true)
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = LetterComboBox.SelectedItem != null ? letterComboBoxContent[LetterComboBox.SelectedIndex][0] : null;
            var number = NumberComboBox.SelectedItem != null ? numberComboBoxContent[NumberComboBox.SelectedIndex][0] : null;
            var subject = SubjectComboBox.SelectedItem != null ? subjectComboBoxContent[SubjectComboBox.SelectedIndex][0] : null;
            var student = StudentComboBox.SelectedItem != null ? studentComboBoxContent[StudentComboBox.SelectedIndex][0] : null;
            var quarter = QuarterComboBox.SelectedItem != null ? QuarterComboBox.SelectedItem.ToString() : null;

            var exam = ExamsCheckBox.Checked;

            // на основе значений переменных, при помощи тернарного оператора cоздаются фильтры 
            var letterFilter = letter != null ? $"Классы.Буква = '{letter}'" : "1=1";
            var numberFilter = number != null ? $"Классы.Класс = {number}" : "1=1";
            var subjectFilter = subject != null ? $"Предметы.Предмет = '{subject}'" : "1=1";
            var studentFilter = student != null ? $"Пользователи.ФИО = '{student}'" : "1=1";
            var quarterFilter = quarter != null ? $"Оценки.Четверть = '{quarter}'" : "1=1";

            if (updateStudentsComboBox)
            {
                // запрос для обновления комбобокса учеников
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

                studentComboBoxContent = DataFill.RequestToList(studentsComboBoxRequest);
                DataFill.UpdateComboBox(StudentComboBox, studentComboBoxContent, 0);
            }

            // запрос на вывод данных
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
                 $"and План.[ID Учителя] = (select id from Пользователи where ФИО = '{teacherFio}') " +
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
            // запрос на получение учеников
            var studentsComboBoxRequest = "select фио from Пользователи where [id должности] = 3 order by фио";
            // запрос на получение букв классов
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            // запрос на получение номера классов
            var numberComboBoxRequest = "Select distinct Класс from Классы";
            // запрос на получение предметов конкретного учителя
            var subjectComboBoxRequest = $"SELECT distinct Предмет FROM Предметы, План " +
                $"WHERE Предметы.ID = План.[ID Предмета] " +
                $"and План.[ID Учителя] = (select id from Пользователи where ФИО = '{teacherFio}') ";

            // запись данных в список массивов
            studentComboBoxContent = DataFill.RequestToList(studentsComboBoxRequest);
            letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);
            subjectComboBoxContent = DataFill.RequestToList(subjectComboBoxRequest);

            // передача данных в комбобокс
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

        private static void CheckDigits(KeyPressEventArgs e, bool isIdTextBox = false)
        {
            var number = e.KeyChar;

            // Проверяем, является ли клавиша Backspace
            if (number == (char)Keys.Back)
            {
                // Разрешаем ввод символа
                return;
            }

            // если это id текстбокс то разрешаем вводить любые цифры
            if (isIdTextBox && char.IsDigit(number))
            {
                // Разрешаем ввод символа
                return;
            }

            // Проверяем, является ли клавиша допустимой цифрой
            if (number >= '2' && number <= '5')
            {
                // Разрешаем ввод символа
                return;
            }

            // Отменяем событие и предотвращаем ввод символа
            e.Handled = true;
        }

        #endregion

        #region Buttons
        // кнопка изменения
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

        // кнопка удаления
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

        // кнопка добавления
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
                // В противном случае в нее записывается null
                var subject = SubjectComboBox.SelectedItem != null ? subjectComboBoxContent[SubjectComboBox.SelectedIndex][0] : null;
                var student = StudentComboBox.SelectedItem != null ? studentComboBoxContent[StudentComboBox.SelectedIndex][0] : null;
                var quarter = QuarterComboBox.SelectedItem != null ? QuarterComboBox.SelectedItem.ToString() : null;

                var exam = ExamsCheckBox.Checked;
                var assessment = AssessmentTextBox.Text;

                // проверка на пустые значения
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

        // вызов метода для обновления данных при изменении выбранного элемента в комбобоксе или чекбоксе
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

        // вызов проверки на цифры при вводе данных в текстбоксы
        private void AssessmentTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private void NewAssessmentTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private void IDTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e, true);

        #endregion
    }
}
