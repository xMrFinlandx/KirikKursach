using SchoolKursach.Scripts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SchoolKursach.Forms
{
    public partial class AddChanges : Form
    {
        private List<string[]> _subjectComboBoxContent = new List<string[]>();
        private List<string[]> _teacherComboBoxContent = new List<string[]>();

        private List<string[]> _roleComboBoxContent = new List<string[]>();

        private List<string[]> _letterComboBoxContent = new List<string[]>();
        private List<string[]> _numberComboBoxContent = new List<string[]>();

        private int _tableId = 0;

        private bool _isStudent = false;

        public AddChanges()
        {
            InitializeComponent();
        }

        private void AddChanges_Load(object sender, EventArgs e)
        {
            AddPlanGroupBox.Visible = false;
            AddSubjectGroupBox.Visible = false;
            AddUserGroupBox.Visible = true;

            ShowData();
        }

        private void ShowData()
        {
            var tableRequest = "";

            if (_tableId < 0)
                _tableId = 3;

            if (_tableId > 3)
                _tableId = 0;

            switch (_tableId)
            {
                case 0:
                    tableRequest = ShowUsers();
                    break;
                case 1:
                    tableRequest = ShowStudents();
                    break;
                case 2:
                    tableRequest = ShowSubjects();
                    break;
                case 3:
                    tableRequest = ShowPlan();
                    break;
            }

            DataFill.UpdateDataGrid(DataTableView, tableRequest);
        }

        #region Show Data Requests

        private string ShowUsers()
        {
            TableNameLabel.Text = "Пользователи";
            
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
            TableNameLabel.Text = "Ученики";
            
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
            TableNameLabel.Text = "Предметы";
            
            AddPlanGroupBox.Visible = false;
            AddSubjectGroupBox.Visible = true;
            AddUserGroupBox.Visible = false;

            var request = "select * from Предметы";

            return request;
        }

        private string ShowPlan()
        {
            TableNameLabel.Text = "План";
            
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
            var teacherComboBoxRequest = "select ФИО from пользователи where [Id должности] = 2";
            var subjectComboBoxRequest = "select Предмет from предметы";
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";
            
            _teacherComboBoxContent = DataFill.RequestToList(teacherComboBoxRequest);
            _subjectComboBoxContent = DataFill.RequestToList(subjectComboBoxRequest);
            _letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            _numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(TeacherComboBox, _teacherComboBoxContent, 0);
            DataFill.UpdateComboBox(SubjectComboBox, _subjectComboBoxContent, 0);
            DataFill.UpdateComboBox(PlanLetterComboBox, _letterComboBoxContent, 0);
            DataFill.UpdateComboBox(PlanNumberComboBox, _numberComboBoxContent, 0);
        }

        private void FillUsersComboBox()
        {
            var roleComboBoxRequest = "select Должность from Должности";
            var letterComboBoxRequest = "Select distinct Буква from Классы";
            var numberComboBoxRequest = "Select distinct Класс from Классы";

            _roleComboBoxContent = DataFill.RequestToList(roleComboBoxRequest);
            _letterComboBoxContent = DataFill.RequestToList(letterComboBoxRequest);
            _numberComboBoxContent = DataFill.RequestToList(numberComboBoxRequest);

            DataFill.UpdateComboBox(RoleComboBox, _roleComboBoxContent, 0);
            DataFill.UpdateComboBox(LetterComboBox, _letterComboBoxContent, 0);
            DataFill.UpdateComboBox(NumberComboBox, _numberComboBoxContent, 0);
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
            var letter = DataFill.GetComboBoxValue(LetterComboBox, _letterComboBoxContent, 0);
            var number = DataFill.GetComboBoxValue(NumberComboBox, _numberComboBoxContent, 0);

            var role = DataFill.GetComboBoxValue(RoleComboBox, _roleComboBoxContent, 0); 
            var fio = FIOTextBox.Text;
            var login = LoginTextBox.Text;
            var pass = PassTextBox.Text;

            try
            {
                if (string.IsNullOrEmpty(role) || string.IsNullOrEmpty(fio) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
                    throw new Exception("Поля Роль, Фамилия, Логин и Пароль должны быть заполнены");
                
                if (_isStudent)
                {
                    if (string.IsNullOrEmpty(letter) || string.IsNullOrEmpty(number))
                        throw new Exception("Для роли Ученик, поля Буква и Класс должны быть заполнены");
                }
                
                var request = $"insert into Пользователи output inserted.ID " +
                    $"values ((select id from Должности where Должность = '{role}') , '{fio}', '{login}',  HASHBYTES('SHA2_256', '{pass}'))";
                
                var id = DataFill.ApplyRequestAndGetID(request);
                
                if (_isStudent)
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
            var letter = DataFill.GetComboBoxValue(PlanLetterComboBox, _letterComboBoxContent, 0);
            var number = DataFill.GetComboBoxValue(PlanNumberComboBox, _numberComboBoxContent, 0);
            var teacher = DataFill.GetComboBoxValue(TeacherComboBox, _teacherComboBoxContent, 0); 
            var subject = DataFill.GetComboBoxValue(SubjectComboBox, _subjectComboBoxContent, 0);

            try
            {
                if (string.IsNullOrEmpty(teacher) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(letter) || string.IsNullOrEmpty(number))
                    throw new Exception("Поля Класса, Учителя и Предмета должны быть заполнены");
                
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
            _tableId--;
            ShowData();
        }

        private void NextTableButton_Click(object sender, EventArgs e)
        {
            _tableId++;
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

            if (_tableId == 0)
                deleteRequest = $"delete from Пользователи where id = {id} and ФИО != '{Person.Fio}'";
            else if (_tableId == 1)
                deleteRequest = $"delete from Ученики where id = {id}";
            else if (_tableId == 2)
                deleteRequest = $"delete from Предметы where id = {id}";
            else if (_tableId == 3)
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
            if (_tableId == 0 || _tableId == 1)
                AddUser();
            else if (_tableId == 2)
                AddSubject();
            else if (_tableId == 3)
                AddPlan();
        }

        private void RoleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isStudent = RoleComboBox.SelectedItem.ToString() == "Ученик";
            
            ClassGroupBox.Enabled = _isStudent;
        }
        
        private void HoursTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private void DeleteIdTextBox_KeyPress(object sender, KeyPressEventArgs e) => CheckDigits(e);

        private static void CheckDigits(KeyPressEventArgs e)
        {
            var number = e.KeyChar;

            if (number == (char)Keys.Back || char.IsDigit(number))
                return;

            e.Handled = true;
        }

        #endregion
    }
}
