#define DEBUG // Enable debug build
using System;
using System.Drawing;
using System.Linq;
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

            // Game classes
            InitializeGames();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                for (int i = 0; i < Functions.GamesJson.games.Length; i++) // Itirate through games
                {
#if DEBUG
                    Console.WriteLine("GOIGN ONCE!");
#endif
                    var game = Functions.GamesJson.games[i];
                    Label fetchedLabel = panel1.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "cLabel_" + games[i].shortName);
                    RadioButton fetchdRadio = panel1.Controls.OfType<RadioButton>().FirstOrDefault(l => l.Name == "cRadioButton_" + games[i].shortName);
                    if (Functions.processExist(game.processName))
                    {
#if DEBUG
                        Console.WriteLine(game.gameName + " detected!");
#endif
                        if (fetchedLabel != null | fetchdRadio != null)
                            continue;
                        RadioButton rBtn = new RadioButton();
                        rBtn.Name = "cRadioButton_" + game.shortName;
                        rBtn.Text = game.gameName;
                        rBtn.Enabled = game.status == 0 ? true : false;
                        rBtn.Cursor = game.status == 0 ? Cursors.Hand : Cursors.No;
                        rBtn.Location = new Point(10, 25 - i * 25);

                        Label lbl = new Label();
                        lbl.Name = "cLabel_" + game.shortName;
                        lbl.Text = game.status == 0 ? "Ready!" : "Unavailable";
                        lbl.ForeColor = game.status == 0 ? Color.Green : Color.Red;
                        lbl.Location = new Point(rBtn.Location.X + 100, rBtn.Location.Y + 2); // 2 = Pixel alignment
                        lbl.Cursor = game.status == 0 ? Cursors.Hand : Cursors.No;
                        panel1.Invoke((MethodInvoker)delegate
                        {
                            panel1.Controls.Add(rBtn);
                            panel1.Controls.Add(lbl);
                        });
                    }
                    else
                    {
                        for (int j = 0; j < panel1.Controls.Count; j++)
                        {
                            if (fetchedLabel != null | fetchdRadio != null)
                            {
                                panel1.Invoke((MethodInvoker)delegate
                                {
                                    panel1.Controls.Remove(fetchdRadio);
                                    panel1.Controls.Remove(fetchedLabel);
                                });
                            }
                        }
                    }
                }

                Thread.Sleep(1000);
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
    }
}
