using System;
using System.Windows.Forms;

namespace JustBanMeGUI
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            Authentication authForm = new Authentication();
            Application.Run(authForm);
            Application.Run(form1); //<- Run this from Authentication
        }
    }
}
