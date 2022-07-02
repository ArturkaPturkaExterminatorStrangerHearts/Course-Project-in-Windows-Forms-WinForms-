using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MaterialSkin.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Staff_Change : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        private const string CON_SQL = "server=localhost;user id=root;database=smartphone_store;characterset=utf8";
        private MySqlConnection con = new MySqlConnection(CON_SQL);
        MySqlCommand myCommand = new MySqlCommand();

        public Staff_Change()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue700, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
            myCommand.Connection = con;
            con.Open();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка",
                                 MessageBoxButtons.OK);
                return;
            }

            myCommand.CommandText = $"UPDATE staff SET fullname= '{textBox1.Text}', job= '{textBox3.Text}', city= '{textBox4.Text}', salary= {textBox5.Text}, phone= {textBox6.Text}, datebirth= '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}' WHERE id=" + transfer.id;

            myCommand.ExecuteNonQuery();
            Close();
        }

        private void Staff_Change_Load(object sender, EventArgs e)
        {
            textBox1.Text = transfer.par1;
            textBox3.Text = transfer.par2;
            textBox4.Text = transfer.par3;
            textBox5.Text = transfer.par4;
            textBox6.Text = transfer.par5;
            dateTimePicker1.Value = transfer.par12.Date;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }
    }
}