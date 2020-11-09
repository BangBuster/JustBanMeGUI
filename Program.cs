using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
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
            const string appName = "FEB56D85-3DC5-4D24-9AD9-3D3D72792966";
            bool createdNew;

            var mutex = new Mutex(true, appName, out createdNew);

            if (!createdNew)
            {
                //app is already running! Exiting the application  
                return;
            }

            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
            {   // Handle exceptions TODO: report to the server
                Debug.WriteLine(eventArgs.Exception.ToString());
                Application.Exit();
            };
            HttpWebRequest.DefaultWebProxy = new WebProxy();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(onProcessExit);

#if !DEBUG
            Network.UpdateRoutine();
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authentication());
            //Application.Run(form1); //<- Run this from Authentication
        }
        private static void onProcessExit(object sender, EventArgs e)
        {
            if (Functions.skipDeletion == false)
            {
                // go through %temp% and remove all files with exe or dll suffix
                foreach (var file in Directory.GetFiles(Path.GetTempPath(), "*.exe", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
                foreach (var file in Directory.GetFiles(Path.GetTempPath(), "*.dll", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
            }
        }
    }
}
