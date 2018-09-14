using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StajyerBilgiSistemi
{
    static class Program
    {
        public static string ConnString = @"server=10.2.7.240;user=guvenlik;pwd=1q2w3e;database=ISBAKG;";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Entry());
        }
    }
}
