using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Stack_machine
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string allText = System.IO.File.ReadAllText(@"def.txt");
            string[] constrain = { "\r\n" };
            string[] operations = allText.Split(constrain, StringSplitOptions.RemoveEmptyEntries);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
