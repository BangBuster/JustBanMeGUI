#define DEBUG // Enable debug build
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JustBanMeGUI
{
    public partial class Form1 : Form
    {
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
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
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                // Notepad status handle
#if DEBUG
                if (Functions.processExist("Notepad"))
#else
                if (Functions.processExist("csgo"))
#endif
                {
                    Console.Write("CSGO!");
                    label_csgo.Text = "Found!";
                    label_csgo.ForeColor = Color.Green;
                    radioButton_csgo.Enabled = true;
                }
                else
                {
                    label_csgo.Text = "not Found";
                    label_csgo.ForeColor = Color.Red;
                    radioButton_csgo.Enabled = false;
                }

                // Discord status handle
#if DEBUG
                if (Functions.processExist("Discord"))
#else
                if (Functions.processExist("Among Us"))
#endif
                {
                    label_amongUs.Text = "Found!";
                    label_amongUs.ForeColor = Color.Green;
                    radioButton_amongUs.Enabled = true;
                }
                else
                {
                    label_amongUs.Text = "not Found";
                    label_amongUs.ForeColor = Color.Red;
                    radioButton_amongUs.Enabled = false;
                }

                Thread.Sleep(2000);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Injected!", "Injected! (injected cheat)", MessageBoxButtons.OK);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label_csgo_Click(object sender, EventArgs e)
        {

        }
    }
}
