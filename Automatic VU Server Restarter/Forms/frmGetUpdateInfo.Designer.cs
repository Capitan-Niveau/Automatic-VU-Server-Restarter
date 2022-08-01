namespace VU.Forms
{
    partial class frmGetUpdateInfo
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
            this.components = new System.ComponentModel.Container();
            this.AbortBtn = new System.Windows.Forms.Button();
            this.InfoProgress = new System.Windows.Forms.ProgressBar();
            this.InfoLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // AbortBtn
            // 
            this.AbortBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AbortBtn.Location = new System.Drawing.Point(360, 80);
            this.AbortBtn.Name = "AbortBtn";
            this.AbortBtn.Size = new System.Drawing.Size(75, 23);
            this.AbortBtn.TabIndex = 0;
            this.AbortBtn.Text = "Abort";
            this.AbortBtn.UseVisualStyleBackColor = true;
            this.AbortBtn.Click += new System.EventHandler(this.AbortBtn_Click);
            // 
            // InfoProgress
            // 
            this.InfoProgress.Location = new System.Drawing.Point(12, 36);
            this.InfoProgress.Name = "InfoProgress";
            this.InfoProgress.Size = new System.Drawing.Size(423, 23);
            this.InfoProgress.Step = 1;
            this.InfoProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.InfoProgress.TabIndex = 1;
            this.InfoProgress.Value = 50;
            // 
            // InfoLbl
            // 
            this.InfoLbl.AutoSize = true;
            this.InfoLbl.Location = new System.Drawing.Point(9, 20);
            this.InfoLbl.Name = "InfoLbl";
            this.InfoLbl.Size = new System.Drawing.Size(203, 13);
            this.InfoLbl.TabIndex = 2;
            this.InfoLbl.Text = "Fetching update information please wait...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmGetUpdateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 115);
            this.Controls.Add(this.InfoLbl);
            this.Controls.Add(this.InfoProgress);
            this.Controls.Add(this.AbortBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGetUpdateInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get update information";
            this.Load += new System.EventHandler(this.frmGetUpdateInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AbortBtn;
        private System.Windows.Forms.ProgressBar InfoProgress;
        private System.Windows.Forms.Label InfoLbl;
        private System.Windows.Forms.Timer timer1;
    }
}