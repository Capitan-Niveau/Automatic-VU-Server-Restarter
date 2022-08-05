﻿namespace VU.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.StartVuServerBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.ToolStrip();
            this.FileTStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.SettingsTStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitTStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoTStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.UpdateTStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerOverviewGBox = new System.Windows.Forms.GroupBox();
            this.StatsContainerPanel = new System.Windows.Forms.Panel();
            this.ServerNameLbl = new System.Windows.Forms.Label();
            this.ServerFpsLbl = new System.Windows.Forms.Label();
            this.ProcessInfoLbl = new System.Windows.Forms.Label();
            this.ModeNameLbl = new System.Windows.Forms.Label();
            this.ServerCpuUsageLbl = new System.Windows.Forms.Label();
            this.MapNameLbl = new System.Windows.Forms.Label();
            this.SlotUsageLbl = new System.Windows.Forms.Label();
            this.ServerMemUsageLbl = new System.Windows.Forms.Label();
            this.StopVuServerBtn = new System.Windows.Forms.Button();
            this.WatermarkLbl = new System.Windows.Forms.Label();
            this.SendCommandBtn = new System.Windows.Forms.Button();
            this.TestCommandTBox = new System.Windows.Forms.TextBox();
            this.ServerLogOutput = new System.Windows.Forms.TextBox();
            this.MainMenu.SuspendLayout();
            this.ServerOverviewGBox.SuspendLayout();
            this.StatsContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartVuServerBtn
            // 
            this.StartVuServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartVuServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartVuServerBtn.Location = new System.Drawing.Point(605, 659);
            this.StartVuServerBtn.Name = "StartVuServerBtn";
            this.StartVuServerBtn.Size = new System.Drawing.Size(159, 23);
            this.StartVuServerBtn.TabIndex = 7;
            this.StartVuServerBtn.Text = "Start Server";
            this.StartVuServerBtn.UseVisualStyleBackColor = true;
            this.StartVuServerBtn.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ExitBtn.Location = new System.Drawing.Point(793, 659);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTStrip,
            this.InfoTStrip});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MainMenu.Size = new System.Drawing.Size(880, 25);
            this.MainMenu.TabIndex = 9;
            this.MainMenu.Text = "Menu";
            // 
            // FileTStrip
            // 
            this.FileTStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileTStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsTStrip,
            this.toolStripSeparator2,
            this.ExitTStrip});
            this.FileTStrip.Image = ((System.Drawing.Image)(resources.GetObject("FileTStrip.Image")));
            this.FileTStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileTStrip.Name = "FileTStrip";
            this.FileTStrip.Size = new System.Drawing.Size(38, 22);
            this.FileTStrip.Text = "File";
            // 
            // SettingsTStrip
            // 
            this.SettingsTStrip.Name = "SettingsTStrip";
            this.SettingsTStrip.Size = new System.Drawing.Size(116, 22);
            this.SettingsTStrip.Text = "Settings";
            this.SettingsTStrip.Click += new System.EventHandler(this.SettingsTStrip_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(113, 6);
            // 
            // ExitTStrip
            // 
            this.ExitTStrip.Name = "ExitTStrip";
            this.ExitTStrip.Size = new System.Drawing.Size(116, 22);
            this.ExitTStrip.Text = "Exit";
            this.ExitTStrip.Click += new System.EventHandler(this.ExitTStrip_Click);
            // 
            // InfoTStrip
            // 
            this.InfoTStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.InfoTStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateTStrip,
            this.AboutBtn});
            this.InfoTStrip.Image = ((System.Drawing.Image)(resources.GetObject("InfoTStrip.Image")));
            this.InfoTStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoTStrip.Name = "InfoTStrip";
            this.InfoTStrip.Size = new System.Drawing.Size(45, 22);
            this.InfoTStrip.Text = "Help";
            // 
            // UpdateTStrip
            // 
            this.UpdateTStrip.Name = "UpdateTStrip";
            this.UpdateTStrip.Size = new System.Drawing.Size(117, 22);
            this.UpdateTStrip.Text = "Updates";
            this.UpdateTStrip.Click += new System.EventHandler(this.UpdateTStrip_Click);
            // 
            // AboutBtn
            // 
            this.AboutBtn.Name = "AboutBtn";
            this.AboutBtn.Size = new System.Drawing.Size(117, 22);
            this.AboutBtn.Text = "About";
            this.AboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // ServerOverviewGBox
            // 
            this.ServerOverviewGBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerOverviewGBox.Controls.Add(this.StatsContainerPanel);
            this.ServerOverviewGBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ServerOverviewGBox.Location = new System.Drawing.Point(13, 509);
            this.ServerOverviewGBox.Name = "ServerOverviewGBox";
            this.ServerOverviewGBox.Size = new System.Drawing.Size(856, 135);
            this.ServerOverviewGBox.TabIndex = 10;
            this.ServerOverviewGBox.TabStop = false;
            this.ServerOverviewGBox.Text = "Venice Unleashed Server information";
            // 
            // StatsContainerPanel
            // 
            this.StatsContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatsContainerPanel.AutoScroll = true;
            this.StatsContainerPanel.BackColor = System.Drawing.Color.Transparent;
            this.StatsContainerPanel.Controls.Add(this.ServerNameLbl);
            this.StatsContainerPanel.Controls.Add(this.ServerFpsLbl);
            this.StatsContainerPanel.Controls.Add(this.ProcessInfoLbl);
            this.StatsContainerPanel.Controls.Add(this.ModeNameLbl);
            this.StatsContainerPanel.Controls.Add(this.ServerCpuUsageLbl);
            this.StatsContainerPanel.Controls.Add(this.MapNameLbl);
            this.StatsContainerPanel.Controls.Add(this.SlotUsageLbl);
            this.StatsContainerPanel.Controls.Add(this.ServerMemUsageLbl);
            this.StatsContainerPanel.Location = new System.Drawing.Point(1, 16);
            this.StatsContainerPanel.Name = "StatsContainerPanel";
            this.StatsContainerPanel.Size = new System.Drawing.Size(854, 116);
            this.StatsContainerPanel.TabIndex = 17;
            // 
            // ServerNameLbl
            // 
            this.ServerNameLbl.AutoSize = true;
            this.ServerNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerNameLbl.Location = new System.Drawing.Point(14, 30);
            this.ServerNameLbl.Name = "ServerNameLbl";
            this.ServerNameLbl.Size = new System.Drawing.Size(32, 15);
            this.ServerNameLbl.TabIndex = 2;
            this.ServerNameLbl.Text = "NaN";
            // 
            // ServerFpsLbl
            // 
            this.ServerFpsLbl.AutoSize = true;
            this.ServerFpsLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerFpsLbl.Location = new System.Drawing.Point(506, 76);
            this.ServerFpsLbl.Name = "ServerFpsLbl";
            this.ServerFpsLbl.Size = new System.Drawing.Size(51, 15);
            this.ServerFpsLbl.TabIndex = 16;
            this.ServerFpsLbl.Text = "FPS: {0}";
            // 
            // ProcessInfoLbl
            // 
            this.ProcessInfoLbl.AutoSize = true;
            this.ProcessInfoLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessInfoLbl.Location = new System.Drawing.Point(14, 7);
            this.ProcessInfoLbl.Name = "ProcessInfoLbl";
            this.ProcessInfoLbl.Size = new System.Drawing.Size(119, 15);
            this.ProcessInfoLbl.TabIndex = 0;
            this.ProcessInfoLbl.Text = "Server is not running";
            // 
            // ModeNameLbl
            // 
            this.ModeNameLbl.AutoSize = true;
            this.ModeNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeNameLbl.Location = new System.Drawing.Point(506, 53);
            this.ModeNameLbl.Name = "ModeNameLbl";
            this.ModeNameLbl.Size = new System.Drawing.Size(60, 15);
            this.ModeNameLbl.TabIndex = 15;
            this.ModeNameLbl.Text = "Mode: {0}";
            // 
            // ServerCpuUsageLbl
            // 
            this.ServerCpuUsageLbl.AutoSize = true;
            this.ServerCpuUsageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerCpuUsageLbl.Location = new System.Drawing.Point(14, 76);
            this.ServerCpuUsageLbl.Name = "ServerCpuUsageLbl";
            this.ServerCpuUsageLbl.Size = new System.Drawing.Size(32, 15);
            this.ServerCpuUsageLbl.TabIndex = 13;
            this.ServerCpuUsageLbl.Text = "NaN";
            // 
            // MapNameLbl
            // 
            this.MapNameLbl.AutoSize = true;
            this.MapNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapNameLbl.Location = new System.Drawing.Point(506, 30);
            this.MapNameLbl.Name = "MapNameLbl";
            this.MapNameLbl.Size = new System.Drawing.Size(53, 15);
            this.MapNameLbl.TabIndex = 14;
            this.MapNameLbl.Text = "Map: {0}";
            // 
            // SlotUsageLbl
            // 
            this.SlotUsageLbl.AutoSize = true;
            this.SlotUsageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlotUsageLbl.Location = new System.Drawing.Point(506, 7);
            this.SlotUsageLbl.Name = "SlotUsageLbl";
            this.SlotUsageLbl.Size = new System.Drawing.Size(136, 15);
            this.SlotUsageLbl.TabIndex = 1;
            this.SlotUsageLbl.Text = "Players online: {0} of {1}";
            // 
            // ServerMemUsageLbl
            // 
            this.ServerMemUsageLbl.AutoSize = true;
            this.ServerMemUsageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerMemUsageLbl.Location = new System.Drawing.Point(14, 53);
            this.ServerMemUsageLbl.Name = "ServerMemUsageLbl";
            this.ServerMemUsageLbl.Size = new System.Drawing.Size(32, 15);
            this.ServerMemUsageLbl.TabIndex = 12;
            this.ServerMemUsageLbl.Text = "NaN";
            // 
            // StopVuServerBtn
            // 
            this.StopVuServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopVuServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StopVuServerBtn.Location = new System.Drawing.Point(605, 659);
            this.StopVuServerBtn.Name = "StopVuServerBtn";
            this.StopVuServerBtn.Size = new System.Drawing.Size(159, 23);
            this.StopVuServerBtn.TabIndex = 12;
            this.StopVuServerBtn.Text = "Stop Server";
            this.StopVuServerBtn.UseVisualStyleBackColor = true;
            this.StopVuServerBtn.Visible = false;
            this.StopVuServerBtn.Click += new System.EventHandler(this.StopVuServerBtn_Click);
            // 
            // WatermarkLbl
            // 
            this.WatermarkLbl.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.WatermarkLbl.AutoSize = true;
            this.WatermarkLbl.Location = new System.Drawing.Point(361, 493);
            this.WatermarkLbl.Name = "WatermarkLbl";
            this.WatermarkLbl.Size = new System.Drawing.Size(161, 13);
            this.WatermarkLbl.TabIndex = 13;
            this.WatermarkLbl.Text = "Early version, bugs are present!!!";
            // 
            // SendCommandBtn
            // 
            this.SendCommandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendCommandBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SendCommandBtn.Location = new System.Drawing.Point(465, 659);
            this.SendCommandBtn.Name = "SendCommandBtn";
            this.SendCommandBtn.Size = new System.Drawing.Size(75, 23);
            this.SendCommandBtn.TabIndex = 14;
            this.SendCommandBtn.Text = "Send";
            this.SendCommandBtn.UseVisualStyleBackColor = true;
            this.SendCommandBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestCommandTBox
            // 
            this.TestCommandTBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TestCommandTBox.AutoCompleteCustomSource.AddRange(new string[] {
            "admin.yell",
            "admin.say",
            "admin.kill",
            "admin.kickPlayer",
            "admin.help",
            "admin.effectiveMaxPlayers",
            "mapList.list",
            "mapList.restartRound",
            "mapList.runNextRound",
            "punkBuster.activate",
            "punkBuster.isActive",
            "version"});
            this.TestCommandTBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TestCommandTBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TestCommandTBox.Location = new System.Drawing.Point(12, 660);
            this.TestCommandTBox.Name = "TestCommandTBox";
            this.TestCommandTBox.Size = new System.Drawing.Size(447, 20);
            this.TestCommandTBox.TabIndex = 15;
            // 
            // ServerLogOutput
            // 
            this.ServerLogOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerLogOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerLogOutput.Cursor = System.Windows.Forms.Cursors.Default;
            this.ServerLogOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerLogOutput.Location = new System.Drawing.Point(13, 37);
            this.ServerLogOutput.Multiline = true;
            this.ServerLogOutput.Name = "ServerLogOutput";
            this.ServerLogOutput.ReadOnly = true;
            this.ServerLogOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ServerLogOutput.Size = new System.Drawing.Size(855, 451);
            this.ServerLogOutput.TabIndex = 16;
            this.ServerLogOutput.TabStop = false;
            this.ServerLogOutput.TextChanged += new System.EventHandler(this.ServerLogOutput_TextChanged);
            this.ServerLogOutput.GotFocus += new System.EventHandler(this.ServerLogOutput_GotFocus);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 694);
            this.Controls.Add(this.ServerLogOutput);
            this.Controls.Add(this.TestCommandTBox);
            this.Controls.Add(this.SendCommandBtn);
            this.Controls.Add(this.WatermarkLbl);
            this.Controls.Add(this.ServerOverviewGBox);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.StartVuServerBtn);
            this.Controls.Add(this.StopVuServerBtn);
            this.MinimumSize = new System.Drawing.Size(525, 475);
            this.Name = "FrmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "{0} - {1}";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ServerOverviewGBox.ResumeLayout(false);
            this.StatsContainerPanel.ResumeLayout(false);
            this.StatsContainerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartVuServerBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.ToolStrip MainMenu;
        private System.Windows.Forms.ToolStripDropDownButton InfoTStrip;
        private System.Windows.Forms.ToolStripDropDownButton FileTStrip;
        private System.Windows.Forms.ToolStripMenuItem SettingsTStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitTStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutBtn;
        private System.Windows.Forms.GroupBox ServerOverviewGBox;
        private System.Windows.Forms.Button StopVuServerBtn;
        private System.Windows.Forms.Label WatermarkLbl;
        private System.Windows.Forms.Button SendCommandBtn;
        private System.Windows.Forms.TextBox TestCommandTBox;
        private System.Windows.Forms.ToolStripMenuItem UpdateTStrip;
        private System.Windows.Forms.TextBox ServerLogOutput;
        private System.Windows.Forms.Panel StatsContainerPanel;
        internal System.Windows.Forms.Label SlotUsageLbl;
        internal System.Windows.Forms.Label ProcessInfoLbl;
        internal System.Windows.Forms.Label ServerMemUsageLbl;
        internal System.Windows.Forms.Label ServerCpuUsageLbl;
        internal System.Windows.Forms.Label ServerNameLbl;
        internal System.Windows.Forms.Label ModeNameLbl;
        internal System.Windows.Forms.Label MapNameLbl;
        internal System.Windows.Forms.Label ServerFpsLbl;
    }
}

