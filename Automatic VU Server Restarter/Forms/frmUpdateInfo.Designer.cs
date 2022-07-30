namespace VU
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
            this.CloseBtn = new System.Windows.Forms.Button();
            this.UpdateNowBtn = new System.Windows.Forms.Button();
            this.UpdateInfoRBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseBtn.Location = new System.Drawing.Point(476, 455);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(75, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateNowBtn
            // 
            this.UpdateNowBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateNowBtn.Location = new System.Drawing.Point(365, 455);
            this.UpdateNowBtn.Name = "UpdateNowBtn";
            this.UpdateNowBtn.Size = new System.Drawing.Size(75, 23);
            this.UpdateNowBtn.TabIndex = 1;
            this.UpdateNowBtn.Text = "Update";
            this.UpdateNowBtn.UseVisualStyleBackColor = true;
            // 
            // UpdateInfoRBox
            // 
            this.UpdateInfoRBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpdateInfoRBox.Location = new System.Drawing.Point(12, 12);
            this.UpdateInfoRBox.Name = "UpdateInfoRBox";
            this.UpdateInfoRBox.Size = new System.Drawing.Size(539, 421);
            this.UpdateInfoRBox.TabIndex = 2;
            this.UpdateInfoRBox.Text = "";
            // 
            // frmUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 490);
            this.Controls.Add(this.UpdateInfoRBox);
            this.Controls.Add(this.UpdateNowBtn);
            this.Controls.Add(this.CloseBtn);
            this.Name = "frmUpdater";
            this.Text = "Updater";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.Button UpdateNowBtn;
        private System.Windows.Forms.RichTextBox UpdateInfoRBox;
    }
}