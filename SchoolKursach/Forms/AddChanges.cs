using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach.Forms
{
    public partial class AddChanges : Form
    {
        List<string[]> subjectComboBoxContent = new List<string[]>();
        List<string[]> teacherComboBoxContent = new List<string[]>();

        List<string[]> roleComboBoxContent = new List<string[]>();

        List<string[]> letterComboBoxContent = new List<string[]>();
        List<string[]> numberComboBoxContent = new List<string[]>();

        int tableId = 0;

        bool isStudent = false;

        public AddChanges()
        {
            InitializeComponent();
        }

        private void AddChanges_Load(object sender, EventArgs e)
        {
            // установление статусов отображения для груп боксов
            AddPlanGroupBox.Visible = false;
            AddSubjectGroupBox.Visible = false;
            AddUserGroupBox.Visible = true;

            ShowData();
        }

        private void ShowData()
        {
            var tableRequest = "";

            if (tableId < 0)
            {
                tableId = 3;
            }

            if (tableId > 3)
            {
                tableId = 0;
            }

            if (tableId == 0)
                tableRequest = ShowUsers();
            else if (tableId == 1)
                tableRequest = ShowStudents();
            else if (tableId == 2)
                tableRequest = ShowSubjects();
            else if (tableId == 3)
                tableRequest = ShowPlan();

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        #region Show Data Requests

        private string ShowUsers()
        {
            // изменение заголовка
            TableNameLabel.Text = "Пользователи";

            // установление статусов отображения для груп боксов
            AddPlanGroupBox.Visible = false;
            AddSubjectGroupBox.Visible = false;
            AddUserGroupBox.Visible = true;

            ClassGroupBox.Enabled = false;

            var request = "select пользователи.id, Должности.Должность, ФИО as Пользователь, Логин, Пароль " +
                "from пользователи, должности " +
                "where Должности.ID = Пользователи.[ID Должности]";

            FillUsersComboBox();

            return request;
        }

        private string ShowStudents()
        {
            // изменение заголовка
            TableNameLabel.Text = "Ученики";

            // установление статусов отображения для груп боксов
            AddPlanGroupBox.Visible = false;
            AddSubjectGroupBox.Visible = false;
            AddUserGroupBox.Visible = true;

            ClassGroupBox.Enabled = false;

            var request = "select Ученики.ID, Фио, Классы.Буква, Классы.Класс as Ученик from Ученики, Классы, Пользователи " +
                "where Ученики.[ID Пользователя] = Пользователи.ID " +
                "and Ученики.[ID Класса] = Классы.ID";

            FillUsersComboBox();

            return request;
        }

        private string ShowSubjects()
        {
            // изменение заголовка
            TableNameLabel.Text = "Предметы";

            // установление статусов отображения для груп боксов
            AddPlanGroupBox.Visible = false;
            AddSubjectGroupBox.Visible = true;
            AddUserGroupBox.Visible = false;

            var request = "select * from Предметы";

            return request;
        }

        private string ShowPlan()
        {
            // изменение заголовка
            TableNameLabel.Text = "План";

            // установление статусов отображения для груп боксов
            AddPlanGroupBox.Visible = true;
            AddSubjectGroupBox.Visible = false;
            AddUserGroupBox.Visible = false;

            var request = "select План.ID, Классы.Буква, Классы.Класс, Предметы.Предмет, Пользователи.ФИО as Преподаватель " +
                "from План, Классы, Предметы, Пользователи " +
                "where План.[ID Класса] = Классы.ID " +
                "and План.[ID Предмета] = Предметы.ID " +
                "and План.[ID Учителя] = Пользователи.ID";

            FillPlanComboBoxes();

            return request;
        }

        #endregion

        #region ComboBox Fill

        private void FillPlanComboBoxes()
        {
            // запросы для получения данных для комбобоксов
            var teacherComboBoxRequest = "select ФИО from пользователи where [Id должности] = 2";
            var subjectComboBoxRequest = "select Предмет from предметы";
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            // получение данных из запроса и запись в список массивов
            teacherComboBoxContent = DataFill.RequestToList(teacherComboBoxRequest);
            subjectComboBoxContent = DataFill.RequestToList(subjectComboBoxRequest);
            letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            // обновление данных комбобоксов
            DataFill.UpdateComboBox(TeacherComboBox, teacherComboBoxContent, 0);
            DataFill.UpdateComboBox(SubjectComboBox, subjectComboBoxContent, 0);
            DataFill.UpdateComboBox(PlanLetterComboBox, letterComboBoxContent, 0);
            DataFill.UpdateComboBox(PlanNumberComboBox, numberComboBoxContent, 0);
        }

        private void FillUsersComboBox()
        {
            // запросы для получения данных для комбобоксов
            var roleComboBoxRequest = "select Должность from Должности";
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            // получение данных из запроса и запись в список массивов
            roleComboBoxContent = DataFill.RequestToList(roleComboBoxRequest);
            letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            // обновление данных комбобоксов
            DataFill.UpdateComboBox(RoleComboBox, roleComboBoxContent, 0);
            DataFill.UpdateComboBox(LetterComboBox, letterComboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, numberComboBoxContent, 0);
        }

        #endregion

        #region Add

        private void AddSubject()
        {
            var subject = SubjectTextBox.Text;
            var hours = HoursTextBox.Text;

            var request = $"insert into Предметы values ('{subject}', {hours})";

            try
            {
                DataFill.ApplyRequest(request);

                MessageBox.Show("Предмет успешно добавлен", "Уведомление");

                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }

        }

        private void AddUser()
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = LetterComboBox.SelectedItem != null ? letterComboBoxContent[LetterComboBox.SelectedIndex][0] : null;
            var number = NumberComboBox.SelectedItem != null ? numberComboBoxContent[NumberComboBox.SelectedIndex][0] : null;

            var role = RoleComboBox.SelectedItem != null ? roleComboBoxContent[RoleComboBox.SelectedIndex][0] : null;
            var fio = FIOTextBox.Text;
            var login = LoginTextBox.Text;
            var pass = PassTextBox.Text;

            try
            {
                // проверка на пустые значения
                if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
                    throw new Exception("Поля Роль, Фамилия, Логин и Пароль должны быть заполнены");

                // если добавляется ученик
                if (isStudent)
                {
                    if (string.IsNullOrEmpty(letter) || string.IsNullOrEmpty(number))
                        throw new Exception("Для роли Ученик, поля Буква и Класс должны быть заполнены");
                }

                // запрос на добавление новой записи в базу данных с хешированием пароля и получение ID этой записи
                var request = $"insert into Пользователи output inserted.ID " +
                    $"values ((select id from Должности where Должность = '{role}') , '{fio}', '{login}',  HASHBYTES('SHA2_256', '{pass}'))";

                // получение id добавленной записи
                var id = DataFill.ApplyRequestAndGetID(request);

                // если это студент, то он добавляется в класс
                if (isStudent)
                {
                    request = $"insert into Ученики " +
                    $"values ({id}, (select id from Классы where Буква = '{letter}' and Класс = {number}))";

                    DataFill.ApplyRequest(request);
                }

                MessageBox.Show("Пользователь успешно добавлен", "Уведомление");

                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void AddPlan()
        {
            // тернарный оператор ?. Если значение SelectedItem != null, то в переменную записывается значение из комбобокса.
            // В противном случае в нее записывается null
            var letter = PlanLetterComboBox.SelectedItem != null ? letterComboBoxContent[PlanLetterComboBox.SelectedIndex][0] : null;
            var number = PlanNumberComboBox.SelectedItem != null ? numberComboBoxContent[PlanNumberComboBox.SelectedIndex][0] : null;
            var teacher = TeacherComboBox.SelectedItem != null ? teacherComboBoxContent[TeacherComboBox.SelectedIndex][0] : null;
            var subject = SubjectComboBox.SelectedItem != null ? subjectComboBoxContent[SubjectComboBox.SelectedIndex][0] : null;

            try
            {
                // проверка на пустые значения
                if (string.IsNullOrEmpty(teacher) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(letter) || string.IsNullOrEmpty(number))
                    throw new Exception("Поля Класса, Учителя и Предмета должны быть заполнены");

                // запрос на добавление с получением необходимых id на основе введенных данных
                var request = $"insert into План values " +
                    $"((select id from Классы where Буква = '{letter}' and Класс = {number}), " +
                    $"(select id from Предметы where Предмет = '{subject}'), " +
                    $"(select id from Пользователи where ФИО = '{teacher}'))";

                DataFill.ApplyRequest(request);

                MessageBox.Show("План успешно добавлен", "Уведомление");

                ShowData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        #endregion

        #region Events

        private void PreviousTableButton_Click(object sender, EventArgs e)
        {
            tableId--;
            ShowData();
        }

        private void NextTableButton_Click(object sender, EventArgs e)
        {
            tableId++;
            ShowData();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            var form = new Director();
            form.Show();
            Hide();
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var id = DeleteIdTextBox.Text;

            var deleteRequest = "";

            if (tableId == 0)
                deleteRequest = $"delete from Пользователи where id = {id} and ФИО != '{Person.fio}'";
            else if (tableId == 1)
                deleteRequest = $"delete from Ученики where id = {id}";
            else if (tableId == 2)
                deleteRequest = $"delete from Предметы where id = {id}";
            else if (tableId == 3)
                deleteRequest = $"delete from План where id = {id}";

            try
            {
                DataFill.ApplyRequest(deleteRequest);

                MessageBox.Show("Запись удалена", "Уведомление");

                ShowData();
            }
            catch (Exception)
            {
                MessageBox.Show("Эта запись не может быть удалена, так как на нее ссылаются другие", "Ошибка");
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (tableId == 0 || tableId == 1)
                AddUser();
            else if (tableId == 2)
                AddSubject();
            else if (tableId == 3)
                AddPlan();
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // установление значения для флага isStudent на основе выбранной роли
            isStudent = RoleComboBox.SelectedItem.ToString() == "Ученик";

            // установление статуса отображения GroupBox с выбором класса на основе значения флага isStudent
            ClassGroupBox.Enabled = isStudent;
        }

        // вызов метода проверки введенного символа 
        private void HoursTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private void DeleteIdTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private static void CheckDigits(KeyPressEventArgs e)
        {
            var number = e.KeyChar;

            // Проверяем, является ли клавиша Backspace или цифрой
            if (number == (char)Keys.Back || char.IsDigit(number))
            {
                // Разрешаем ввод символа
                return;
            }

            e.Handled = true;
        }

        #endregion
    }
}
