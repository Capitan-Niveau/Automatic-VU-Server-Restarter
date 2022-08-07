namespace VU.Forms
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.CloseBtn = new System.Windows.Forms.Button();
            this.LogoPBox = new System.Windows.Forms.PictureBox();
            this.Background = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.AVUSRTPage = new System.Windows.Forms.TabPage();
            this.InfoOLbl = new System.Windows.Forms.Label();
            this.BuildDateLbl = new System.Windows.Forms.Label();
            this.ContributorTPage = new System.Windows.Forms.TabPage();
            this.ImposterLlbl = new System.Windows.Forms.LinkLabel();
            this.IniLbl = new System.Windows.Forms.Label();
            this.RCONLbl = new System.Windows.Forms.Label();
            this.CopyrightLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPBox)).BeginInit();
            this.Background.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.AVUSRTPage.SuspendLayout();
            this.ContributorTPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseBtn.Location = new System.Drawing.Point(411, 232);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // LogoPBox
            // 
            this.LogoPBox.BackColor = System.Drawing.Color.White;
            this.LogoPBox.Location = new System.Drawing.Point(12, 12);
            this.LogoPBox.Name = "LogoPBox";
            this.LogoPBox.Size = new System.Drawing.Size(64, 64);
            this.LogoPBox.TabIndex = 1;
            this.LogoPBox.TabStop = false;
            // 
            // Background
            // 
            this.Background.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Background.BackColor = System.Drawing.Color.White;
            this.Background.Controls.Add(this.tabControl1);
            this.Background.Location = new System.Drawing.Point(-1, -1);
            this.Background.Name = "Background";
            this.Background.Size = new System.Drawing.Size(500, 220);
            this.Background.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.AVUSRTPage);
            this.tabControl1.Controls.Add(this.ContributorTPage);
            this.tabControl1.Location = new System.Drawing.Point(108, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 189);
            this.tabControl1.TabIndex = 0;
            // 
            // AVUSRTPage
            // 
            this.AVUSRTPage.Controls.Add(this.InfoOLbl);
            this.AVUSRTPage.Controls.Add(this.BuildDateLbl);
            this.AVUSRTPage.Location = new System.Drawing.Point(4, 22);
            this.AVUSRTPage.Name = "AVUSRTPage";
            this.AVUSRTPage.Padding = new System.Windows.Forms.Padding(3);
            this.AVUSRTPage.Size = new System.Drawing.Size(357, 163);
            this.AVUSRTPage.TabIndex = 0;
            this.AVUSRTPage.Text = "AVUSR";
            this.AVUSRTPage.UseVisualStyleBackColor = true;
            // 
            // InfoOLbl
            // 
            this.InfoOLbl.AutoSize = true;
            this.InfoOLbl.Location = new System.Drawing.Point(7, 7);
            this.InfoOLbl.Name = "InfoOLbl";
            this.InfoOLbl.Size = new System.Drawing.Size(352, 78);
            this.InfoOLbl.TabIndex = 1;
            this.InfoOLbl.Text = resources.GetString("InfoOLbl.Text");
            // 
            // BuildDateLbl
            // 
            this.BuildDateLbl.AutoSize = true;
            this.BuildDateLbl.Location = new System.Drawing.Point(3, 146);
            this.BuildDateLbl.Name = "BuildDateLbl";
            this.BuildDateLbl.Size = new System.Drawing.Size(0, 13);
            this.BuildDateLbl.TabIndex = 0;
            // 
            // ContributorTPage
            // 
            this.ContributorTPage.Controls.Add(this.ImposterLlbl);
            this.ContributorTPage.Controls.Add(this.IniLbl);
            this.ContributorTPage.Controls.Add(this.RCONLbl);
            this.ContributorTPage.Location = new System.Drawing.Point(4, 22);
            this.ContributorTPage.Name = "ContributorTPage";
            this.ContributorTPage.Padding = new System.Windows.Forms.Padding(3);
            this.ContributorTPage.Size = new System.Drawing.Size(357, 163);
            this.ContributorTPage.TabIndex = 1;
            this.ContributorTPage.Text = "Contributor/Third party tools";
            this.ContributorTPage.UseVisualStyleBackColor = true;
            // 
            // ImposterLlbl
            // 
            this.ImposterLlbl.AutoSize = true;
            this.ImposterLlbl.Location = new System.Drawing.Point(3, 147);
            this.ImposterLlbl.Name = "ImposterLlbl";
            this.ImposterLlbl.Size = new System.Drawing.Size(95, 13);
            this.ImposterLlbl.TabIndex = 2;
            this.ImposterLlbl.TabStop = true;
            this.ImposterLlbl.Text = "RCON by Imposter";
            this.ImposterLlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ImposterLlbl_LinkClicked);
            // 
            // IniLbl
            // 
            this.IniLbl.AutoSize = true;
            this.IniLbl.Location = new System.Drawing.Point(7, 29);
            this.IniLbl.Name = "IniLbl";
            this.IniLbl.Size = new System.Drawing.Size(296, 13);
            this.IniLbl.TabIndex = 1;
            this.IniLbl.Text = "INI parser: This program uses an INI parser developed by me.";
            // 
            // RCONLbl
            // 
            this.RCONLbl.AutoSize = true;
            this.RCONLbl.Location = new System.Drawing.Point(7, 7);
            this.RCONLbl.Name = "RCONLbl";
            this.RCONLbl.Size = new System.Drawing.Size(338, 13);
            this.RCONLbl.TabIndex = 0;
            this.RCONLbl.Text = "RCON: This program uses a basic RCon client developed by Imposter.";
            // 
            // CopyrightLbl
            // 
            this.CopyrightLbl.AutoSize = true;
            this.CopyrightLbl.Location = new System.Drawing.Point(12, 237);
            this.CopyrightLbl.Name = "CopyrightLbl";
            this.CopyrightLbl.Size = new System.Drawing.Size(0, 13);
            this.CopyrightLbl.TabIndex = 3;
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 267);
            this.Controls.Add(this.CopyrightLbl);
            this.Controls.Add(this.LogoPBox);
            this.Controls.Add(this.Background);
            this.Controls.Add(this.CloseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAbout";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAbout_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.LogoPBox)).EndInit();
            this.Background.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.AVUSRTPage.ResumeLayout(false);
            this.AVUSRTPage.PerformLayout();
            this.ContributorTPage.ResumeLayout(false);
            this.ContributorTPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.PictureBox LogoPBox;
        private System.Windows.Forms.Panel Background;
        private System.Windows.Forms.Label CopyrightLbl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage AVUSRTPage;
        private System.Windows.Forms.TabPage ContributorTPage;
        private System.Windows.Forms.Label BuildDateLbl;
        private System.Windows.Forms.Label InfoOLbl;
        private System.Windows.Forms.LinkLabel ImposterLlbl;
        private System.Windows.Forms.Label IniLbl;
        private System.Windows.Forms.Label RCONLbl;
    }
}