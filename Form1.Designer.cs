namespace JustBanMeGUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label_csgo = new System.Windows.Forms.Label();
            this.label_amongUs = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton_csgo = new System.Windows.Forms.RadioButton();
            this.radioButton_amongUs = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(118, 434);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome User!";
            // 
            // label_csgo
            // 
            this.label_csgo.AutoSize = true;
            this.label_csgo.ForeColor = System.Drawing.Color.White;
            this.label_csgo.Location = new System.Drawing.Point(189, 230);
            this.label_csgo.Name = "label_csgo";
            this.label_csgo.Size = new System.Drawing.Size(63, 20);
            this.label_csgo.TabIndex = 2;
            this.label_csgo.Text = "Notepad";
            this.label_csgo.Click += new System.EventHandler(this.label_csgo_Click);
            // 
            // label_amongUs
            // 
            this.label_amongUs.AutoSize = true;
            this.label_amongUs.ForeColor = System.Drawing.Color.White;
            this.label_amongUs.Location = new System.Drawing.Point(189, 264);
            this.label_amongUs.Name = "label_amongUs";
            this.label_amongUs.Size = new System.Drawing.Size(58, 20);
            this.label_amongUs.TabIndex = 3;
            this.label_amongUs.Text = "Discord";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DimGray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(116, 50);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start cheat";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton_csgo
            // 
            this.radioButton_csgo.AutoSize = true;
            this.radioButton_csgo.Location = new System.Drawing.Point(89, 228);
            this.radioButton_csgo.Name = "radioButton_csgo";
            this.radioButton_csgo.Size = new System.Drawing.Size(69, 24);
            this.radioButton_csgo.TabIndex = 8;
            this.radioButton_csgo.TabStop = true;
            this.radioButton_csgo.Text = "CS:GO";
            this.radioButton_csgo.UseVisualStyleBackColor = true;
            // 
            // radioButton_amongUs
            // 
            this.radioButton_amongUs.AutoSize = true;
            this.radioButton_amongUs.Location = new System.Drawing.Point(89, 262);
            this.radioButton_amongUs.Name = "radioButton_amongUs";
            this.radioButton_amongUs.Size = new System.Drawing.Size(92, 24);
            this.radioButton_amongUs.TabIndex = 9;
            this.radioButton_amongUs.TabStop = true;
            this.radioButton_amongUs.Text = "Among Us";
            this.radioButton_amongUs.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(344, 463);
            this.Controls.Add(this.radioButton_amongUs);
            this.Controls.Add(this.radioButton_csgo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_amongUs);
            this.Controls.Add(this.label_csgo);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_csgo;
        private System.Windows.Forms.Label label_amongUs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton_csgo;
        private System.Windows.Forms.RadioButton radioButton_amongUs;
    }
}

