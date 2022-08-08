using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using INIReader;
using VU.Server;
using VU.Settings;
using VU.Tools;
using VU.Updater;

namespace VU.Forms
{
    public partial class FrmMain : Form
    {
        private int _restartCounter;
        private Thread _serverThread;
        private Thread _updateControls;

        private readonly HostServer _server = new HostServer();

        public FrmMain()
        {
            InitializeComponent();
            Text = Properties.Resources.ProcName;
            Icon = Properties.Resources.AVUSR;
            _server.OutPudBox = ServerLogOutput;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (SettingsManager.AVUSRUpdates)
            {
                BgUpdateSearchSTLbl.Visible = true;
                CheckUpdate.CheckForUpdateBg(this);
            }
            Icon updateImg = new Icon(Properties.Resources.Update, new Size(16, 16));
            Icon aboutImg = new Icon(Properties.Resources.About, new Size(16, 16));
            Icon settingsImg = new Icon(Properties.Resources.Settings, new Size(16, 16));
            UpdateTStrip.Image = updateImg.ToBitmap();
            AboutBtn.Image = aboutImg.ToBitmap();
            SettingsTStrip.Image = settingsImg.ToBitmap();
        }

        internal void WC_GetCheckList_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var updateInfo = new INI { Path = $"{Path.GetTempPath()}avusr_update.ini" };
            CheckUpdate.Version = updateInfo.Read("Updater", "Version");
            CheckUpdate.Md5Hash = updateInfo.Read("Updater", "MD5");
            CheckUpdate.FileSize = int.Parse(updateInfo.Read("Updater", "FileSize"));
            CheckUpdate.UpdateUrl = new Uri(updateInfo.Read("Updater", "FileUrl"));
            CheckUpdate.UpdateInfoUrl = new Uri(updateInfo.Read("Updater", "InfoUrl"));
            CheckUpdate.IsNewerVersion = Application.ProductVersion.Equals(CheckUpdate.Version);
            CheckUpdate.IsBetaVersion = Convert.ToBoolean(updateInfo.Read("Updater", "BetaVersion"));
            if (!CheckUpdate.IsNewerVersion)
            {
                BgUpdateSearchSTLbl.Text = @"New update available";
                BgUpdateSearchSTLbl.IsLink = true;
            }
            else
            {
                BgUpdateSearchSTLbl.Visible = false;
                File.Delete($@"{Path.GetTempPath()}avusr_update.ini");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(CheckUpdate.UpdatePath))
            {
                Process.Start(CheckUpdate.UpdatePath);
                Exit(e);
            }
            else
            {
                Exit(e);
            }
        }

