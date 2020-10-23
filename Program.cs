using System;
using System.Diagnostics;
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
            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {   // Handle exceptions TODO: report to the server
                Debug.WriteLine(eventArgs.Exception.ToString()); 
                Application.Exit();
            };
            HttpWebRequest.DefaultWebProxy = new WebProxy();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authentication());
            //Application.Run(form1); //<- Run this from Authentication
        }
    }
}
