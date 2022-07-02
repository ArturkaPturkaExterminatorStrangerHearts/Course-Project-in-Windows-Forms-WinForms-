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
    public partial class Smartphones_Xiaomi_Add : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        private const string CON_SQL = "server=localhost;user id=root;database=smartphone_store;characterset=utf8";
        private MySqlConnection con = new MySqlConnection(CON_SQL);
        MySqlCommand myCommand = new MySqlCommand();

        public Smartphones_Xiaomi_Add()
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
            if (textBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || textBox8.Text.Length == 0 || textBox9.Text.Length == 0 || textBox10.Text.Length == 0 || textBox11.Text.Length == 0 || textBox12.Text.Length == 0)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка",
                                 MessageBoxButtons.OK);
                return;
            }

            string model, class1, cpu, display, color;
            int price, dram, memory, battery, quantity;
            model = textBox1.Text;
            class1 = textBox3.Text;
            cpu = textBox5.Text;
            display = textBox6.Text;
            color = textBox10.Text;
            price = Convert.ToInt32(textBox4.Text);
            dram = Convert.ToInt32(textBox7.Text);
            memory = Convert.ToInt32(textBox8.Text);
            battery = Convert.ToInt32(textBox9.Text);
            quantity = Convert.ToInt32(textBox11.Text);

            myCommand.CommandText = $"insert into smartphones_xiaomi(model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date) values('{textBox1.Text}','{textBox3.Text}',{textBox4.Text},'{textBox5.Text}','{textBox6.Text}',{textBox7.Text},{textBox8.Text},{textBox9.Text},'{textBox10.Text}',{textBox11.Text},'{textBox12.Text}','{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}')";

            myCommand.ExecuteNonQuery();

            myCommand.CommandText = $"select count(*) from smartphones_xiaomi_warehouse where model = '{model}' and class = '{class1}' and price = {price} and cpu = '{cpu}' and display = '{display}' and dram = {dram} and memory = {memory} and battery = {battery} and color = '{color}' and quantity = {quantity}";

            int cnt = Convert.ToInt32(myCommand.ExecuteScalar());

            if (cnt != 0)
                myCommand.CommandText = $"update smartphones_xiaomi_warehouse set quantity = quantity + {quantity} where model = '{model}' and class = '{class1}' and price = {price} and cpu = '{cpu}' and display = '{display}' and dram = {dram} and memory = {memory} and battery = {battery} and color = '{color}'";
            else
                myCommand.CommandText = $"insert into smartphones_xiaomi_warehouse(model,class,price,cpu,display,dram,memory,battery,color,quantity) values('{textBox1.Text}','{textBox3.Text}',{textBox4.Text},'{textBox5.Text}','{textBox6.Text}',{textBox7.Text},{textBox8.Text},{textBox9.Text},'{textBox10.Text}',{textBox11.Text})";

            myCommand.ExecuteNonQuery();

            Close();
        }

        private void Smartphones_Xiaomi_Add_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }
    }
}