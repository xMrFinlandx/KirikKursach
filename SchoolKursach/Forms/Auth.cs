using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SchoolKursach.Scripts;

namespace SchoolKursach.Forms
{
    public partial class Auth : Form
    {
        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            // скрывает пароль
            PassTextBox.UseSystemPasswordChar = true;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            // получение логина и пароля из текстбоксов
            var login = LoginTextBox.Text;
            var pass = PassTextBox.Text;

            // передача логина и пароля в метод, который вернет ID должности 
            var roleId = GetRoleID(login, pass);

            if (roleId == -1)
                return;

            // Открытие формы на основе Id работника и закрытие текущей
            if (roleId == 1)
            {
                var form = new Director();
                form.Show();
                Hide();
            }
            else if (roleId == 2)
            {
                var form = new Teacher();
                form.Show();
                Hide();
            }
            else if (roleId == 3)
            {
                var form = new Student();
                form.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно", "Ошибка");
            }
        }

        private int GetRoleID(string login, string pass)
        {
            try
            {
                if (string.IsNullOrEmpty(login))
                    throw new Exception("Поле Логин должно быть заполнено");

                if (string.IsNullOrEmpty(pass))
                    throw new Exception("Поле Пароль должно быть заполнено");

                var dataTable = new DataTable();

                // запрос, который получит айди, должность, фио на основе введенных логина и пароля
                var request = $"select id, [ID Должности], фио from Пользователи where Логин = '{login}' and Пароль = HASHBYTES('SHA2_256', '{pass}')";

                var command = new SqlCommand(request, Connection.GetSqlConnection());

                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(dataTable);

                Connection.OpenConnection();

                var reader = command.ExecuteReader();

                // запись полученных данных в статический класс
                while (reader.Read())
                {
                    Person.id = reader.GetValue(0).ToString();
                    Person.roleId = reader.GetValue(1).ToString();
                    Person.fio = (string)reader.GetValue(2);
                }

                Connection.CloseConnection();

                var roleId = Convert.ToInt32(Person.roleId);

                return roleId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
                return -1;
            }
        }
    }
}
