namespace VU.Forms
{
    partial class frmDownloadUpdate
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
            this.DownloadProgressProgBar = new System.Windows.Forms.ProgressBar();
            this.DownloadProgressLbl = new System.Windows.Forms.Label();
            this.DownloadSpeedLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DownloadProgressProgBar
            // 
            this.DownloadProgressProgBar.Location = new System.Drawing.Point(12, 30);
            this.DownloadProgressProgBar.Name = "DownloadProgressProgBar";
            this.DownloadProgressProgBar.Size = new System.Drawing.Size(425, 23);
            this.DownloadProgressProgBar.TabIndex = 0;
            // 
            // DownloadProgressLbl
            // 
            this.DownloadProgressLbl.AutoSize = true;
            this.DownloadProgressLbl.Location = new System.Drawing.Point(9, 14);
            this.DownloadProgressLbl.Name = "DownloadProgressLbl";
            this.DownloadProgressLbl.Size = new System.Drawing.Size(156, 13);
            this.DownloadProgressLbl.TabIndex = 1;
            this.DownloadProgressLbl.Text = "Downloading update: Waiting...";
            // 
            // DownloadSpeedLbl
            // 
            this.DownloadSpeedLbl.AutoSize = true;
            this.DownloadSpeedLbl.Location = new System.Drawing.Point(12, 56);
            this.DownloadSpeedLbl.Name = "DownloadSpeedLbl";
            this.DownloadSpeedLbl.Size = new System.Drawing.Size(0, 13);
            this.DownloadSpeedLbl.TabIndex = 2;
            // 
            // frmDownloadUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 111);
            this.ControlBox = false;
            this.Controls.Add(this.DownloadSpeedLbl);
            this.Controls.Add(this.DownloadProgressLbl);
            this.Controls.Add(this.DownloadProgressProgBar);
            this.MaximizeBox = false;
            this.Name = "frmDownloadUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download file";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDownloadUpdate_FormClosing);
            this.Load += new System.EventHandler(this.frmDownloadUpdate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar DownloadProgressProgBar;
        private System.Windows.Forms.Label DownloadProgressLbl;
        private System.Windows.Forms.Label DownloadSpeedLbl;
    }
}