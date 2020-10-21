using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JustBanMeGUI
{
    public partial class Authentication : Form
    {
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
            IntPtr lib = nativeFunctions.LoadLibrary("C:\\Users\\BangBuster\\source\\repos\\DLL-Stealth-Injection\\Testing_dll\\x64\\Debug\\Testing_dll.dll");

            int a = Functions.invokeFunction<int>(lib, 1, typeof(Functions.f_print));

        }
    }
}



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