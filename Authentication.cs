using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace JustBanMeGUI
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            backgroundWorker_auth.DoWork += backgroundWork;
        }
        public const string registryPath = "HKEY_CURRENT_USER\\Software\\Sym";
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
            backgroundWorker_auth.RunWorkerAsync();
            auth_input.TextChanged += textUpdater;
            checkBox1.Checked = true;

            var storedHash = Registry.GetValue(registryPath, "val", "none");
            if (storedHash != null)
            {
                auth_input.Text = Crypto.XOR_EncryptDecrypt(storedHash.ToString(), Crypto.hardcoded_xor_key);
            }
        }
        private bool rememberCheck = true;
        private void textUpdater(object sender, EventArgs e)
        {
            if (auth_input.Text.Length == 16)
            {
                login_btn.Enabled = true;
            }
            else
            {
                login_btn.Enabled = false;
            }
        }
        private void backgroundWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {

                Thread.Sleep(Constants.THREADSLEEP);
            }
        }
        
        public object JsonSerializer { get; private set; }
        public object Newtonsoft { get; private set; }

        private void validateAuthentication(string jsonString)
        {
            if (jsonString == "0") // If response is invalid
            {
                MessageBox.Show("Invalid passcode provided!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Registry.CurrentUser.DeleteSubKey("Software\\Sym");
                this.Close();
            }
            if (checkBox1.Checked == true) // If "remember" is checked
            {
                Registry.SetValue(registryPath, "val", Crypto.XOR_EncryptDecrypt(auth_input.Text, Crypto.hardcoded_xor_key));
            }
            else
            {
                Registry.CurrentUser.DeleteSubKey("Software\\Sym");
            }

            Functions.GamesJson = JsonConvert.DeserializeObject<Functions.SuccessJson>(jsonString);
            Form1 mainForm = new Form1();
            mainForm.Show(this);
            this.Hide();
        }
        private async void login_btn_ClickAsync(object sender, EventArgs e)
        {
            string responseString = await Network.Authenticate(auth_input.Text);
#if DEBUG
            Console.WriteLine(responseString);
#endif
            validateAuthentication(responseString);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            rememberCheck = !rememberCheck;
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