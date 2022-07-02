using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 first = new Form1();
            DateTime end = DateTime.Now + TimeSpan.FromSeconds(1);
            first.Show();
            while (end > DateTime.Now)
            {
                Application.DoEvents();
            }
            first.Close();
            first.Dispose();
            Application.Run(new Form2());
        }
    }

    static class transfer
    {
        public static int id { get; set; }
        public static string par1 { get; set; }
        public static string par2 { get; set; }
        public static string par3 { get; set; }
        public static string par4 { get; set; }
        public static string par5 { get; set; }
        public static string par6 { get; set; }
        public static string par7 { get; set; }
        public static string par8 { get; set; }
        public static string par9 { get; set; }
        public static string par10 { get; set; }
        public static string par11 { get; set; }
        public static DateTime par12 { get; set; }
    }
}