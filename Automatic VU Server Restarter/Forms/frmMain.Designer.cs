namespace VU.Forms
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
            this.ServerNameLbl = new System.Windows.Forms.Label();
            this.ModeNameLbl = new System.Windows.Forms.Label();
            this.SlotUsageLbl = new System.Windows.Forms.Label();
            this.MapNameLbl = new System.Windows.Forms.Label();
            this.StopVuServerBtn = new System.Windows.Forms.Button();
            this.WatermarkLbl = new System.Windows.Forms.Label();
            this.SendCommandBtn = new System.Windows.Forms.Button();
            this.TestCommandTBox = new System.Windows.Forms.TextBox();
            this.ServerLogOutput = new System.Windows.Forms.TextBox();
            this.ServerUsageSStrip = new System.Windows.Forms.StatusStrip();
            this.ServerConStateSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerCpuUsageSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerCpuUsageProcBar = new System.Windows.Forms.ToolStripProgressBar();
            this.MemUsageSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.MemUsageProcBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ServerFpsSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerVersionSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.RestartsSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.BgUpdateSearchSTLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            this.ServerOverviewGBox.SuspendLayout();
            this.ServerUsageSStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartVuServerBtn
            // 
            this.StartVuServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartVuServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StartVuServerBtn.Location = new System.Drawing.Point(605, 637);
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
            this.ExitBtn.Location = new System.Drawing.Point(794, 636);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 23);
            this.ExitBtn.TabIndex = 8;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTStrip,
            this.InfoTStrip});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
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
            this.ServerOverviewGBox.Controls.Add(this.ServerNameLbl);
            this.ServerOverviewGBox.Controls.Add(this.ModeNameLbl);
            this.ServerOverviewGBox.Controls.Add(this.SlotUsageLbl);
            this.ServerOverviewGBox.Controls.Add(this.MapNameLbl);
            this.ServerOverviewGBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ServerOverviewGBox.Location = new System.Drawing.Point(13, 509);
            this.ServerOverviewGBox.Name = "ServerOverviewGBox";
            this.ServerOverviewGBox.Size = new System.Drawing.Size(856, 116);
            this.ServerOverviewGBox.TabIndex = 10;
            this.ServerOverviewGBox.TabStop = false;
            this.ServerOverviewGBox.Text = "Venice Unleashed Server information";
            // 
            // ServerNameLbl
            // 
            this.ServerNameLbl.AutoSize = true;
            this.ServerNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServerNameLbl.Location = new System.Drawing.Point(11, 21);
            this.ServerNameLbl.Name = "ServerNameLbl";
            this.ServerNameLbl.Size = new System.Drawing.Size(89, 15);
            this.ServerNameLbl.TabIndex = 2;
            this.ServerNameLbl.Text = "Server Name: -";
            // 
            // ModeNameLbl
            // 
            this.ModeNameLbl.AutoSize = true;
            this.ModeNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModeNameLbl.Location = new System.Drawing.Point(11, 87);
            this.ModeNameLbl.Name = "ModeNameLbl";
            this.ModeNameLbl.Size = new System.Drawing.Size(49, 15);
            this.ModeNameLbl.TabIndex = 15;
            this.ModeNameLbl.Text = "Mode: -";
            // 
            // SlotUsageLbl
            // 
            this.SlotUsageLbl.AutoSize = true;
            this.SlotUsageLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlotUsageLbl.Location = new System.Drawing.Point(11, 43);
            this.SlotUsageLbl.Name = "SlotUsageLbl";
            this.SlotUsageLbl.Size = new System.Drawing.Size(94, 15);
            this.SlotUsageLbl.TabIndex = 1;
            this.SlotUsageLbl.Text = "Players online: -";
            // 
            // MapNameLbl
            // 
            this.MapNameLbl.AutoSize = true;
            this.MapNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapNameLbl.Location = new System.Drawing.Point(11, 65);
            this.MapNameLbl.Name = "MapNameLbl";
            this.MapNameLbl.Size = new System.Drawing.Size(42, 15);
            this.MapNameLbl.TabIndex = 14;
            this.MapNameLbl.Text = "Map: -";
            // 
            // StopVuServerBtn
            // 
            this.StopVuServerBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopVuServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.StopVuServerBtn.Location = new System.Drawing.Point(605, 637);
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
            this.WatermarkLbl.Location = new System.Drawing.Point(363, 495);
            this.WatermarkLbl.Name = "WatermarkLbl";
            this.WatermarkLbl.Size = new System.Drawing.Size(161, 13);
            this.WatermarkLbl.TabIndex = 13;
            this.WatermarkLbl.Text = "Early version, bugs are present!!!";
            // 
            // SendCommandBtn
            // 
            this.SendCommandBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendCommandBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SendCommandBtn.Location = new System.Drawing.Point(465, 636);
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
            this.TestCommandTBox.Location = new System.Drawing.Point(13, 638);
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
            // ServerUsageSStrip
            // 
            this.ServerUsageSStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerConStateSTLbl,
            this.ServerCpuUsageSTLbl,
            this.ServerCpuUsageProcBar,
            this.MemUsageSTLbl,
            this.MemUsageProcBar,
            this.ServerFpsSTLbl,
            this.ServerVersionSTLbl,
            this.RestartsSTLbl,
            this.BgUpdateSearchSTLbl});
            this.ServerUsageSStrip.Location = new System.Drawing.Point(0, 670);
            this.ServerUsageSStrip.Name = "ServerUsageSStrip";
            this.ServerUsageSStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ServerUsageSStrip.Size = new System.Drawing.Size(880, 24);
            this.ServerUsageSStrip.SizingGrip = false;
            this.ServerUsageSStrip.TabIndex = 17;
            this.ServerUsageSStrip.Text = "Server status";
            // 
            // ServerConStateSTLbl
            // 
            this.ServerConStateSTLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ServerConStateSTLbl.Name = "ServerConStateSTLbl";
            this.ServerConStateSTLbl.Size = new System.Drawing.Size(81, 19);
            this.ServerConStateSTLbl.Text = "Server: Offline";
            this.ServerConStateSTLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerCpuUsageSTLbl
            // 
            this.ServerCpuUsageSTLbl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.ServerCpuUsageSTLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ServerCpuUsageSTLbl.Name = "ServerCpuUsageSTLbl";
            this.ServerCpuUsageSTLbl.Size = new System.Drawing.Size(45, 19);
            this.ServerCpuUsageSTLbl.Text = "CPU: -";
            this.ServerCpuUsageSTLbl.Visible = false;
            // 
            // ServerCpuUsageProcBar
            // 
            this.ServerCpuUsageProcBar.MarqueeAnimationSpeed = 0;
            this.ServerCpuUsageProcBar.Name = "ServerCpuUsageProcBar";
            this.ServerCpuUsageProcBar.Size = new System.Drawing.Size(100, 18);
            this.ServerCpuUsageProcBar.Step = 1;
            this.ServerCpuUsageProcBar.Visible = false;
            // 
            // MemUsageSTLbl
            // 
            this.MemUsageSTLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.MemUsageSTLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MemUsageSTLbl.Name = "MemUsageSTLbl";
            this.MemUsageSTLbl.Size = new System.Drawing.Size(55, 19);
            this.MemUsageSTLbl.Text = "Memory:";
            this.MemUsageSTLbl.Visible = false;
            // 
            // MemUsageProcBar
            // 
            this.MemUsageProcBar.MarqueeAnimationSpeed = 0;
            this.MemUsageProcBar.Maximum = 2147483647;
            this.MemUsageProcBar.Name = "MemUsageProcBar";
            this.MemUsageProcBar.Size = new System.Drawing.Size(100, 18);
            this.MemUsageProcBar.Step = 1;
            this.MemUsageProcBar.Visible = false;
            // 
            // ServerFpsSTLbl
            // 
            this.ServerFpsSTLbl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.ServerFpsSTLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ServerFpsSTLbl.Name = "ServerFpsSTLbl";
            this.ServerFpsSTLbl.Size = new System.Drawing.Size(41, 19);
            this.ServerFpsSTLbl.Text = "FPS: -";
            this.ServerFpsSTLbl.Visible = false;
            // 
            // ServerVersionSTLbl
            // 
            this.ServerVersionSTLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ServerVersionSTLbl.Name = "ServerVersionSTLbl";
            this.ServerVersionSTLbl.Size = new System.Drawing.Size(83, 19);
            this.ServerVersionSTLbl.Text = "Server version:";
            this.ServerVersionSTLbl.Visible = false;
            // 
            // RestartsSTLbl
            // 
            this.RestartsSTLbl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.RestartsSTLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.RestartsSTLbl.Name = "RestartsSTLbl";
            this.RestartsSTLbl.Size = new System.Drawing.Size(64, 19);
            this.RestartsSTLbl.Text = "Restarts: 0";
            this.RestartsSTLbl.Visible = false;
            // 
            // BgUpdateSearchSTLbl
            // 
            this.BgUpdateSearchSTLbl.ActiveLinkColor = System.Drawing.Color.Black;
            this.BgUpdateSearchSTLbl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.BgUpdateSearchSTLbl.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.BgUpdateSearchSTLbl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.BgUpdateSearchSTLbl.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.BgUpdateSearchSTLbl.LinkColor = System.Drawing.Color.Black;
            this.BgUpdateSearchSTLbl.Name = "BgUpdateSearchSTLbl";
            this.BgUpdateSearchSTLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BgUpdateSearchSTLbl.Size = new System.Drawing.Size(112, 19);
            this.BgUpdateSearchSTLbl.Text = "Searching update...";
            this.BgUpdateSearchSTLbl.VisitedLinkColor = System.Drawing.Color.Black;
            this.BgUpdateSearchSTLbl.Click += new System.EventHandler(this.BgUpdateSearchSTLbl_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 694);
            this.Controls.Add(this.ServerUsageSStrip);
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
            this.ServerOverviewGBox.PerformLayout();
            this.ServerUsageSStrip.ResumeLayout(false);
            this.ServerUsageSStrip.PerformLayout();
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
        internal System.Windows.Forms.Label SlotUsageLbl;
        internal System.Windows.Forms.Label ServerNameLbl;
        internal System.Windows.Forms.Label ModeNameLbl;
        internal System.Windows.Forms.Label MapNameLbl;
        private System.Windows.Forms.StatusStrip ServerUsageSStrip;
        private System.Windows.Forms.ToolStripStatusLabel ServerConStateSTLbl;
        private System.Windows.Forms.ToolStripProgressBar ServerCpuUsageProcBar;
        private System.Windows.Forms.ToolStripStatusLabel MemUsageSTLbl;
        private System.Windows.Forms.ToolStripProgressBar MemUsageProcBar;
        private System.Windows.Forms.ToolStripStatusLabel RestartsSTLbl;
        private System.Windows.Forms.ToolStripStatusLabel ServerVersionSTLbl;
        private System.Windows.Forms.ToolStripStatusLabel ServerFpsSTLbl;
        private System.Windows.Forms.ToolStripStatusLabel ServerCpuUsageSTLbl;
        private System.Windows.Forms.ToolStripStatusLabel BgUpdateSearchSTLbl;
        internal System.Windows.Forms.TextBox ServerLogOutput;
    }
}

