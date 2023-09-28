using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SchoolKursach.Scripts;

namespace SchoolKursach.Forms
{
    public partial class Auth : Form
    {
        private SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter();

        public Auth()
        {
            InitializeComponent();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            PassTextBox.UseSystemPasswordChar = true;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            var login = LoginTextBox.Text;
            var pass = PassTextBox.Text;
            
            var roleId = GetRoleID(login, pass);

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
                
                var request = $"select id, [ID Должности], фио from Пользователи where Логин = '{login}' and Пароль = HASHBYTES('SHA2_256', '{pass}')";

                var command = new SqlCommand(request, Connection.GetSqlConnection());

                _sqlDataAdapter.SelectCommand = command;
                _sqlDataAdapter.Fill(dataTable);

                Connection.OpenConnection();

                var reader = command.ExecuteReader();

                var roleId = -1;
                
                while (reader.Read())
                {
                    Person.RoleId = reader.GetValue(1).ToString();
                    Person.Fio = (string)reader.GetValue(2);

                    roleId = Convert.ToInt32(Person.RoleId);
                }

                Connection.CloseConnection();

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