        private void Exit(FormClosingEventArgs e = null)
        {
            if (_server.IsRunning())
            {
                var stopServer = MessageBox.Show(@"The server is still running, do you want to shut it down?", @"Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (stopServer)
                {
                    case DialogResult.Yes:
                        _server.DisposeServer();
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        if (e != null) e.Cancel = true;
                        return;
                }
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void RestartServer()
        {
            _restartCounter++;
            Stop();
            if (StartVuServerBtn.Visible)
            {
                StartVuServerBtn.Visible = false;
                StopVuServerBtn.Visible = true;
            }

            _serverThread = new Thread(_server.Start)
            {
                Name = "Server::Logging",
                IsBackground = true,
            };
            _serverThread.Start();

            _updateControls = new Thread(UpdateControls)
            {
                Name = "Control::Updater",
                IsBackground = true,
            };
            _updateControls.Start();

            if (SettingsManager.UseProCon)
                Utilitys.StartProCon(SettingsManager.UseCutDownProCon);

            RestartsSTLbl.Text = $@"Restarts: {_restartCounter}";
            _server.ServerStatus = @"Server: Restarting...";
            MemUsageSTLbl.Visible = true;
            MemUsageProcBar.Visible = true;
            ServerCpuUsageProcBar.Visible = true;
            ServerFpsSTLbl.Visible = true;
            ServerCpuUsageSTLbl.Visible = true;
            ServerVersionSTLbl.Visible = true;
            
        }

        internal void Stop()
        {
            _server.ServerPid = 0;
            _server.ServerExitCode = 0;
            _server.PlayerCount = 0;
            _server.MemUsage = 0;
            _server.ServerKeyInUse = false;

            _server.DisposeServer();

            if (_serverThread != null && _serverThread.IsAlive)
                _serverThread.Abort();

            if (_updateControls != null && _updateControls.IsAlive)
                _updateControls.Abort();

            ServerConStateSTLbl.Text = @"Server: Offline";
            ServerNameLbl.Text = $@"Server name: {_server.ServerName}";
            SlotUsageLbl.Text = @"Players online: -";
            MapNameLbl.Text = @"Map: -";
            ModeNameLbl.Text = @"Mode: -";
            StartVuServerBtn.Visible = true;
            StopVuServerBtn.Visible = false;
            MemUsageSTLbl.Visible = false;
            MemUsageProcBar.Visible = false;
            ServerCpuUsageProcBar.Value = 0;
            ServerCpuUsageProcBar.Visible = false;
            ServerVersionSTLbl.Visible = false;
            ServerCpuUsageSTLbl.Visible = false;
            ServerFpsSTLbl.Visible = false;
            ServerCpuUsageProcBar.Value = 0;
            MemUsageProcBar.Value = 0;

            _serverThread = null;
            _updateControls = null;
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SettingsManager.VuInstancePath))
            {
                if (!File.Exists(SettingsManager.VuInstancePath + "\\server.key"))
                {
                    if (DialogResult.OK == MessageBox.Show(
                            $@"The server key file could not be found in the specified path:" + Environment.NewLine +
                            $@"{SettingsManager.VuInstancePath}\server.key", @"File not fount", MessageBoxButtons.OK,
                            MessageBoxIcon.Error))
                    {

                        StartVuServerBtn.Visible = true;
                        StopVuServerBtn.Visible = false;
                        return;
                    }
                }
            }

            _serverThread = new Thread(_server.Start)
            {
                Name = "Server::Logging",
                IsBackground = true
            };
            _serverThread.Start();

            _updateControls = new Thread(UpdateControls)
            {
                Name = "Control::CUpdater",
                IsBackground = true,
            };
            _updateControls.Start();

            if (SettingsManager.UseProCon)
                Utilitys.StartProCon(SettingsManager.UseCutDownProCon);

            _server.ServerStatus = "Server: Starting...";
            StartVuServerBtn.Visible = false;
            StopVuServerBtn.Visible = true;
            MemUsageSTLbl.Visible = true;
            MemUsageProcBar.Visible = true;
            RestartsSTLbl.Visible = true;
            ServerCpuUsageProcBar.Visible = true;
            ServerVersionSTLbl.Visible = true;
            ServerFpsSTLbl.Visible = true;
            ServerCpuUsageSTLbl.Visible = true;
        }

        private void StopVuServerBtn_Click(object sender, EventArgs e)
        {
            Stop();
            ServerLogOutput.AppendText(Environment.NewLine + "[Local] Server has been stopped...");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void ExitTStrip_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void SettingsTStrip_Click(object sender, EventArgs e)
        {
            using (frmSettings shwSettings= new frmSettings())
            {
                if (DialogResult.OK == shwSettings.ShowDialog())
                {
                    SettingsManager.LoadSettings();
                }
            }
        }

        private void UpdateControls()
        {
            do
            {
                Thread.Sleep(1000);
                if (_server.ServerKeyInUse)
                {
                    Invoke((Action)Stop);
                }
                if (_server.ServerExitCode > 0)
                {
                    if (!ServerLogOutput.InvokeRequired) continue;

                    void WriteCrashLog()
                    {
                        ServerLogOutput.AppendText(Environment.NewLine + $"[Local] Server crashed with exit code {_server.ServerExitCode}... restarting...");
                        RestartServer();
                    }
                    Invoke((Action)WriteCrashLog);
                }
                else
                {
                    if (_server.ServerPid < 0) return;
                    double cpuUsage = Utilitys.ServerCpuUsage(_server.ServerPid);
                    _server.GetServerFps();
                    _server.RefreshMemUsage();

                    void Controls()
                    {
                        ServerCpuUsageSTLbl.Text = $@"CPU: {cpuUsage:0.0}%";
                        if (cpuUsage > 0)
                        {
                            ServerCpuUsageProcBar.Value = (int)Math.Round(cpuUsage);
                        }
                        else
                        {
                            ServerCpuUsageProcBar.Value = 0;
                        }

                        ServerConStateSTLbl.Text = _server.ServerStatus;
                        MemUsageSTLbl.Text = $@"Memory: {Utilitys.SizeSuffix(_server.MemUsage, 2)}";
                        MemUsageProcBar.Value = _server.MemUsage;
                        ServerVersionSTLbl.Text = $@"Server Version: {Utilitys.ServerVersion}";
                        ServerFpsSTLbl.Text = $@"FPS: {_server.ServerFps}";
                        ServerNameLbl.Text = $@"Server name: {_server.ServerName}";
                        SlotUsageLbl.Text = $@"Players online: {_server.PlayerCount} of {_server.MaxPlayerCount}";
                        MapNameLbl.Text = $@"Map: {_server.MapName}";
                        ModeNameLbl.Text = $@"Mode: {_server.ModeName}";
                    }
                    Invoke((Action)Controls);
                }
            } while (true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           _server.SendRConCommand(TestCommandTBox.Text);
        }

        private void UpdateTStrip_Click(object sender, EventArgs e)
        {
            using (frmGetUpdateInfo showGetUpdateInfo = new frmGetUpdateInfo())
            {
                showGetUpdateInfo.Show();
            }
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            using (frmAbout showAbout = new frmAbout())
            {
                showAbout.ShowDialog();
            }
        }

        private void ServerLogOutput_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text.Length <= 131068) return;
            ServerLogOutput.Clear();
            ServerLogOutput.AppendText("[Local] Maximum character length reached... Clear outpud window...");

        }

        private void ServerLogOutput_GotFocus(object sender, EventArgs e)
        {
            Utilitys.HideCaret(ServerLogOutput.Handle);
        }

        private void BgUpdateSearchSTLbl_Click(object sender, EventArgs e)
        {
            if (!BgUpdateSearchSTLbl.IsLink) return;
            using (frmUpdateInfo infoForm = new frmUpdateInfo())
            {
                infoForm.ShowDialog();
            }
        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
