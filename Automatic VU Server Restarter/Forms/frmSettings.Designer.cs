namespace VU.Forms
{
    partial class FrmSettings
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
            this.ServerSettingsTControl = new System.Windows.Forms.TabControl();
            this.VuGamePathTab = new System.Windows.Forms.TabPage();
            this.UseMiniProConCBox = new System.Windows.Forms.CheckBox();
            this.ProConPathTBox = new System.Windows.Forms.TextBox();
            this.ProconPathLbl = new System.Windows.Forms.Label();
            this.UseCustomGamePathCBox = new System.Windows.Forms.CheckBox();
            this.BattlefieldInstallDirTBox = new System.Windows.Forms.TextBox();
            this.Bf3GamePathLbl = new System.Windows.Forms.Label();
            this.VuInstancePathTBox = new System.Windows.Forms.TextBox();
            this.VuPathTBox = new System.Windows.Forms.TextBox();
            this.VuServerInstancePathLbl = new System.Windows.Forms.Label();
            this.VuPathLbl = new System.Windows.Forms.Label();
            this.VuServerArgsTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MiscGBox = new System.Windows.Forms.GroupBox();
            this.SaveLoggingOutputCBox = new System.Windows.Forms.CheckBox();
            this.WritePerfProfileCBox = new System.Windows.Forms.CheckBox();
            this.DisableAutomaticUpdatesCBox = new System.Windows.Forms.CheckBox();
            this.UnlistedCBox = new System.Windows.Forms.CheckBox();
            this.SkipChecksumCBox = new System.Windows.Forms.CheckBox();
            this.ServerFreqGBox = new System.Windows.Forms.GroupBox();
            this.ServerFrequency30HzRBtn = new System.Windows.Forms.RadioButton();
            this.ServerFrequency120HzRBtn = new System.Windows.Forms.RadioButton();
            this.ServerFrequency60HzRBtn = new System.Windows.Forms.RadioButton();
            this.TerrainOptionsGBox = new System.Windows.Forms.GroupBox();
            this.HighResTerrainCBox = new System.Windows.Forms.CheckBox();
            this.DisableTerrainInterpCBox = new System.Windows.Forms.CheckBox();
            this.AvusrSettingsTab = new System.Windows.Forms.TabPage();
            this.ModsGBox = new System.Windows.Forms.GroupBox();
            this.ServerSettingsTControl.SuspendLayout();
            this.VuGamePathTab.SuspendLayout();
            this.VuServerArgsTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MiscGBox.SuspendLayout();
            this.ServerFreqGBox.SuspendLayout();
            this.TerrainOptionsGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseBtn
            // 
            this.CloseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CloseBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CloseBtn.Location = new System.Drawing.Point(329, 451);
            this.CloseBtn.Name = "CloseBtn";
            this.CloseBtn.Size = new System.Drawing.Size(103, 23);
            this.CloseBtn.TabIndex = 0;
            this.CloseBtn.Text = "Close";
            this.CloseBtn.UseVisualStyleBackColor = true;
            this.CloseBtn.Click += new System.EventHandler(this.CloseBtn_Click);
            // 
            // ServerSettingsTControl
            // 
            this.ServerSettingsTControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerSettingsTControl.Controls.Add(this.VuGamePathTab);
            this.ServerSettingsTControl.Controls.Add(this.VuServerArgsTab);
            this.ServerSettingsTControl.Controls.Add(this.AvusrSettingsTab);
            this.ServerSettingsTControl.Location = new System.Drawing.Point(12, 12);
            this.ServerSettingsTControl.Name = "ServerSettingsTControl";
            this.ServerSettingsTControl.SelectedIndex = 0;
            this.ServerSettingsTControl.Size = new System.Drawing.Size(420, 433);
            this.ServerSettingsTControl.TabIndex = 2;
            // 
            // VuGamePathTab
            // 
            this.VuGamePathTab.AccessibleDescription = "+";
            this.VuGamePathTab.Controls.Add(this.UseMiniProConCBox);
            this.VuGamePathTab.Controls.Add(this.ProConPathTBox);
            this.VuGamePathTab.Controls.Add(this.ProconPathLbl);
            this.VuGamePathTab.Controls.Add(this.UseCustomGamePathCBox);
            this.VuGamePathTab.Controls.Add(this.BattlefieldInstallDirTBox);
            this.VuGamePathTab.Controls.Add(this.Bf3GamePathLbl);
            this.VuGamePathTab.Controls.Add(this.VuInstancePathTBox);
            this.VuGamePathTab.Controls.Add(this.VuPathTBox);
            this.VuGamePathTab.Controls.Add(this.VuServerInstancePathLbl);
            this.VuGamePathTab.Controls.Add(this.VuPathLbl);
            this.VuGamePathTab.Location = new System.Drawing.Point(4, 22);
            this.VuGamePathTab.Name = "VuGamePathTab";
            this.VuGamePathTab.Padding = new System.Windows.Forms.Padding(3);
            this.VuGamePathTab.Size = new System.Drawing.Size(412, 406);
            this.VuGamePathTab.TabIndex = 0;
            this.VuGamePathTab.Text = "VU/Game path";
            this.VuGamePathTab.UseVisualStyleBackColor = true;
            // 
            // UseMiniProConCBox
            // 
            this.UseMiniProConCBox.AutoSize = true;
            this.UseMiniProConCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseMiniProConCBox.Location = new System.Drawing.Point(19, 290);
            this.UseMiniProConCBox.Name = "UseMiniProConCBox";
            this.UseMiniProConCBox.Size = new System.Drawing.Size(228, 18);
            this.UseMiniProConCBox.TabIndex = 9;
            this.UseMiniProConCBox.Text = "Use cut down version (no output is given)";
            this.UseMiniProConCBox.UseVisualStyleBackColor = true;
            this.UseMiniProConCBox.CheckedChanged += new System.EventHandler(this.UseMiniProConCBox_CheckedChanged);
            // 
            // ProConPathTBox
            // 
            this.ProConPathTBox.Location = new System.Drawing.Point(19, 264);
            this.ProConPathTBox.Name = "ProConPathTBox";
            this.ProConPathTBox.ReadOnly = true;
            this.ProConPathTBox.Size = new System.Drawing.Size(370, 20);
            this.ProConPathTBox.TabIndex = 8;
            // 
            // ProconPathLbl
            // 
            this.ProconPathLbl.AutoSize = true;
            this.ProconPathLbl.Location = new System.Drawing.Point(16, 248);
            this.ProconPathLbl.Name = "ProconPathLbl";
            this.ProconPathLbl.Size = new System.Drawing.Size(161, 13);
            this.ProconPathLbl.TabIndex = 7;
            this.ProconPathLbl.Text = "Path to ProCon (not necessarily):";
            // 
            // UseCustomGamePathCBox
            // 
            this.UseCustomGamePathCBox.AutoSize = true;
            this.UseCustomGamePathCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UseCustomGamePathCBox.Location = new System.Drawing.Point(19, 194);
            this.UseCustomGamePathCBox.Name = "UseCustomGamePathCBox";
            this.UseCustomGamePathCBox.Size = new System.Drawing.Size(152, 18);
            this.UseCustomGamePathCBox.TabIndex = 6;
            this.UseCustomGamePathCBox.Text = "Select custom game path";
            this.UseCustomGamePathCBox.UseVisualStyleBackColor = true;
            this.UseCustomGamePathCBox.CheckedChanged += new System.EventHandler(this.UseCustomGamePathCBox_CheckedChanged);
            // 
            // BattlefieldInstallDirTBox
            // 
            this.BattlefieldInstallDirTBox.Location = new System.Drawing.Point(19, 168);
            this.BattlefieldInstallDirTBox.Name = "BattlefieldInstallDirTBox";
            this.BattlefieldInstallDirTBox.ReadOnly = true;
            this.BattlefieldInstallDirTBox.Size = new System.Drawing.Size(370, 20);
            this.BattlefieldInstallDirTBox.TabIndex = 5;
            // 
            // Bf3GamePathLbl
            // 
            this.Bf3GamePathLbl.AutoSize = true;
            this.Bf3GamePathLbl.Location = new System.Drawing.Point(16, 152);
            this.Bf3GamePathLbl.Name = "Bf3GamePathLbl";
            this.Bf3GamePathLbl.Size = new System.Drawing.Size(118, 13);
            this.Bf3GamePathLbl.TabIndex = 4;
            this.Bf3GamePathLbl.Text = "Battlefield 3 game path:";
            // 
            // VuInstancePathTBox
            // 
            this.VuInstancePathTBox.Location = new System.Drawing.Point(19, 107);
            this.VuInstancePathTBox.Name = "VuInstancePathTBox";
            this.VuInstancePathTBox.ReadOnly = true;
            this.VuInstancePathTBox.Size = new System.Drawing.Size(370, 20);
            this.VuInstancePathTBox.TabIndex = 3;
            this.VuInstancePathTBox.TextChanged += new System.EventHandler(this.VuInstancePathTBox_TextChanged);
            // 
            // VuPathTBox
            // 
            this.VuPathTBox.Location = new System.Drawing.Point(19, 48);
            this.VuPathTBox.Name = "VuPathTBox";
            this.VuPathTBox.ReadOnly = true;
            this.VuPathTBox.Size = new System.Drawing.Size(370, 20);
            this.VuPathTBox.TabIndex = 2;
            // 
            // VuServerInstancePathLbl
            // 
            this.VuServerInstancePathLbl.AutoSize = true;
            this.VuServerInstancePathLbl.Location = new System.Drawing.Point(16, 91);
            this.VuServerInstancePathLbl.Name = "VuServerInstancePathLbl";
            this.VuServerInstancePathLbl.Size = new System.Drawing.Size(119, 13);
            this.VuServerInstancePathLbl.TabIndex = 1;
            this.VuServerInstancePathLbl.Text = "Path to server instance:";
            // 
            // VuPathLbl
            // 
            this.VuPathLbl.AutoSize = true;
            this.VuPathLbl.Location = new System.Drawing.Point(16, 32);
            this.VuPathLbl.Name = "VuPathLbl";
            this.VuPathLbl.Size = new System.Drawing.Size(131, 13);
            this.VuPathLbl.TabIndex = 0;
            this.VuPathLbl.Text = "Path to VeniceUnleashed:";
            // 
            // VuServerArgsTab
            // 
            this.VuServerArgsTab.Controls.Add(this.panel1);
            this.VuServerArgsTab.Location = new System.Drawing.Point(4, 22);
            this.VuServerArgsTab.Name = "VuServerArgsTab";
            this.VuServerArgsTab.Padding = new System.Windows.Forms.Padding(3);
            this.VuServerArgsTab.Size = new System.Drawing.Size(412, 407);
            this.VuServerArgsTab.TabIndex = 1;
            this.VuServerArgsTab.Text = "Server Settings";
            this.VuServerArgsTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.ModsGBox);
            this.panel1.Controls.Add(this.MiscGBox);
            this.panel1.Controls.Add(this.ServerFreqGBox);
            this.panel1.Controls.Add(this.TerrainOptionsGBox);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 407);
            this.panel1.TabIndex = 4;
            // 
            // MiscGBox
            // 
            this.MiscGBox.Controls.Add(this.SaveLoggingOutputCBox);
            this.MiscGBox.Controls.Add(this.WritePerfProfileCBox);
            this.MiscGBox.Controls.Add(this.DisableAutomaticUpdatesCBox);
            this.MiscGBox.Controls.Add(this.UnlistedCBox);
            this.MiscGBox.Controls.Add(this.SkipChecksumCBox);
            this.MiscGBox.Location = new System.Drawing.Point(9, 238);
            this.MiscGBox.Name = "MiscGBox";
            this.MiscGBox.Size = new System.Drawing.Size(375, 156);
            this.MiscGBox.TabIndex = 8;
            this.MiscGBox.TabStop = false;
            this.MiscGBox.Text = "Misc";
            // 
            // SaveLoggingOutputCBox
            // 
            this.SaveLoggingOutputCBox.AutoSize = true;
            this.SaveLoggingOutputCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SaveLoggingOutputCBox.Location = new System.Drawing.Point(16, 123);
            this.SaveLoggingOutputCBox.Name = "SaveLoggingOutputCBox";
            this.SaveLoggingOutputCBox.Size = new System.Drawing.Size(164, 18);
            this.SaveLoggingOutputCBox.TabIndex = 8;
            this.SaveLoggingOutputCBox.Text = "Save logging output to a file";
            this.SaveLoggingOutputCBox.UseVisualStyleBackColor = true;
            this.SaveLoggingOutputCBox.CheckedChanged += new System.EventHandler(this.SaveLoggingOutputCBox_CheckedChanged);
            // 
            // WritePerfProfileCBox
            // 
            this.WritePerfProfileCBox.AutoSize = true;
            this.WritePerfProfileCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.WritePerfProfileCBox.Location = new System.Drawing.Point(16, 99);
            this.WritePerfProfileCBox.Name = "WritePerfProfileCBox";
            this.WritePerfProfileCBox.Size = new System.Drawing.Size(150, 18);
            this.WritePerfProfileCBox.TabIndex = 7;
            this.WritePerfProfileCBox.Text = "Write performance profile";
            this.WritePerfProfileCBox.UseVisualStyleBackColor = true;
            this.WritePerfProfileCBox.CheckedChanged += new System.EventHandler(this.WritePerfProfileCBox_CheckedChanged);
            // 
            // DisableAutomaticUpdatesCBox
            // 
            this.DisableAutomaticUpdatesCBox.AutoSize = true;
            this.DisableAutomaticUpdatesCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DisableAutomaticUpdatesCBox.Location = new System.Drawing.Point(16, 75);
            this.DisableAutomaticUpdatesCBox.Name = "DisableAutomaticUpdatesCBox";
            this.DisableAutomaticUpdatesCBox.Size = new System.Drawing.Size(157, 18);
            this.DisableAutomaticUpdatesCBox.TabIndex = 6;
            this.DisableAutomaticUpdatesCBox.Text = "Disable automatic updates";
            this.DisableAutomaticUpdatesCBox.UseVisualStyleBackColor = true;
            this.DisableAutomaticUpdatesCBox.CheckedChanged += new System.EventHandler(this.DisableAutomaticUpdatesCBox_CheckedChanged);
            // 
            // UnlistedCBox
            // 
            this.UnlistedCBox.AutoSize = true;
            this.UnlistedCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.UnlistedCBox.Location = new System.Drawing.Point(16, 51);
            this.UnlistedCBox.Name = "UnlistedCBox";
            this.UnlistedCBox.Size = new System.Drawing.Size(130, 18);
            this.UnlistedCBox.TabIndex = 5;
            this.UnlistedCBox.Text = "Make server unlisted";
            this.UnlistedCBox.UseVisualStyleBackColor = true;
            this.UnlistedCBox.CheckedChanged += new System.EventHandler(this.UnlistedCBox_CheckedChanged);
            // 
            // SkipChecksumCBox
            // 
            this.SkipChecksumCBox.AutoSize = true;
            this.SkipChecksumCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SkipChecksumCBox.Location = new System.Drawing.Point(16, 27);
            this.SkipChecksumCBox.Name = "SkipChecksumCBox";
            this.SkipChecksumCBox.Size = new System.Drawing.Size(156, 18);
            this.SkipChecksumCBox.TabIndex = 4;
            this.SkipChecksumCBox.Text = "Skip checksum validation ";
            this.SkipChecksumCBox.UseVisualStyleBackColor = true;
            this.SkipChecksumCBox.CheckedChanged += new System.EventHandler(this.SkipChecksumCBox_CheckedChanged);
            // 
            // ServerFreqGBox
            // 
            this.ServerFreqGBox.Controls.Add(this.ServerFrequency30HzRBtn);
            this.ServerFreqGBox.Controls.Add(this.ServerFrequency120HzRBtn);
            this.ServerFreqGBox.Controls.Add(this.ServerFrequency60HzRBtn);
            this.ServerFreqGBox.Location = new System.Drawing.Point(9, 11);
            this.ServerFreqGBox.Name = "ServerFreqGBox";
            this.ServerFreqGBox.Size = new System.Drawing.Size(375, 106);
            this.ServerFreqGBox.TabIndex = 6;
            this.ServerFreqGBox.TabStop = false;
            this.ServerFreqGBox.Text = "Server frequency";
            // 
            // ServerFrequency30HzRBtn
            // 
            this.ServerFrequency30HzRBtn.AutoSize = true;
            this.ServerFrequency30HzRBtn.Location = new System.Drawing.Point(16, 25);
            this.ServerFrequency30HzRBtn.Name = "ServerFrequency30HzRBtn";
            this.ServerFrequency30HzRBtn.Size = new System.Drawing.Size(154, 17);
            this.ServerFrequency30HzRBtn.TabIndex = 5;
            this.ServerFrequency30HzRBtn.TabStop = true;
            this.ServerFrequency30HzRBtn.Text = "30Hz Server mode (default)";
            this.ServerFrequency30HzRBtn.UseVisualStyleBackColor = true;
            this.ServerFrequency30HzRBtn.CheckedChanged += new System.EventHandler(this.ServerFrequency30HzRBtn_CheckedChanged);
            // 
            // ServerFrequency120HzRBtn
            // 
            this.ServerFrequency120HzRBtn.AutoSize = true;
            this.ServerFrequency120HzRBtn.Location = new System.Drawing.Point(16, 71);
            this.ServerFrequency120HzRBtn.Name = "ServerFrequency120HzRBtn";
            this.ServerFrequency120HzRBtn.Size = new System.Drawing.Size(119, 17);
            this.ServerFrequency120HzRBtn.TabIndex = 4;
            this.ServerFrequency120HzRBtn.TabStop = true;
            this.ServerFrequency120HzRBtn.Text = "120Hz Server mode";
            this.ServerFrequency120HzRBtn.UseVisualStyleBackColor = true;
            this.ServerFrequency120HzRBtn.CheckedChanged += new System.EventHandler(this.ServerFrequency120HzRBtn_CheckedChanged);
            // 
            // ServerFrequency60HzRBtn
            // 
            this.ServerFrequency60HzRBtn.AutoSize = true;
            this.ServerFrequency60HzRBtn.Location = new System.Drawing.Point(16, 48);
            this.ServerFrequency60HzRBtn.Name = "ServerFrequency60HzRBtn";
            this.ServerFrequency60HzRBtn.Size = new System.Drawing.Size(113, 17);
            this.ServerFrequency60HzRBtn.TabIndex = 3;
            this.ServerFrequency60HzRBtn.TabStop = true;
            this.ServerFrequency60HzRBtn.Text = "60Hz Server mode";
            this.ServerFrequency60HzRBtn.UseVisualStyleBackColor = true;
            this.ServerFrequency60HzRBtn.CheckedChanged += new System.EventHandler(this.ServerFrequency60HzRBtn_CheckedChanged);
            // 
            // TerrainOptionsGBox
            // 
            this.TerrainOptionsGBox.Controls.Add(this.HighResTerrainCBox);
            this.TerrainOptionsGBox.Controls.Add(this.DisableTerrainInterpCBox);
            this.TerrainOptionsGBox.Location = new System.Drawing.Point(9, 135);
            this.TerrainOptionsGBox.Name = "TerrainOptionsGBox";
            this.TerrainOptionsGBox.Size = new System.Drawing.Size(375, 83);
            this.TerrainOptionsGBox.TabIndex = 7;
            this.TerrainOptionsGBox.TabStop = false;
            this.TerrainOptionsGBox.Text = "Terrain options";
            // 
            // HighResTerrainCBox
            // 
            this.HighResTerrainCBox.AutoSize = true;
            this.HighResTerrainCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.HighResTerrainCBox.Location = new System.Drawing.Point(16, 49);
            this.HighResTerrainCBox.Name = "HighResTerrainCBox";
            this.HighResTerrainCBox.Size = new System.Drawing.Size(134, 18);
            this.HighResTerrainCBox.TabIndex = 3;
            this.HighResTerrainCBox.Text = "High resolution terrain";
            this.HighResTerrainCBox.UseVisualStyleBackColor = true;
            this.HighResTerrainCBox.CheckedChanged += new System.EventHandler(this.HighResTerrainCBox_CheckedChanged);
            // 
            // DisableTerrainInterpCBox
            // 
            this.DisableTerrainInterpCBox.AutoSize = true;
            this.DisableTerrainInterpCBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.DisableTerrainInterpCBox.Location = new System.Drawing.Point(16, 26);
            this.DisableTerrainInterpCBox.Name = "DisableTerrainInterpCBox";
            this.DisableTerrainInterpCBox.Size = new System.Drawing.Size(159, 18);
            this.DisableTerrainInterpCBox.TabIndex = 2;
            this.DisableTerrainInterpCBox.Text = "Disable terrain interpolation";
            this.DisableTerrainInterpCBox.UseVisualStyleBackColor = true;
            this.DisableTerrainInterpCBox.CheckedChanged += new System.EventHandler(this.DisableTerrainInterpCBox_CheckedChanged);
            // 
            // AvusrSettingsTab
            // 
            this.AvusrSettingsTab.Location = new System.Drawing.Point(4, 22);
            this.AvusrSettingsTab.Name = "AvusrSettingsTab";
            this.AvusrSettingsTab.Padding = new System.Windows.Forms.Padding(3);
            this.AvusrSettingsTab.Size = new System.Drawing.Size(412, 406);
            this.AvusrSettingsTab.TabIndex = 2;
            this.AvusrSettingsTab.Text = "Settings";
            this.AvusrSettingsTab.UseVisualStyleBackColor = true;
            // 
            // ModsGBox
            // 
            this.ModsGBox.Location = new System.Drawing.Point(9, 415);
            this.ModsGBox.Margin = new System.Windows.Forms.Padding(6);
            this.ModsGBox.Name = "ModsGBox";
            this.ModsGBox.Size = new System.Drawing.Size(375, 219);
            this.ModsGBox.TabIndex = 9;
            this.ModsGBox.TabStop = false;
            this.ModsGBox.Text = "Mods";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 486);
            this.Controls.Add(this.ServerSettingsTControl);
            this.Controls.Add(this.CloseBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimumSize = new System.Drawing.Size(460, 525);
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ServerSettingsTControl.ResumeLayout(false);
            this.VuGamePathTab.ResumeLayout(false);
            this.VuGamePathTab.PerformLayout();
            this.VuServerArgsTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.MiscGBox.ResumeLayout(false);
            this.MiscGBox.PerformLayout();
            this.ServerFreqGBox.ResumeLayout(false);
            this.ServerFreqGBox.PerformLayout();
            this.TerrainOptionsGBox.ResumeLayout(false);
            this.TerrainOptionsGBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseBtn;
        private System.Windows.Forms.TabControl ServerSettingsTControl;
        private System.Windows.Forms.TabPage VuGamePathTab;
        private System.Windows.Forms.Label VuServerInstancePathLbl;
        private System.Windows.Forms.Label VuPathLbl;
        private System.Windows.Forms.TabPage VuServerArgsTab;
        private System.Windows.Forms.GroupBox ServerFreqGBox;
        private System.Windows.Forms.CheckBox UnlistedCBox;
        private System.Windows.Forms.CheckBox SkipChecksumCBox;
        private System.Windows.Forms.CheckBox HighResTerrainCBox;
        private System.Windows.Forms.CheckBox DisableTerrainInterpCBox;
        private System.Windows.Forms.GroupBox TerrainOptionsGBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox MiscGBox;
        private System.Windows.Forms.CheckBox WritePerfProfileCBox;
        private System.Windows.Forms.CheckBox DisableAutomaticUpdatesCBox;
        private System.Windows.Forms.CheckBox SaveLoggingOutputCBox;
        private System.Windows.Forms.TextBox VuInstancePathTBox;
        private System.Windows.Forms.TextBox VuPathTBox;
        private System.Windows.Forms.Label Bf3GamePathLbl;
        private System.Windows.Forms.TextBox BattlefieldInstallDirTBox;
        private System.Windows.Forms.CheckBox UseCustomGamePathCBox;
        private System.Windows.Forms.TextBox ProConPathTBox;
        private System.Windows.Forms.Label ProconPathLbl;
        private System.Windows.Forms.CheckBox UseMiniProConCBox;
        private System.Windows.Forms.RadioButton ServerFrequency120HzRBtn;
        private System.Windows.Forms.RadioButton ServerFrequency60HzRBtn;
        private System.Windows.Forms.RadioButton ServerFrequency30HzRBtn;
        private System.Windows.Forms.GroupBox ModsGBox;
        private System.Windows.Forms.TabPage AvusrSettingsTab;
    }
}