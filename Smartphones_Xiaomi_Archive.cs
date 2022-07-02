using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MaterialSkin.Controls;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace WindowsFormsApp1
{
    public partial class Smartphones_Xiaomi_Archive : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        private const string CON_SQL = "server=localhost;user id=root;database=smartphone_store;characterset=utf8;Convert Zero Datetime=True;";
        private MySqlConnection con = new MySqlConnection(CON_SQL);
        MySqlCommand myCommand = new MySqlCommand();

        public Smartphones_Xiaomi_Archive()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue700, MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.LightBlue700, MaterialSkin.TextShade.WHITE);
            myCommand.Connection = con;
            con.Open();
        }

        private void Smartphones_Xiaomi_Archive_Load(object sender, EventArgs e)
        {
            int i, n;
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM smartphones_xiaomi_archive";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 11; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView1.Rows[n].Cells[11].Value = (DateTime)reader[11];
            }

            reader.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            int i, n;
            string sql = "";
            sql = $"select * from smartphones_xiaomi_archive where receipt_date = '{dateTimePicker1.Value.Date.ToString("yyyy-MM-dd")}'";
            dataGridView1.Rows.Clear();
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 11; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                    dataGridView1.Rows[n].Cells[11].Value = (DateTime)reader[11];
            }
            reader.Close();
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
            wordParag.Range.Text = $"[Архив] Смартфоны Xiaomi";
            wordParag.Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            wordDoc.Paragraphs.Add(Type.Missing);
            wordParag.Range.Font.Name = "Times New Roman";
            wordParag.Range.Font.Size = 12;
            wordParag.Range.Font.Bold = 1;
            wordParag.Range.Text = $"Информация о архиве смартфонов Xiaomi";
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
                    wordTable.Cell(i, j + 1).Range.Text = dataGridView1.Rows[i - 1].Cells[j].Value.ToString();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i, n;
            dataGridView1.Rows.Clear();
            string sql = "SELECT * FROM smartphones_xiaomi_archive";
            myCommand.CommandText = sql;
            MySqlDataReader reader = myCommand.ExecuteReader();

            while (reader.Read())
            {
                n = dataGridView1.NewRowIndex;
                dataGridView1.Rows.Add();
                for (i = 0; i < 11; i++)
                    dataGridView1.Rows[n].Cells[i].Value = reader[i].ToString();
                dataGridView1.Rows[n].Cells[11].Value = (DateTime)reader[11];
            }

            reader.Close();
        }
    }
}