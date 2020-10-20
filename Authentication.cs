using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Reflection;
using Lunar;

namespace JustBanMeGUI
{
    public partial class Authentication : Form
    {
        [DllImport("user32.dll", EntryPoint = "MessageBoxA")]
        internal static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        public Authentication()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return; 
            }
            base.WndProc(ref m);
        }
        private void Authentication_load(object sender, EventArgs e)
        {
            string aRandomString = "A random sting herobine";
            string hash = Functions.sha1_hash(aRandomString);
            Console.WriteLine(hash);
            MessageBox((IntPtr) null, "exampleText", "Examplee Caption", 0x00000000);
            
            var process = 
            /*
            // Run checks if user recently authenticated or if login exipred
            const string url_endpoint = "https://run.mocky.io/v3/03e364dc-7752-4b48-b77e-c5eb57d65c30";
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url_endpoint);
            HttpWebResponse response = (HttpWebResponse)myReq.GetResponse();
            Stream recieveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(recieveStream, Encoding.UTF8);
            Console.WriteLine(readStream.ReadToEnd() + "\n\n");

            dynamic stuff = JsonConvert.DeserializeObject(readStream.ReadToEnd());

            string id = stuff[0]._id;
            Console.WriteLine(id);
             */
        }
    }
}
