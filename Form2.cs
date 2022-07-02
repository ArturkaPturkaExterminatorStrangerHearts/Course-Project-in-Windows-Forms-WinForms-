using MaterialSkin.Controls;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using LiveCharts;
using LiveCharts.Wpf;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form2 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        private bool asd = false;
        private const string CON_SQL = "server=localhost;user id=root;database=smartphone_store;characterset=utf8;Convert Zero Datetime=True;";
        private MySqlConnection con = new MySqlConnection(CON_SQL);
        private static readonly Regex hostReg = new Regex(@"(\w+)\.(\w+)");
        MySqlCommand myCommand = new MySqlCommand();
        Smartphones_Add smartphones_add = new Smartphones_Add();
        Smartphones_Apple_Add smartphones_apple_add = new Smartphones_Apple_Add();
        Smartphones_Samsung_Add smartphones_samsung_add = new Smartphones_Samsung_Add();
        Smartphones_Xiaomi_Add smartphones_xiaomi_add = new Smartphones_Xiaomi_Add();
        Smartphones_Availability smartphones_availability = new Smartphones_Availability();
        Smartphones_Apple_Availability smartphones_apple_availability = new Smartphones_Apple_Availability();
        Smartphones_Samsung_Availability smartphones_samsung_availability = new Smartphones_Samsung_Availability();
        Smartphones_Xiaomi_Availability smartphones_xiaomi_availability = new Smartphones_Xiaomi_Availability();
        Staff_Add staff_add = new Staff_Add();
        Staff_Change staff_change = new Staff_Change();
        Smartphones_Archive smartphones_archive = new Smartphones_Archive();
        Smartphones_Apple_Archive smartphones_apple_archive = new Smartphones_Apple_Archive();
        Smartphones_Samsung_Archive smartphones_samsung_archive = new Smartphones_Samsung_Archive();
        Smartphones_Xiaomi_Archive smartphones_xiaomi_archive = new Smartphones_Xiaomi_Archive();

        public Form2()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue700, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
            myCommand.Connection = con;

            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2021",
                    Values = new ChartValues<double> { 33.6, 27.2, 21.5, 18.4 }
                }
            };

            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "2022",
                Values = new ChartValues<double> { 36.8, 29.9, 23.4, 20.1 }
            });

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Города",
                Labels = new[] { "Алматы", "Нур-Султан", "Шымкент", "Актобе" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Проданные смартфоны",
                LabelFormatter = value => value.ToString("N")
            });

            cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "2021",
                    Values = new ChartValues<double> { 7.9, 8.8, 8.1, 8.3, 8.6, 9.3, 9.5, 9.0, 8.4, 8.1, 7.6, 8.0 }
                },
                new LineSeries
                {
                    Title = "2022",
                    Values = new ChartValues<double> { 8.5, 8.5, 8.8, 9.2, 9.7, 10.0, 10.7, 9.5, 9.1, 8.7, 8.1, 8.8 },
                    PointGeometry = null
                },

            };

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Месяц",
                Labels = new[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" }
            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Проданные смартфоны",
                LabelFormatter = value => value.ToString("N")
            });

            cartesianChart2.LegendLocation = LegendLocation.None;
        }

        bool changed = false;
        Image buttImage;
        Image buttImage3;
        Image buttImage4;
        Image buttImage5;
        Image buttImage6;

        private void Form2_Load(object sender, EventArgs e)
        {
            buttImage = this.materialToolStripMenuItem49.Image;
            buttImage3 = this.materialToolStripMenuItem29.Image;
            buttImage4 = this.materialToolStripMenuItem21.Image;
            buttImage5 = this.materialToolStripMenuItem13.Image;
            buttImage6 = this.materialToolStripMenuItem2.Image;
            materialTextBox222.Text = "";
            materialTextBox223.Text = "";
            materialMultiLineTextBox21.Text = "";
            int i, n;
            try
            {
                con.Open();

                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                dataGridView6.Rows.Clear();

                string sql = "SELECT * FROM smartphones";
                myCommand.CommandText = sql;
                MySqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    n = dataGridView1.NewRowIndex;
                    dataGridView1.Rows.Add();
                    for (i = 0; i < 13; i++)
                        dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                        dataGridView1.Rows[n].Cells[13].Value = (DateTime)reader[13];
                }
                reader.Close();

                string sql_apple = "SELECT * FROM smartphones_apple";
                myCommand.CommandText = sql_apple;
                MySqlDataReader readera = myCommand.ExecuteReader();

                while (readera.Read())
                {
                    n = dataGridView2.NewRowIndex;
                    dataGridView2.Rows.Add();
                    for (i = 0; i < 12; i++)
                        dataGridView2.Rows[n].Cells[i].Value = readera[i].ToString();
                        dataGridView2.Rows[n].Cells[12].Value = (DateTime)readera[12];
                }
                readera.Close();

                string sql_samsung = "SELECT * FROM smartphones_samsung";
                myCommand.CommandText = sql_samsung;
                MySqlDataReader readers = myCommand.ExecuteReader();

                while (readers.Read())
                {
                    n = dataGridView3.NewRowIndex;
                    dataGridView3.Rows.Add();
                    for (i = 0; i < 12; i++)
                        dataGridView3.Rows[n].Cells[i].Value = readers[i].ToString();
                        dataGridView3.Rows[n].Cells[12].Value = (DateTime)readers[12];
                }
                readers.Close();

                string sql_xiaomi = "SELECT * FROM smartphones_xiaomi";
                myCommand.CommandText = sql_xiaomi;
                MySqlDataReader readerx = myCommand.ExecuteReader();

                while (readerx.Read())
                {
                    n = dataGridView4.NewRowIndex;
                    dataGridView4.Rows.Add();
                    for (i = 0; i < 12; i++)
                        dataGridView4.Rows[n].Cells[i].Value = readerx[i].ToString();
                        dataGridView4.Rows[n].Cells[12].Value = (DateTime)readerx[12];
                }
                readerx.Close();

                string sql_staff = "SELECT * FROM staff";
                myCommand.CommandText = sql_staff;
                MySqlDataReader readerst = myCommand.ExecuteReader();

                while (readerst.Read())
                {
                    n = dataGridView6.NewRowIndex;
                    dataGridView6.Rows.Add();
                    for (i = 0; i < 6; i++)
                        dataGridView6.Rows[n].Cells[i].Value = readerst[i].ToString();
                        dataGridView6.Rows[n].Cells[6].Value = (DateTime)readerst[6];
                }
                readerst.Close();
            }

            catch
            {
                MessageBox.Show(
                "Соединение с базой данных не установлено.",
                "Ошибка",
                MessageBoxButtons.OK);
                Environment.Exit(0);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            int i, n;
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM smartphones";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView1.Rows[n].Cells[13].Value = (DateTime)reader[13];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            var oMissing = System.Reflection.Missing.Value;
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook WorkBook = ExcelApp.Workbooks.Add(oMissing);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Код";
            WorkSheet.Cells[1, 2] = "Модель смартфона";
            WorkSheet.Cells[1, 3] = "Производитель";
            WorkSheet.Cells[1, 4] = "Класс";
            WorkSheet.Cells[1, 5] = "Цена (в тенге)";
            WorkSheet.Cells[1, 6] = "Процессор";
            WorkSheet.Cells[1, 7] = "Дисплей";
            WorkSheet.Cells[1, 8] = "Объем оперативной памяти (в Гб)";
            WorkSheet.Cells[1, 9] = "Объем встроенной памяти (в Гб)";
            WorkSheet.Cells[1, 10] = "Ёмкость аккумулятора (в мАч)";
            WorkSheet.Cells[1, 11] = "Цвет";
            WorkSheet.Cells[1, 12] = "Количество (в штуках)";
            WorkSheet.Cells[1, 13] = "Номер накладной";
            WorkSheet.Cells[1, 14] = "Дата поставки";

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    WorkSheet.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString();

            Excel.Range cells = WorkSheet.Range[WorkSheet.Cells[1, 1], WorkSheet.Cells[dataGridView1.RowCount, dataGridView1.ColumnCount]];
            cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            cells.EntireColumn.AutoFit();
            cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Visible = true;
        }

        private void materialToolStripMenuItem8_Click(object sender, EventArgs e)
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
            wordParag.Range.Text = $"Smartphone Store - Все смартфоны";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Информация о всех смартфонах";
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

        private void materialToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!asd)
            {
                this.Size = new System.Drawing.Size(1197, 1030);
                asd = !asd;
                CenterToScreen();
                tabPage1.AutoScroll = true;
                materialToolStripMenuItem2.Text = "Скрыть фильтры";
                if (changed)
                {
                    materialToolStripMenuItem2.Image = buttImage6;
                }
                else
                {
                    materialToolStripMenuItem2.Image = Properties.Resources.invisible;
                }
                label18.Visible = true;
                textBox1.Visible = true;
                button1.Visible = true;
                label19.Visible = true;
                radioButton6.Visible = true;
                radioButton7.Visible = true;
                radioButton8.Visible = true;
                label20.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                button2.Visible = true;
                materialCard6.Visible = true;
                materialCard7.Visible = true;
                materialCard8.Visible = true;
                materialCard9.Visible = true;
            }

            else
            {
                this.Size = new System.Drawing.Size(1197, 599);
                asd = !asd;
                CenterToScreen();
                tabPage1.AutoScroll = false;
                materialToolStripMenuItem2.Text = "Показать фильтры";
                if (changed)
                {
                    materialToolStripMenuItem2.Image = buttImage6;
                }
                else
                {
                    materialToolStripMenuItem2.Image = Properties.Resources.eye;
                }
                label18.Visible = false;
                textBox1.Visible = false;
                button1.Visible = false;
                label19.Visible = false;
                radioButton6.Visible = false;
                radioButton7.Visible = false;
                radioButton8.Visible = false;
                label20.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                radioButton5.Visible = false;
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                button2.Visible = false;
                materialCard6.Visible = false;
                materialCard7.Visible = false;
                materialCard8.Visible = false;
                materialCard9.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по модели смартфона!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from smartphones where model like '%{textBox1.Text}%'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where class = '{radioButton1.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where class = '{radioButton2.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where class = '{radioButton3.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where class = '{radioButton4.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where class = '{radioButton5.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where brand = '{radioButton6.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where brand = '{radioButton7.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where brand = '{radioButton8.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону цен!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where price >= {textBox2.Text} and price <= {textBox3.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where cpu like 'Apple%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where cpu like 'MediaTek Dimensity%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where cpu like 'Qualcomm%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where cpu like 'Samsung%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where cpu like 'Unisoc%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where cpu like 'MediaTek Helio%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where display = '{radioButton15.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where display = '{radioButton20.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where display = '{radioButton19.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where display = '{radioButton16.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where display = '{radioButton17.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where display = '{radioButton18.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where dram = 12";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton21_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where dram = 8";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton22_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where dram = 6";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where dram = 4";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton24_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where dram = 3";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton23_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where dram = 2";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton32_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where memory = 1000";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton27_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where memory = 512";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton28_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where memory = 256";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton31_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where memory = 128";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton30_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where memory = 64";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton29_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where memory = 32";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Length == 0 || textBox4.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону ёмкости аккумулятора!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where battery >= {textBox5.Text} and battery <= {textBox4.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton38_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where color = '{radioButton38.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton33_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where color = '{radioButton33.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton34_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where color = '{radioButton34.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton37_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where color = '{radioButton37.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void radioButton36_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones where color = '{radioButton36.Text}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox7.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону количества!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView1.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where quantity >= '{textBox7.Text}' and quantity <= '{textBox6.Text}'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (int i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void tabPage11_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
        }

        private void Update_Apple_Click(object sender, EventArgs e)
        {
            int i, n;
            dataGridView2.Rows.Clear();
            string sql = "SELECT * FROM smartphones_apple";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView2.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (materialTextBox27.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по модели смартфона!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from smartphones_apple where model like '%{materialTextBox27.Text}%'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton26_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where class = '{materialRadioButton26.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialToolStripMenuItem13_Click(object sender, EventArgs e)
        {
            if (!asd)
            {
                this.Size = new System.Drawing.Size(1197, 1030);
                asd = !asd;
                CenterToScreen();
                tabPage3.AutoScroll = true;
                materialToolStripMenuItem13.Text = "Скрыть фильтры";
                if (changed)
                {
                    materialToolStripMenuItem13.Image = buttImage5;
                }
                else
                {
                    materialToolStripMenuItem13.Image = Properties.Resources.invisible;
                }
                label53.Visible = true;
                materialTextBox27.Visible = true;
                button8.Visible = true;
                materialCard27.Visible = true;
                label44.Visible = true;
                materialRadioButton26.Visible = true;
                materialRadioButton25.Visible = true;
                materialCard18.Visible = true;
                label46.Visible = true;
                label47.Visible = true;
                label48.Visible = true;
                materialTextBox23.Visible = true;
                materialTextBox24.Visible = true;
                button6.Visible = true;
                materialCard19.Visible = true;
            }

            else
            {
                this.Size = new System.Drawing.Size(1197, 599);
                asd = !asd;
                CenterToScreen();
                tabPage3.AutoScroll = false;
                materialToolStripMenuItem13.Text = "Показать фильтры";
                if (changed)
                {
                    materialToolStripMenuItem13.Image = buttImage5;
                }
                else
                {
                    materialToolStripMenuItem13.Image = Properties.Resources.eye;
                }
                label53.Visible = false;
                materialTextBox27.Visible = false;
                button8.Visible = false;
                materialCard27.Visible = false;
                label44.Visible = false;
                materialRadioButton26.Visible = false;
                materialRadioButton25.Visible = false;
                materialCard18.Visible = false;
                label46.Visible = false;
                label47.Visible = false;
                label48.Visible = false;
                materialTextBox23.Visible = false;
                materialTextBox24.Visible = false;
                button6.Visible = false;
                materialCard19.Visible = false;
            }
        }

        private void materialToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            var oMissing = System.Reflection.Missing.Value;
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook WorkBook = ExcelApp.Workbooks.Add(oMissing);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Код";
            WorkSheet.Cells[1, 2] = "Модель смартфона";
            WorkSheet.Cells[1, 3] = "Класс";
            WorkSheet.Cells[1, 4] = "Цена (в тенге)";
            WorkSheet.Cells[1, 5] = "Процессор";
            WorkSheet.Cells[1, 6] = "Дисплей";
            WorkSheet.Cells[1, 7] = "Объем оперативной памяти (в Гб)";
            WorkSheet.Cells[1, 8] = "Объем встроенной памяти (в Гб)";
            WorkSheet.Cells[1, 9] = "Ёмкость аккумулятора (в мАч)";
            WorkSheet.Cells[1, 10] = "Цвет";
            WorkSheet.Cells[1, 11] = "Количество (в штуках)";
            WorkSheet.Cells[1, 12] = "Номер накладной";
            WorkSheet.Cells[1, 13] = "Дата поставки";

            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    WorkSheet.Cells[i + 2, j + 1] = dataGridView2[j, i].Value.ToString();

            Excel.Range cells = WorkSheet.Range[WorkSheet.Cells[1, 1], WorkSheet.Cells[dataGridView2.RowCount, dataGridView2.ColumnCount]];
            cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            cells.EntireColumn.AutoFit();
            cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Visible = true;
        }

        private void materialToolStripMenuItem16_Click(object sender, EventArgs e)
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
            wordParag.Range.Text = $"Smartphone Store - Смартфоны Apple";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Информация о смартфонах Apple";
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

            wordParag.Range.Tables.Add(wordParag.Range, dataGridView2.RowCount, dataGridView2.ColumnCount, t1, t2);
            wordTable = wordDoc.Tables[1];
            wordTable.Range.Font.Size = 9;
            wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
            wordTable.Columns.SetWidth(50, Word.WdRulerStyle.wdAdjustFirstColumn);

            // Вывод заголовка
            for (i = 0; i < dataGridView2.ColumnCount; i++)
                wordTable.Cell(1, i + 1).Range.Text = dataGridView2.Columns[i].HeaderText;

            // Вывод таблицы
            for (i = 1; i < dataGridView2.RowCount; i++)
                for (j = 0; j < dataGridView2.ColumnCount; j++)
                    wordTable.Cell(i + 1, j + 1).Range.Text = dataGridView2.Rows[i - 1].Cells[j].Value.ToString();
        }

        private void materialRadioButton25_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where class = '{materialRadioButton25.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (materialTextBox23.Text.Length == 0 || materialTextBox24.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону цен!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView2.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_apple where price >= {materialTextBox23.Text} and price <= {materialTextBox24.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton21_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where cpu = '{materialRadioButton21.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton20_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where cpu = '{materialRadioButton20.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton22_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where cpu = '{materialRadioButton22.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton19_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where cpu = '{materialRadioButton19.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton15_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where display= '{materialRadioButton15.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton14_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where display= '{materialRadioButton14.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton9_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where dram = 6";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where dram = 4";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton10_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where dram = 3";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where memory = 1000";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where memory = 512";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where memory = 256";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton34_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where memory = 128";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton35_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where memory = 64";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (materialTextBox25.Text.Length == 0 || materialTextBox26.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону ёмкости аккумулятора!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView2.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones where battery >= {materialTextBox25.Text} and battery <= {materialTextBox26.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where color= '{materialRadioButton3.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where color= '{materialRadioButton2.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where color= '{materialRadioButton4.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where color= '{materialRadioButton1.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton37_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_apple where color= '{materialRadioButton37.Text}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (materialTextBox22.Text.Length == 0 || materialTextBox21.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону количества!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView2.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_apple where quantity >= '{materialTextBox22.Text}' and quantity <= '{materialTextBox21.Text}'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - Смартфоны Apple";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
            int i, n;
            dataGridView2.Rows.Clear();
            string sql = "SELECT * FROM smartphones_apple";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView2.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - Все смартфоны";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
            int i, n;
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM smartphones";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView1.Rows[n].Cells[13].Value = (DateTime)reader[13];
            }
            reader.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i, n;
            dataGridView3.Rows.Clear();
            string sql = "SELECT * FROM smartphones_samsung";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView3.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem21_Click(object sender, EventArgs e)
        {
            if (!asd)
            {
                this.Size = new System.Drawing.Size(1197, 1030);
                asd = !asd;
                CenterToScreen();
                tabPage4.AutoScroll = true;
                materialToolStripMenuItem21.Text = "Скрыть фильтры";
                if (changed)
                {
                    materialToolStripMenuItem21.Image = buttImage4;
                }
                else
                {
                    materialToolStripMenuItem21.Image = Properties.Resources.invisible;
                }
                materialCard35.Visible = true;
                label72.Visible = true;
                materialTextBox214.Visible = true;
                button13.Visible = true;
                materialCard28.Visible = true;
                label64.Visible = true;
                materialRadioButton30.Visible = true;
                materialRadioButton45.Visible = true;
                materialRadioButton44.Visible = true;
                materialRadioButton43.Visible = true;
                materialCard29.Visible = true;
                label65.Visible = true;
                label66.Visible = true;
                label67.Visible = true;
                materialTextBox29.Visible = true;
                materialTextBox210.Visible = true;
                button11.Visible = true;
            }

            else
            {
                this.Size = new System.Drawing.Size(1197, 599);
                asd = !asd;
                CenterToScreen();
                tabPage4.AutoScroll = false;
                materialToolStripMenuItem21.Text = "Показать фильтры";
                if (changed)
                {
                    materialToolStripMenuItem21.Image = buttImage4;
                }
                else
                {
                    materialToolStripMenuItem21.Image = Properties.Resources.eye;
                }
                materialCard35.Visible = false;
                label72.Visible = false;
                materialTextBox214.Visible = false;
                button13.Visible = false;
                materialCard28.Visible = false;
                label64.Visible = false;
                materialRadioButton30.Visible = false;
                materialRadioButton45.Visible = false;
                materialRadioButton44.Visible = false;
                materialRadioButton43.Visible = false;
                materialCard29.Visible = false;
                label65.Visible = false;
                label66.Visible = false;
                label67.Visible = false;
                materialTextBox29.Visible = false;
                materialTextBox210.Visible = false;
                button11.Visible = false;
            }
        }

        private void materialToolStripMenuItem23_Click(object sender, EventArgs e)
        {
            var oMissing = System.Reflection.Missing.Value;
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook WorkBook = ExcelApp.Workbooks.Add(oMissing);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Код";
            WorkSheet.Cells[1, 2] = "Модель смартфона";
            WorkSheet.Cells[1, 3] = "Класс";
            WorkSheet.Cells[1, 4] = "Цена (в тенге)";
            WorkSheet.Cells[1, 5] = "Процессор";
            WorkSheet.Cells[1, 6] = "Дисплей";
            WorkSheet.Cells[1, 7] = "Объем оперативной памяти (в Гб)";
            WorkSheet.Cells[1, 8] = "Объем встроенной памяти (в Гб)";
            WorkSheet.Cells[1, 9] = "Ёмкость аккумулятора (в мАч)";
            WorkSheet.Cells[1, 10] = "Цвет";
            WorkSheet.Cells[1, 11] = "Количество (в штуках)";
            WorkSheet.Cells[1, 12] = "Номер накладной";
            WorkSheet.Cells[1, 13] = "Дата поставки";

            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    WorkSheet.Cells[i + 2, j + 1] = dataGridView3[j, i].Value.ToString();

            Excel.Range cells = WorkSheet.Range[WorkSheet.Cells[1, 1], WorkSheet.Cells[dataGridView3.RowCount, dataGridView3.ColumnCount]];
            cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            cells.EntireColumn.AutoFit();
            cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Visible = true;
        }

        private void materialToolStripMenuItem24_Click(object sender, EventArgs e)
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
            wordParag.Range.Text = $"Smartphone Store - Смартфоны Samsung";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Информация о смартфонах Samsung";
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

            wordParag.Range.Tables.Add(wordParag.Range, dataGridView3.RowCount, dataGridView3.ColumnCount, t1, t2);
            wordTable = wordDoc.Tables[1];
            wordTable.Range.Font.Size = 9;
            wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
            wordTable.Columns.SetWidth(50, Word.WdRulerStyle.wdAdjustFirstColumn);

            // Вывод заголовка
            for (i = 0; i < dataGridView3.ColumnCount; i++)
                wordTable.Cell(1, i + 1).Range.Text = dataGridView3.Columns[i].HeaderText;

            // Вывод таблицы
            for (i = 1; i < dataGridView3.RowCount; i++)
                for (j = 0; j < dataGridView3.ColumnCount; j++)
                    wordTable.Cell(i + 1, j + 1).Range.Text = dataGridView3.Rows[i - 1].Cells[j].Value.ToString();
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - Смартфоны Samsung";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
            int i, n;
            dataGridView3.Rows.Clear();
            string sql = "SELECT * FROM smartphones_samsung";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView3.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (materialTextBox214.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по модели смартфона!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from smartphones_samsung where model like '%{materialTextBox214.Text}%'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton30_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where class = '{materialRadioButton30.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton45_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where class = '{materialRadioButton45.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton44_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where class = '{materialRadioButton44.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton43_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where class = '{materialRadioButton43.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (materialTextBox29.Text.Length == 0 || materialTextBox210.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону цен!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where price >= {materialTextBox29.Text} and price <= {materialTextBox210.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton16_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where cpu like 'MediaTek Helio%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton13_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where cpu like 'Qualcomm Snapdragon%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton17_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where cpu like 'Samsung Exynos%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton12_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where cpu like 'Unisoc%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton47_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where display = '{materialRadioButton47.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton46_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where display = '{materialRadioButton46.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton28_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where display = '{materialRadioButton28.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton51_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where dram = 12";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton52_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where dram = 8";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton53_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where dram = 6";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton29_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where dram = 4";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton49_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where dram = 3";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton50_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where dram = 2";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton36_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where memory = 512";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton38_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where memory = 256";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton39_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where memory = 128";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton32_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where memory = 64";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton33_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where memory = 32";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (materialTextBox211.Text.Length == 0 || materialTextBox212.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону ёмкости аккумулятора!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where battery >= {materialTextBox211.Text} and battery <= {materialTextBox212.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton24_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where color= '{materialRadioButton24.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton23_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where color= '{materialRadioButton23.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton27_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where color= '{materialRadioButton27.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton18_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where color= '{materialRadioButton18.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton11_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_samsung where color= '{materialRadioButton11.Text}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (materialTextBox28.Text.Length == 0 || materialTextBox213.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону количества!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView3.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_samsung where quantity >= '{materialTextBox28.Text}' and quantity <= '{materialTextBox213.Text}'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int i, n;
            dataGridView4.Rows.Clear();
            string sql = "SELECT * FROM smartphones_xiaomi";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView4.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem29_Click(object sender, EventArgs e)
        {
            if (!asd)
            {
                this.Size = new System.Drawing.Size(1197, 1030);
                asd = !asd;
                CenterToScreen();
                tabPage5.AutoScroll = true;
                materialToolStripMenuItem29.Text = "Скрыть фильтры";
                if (changed)
                {
                    materialToolStripMenuItem29.Image = buttImage3;
                }
                else
                {
                    materialToolStripMenuItem29.Image = Properties.Resources.invisible;
                }
                materialCard45.Visible = true;
                label92.Visible = true;
                materialTextBox221.Visible = true;
                button18.Visible = true;
                materialCard48.Visible = true;
                label94.Visible = true;
                materialRadioButton82.Visible = true;
                materialRadioButton79.Visible = true;
                materialRadioButton83.Visible = true;
                materialRadioButton81.Visible = true;
                materialRadioButton80.Visible = true;
                materialCard39.Visible = true;
                label85.Visible = true;
                label86.Visible = true;
                label87.Visible = true;
                materialTextBox216.Visible = true;
                materialTextBox217.Visible = true;
                button16.Visible = true;
            }

            else
            {
                this.Size = new System.Drawing.Size(1197, 599);
                asd = !asd;
                CenterToScreen();
                tabPage5.AutoScroll = false;
                materialToolStripMenuItem29.Text = "Показать фильтры";
                if (changed)
                {
                    materialToolStripMenuItem29.Image = buttImage3;
                }
                else
                {
                    materialToolStripMenuItem29.Image = Properties.Resources.eye;
                }
                materialCard45.Visible = false;
                label92.Visible = false;
                materialTextBox221.Visible = false;
                button18.Visible = false;
                materialCard48.Visible = false;
                label94.Visible = false;
                materialRadioButton82.Visible = false;
                materialRadioButton79.Visible = false;
                materialRadioButton83.Visible = false;
                materialRadioButton81.Visible = false;
                materialRadioButton80.Visible = false;
                materialCard39.Visible = false;
                label85.Visible = false;
                label86.Visible = false;
                label87.Visible = false;
                materialTextBox216.Visible = false;
                materialTextBox217.Visible = false;
                button16.Visible = false;
            }
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - Смартфоны Xiaomi";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
            int i, n;
            dataGridView4.Rows.Clear();
            string sql = "SELECT * FROM smartphones_xiaomi";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView4.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem31_Click(object sender, EventArgs e)
        {
            var oMissing = System.Reflection.Missing.Value;
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook WorkBook = ExcelApp.Workbooks.Add(oMissing);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Код";
            WorkSheet.Cells[1, 2] = "Модель смартфона";
            WorkSheet.Cells[1, 3] = "Класс";
            WorkSheet.Cells[1, 4] = "Цена (в тенге)";
            WorkSheet.Cells[1, 5] = "Процессор";
            WorkSheet.Cells[1, 6] = "Дисплей";
            WorkSheet.Cells[1, 7] = "Объем оперативной памяти (в Гб)";
            WorkSheet.Cells[1, 8] = "Объем встроенной памяти (в Гб)";
            WorkSheet.Cells[1, 9] = "Ёмкость аккумулятора (в мАч)";
            WorkSheet.Cells[1, 10] = "Цвет";
            WorkSheet.Cells[1, 11] = "Количество (в штуках)";
            WorkSheet.Cells[1, 12] = "Номер накладной";
            WorkSheet.Cells[1, 13] = "Дата поставки";

            for (int i = 0; i < dataGridView4.RowCount - 1; i++)
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    WorkSheet.Cells[i + 2, j + 1] = dataGridView4[j, i].Value.ToString();

            Excel.Range cells = WorkSheet.Range[WorkSheet.Cells[1, 1], WorkSheet.Cells[dataGridView4.RowCount, dataGridView4.ColumnCount]];
            cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            cells.EntireColumn.AutoFit();
            cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Visible = true;
        }

        private void materialToolStripMenuItem32_Click(object sender, EventArgs e)
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
            wordParag.Range.Text = $"Smartphone Store - Смартфоны Xiaomi";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Информация о смартфонах Xiaomi";
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

            wordParag.Range.Tables.Add(wordParag.Range, dataGridView4.RowCount, dataGridView4.ColumnCount, t1, t2);
            wordTable = wordDoc.Tables[1];
            wordTable.Range.Font.Size = 9;
            wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
            wordTable.Columns.SetWidth(50, Word.WdRulerStyle.wdAdjustFirstColumn);

            // Вывод заголовка
            for (i = 0; i < dataGridView4.ColumnCount; i++)
                wordTable.Cell(1, i + 1).Range.Text = dataGridView4.Columns[i].HeaderText;

            // Вывод таблицы
            for (i = 1; i < dataGridView4.RowCount; i++)
                for (j = 0; j < dataGridView4.ColumnCount; j++)
                    wordTable.Cell(i + 1, j + 1).Range.Text = dataGridView4.Rows[i - 1].Cells[j].Value.ToString();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (materialTextBox221.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по модели смартфона!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from smartphones_xiaomi where model like '%{materialTextBox221.Text}%'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton82_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where class = '{materialRadioButton82.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton79_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where class = '{materialRadioButton79.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton83_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where class = '{materialRadioButton83.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton81_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where class = '{materialRadioButton81.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton80_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where class = '{materialRadioButton80.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (materialTextBox216.Text.Length == 0 || materialTextBox217.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону цен!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView4.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_xiaomi where price >= {materialTextBox216.Text} and price <= {materialTextBox217.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton42_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_xiaomi where cpu like 'MediaTek Dimensity%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton41_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_xiaomi where cpu like 'MediaTek Helio%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton54_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_xiaomi where cpu like 'Qualcomm Snapdragon%'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton65_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where display = '{materialRadioButton65.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton64_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where display = '{materialRadioButton64.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton63_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where display = '{materialRadioButton63.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton75_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where dram = 12";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton76_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where dram = 8";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton77_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where dram = 6";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton72_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where dram = 4";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton73_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where dram = 2";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton69_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where memory = 512";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton70_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where memory = 256";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton71_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where memory = 128";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton67_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where memory = 64";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton68_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where memory = 32";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (materialTextBox218.Text.Length == 0 || materialTextBox219.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону ёмкости аккумулятора!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView4.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_xiaomi where battery >= {materialTextBox218.Text} and battery <= {materialTextBox219.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton57_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where color= '{materialRadioButton57.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton56_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where color= '{materialRadioButton56.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton58_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where color= '{materialRadioButton58.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton55_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where color= '{materialRadioButton55.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton31_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from smartphones_xiaomi where color= '{materialRadioButton31.Text}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (materialTextBox215.Text.Length == 0 || materialTextBox220.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону количества!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView4.Rows.Clear();
            myCommand.CommandText = $"select * from smartphones_xiaomi where quantity >= '{materialTextBox215.Text}' and quantity <= '{materialTextBox220.Text}'";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (int i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialToolStripMenuItem41_Click(object sender, EventArgs e)
        {
            smartphones_availability.ShowDialog();
        }

        private void materialToolStripMenuItem42_Click(object sender, EventArgs e)
        {
            smartphones_apple_availability.ShowDialog();
        }

        private void materialToolStripMenuItem43_Click(object sender, EventArgs e)
        {
            smartphones_samsung_availability.ShowDialog();
        }

        private void materialToolStripMenuItem44_Click(object sender, EventArgs e)
        {
            smartphones_xiaomi_availability.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int i, n;
            dataGridView6.Rows.Clear();
            string sql = "SELECT * FROM staff";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (i = 0; i < 6; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView6.Rows[n].Cells[6].Value = (DateTime)reader[6];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem46_Click(object sender, EventArgs e)
        {
            staff_add.ShowDialog();
        }

        private void materialToolStripMenuItem47_Click(object sender, EventArgs e)
        {
            transfer.id = Convert.ToInt32(dataGridView6.CurrentRow.Cells[0].Value);
            transfer.par1 = dataGridView6.CurrentRow.Cells[1].Value.ToString();
            transfer.par2 = dataGridView6.CurrentRow.Cells[2].Value.ToString();
            transfer.par3 = dataGridView6.CurrentRow.Cells[3].Value.ToString();
            transfer.par4 = dataGridView6.CurrentRow.Cells[4].Value.ToString();
            transfer.par5 = dataGridView6.CurrentRow.Cells[5].Value.ToString();
            transfer.par12 = Convert.ToDateTime(dataGridView6.CurrentRow.Cells[6].Value.ToString());

            staff_change.ShowDialog();
        }

        private void materialToolStripMenuItem48_Click(object sender, EventArgs e)
        {
            int id, n, i;

            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                id = Convert.ToInt32(dataGridView6.CurrentRow.Cells[0].Value);
                myCommand.CommandText = $"delete from staff where id =" + id;
                myCommand.ExecuteNonQuery();

                dataGridView6.Rows.Clear();
                string sql = "SELECT * FROM staff";
                myCommand.CommandText = sql;
                MySqlDataReader reader = myCommand.ExecuteReader();

                while (reader.Read())
                {
                    n = dataGridView6.NewRowIndex;
                    dataGridView6.Rows.Add();
                    for (i = 0; i < 7; i++)
                        dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
                }
                reader.Close();
            }
        }

        private void materialToolStripMenuItem49_Click(object sender, EventArgs e)
        {
            if (!asd)
            {
                this.Size = new System.Drawing.Size(1197, 913);
                asd = !asd;
                CenterToScreen();
                tabPage7.AutoScroll = true;
                materialToolStripMenuItem49.Text = "Скрыть фильтры";
                if (changed)
                {
                    materialToolStripMenuItem49.Image = buttImage;
                }
                else
                {
                    materialToolStripMenuItem49.Image = Properties.Resources.invisible;
                }
                changed = !changed;
                materialCard60.Visible = true;
                label111.Visible = true;
                materialTextBox233.Visible = true;
                button29.Visible = true;
                materialCard56.Visible = true;
                label102.Visible = true;
                materialTextBox230.Visible = true;
                button27.Visible = true;
                materialCard57.Visible = true;
                label103.Visible = true;
                materialRadioButton94.Visible = true;
                materialRadioButton95.Visible = true;
                materialRadioButton93.Visible = true;
                materialRadioButton92.Visible = true;
                materialRadioButton91.Visible = true;
                materialRadioButton90.Visible = true;
                materialRadioButton89.Visible = true;
            }

            else
            {
                this.Size = new System.Drawing.Size(1197, 599);
                asd = !asd;
                CenterToScreen();
                tabPage7.AutoScroll = false;
                materialToolStripMenuItem49.Text = "Показать фильтры";
                if (changed)
                {
                    materialToolStripMenuItem49.Image = buttImage;
                }
                else
                {
                    materialToolStripMenuItem49.Image = Properties.Resources.eye;
                }
                changed = !changed;
                materialCard60.Visible = false;
                label111.Visible = false;
                materialTextBox233.Visible = false;
                button29.Visible = false;
                materialCard56.Visible = false;
                label102.Visible = false;
                materialTextBox230.Visible = false;
                button27.Visible = false;
                materialCard57.Visible = false;
                label103.Visible = false;
                materialRadioButton94.Visible = false;
                materialRadioButton95.Visible = false;
                materialRadioButton93.Visible = false;
                materialRadioButton92.Visible = false;
                materialRadioButton91.Visible = false;
                materialRadioButton90.Visible = false;
                materialRadioButton89.Visible = false;
            }
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - Сотрудники";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
            int i, n;
            dataGridView6.Rows.Clear();
            string sql = "SELECT * FROM staff";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (i = 0; i < 6; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView6.Rows[n].Cells[6].Value = (DateTime)reader[6];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem51_Click(object sender, EventArgs e)
        {
            var oMissing = System.Reflection.Missing.Value;
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook WorkBook = ExcelApp.Workbooks.Add(oMissing);
            Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

            WorkSheet.Cells[1, 1] = "Код";
            WorkSheet.Cells[1, 2] = "ФИО";
            WorkSheet.Cells[1, 3] = "Должность";
            WorkSheet.Cells[1, 4] = "Город";
            WorkSheet.Cells[1, 5] = "Зарплата";
            WorkSheet.Cells[1, 6] = "Контактный телефон";
            WorkSheet.Cells[1, 7] = "Дата рождения";

            for (int i = 0; i < dataGridView6.RowCount - 1; i++)
                for (int j = 0; j < dataGridView6.ColumnCount; j++)
                    WorkSheet.Cells[i + 2, j + 1] = dataGridView6[j, i].Value.ToString();

            Excel.Range cells = WorkSheet.Range[WorkSheet.Cells[1, 1], WorkSheet.Cells[dataGridView6.RowCount, dataGridView6.ColumnCount]];
            cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            cells.EntireColumn.AutoFit();
            cells.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Visible = true;
        }

        private void materialToolStripMenuItem52_Click(object sender, EventArgs e)
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
            wordParag.Range.Text = $"Smartphone Store - Сотрудники";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Информация о сотрудниках";
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

            wordParag.Range.Tables.Add(wordParag.Range, dataGridView6.RowCount, dataGridView6.ColumnCount, t1, t2);
            wordTable = wordDoc.Tables[1];
            wordTable.Range.Font.Size = 9;
            wordTable.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitWindow);
            wordTable.Columns.SetWidth(50, Word.WdRulerStyle.wdAdjustFirstColumn);

            // Вывод заголовка
            for (i = 0; i < dataGridView6.ColumnCount; i++)
                wordTable.Cell(1, i + 1).Range.Text = dataGridView6.Columns[i].HeaderText;

            // Вывод таблицы
            for (i = 1; i < dataGridView6.RowCount; i++)
                for (j = 0; j < dataGridView6.ColumnCount; j++)
                    wordTable.Cell(i + 1, j + 1).Range.Text = dataGridView6.Rows[i - 1].Cells[j].Value.ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            if (materialTextBox233.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по ФИО!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from staff where fullname like '%{materialTextBox233.Text}%'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (materialTextBox230.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по должности!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from staff where job like '%{materialTextBox230.Text}%'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (materialTextBox225.Text.Length == 0)
            {
                MessageBox.Show("Заполните поле фильтрации по контактному телефону!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            string sql = "";
            sql = $"select * from staff where phone = {materialTextBox225.Text}";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (materialTextBox231.Text.Length == 0 || materialTextBox232.Text.Length == 0)
            {
                MessageBox.Show("Заполните поля фильтрации по диапазону зарплаты!", "Ошибка фильтрации", MessageBoxButtons.OK);
                return;
            }

            dataGridView6.Rows.Clear();
            myCommand.CommandText = $"select * from staff where salary >= {materialTextBox231.Text} and salary <= {materialTextBox232.Text}";
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton94_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton94.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton95_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton95.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton93_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton93.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton92_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton92.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton91_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton91.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton90_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton90.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialRadioButton89_CheckedChanged(object sender, EventArgs e)
        {
            string sql = "";
            sql = $"select * from staff where city = '{materialRadioButton89.Text}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                int n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (int i = 0; i < 7; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void tabPage9_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - О нас";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 663);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete) 
                return;
            else
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox24_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox25_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox26_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox29_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox210_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox211_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox212_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox28_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox213_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox216_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox217_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox218_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox219_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox215_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox220_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox231_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox232_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void materialTextBox225_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == '\b' || e.KeyChar == (char)Keys.Delete)
                return;
            else
                e.Handled = true;
        }

        private void tabPage10_Enter(object sender, EventArgs e)
        {
            this.Text = "Smartphone Store - Связаться с нами";
            label84.Text = "";
            materialMultiLineTextBox21.Text = "";
            materialTextBox222.Text = "";
            materialTextBox223.Text = "";
            materialToolStripMenuItem49.Image = Properties.Resources.eye;
            materialToolStripMenuItem29.Image = Properties.Resources.eye;
            materialToolStripMenuItem21.Image = Properties.Resources.eye;
            materialToolStripMenuItem13.Image = Properties.Resources.eye;
            materialToolStripMenuItem2.Image = Properties.Resources.eye;
            tabPage1.AutoScroll = false;
            tabPage3.AutoScroll = false;
            tabPage4.AutoScroll = false;
            tabPage5.AutoScroll = false;
            tabPage7.AutoScroll = false;
            label18.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            label19.Visible = false;
            radioButton6.Visible = false;
            radioButton7.Visible = false;
            radioButton8.Visible = false;
            label20.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            materialCard6.Visible = false;
            materialCard7.Visible = false;
            materialCard8.Visible = false;
            materialCard9.Visible = false;
            label53.Visible = false;
            materialTextBox27.Visible = false;
            button8.Visible = false;
            materialCard27.Visible = false;
            label44.Visible = false;
            materialRadioButton26.Visible = false;
            materialRadioButton25.Visible = false;
            materialCard18.Visible = false;
            label46.Visible = false;
            label47.Visible = false;
            label48.Visible = false;
            materialTextBox23.Visible = false;
            materialTextBox24.Visible = false;
            button6.Visible = false;
            materialCard19.Visible = false;
            materialCard35.Visible = false;
            label72.Visible = false;
            materialTextBox214.Visible = false;
            button13.Visible = false;
            materialCard28.Visible = false;
            label64.Visible = false;
            materialRadioButton30.Visible = false;
            materialRadioButton45.Visible = false;
            materialRadioButton44.Visible = false;
            materialRadioButton43.Visible = false;
            materialCard29.Visible = false;
            label65.Visible = false;
            label66.Visible = false;
            label67.Visible = false;
            materialTextBox29.Visible = false;
            materialTextBox210.Visible = false;
            button11.Visible = false;
            materialCard45.Visible = false;
            label92.Visible = false;
            materialTextBox221.Visible = false;
            button18.Visible = false;
            materialCard48.Visible = false;
            label94.Visible = false;
            materialRadioButton82.Visible = false;
            materialRadioButton79.Visible = false;
            materialRadioButton83.Visible = false;
            materialRadioButton81.Visible = false;
            materialRadioButton80.Visible = false;
            materialCard39.Visible = false;
            label85.Visible = false;
            label86.Visible = false;
            label87.Visible = false;
            materialTextBox216.Visible = false;
            materialTextBox217.Visible = false;
            button16.Visible = false;
            materialCard60.Visible = false;
            label111.Visible = false;
            materialTextBox233.Visible = false;
            button29.Visible = false;
            materialCard56.Visible = false;
            label102.Visible = false;
            materialTextBox230.Visible = false;
            button27.Visible = false;
            materialCard57.Visible = false;
            label103.Visible = false;
            materialRadioButton94.Visible = false;
            materialRadioButton95.Visible = false;
            materialRadioButton93.Visible = false;
            materialRadioButton92.Visible = false;
            materialRadioButton91.Visible = false;
            materialRadioButton90.Visible = false;
            materialRadioButton89.Visible = false;
            this.Size = new System.Drawing.Size(1197, 599);
            CenterToScreen();
            materialToolStripMenuItem2.Text = "Показать фильтры";
            materialToolStripMenuItem13.Text = "Показать фильтры";
            materialToolStripMenuItem21.Text = "Показать фильтры";
            materialToolStripMenuItem29.Text = "Показать фильтры";
            materialToolStripMenuItem49.Text = "Показать фильтры";
            if (asd != false)
                asd = false;
        }

        private void materialTextBox222_KeyUp(object sender, KeyEventArgs e)
        {
            if (materialTextBox222.Text != "")
                materialTextBox222.HelperText = "";
            else
                materialTextBox222.HelperText = "Введите ваше имя";
        }

        private void materialTextBox223_KeyUp(object sender, KeyEventArgs e)
        {
            if (materialTextBox223.Text != "")
                materialTextBox223.HelperText = "";
            else
                materialTextBox223.HelperText = "Введите ваш действительный email";
        }

        private void materialTextBox222_Enter(object sender, EventArgs e)
        {
            if (materialTextBox222.Text != "")
                materialTextBox222.HelperText = "";
            else
                materialTextBox222.HelperText = "Введите ваше имя";
        }

        private void materialTextBox223_Enter(object sender, EventArgs e)
        {
            if (materialTextBox223.Text != "")
                materialTextBox223.HelperText = "";
            else
                materialTextBox223.HelperText = "Введите ваш действительный email";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (materialTextBox222.Text == "" && materialTextBox223.Text == "" && materialMultiLineTextBox21.Text == "")
            {
                label84.Text = "Все поля должны быть заполнены!";
                label84.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            if (materialTextBox222.Text == "")
            {
                label84.Text = "Заполните поле имени!";
                label84.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            if (materialTextBox223.Text == "")
            {
                label84.Text = "Заполните поле email!";
                label84.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            if (materialMultiLineTextBox21.Text == "")
            {
                label84.Text = "Заполните поле сообщения!";
                label84.ForeColor = Color.FromArgb(244, 67, 54);
                return;
            }

            materialTextBox222.Text.Trim();
            materialTextBox223.Text.Trim();
            materialMultiLineTextBox21.Text.Trim();

            if (materialTextBox222.TextLength >= 2)
            {
                if (IsValidEmail(materialTextBox223.Text) == true)
                {
                    if (materialMultiLineTextBox21.TextLength >= 10)
                    {
                        DateTime dateTimeVariable = DateTime.Now;
                        string format = "yyyy-MM-dd HH:mm:ss";
                        string sql = $"insert into messages(name,email,message,date) values('{materialTextBox222.Text}','{materialTextBox223.Text}', '{materialMultiLineTextBox21.Text}', '" + dateTimeVariable.ToString(format) + "')";
                        myCommand.CommandText = sql;

                        myCommand.ExecuteNonQuery();
                        label84.Text = "Сообщение было отправлено.";
                        label84.ForeColor = Color.FromArgb(102, 187, 106);
                    }

                    else
                    {
                        label84.Text = "Сообщение должно содержать не менее 10 символов.";
                        label84.ForeColor = Color.FromArgb(244, 67, 54);
                    }
                }

                else
                {
                    label84.Text = "Укажите правильный адрес электронной почты.";
                    label84.ForeColor = Color.FromArgb(244, 67, 54);
                }
            }

            else
            {
                label84.Text = "Имя должно содержать не менее 2 символов.";
                label84.ForeColor = Color.FromArgb(244, 67, 54);
            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            #pragma warning disable CS0168
            catch (RegexMatchTimeoutException e)
            #pragma warning restore CS0168
            {
                return false;
            }
            #pragma warning disable CS0168
            catch (ArgumentException e)
            #pragma warning restore CS0168
            {
                return false;
            }

            try
            {       return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private void materialMultiLineTextBox21_KeyUp(object sender, KeyEventArgs e)
        {
            materialLabel26.Text = materialMultiLineTextBox21.Text.Length.ToString() + "/1000";

            if (materialMultiLineTextBox21.Text.Length > 9)
            {
                materialLabel26.Location = new Point(1048, 363);
            }

            if(materialMultiLineTextBox21.Text.Length <= 9)
            {
                materialLabel26.Location = new Point(1056, 363);
            }

            if (materialMultiLineTextBox21.Text.Length >= 100)
            {
                materialLabel26.Location = new Point(1040, 363);
            }

            if (materialMultiLineTextBox21.Text.Length == 1000)
            {
                materialLabel26.Location = new Point(1032, 363);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginForm loginform = new LoginForm();
            Environment.Exit(0);
        }

        private void materialTabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == tabPage2.Name)
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Выход из аккаунта", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    Hide();
                    LoginForm loginform = new LoginForm();
                    loginform.ShowDialog();
                }

                e.Cancel = true;
            }
        }

        private void dataGridView6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int id, n, i;

                DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dataGridView6.CurrentRow.Cells[0].Value);
                    myCommand.CommandText = $"delete from staff where id =" + id;
                    myCommand.ExecuteNonQuery();

                    dataGridView6.Rows.Clear();
                    string sql = "SELECT * FROM staff";
                    myCommand.CommandText = sql;
                    MySqlDataReader reader = myCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        n = dataGridView6.NewRowIndex;
                        dataGridView6.Rows.Add();
                        for (i = 0; i < 7; i++)
                            dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
                    }
                    reader.Close();
                }
            }
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            int i, n;
            string sql = "";
            sql = $"select * from staff where datebirth = '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}'";
            dataGridView6.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView6.NewRowIndex;
                dataGridView6.Rows.Add();
                for (i = 0; i < 6; i++)
                    dataGridView6.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView6.Rows[n].Cells[6].Value = (DateTime)reader[6];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem33_Click(object sender, EventArgs e)
        {
            smartphones_add.ShowDialog();
        }

        private void materialToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            smartphones_archive.ShowDialog();
        }

        private void materialToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int i, n;
            myCommand.CommandText = $"insert into `smartphones_archive`(model,brand,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date) SELECT model,brand,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date FROM `smartphones`";
            myCommand.ExecuteNonQuery();

            myCommand.CommandText = $"delete from smartphones";
            myCommand.ExecuteNonQuery();

            MessageBox.Show("Таблица «Все смартфоны» была успешно перемещена в архив.", "Архив");

            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM smartphones";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView1.Rows[n].Cells[13].Value = (DateTime)reader[13];
            }
            reader.Close();
        }

        private void materialToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            smartphones_apple_add.ShowDialog();
        }

        private void materialToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            smartphones_samsung_add.ShowDialog();
        }

        private void materialToolStripMenuItem25_Click(object sender, EventArgs e)
        {
            smartphones_xiaomi_add.ShowDialog();
        }

        private void materialToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            int i, n;
 
            myCommand.CommandText = $"insert into `smartphones_apple_archive`(model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date) SELECT model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date FROM `smartphones_apple`";
            myCommand.ExecuteNonQuery();

            myCommand.CommandText = $"delete from smartphones_apple";
            myCommand.ExecuteNonQuery();

            MessageBox.Show("Таблица «Смартфоны Apple» была успешно перемещена в архив.", "Архив");

            dataGridView2.Rows.Clear();
            string sql = "SELECT * FROM smartphones_apple";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            smartphones_apple_archive.ShowDialog();
        }

        private void materialToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            int i, n;

            myCommand.CommandText = $"insert into `smartphones_samsung_archive`(model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date) SELECT model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date FROM `smartphones_samsung`";
            myCommand.ExecuteNonQuery();

            myCommand.CommandText = $"delete from smartphones_samsung";
            myCommand.ExecuteNonQuery();

            MessageBox.Show("Таблица «Смартфоны Samsung» была успешно перемещена в архив.", "Архив");

            dataGridView3.Rows.Clear();
            string sql = "SELECT * FROM smartphones_samsung";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            smartphones_samsung_archive.ShowDialog();
        }

        private void materialToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            int i, n;

            myCommand.CommandText = $"insert into `smartphones_xiaomi_archive`(model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date) SELECT model,class,price,cpu,display,dram,memory,battery,color,quantity,consignment,receipt_date FROM `smartphones_xiaomi`";
            myCommand.ExecuteNonQuery();

            myCommand.CommandText = $"delete from smartphones_xiaomi";
            myCommand.ExecuteNonQuery();

            MessageBox.Show("Таблица «Смартфоны Xiaomi» была успешно перемещена в архив.", "Архив");

            dataGridView4.Rows.Clear();
            string sql = "SELECT * FROM smartphones_xiaomi";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
            }
            reader.Close();
        }

        private void materialToolStripMenuItem12_Click(object sender, EventArgs e)
        {
            smartphones_xiaomi_archive.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int i, n;
            string sql = "";
            sql = $"select * from smartphones where receipt_date = '{dateTimePicker2.Value.Date.ToString("yyyy-MM-dd")}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 13; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView1.Rows[n].Cells[13].Value = (DateTime)reader[13];
            }
            reader.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int i, n;
            string sql = "";
            sql = $"select * from smartphones_apple where receipt_date = '{dateTimePicker3.Value.Date.ToString("yyyy-MM-dd")}'";
            dataGridView2.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView2.NewRowIndex;
                dataGridView2.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView2.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView2.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int i, n;
            string sql = "";
            sql = $"select * from smartphones_samsung where receipt_date = '{dateTimePicker4.Value.Date.ToString("yyyy-MM-dd")}'";
            dataGridView3.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView3.NewRowIndex;
                dataGridView3.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView3.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView3.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int i, n;
            string sql = "";
            sql = $"select * from smartphones_xiaomi where receipt_date = '{dateTimePicker5.Value.Date.ToString("yyyy-MM-dd")}'";
            dataGridView4.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView4.NewRowIndex;
                dataGridView4.Rows.Add();
                for (i = 0; i < 12; i++)
                    dataGridView4.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView4.Rows[n].Cells[12].Value = (DateTime)reader[12];
            }
            reader.Close();
        }
    }
}