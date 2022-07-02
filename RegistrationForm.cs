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
    public partial class RegistrationForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public RegistrationForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue700, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
            passFieldReg.UseSystemPasswordChar = true;
            repeatPassword.UseSystemPasswordChar = true;
        }

        bool changed = false;
        Image buttImage;

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (loginFieldReg.Text == "" && passFieldReg.Text == "")
            {
                label2.Text = "Заполните поле логина и пароля!";
                label2.ForeColor = Color.FromArgb(102, 187, 106);
                return;
            }

            if (loginFieldReg.Text == "")
            {
                label2.Text = "Заполните поле логина!";
                label2.ForeColor = Color.FromArgb(102, 187, 106);
                return;
            }

            if (passFieldReg.Text == "")
            {
                label2.Text = "Заполните поле пароля!";
                label2.ForeColor = Color.FromArgb(102, 187, 106);
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`) VALUES (@rL, @rP)", db.getConnection());

            command.Parameters.Add("@rL", MySqlDbType.VarChar).Value = loginFieldReg.Text.Trim();
            command.Parameters.Add("@rP", MySqlDbType.VarChar).Value = passFieldReg.Text.Trim();

            db.openConnection();

            if (passFieldReg.Text.Trim() == repeatPassword.Text.Trim())
            {

                if (passFieldReg.TextLength >= 6 && repeatPassword.TextLength >= 6)
                {

                        if (loginFieldReg.TextLength >= 3)
                        {

                                if (command.ExecuteNonQuery() == 1)
                                {
                                    label2.Text = "Пользователь был зарегистрирован.";
                                    label2.ForeColor = Color.FromArgb(102, 187, 106);
                                    loginFieldReg.Text = "";
                                    passFieldReg.Text = "";
                                    repeatPassword.Text = "";
                                }

                                else
                                {
                                    label2.Text = "Произошла ошибка регистрации.";
                                    label2.ForeColor = Color.FromArgb(244, 67, 54);
                                }

                        db.closeConnection();
                        }

                        else
                        {
                            label2.Text = "Логин должен содержать не менее 3 символов.";
                            label2.ForeColor = Color.FromArgb(244, 67, 54);
                        }
                }

                else
                {
                    label2.Text = "Пароль должен содержать не менее 6 символов.";
                    label2.ForeColor = Color.FromArgb(244, 67, 54);
                }
            }

            else
            {
                label2.Text = "Пароли не совпадают.";
                label2.ForeColor = Color.FromArgb(244, 67, 54);
            }
        }

        public Boolean isUserExists()
        {
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @L", db.getConnection());
            command.Parameters.Add("@L", MySqlDbType.VarChar).Value = loginFieldReg.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                label2.Text = "Такой логин уже существует.";
                label2.ForeColor = Color.FromArgb(244, 67, 54);
                return true;
            }

            else
                return false;
        }

        private void repeatPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (loginFieldReg.Text == "" && passFieldReg.Text == "")
                {
                    label2.Text = "Заполните поле логина и пароля!";
                    label2.ForeColor = Color.FromArgb(244, 67, 54);
                    return;
                }

                if (loginFieldReg.Text == "")
                {
                    label2.Text = "Заполните поле логина!";
                    label2.ForeColor = Color.FromArgb(102, 187, 106);
                    return;
                }

                if (passFieldReg.Text == "")
                {
                    label2.Text = "Заполните поле пароля!";
                    label2.ForeColor = Color.FromArgb(102, 187, 106);
                    return;
                }

                if (isUserExists())
                    return;

                DB db = new DB();
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `password`) VALUES (@rL, @rP)", db.getConnection());

                command.Parameters.Add("@rL", MySqlDbType.VarChar).Value = loginFieldReg.Text.Trim();
                command.Parameters.Add("@rP", MySqlDbType.VarChar).Value = passFieldReg.Text.Trim();

                db.openConnection();

                if (passFieldReg.Text.Trim() == repeatPassword.Text.Trim())
                {
                    if (passFieldReg.TextLength >= 6 && repeatPassword.TextLength >= 6)
                    {

                        if (loginFieldReg.TextLength >= 3)
                        {

                            if (command.ExecuteNonQuery() == 1)
                            {
                                label2.Text = "Пользователь был зарегистрирован.";
                                label2.ForeColor = Color.FromArgb(102, 187, 106);
                                loginFieldReg.Text = "";
                                passFieldReg.Text = "";
                                repeatPassword.Text = "";
                            }

                            else
                            {
                                label2.Text = "Произошла ошибка регистрации.";
                                label2.ForeColor = Color.FromArgb(244, 67, 54);
                            }

                            db.closeConnection();
                        }

                        else
                        {
                            label2.Text = "Логин должен содержать не менее 3 символов.";
                            label2.ForeColor = Color.FromArgb(244, 67, 54);
                        }
                    }

                    else
                    {
                        label2.Text = "Пароль должен содержать не менее 6 символов.";
                        label2.ForeColor = Color.FromArgb(244, 67, 54);
                    }
                }

                else
                {
                    label2.Text = "Пароли не совпадают.";
                    label2.ForeColor = Color.FromArgb(244, 67, 54);
                }
            }
        }

        private void loginFieldReg_KeyUp(object sender, KeyEventArgs e)
        {
            label2.Text = "";
            if (loginFieldReg.Text != "")
                loginFieldReg.HelperText = "";
            else
                loginFieldReg.HelperText = "Придумайте логин";
        }

        private void passFieldReg_KeyUp(object sender, KeyEventArgs e)
        {
            label2.Text = "";
            if (passFieldReg.Text != "")
                passFieldReg.HelperText = "";
            else
                passFieldReg.HelperText = "Придумайте пароль";
        }

        private void repeatPassword_KeyUp(object sender, KeyEventArgs e)
        {
            label2.Text = "";
            if (repeatPassword.Text != "")
                repeatPassword.HelperText = "";
            else
                repeatPassword.HelperText = "Повторите пароль";
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            buttImage = this.passFieldReg.TrailingIcon;
        }

        private void passFieldReg_TrailingIconClick(object sender, EventArgs e)
        {
            if (changed)
            {
                passFieldReg.TrailingIcon = buttImage;
                passFieldReg.UseSystemPasswordChar = true;
                repeatPassword.UseSystemPasswordChar = true;
            }
            else
            {
                passFieldReg.TrailingIcon = Properties.Resources.visible;
                passFieldReg.UseSystemPasswordChar = false;
                repeatPassword.UseSystemPasswordChar = false;
            }
            changed = !changed;
        }

        private void loginFieldReg_Enter(object sender, EventArgs e)
        {
            if (loginFieldReg.Text != "")
                loginFieldReg.HelperText = "";
            else
                loginFieldReg.HelperText = "Придумайте логин";
        }

        private void passFieldReg_Enter(object sender, EventArgs e)
        {
            if (passFieldReg.Text != "")
                passFieldReg.HelperText = "";
            else
                passFieldReg.HelperText = "Придумайте пароль";
        }

        private void repeatPassword_Enter(object sender, EventArgs e)
        {
            if (repeatPassword.Text != "")
                repeatPassword.HelperText = "";
            else
                repeatPassword.HelperText = "Повторите пароль";
        }

        private void loginFieldReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void passFieldReg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void repeatPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == '-' || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
            {

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}