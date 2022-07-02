using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using MaterialSkin.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Smartphones_Samsung_Availability : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        private const string CON_SQL = "server=localhost;user id=root;database=smartphone_store;characterset=utf8";
        private MySqlConnection con = new MySqlConnection(CON_SQL);
        MySqlCommand myCommand = new MySqlCommand();

        public Smartphones_Samsung_Availability()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue700, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
            myCommand.Connection = con;
            con.Open();
        }

        private void Smartphones_Samsung_Availability_Load(object sender, EventArgs e)
        {
            int i, n;
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM smartphones_samsung_warehouse order by model,price";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 10; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }

            reader.Close();

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
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox3.Text.Length == 0 || textBox4.Text.Length == 0 || textBox5.Text.Length == 0 || textBox6.Text.Length == 0 || textBox7.Text.Length == 0 || textBox8.Text.Length == 0 || textBox9.Text.Length == 0 || textBox10.Text.Length == 0 || textBox11.Text.Length == 0)
            {
                MessageBox.Show("Заполните все поля.", "Ошибка", MessageBoxButtons.OK);
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

            myCommand.CommandText = $"select count(*) from smartphones_samsung_warehouse where model = '{model}' and class = '{class1}' and price = {price} and cpu = '{cpu}' and display = '{display}' and dram = {dram} and memory = {memory} and battery = {battery} and color = '{color}'";

            int cnt = Convert.ToInt32(myCommand.ExecuteScalar());

            // Проверяем имеется ли такой товар на складе
            if (cnt != 0)
            {
                // Такой товар на складе есть
                // Определяем количество такого товара
                myCommand.CommandText = $"select quantity from smartphones_samsung_warehouse where model = '{model}' and class = '{class1}' and price = {price} and cpu = '{cpu}' and display = '{display}' and dram = {dram} and memory = {memory} and battery = {battery} and color = '{color}'";

                int quantity1 = Convert.ToInt32(myCommand.ExecuteScalar());

                // Проверяем достаточно ли такого товара на складе
                if (quantity1 >= quantity)
                {
                    // Товара на складе достаточно 
                    myCommand.CommandText = $"update smartphones_samsung_warehouse set quantity = quantity - {quantity} where model = '{model}' and class = '{class1}' and price = {price} and cpu = '{cpu}' and display = '{display}' and dram = {dram} and memory = {memory} and battery = {battery} and color = '{color}'";
                    myCommand.ExecuteNonQuery();

                    int i, n;
                    dataGridView1.Rows.Clear();
                    string sql = "SELECT * FROM smartphones_samsung_warehouse order by model,price";
                    myCommand.CommandText = sql;
                    MySqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        n = dataGridView1.NewRowIndex;
                        dataGridView1.Rows.Add();
                        for (i = 0; i < 10; i++)
                            dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    }

                    reader.Close();
                }

                else
                {
                    // Товара на складе не достаточно  
                    MessageBox.Show("Такого количества товара на складе нет.", "Информация", MessageBoxButtons.OK);
                    return;
                }
            }

            else
            {
                // Товара на складе нет 
                MessageBox.Show("Такого товара на складе нет.", "Информация", MessageBoxButtons.OK);
                return;
            }
        }

        private void materialToolStripMenuItem39_Click(object sender, EventArgs e)
        {
            var oMissing = System.Reflection.Missing.Value;
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook WorkBook = ExcelApp.Workbooks.Add(oMissing);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Модель смартфона";
            WorkSheet.Cells[1, 2] = "Класс";
            WorkSheet.Cells[1, 3] = "Цена (в тенге)";
            WorkSheet.Cells[1, 4] = "Процессор";
            WorkSheet.Cells[1, 5] = "Дисплей";
            WorkSheet.Cells[1, 6] = "Объем оперативной памяти (в Гб)";
            WorkSheet.Cells[1, 7] = "Объем встроенной памяти (в Гб)";
            WorkSheet.Cells[1, 8] = "Ёмкость аккумулятора (в мАч)";
            WorkSheet.Cells[1, 9] = "Цвет";
            WorkSheet.Cells[1, 10] = "Количество (в штуках)";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    WorkSheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();

            Excel.Range cells = WorkSheet.Range[WorkSheet.Cells[1, 1], WorkSheet.Cells[dataGridView1.RowCount, dataGridView1.ColumnCount]];
            cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            cells.EntireColumn.AutoFit();
            cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Visible = true;
        }

        private void materialToolStripMenuItem40_Click(object sender, EventArgs e)
        {
            int i, j;
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = true;
            Word.Document wordDoc;
            Word.Paragraph wordParag;
            Word.Table wordTable;

            wordDoc = wordApp.Documents.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            wordParag = wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 14;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Смартфоны Samsung";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Наличие товара в магазине";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 9;
            wordParag.Range.Font.Italic = 1;

            // Параметр, указывающий показывать ли границы ячеек
            var t1 = Word.WdDefaultTableBehavior.wdWord9TableBehavior;

            // Параметр, указывающий ,будут ли автоматически изменяться размеры ячеек
            // для подгонки содержимого
            var t2 = Word.WdAutoFitBehavior.wdAutoFitWindow;

            wordParag.Range.Tables.Add(wordParag.Range, dataGridView1.RowCount, dataGridView1.ColumnCount, t1, t2);
            wordTable = wordDoc.Tables[1];
            wordTable.Range.Font.Size = 9;
            wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
            wordTable.Columns.SetWidth(50, Word.WdRulerStyle.wdAdjustFirstColumn);

            // Вывод заголовка
            for (i = 0; i < dataGridView1.ColumnCount; i++)
                wordTable.Cell(1, i + 1).Range.Text = dataGridView1.Columns[i].HeaderText;

            // Вывод таблицы
            for (i = 1; i < dataGridView1.RowCount; i++)
                for (j = 0; j < dataGridView1.ColumnCount; j++)
                    wordTable.Cell(i + 1, j + 1).Range.Text = dataGridView1.Rows[i - 1].Cells[j].Value.ToString();
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
    }
}