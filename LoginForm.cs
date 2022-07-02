using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public LoginForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue700, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 48);
            passField.UseSystemPasswordChar = true;
        }

        bool changed = false;
        Image buttImage;

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (loginField.Text == "" && passField.Text == "")
            {
                label1.Text = "Заполните поле логина и пароля!";
                label1.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            if (loginField.Text == "")
            {
                label1.Text = "Заполните поле логина!";
                label1.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            if (passField.Text == "")
            {
                label1.Text = "Заполните поле пароля!";
                label1.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            String login = loginField.Text;
            String password = passField.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @L AND `password` = @P", db.getConnection());
            command.Parameters.Add("@L", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@P", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                label1.Text = "";
                Hide();
                Form2 glavnaya = new Form2();
                glavnaya.ShowDialog();
            }

            else
            {
                label1.Text = "Указаны неверные данные.";
                label1.ForeColor = Color.FromArgb(244, 67, 54);
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(91, 169, 240);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(2, 136, 209);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegistrationForm RegistrationForm = new RegistrationForm();
            RegistrationForm.ShowDialog();
        }

        private void loginField_KeyUp(object sender, KeyEventArgs e)
        {
            label2.Visible = false;

            if (loginField.Text != "")
                loginField.HelperText = "";
            else
                loginField.HelperText = "Введите ваше имя";

            String login = loginField.Text;
            String password = passField.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE 'Admin' = @L AND 'root123' = @P", db.getConnection());
            command.Parameters.Add("@L", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@P", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                label2.Visible = true;
                label1.Text = "";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void passField_KeyUp(object sender, KeyEventArgs e)
        {
            label2.Visible = false;

            if (passField.Text != "")
                passField.HelperText = "";
            else
                passField.HelperText = "Введите ваш пароль";

            if (loginField.Text != "")
                loginField.HelperText = "";
            else
                loginField.HelperText = "Введите ваше имя";

            String login = loginField.Text;
            String password = passField.Text;

            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE 'Admin' = @L AND 'root123' = @P", db.getConnection());
            command.Parameters.Add("@L", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@P", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                label2.Visible = true;
                label1.Text = "";
            }
            else
            {
                label1.Text = "";
            }
        }

        private void passField_TrailingIconClick(object sender, EventArgs e)
        {
            if (changed)
            {
                passField.TrailingIcon = buttImage;
                passField.UseSystemPasswordChar = true;
            }
            else
            {
                passField.TrailingIcon = Properties.Resources.visible;
                passField.UseSystemPasswordChar = false;
            }
            changed = !changed;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            buttImage = this.passField.TrailingIcon;
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text != "")
                loginField.HelperText = "";
            else
                loginField.HelperText = "Введите ваше имя";
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text != "")
                passField.HelperText = "";
            else
                passField.HelperText = "Введите ваш пароль";
        }
    }
}