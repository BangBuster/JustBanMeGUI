using System;
using System.Net;
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
            HttpWebRequest.DefaultWebProxy = new WebProxy();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authentication());
            //Application.Run(form1); //<- Run this from Authentication
        }
    }
}
