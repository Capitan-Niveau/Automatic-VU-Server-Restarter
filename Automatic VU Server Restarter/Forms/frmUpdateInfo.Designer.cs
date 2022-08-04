namespace VU.Forms
{
    partial class frmUpdateInfo
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
            this.AbortBtn = new System.Windows.Forms.Button();
            this.UpdateNowBtn = new System.Windows.Forms.Button();
            this.UpdateInfoRBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AbortBtn
            // 
            this.AbortBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AbortBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.AbortBtn.Location = new System.Drawing.Point(411, 232);
            this.AbortBtn.Name = "AbortBtn";
            this.AbortBtn.Size = new System.Drawing.Size(75, 23);
            this.AbortBtn.TabIndex = 0;
            this.AbortBtn.Text = "Abort";
            this.AbortBtn.UseVisualStyleBackColor = true;
            this.AbortBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // UpdateNowBtn
            // 
            this.UpdateNowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateNowBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UpdateNowBtn.Location = new System.Drawing.Point(240, 232);
            this.UpdateNowBtn.Name = "UpdateNowBtn";
            this.UpdateNowBtn.Size = new System.Drawing.Size(135, 23);
            this.UpdateNowBtn.TabIndex = 1;
            this.UpdateNowBtn.Text = "Download and install";
            this.UpdateNowBtn.UseVisualStyleBackColor = true;
            this.UpdateNowBtn.Click += new System.EventHandler(this.UpdateNowBtn_Click);
            // 
            // UpdateInfoRBox
            // 
            this.UpdateInfoRBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateInfoRBox.Location = new System.Drawing.Point(12, 12);
            this.UpdateInfoRBox.Name = "UpdateInfoRBox";
            this.UpdateInfoRBox.ReadOnly = true;
            this.UpdateInfoRBox.Size = new System.Drawing.Size(474, 178);
            this.UpdateInfoRBox.TabIndex = 2;
            this.UpdateInfoRBox.Text = "";
            // 
            // frmUpdateInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 267);
            this.Controls.Add(this.UpdateInfoRBox);
            this.Controls.Add(this.UpdateNowBtn);
            this.Controls.Add(this.AbortBtn);
            this.Name = "frmUpdateInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater";
            this.Load += new System.EventHandler(this.frmUpdateInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AbortBtn;
        private System.Windows.Forms.Button UpdateNowBtn;
        private System.Windows.Forms.RichTextBox UpdateInfoRBox;
    }
}