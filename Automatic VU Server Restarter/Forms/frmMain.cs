using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using Rcon.Net;
using VU.Server;
using System.Net;
using System.Threading.Tasks;
using VU.Settings;

namespace VU.Forms
{
    public partial class FrmMain : Form
    {
        private int _serverExitCode;
        private int _serverPid;
        private int _restartCounter;
        private Process _serverProcess;
        private Thread _serverThread;
        private string _rconPassword;
        private string _maxPlayerCount;
        private string line;
        private string[] _firstMapMode;
        private Client _rconClient;
        private Dictionary<string, string> _serverPassword;
        private Dictionary<string, string> _serverMaxPlayerCount;
        public int PlayerCount { get; private set; }
        public int PlayerLimit { get; private set; }
        public string Map { get; private set; }
        public string Mode { get; private set; }
        public bool CanSendCommands => _rconClient != null && _rconClient.IsOpen;
        private event ActionDelegate<IList<string>> DataReceived;
        private delegate void ActionDelegate<in T>(T args);

        public FrmMain()
        {
            InitializeComponent();
            Text = Properties.Resources.ProcName;
            Icon = Properties.Resources.AVURS;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ProcessInfoLbl.Text = @"Server is not running";
            ServerCpuUsageLbl.Text = @"CPU usage: -";
            SlotUsageLbl.Text = @"Players online: -";
            MapNameLbl.Text = @"Map: -";
            ModeNameLbl.Text = @"Mode: -";
            ServerMemUsageLbl.Text = @"Physical memory usage: - / Peak: -";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
            Environment.Exit(0);
        }

        private void Start()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                MessageBox.Show(@"Server is already running", @"Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadConfig();
                _rconClient = new Client();
                _rconClient.WordsReceived += RconClient_WordsReceived;
                _rconPassword = _serverPassword["admin.password"];
                _maxPlayerCount = _serverMaxPlayerCount["vars.maxPlayers"];
                _serverProcess = new Process();
                _serverProcess.StartInfo.FileName = SettingsManager.VuPath + "\\vu.exe";
                _serverProcess.StartInfo.WorkingDirectory = SettingsManager.VuPath;
                _serverProcess.StartInfo.CreateNoWindow = false;
                _serverProcess.StartInfo.RedirectStandardOutput = true;
                _serverProcess.StartInfo.RedirectStandardError = true;
                _serverProcess.StartInfo.UseShellExecute = false;   
                _serverProcess.StartInfo.Arguments = "-server -dedicated -headless";

                if (!string.IsNullOrEmpty(SettingsManager.VuInstancePath))
                {
                    _serverProcess.StartInfo.Arguments += $" -serverInstancePath \"{SettingsManager.VuInstancePath}\"";
                }

                switch (SettingsManager.ServerFrequency)
                {
                    case 1:
                        _serverProcess.StartInfo.Arguments += "";
                        break;
                    case 2:
                        _serverProcess.StartInfo.Arguments += " -high60";
                        break;
                    case 3:
                        _serverProcess.StartInfo.Arguments += " -high120";
                        break;
                    default:
                        _serverProcess.StartInfo.Arguments += "";
                        break;
                }

                if (SettingsManager.UseCustomGamePath)
                    _serverProcess.StartInfo.Arguments += $" -gamepath {SettingsManager.CustomGamePath}";
                if (SettingsManager.MakeUnlisted)
                    _serverProcess.StartInfo.Arguments += " -unlisted";
                if (SettingsManager.UseAutomaticUpdates)
                    _serverProcess.StartInfo.Arguments += " -noUpdate";
                if (SettingsManager.UseHighResTerrain)
                    _serverProcess.StartInfo.Arguments += " -highResTerrain";
                if (SettingsManager.UseDisableTerrainInterp)
                    _serverProcess.StartInfo.Arguments += " -disableTerrainInterop";
                if (SettingsManager.UseSkipChecksumValidation)
                    _serverProcess.StartInfo.Arguments += " -skipChecksum";
                if (SettingsManager.UseSaveLoggingOutput)
                    _serverProcess.StartInfo.Arguments += " -debuglog";
                if (SettingsManager.UseWritePerfProfile)
                    _serverProcess.StartInfo.Arguments += " -perftrace ";

                //{
                //    StartInfo = new ProcessStartInfo(SettingsManager.VuPath + "\\vu.exe", "-server -dedicated -headless")
                //    {
                //        RedirectStandardOutput = true,
                //        RedirectStandardError = true,
                //        CreateNoWindow = true,
                //        UseShellExecute = false
                //    },
                //    EnableRaisingEvents = true
                //};
                //_serverProcess.ErrorDataReceived += ServerProcessError_DataReceived;
                _serverProcess.OutputDataReceived += ServerProcess_DataReceived;
                _serverProcess.Start();
                _serverProcess.BeginErrorReadLine();
                _serverProcess.BeginOutputReadLine();
                _serverPid = _serverProcess.Id;
                _serverProcess.WaitForExit();
                _serverExitCode = _serverProcess.ExitCode;
            }
        }

        private void RestartServer()
        {
            Stop();
            ServerInfoUpdater.Start();
            if (StartVuServerBtn.Visible)
            {
                StartVuServerBtn.Visible = false;
                StopVuServerBtn.Visible = true;
            }

            _serverThread = new Thread(Start)
            {
                Name = "Server::Logging::Thread"
            };
            _serverThread.Start();
        }

        private async void ServerProcess_DataReceived(object sender, DataReceivedEventArgs e)
        {
            line = e.Data;

            if (string.IsNullOrWhiteSpace(line))
                return;

            Utilitys.GetServerBuild(line);
            Utilitys.CheckIfKeyIsInUse(line);

            if (ServerLogOutput.InvokeRequired)
            {
                void WriteLog()
                {
                    ServerLogOutput.Text += Environment.NewLine + line;
                }

                ServerLogOutput.Invoke((Action)WriteLog);
            }

            if (!Regex.Match(line, @"\[.+\] \[.+\] Monitored Harmony server listening on 0.0.0.0:\d+").Success) return;
            _rconClient.Open(IPAddress.Loopback, 47200);

            await _rconClient.SendMessageAsync("login.plainText", _rconPassword);
        }

        private void Stop()
        {
            _serverPid = 0;
            _serverExitCode = 0;

            if (ServerInfoUpdater.Enabled)
                ServerInfoUpdater.Stop();

            if (Utilitys.ServerKeyIsUsed)
                Utilitys.ServerKeyIsUsed = false;

            if (_rconClient != null && _rconClient.IsOpen)
                _rconClient.Close();

            if(_serverProcess != null && !_serverProcess.HasExited)
               _serverProcess.Kill();

            if(_serverThread != null && _serverThread.IsAlive)
                _serverThread.Abort();

            ProcessInfoLbl.Text = @"Server is not running";
            ServerCpuUsageLbl.Text = @"CPU usage: -";
            SlotUsageLbl.Text = @"Players online: -";
            MapNameLbl.Text = @"Map: -";
            ModeNameLbl.Text = @"Mode: -";
            ServerMemUsageLbl.Text = @"Physical memory usage: - / Peak: -";

            StartVuServerBtn.Visible = true;
            StopVuServerBtn.Visible = false;
            _serverThread = null;  
            _serverProcess = null;
            _rconClient = null;
            PlayerCount = 0;
        }

        private void RconClient_WordsReceived(IList<string> words)
        {
            // Handle event based on command
            switch (words[0])
            {
                case "player.onJoin":
                    PlayerCount++;
                    break;
                case "player.onLeave":
                    PlayerCount--;
                    break;
                case "server.onMaxPlayerCountChange":
                    PlayerLimit = int.Parse(words[1]);
                    break;
                case "server.onLevelLoaded":
                    Map = words[1];
                    Mode = words[2];
                    break;
                default:
                    break;
            }
            // Pass event args
            DataReceived?.Invoke(words);
        }

        private void LoadConfig()
        {
            _serverPassword = new Dictionary<string, string>();
            _serverMaxPlayerCount = new Dictionary<string, string>();

            var configLines = File.ReadAllLines(SettingsManager.VuInstancePath + "\\Admin\\Startup.txt");
            var mapLines = File.ReadAllLines(SettingsManager.VuInstancePath + "\\Admin\\Maplist.txt");
            var trim = Regex.Replace(mapLines[0], @"\s+", ",");

            _firstMapMode = trim.Split(',');

            foreach (var line in configLines)
            {
                if (!line.StartsWith("#"))
                {
                    var configParts = Utilitys.SplitStringBySpace(line);
                    switch (configParts.Count >= 2)
                    {
                        case true:
                            _serverPassword.Add(configParts[0], configParts[1].Replace("\"", string.Empty));
                            _serverMaxPlayerCount.Add(configParts[0], configParts[1].Replace(" ", string.Empty));
                            break;
                    }

                }
            }

            Map = _firstMapMode[0];
            Mode = _firstMapMode[1];
        }




        private void StartServer_Click(object sender, EventArgs e)
        {
            ServerInfoUpdater.Start();
            _serverThread = new Thread(Start)
            {
                Name = "Server::Logging::Thread"
            };
            _serverThread.Start();
            StartVuServerBtn.Visible = false;
            StopVuServerBtn.Visible = true;
        }

        private void StopVuServerBtn_Click(object sender, EventArgs e)
        {
            Stop();
            StartVuServerBtn.Visible = true;
            StopVuServerBtn.Visible = false;
            ServerLogOutput.AppendText(Environment.NewLine + "[Local] Server has been stopped...");
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Stop();
            Environment.Exit(0);
        }

        private void SettingsTStrip_Click(object sender, EventArgs e)
        {
            FrmSettings showSetting = new FrmSettings();
            if (DialogResult.OK == showSetting.ShowDialog())
            {
                SettingsManager.LoadSettings();
            }
        }

        private void ExitTStrip_Click(object sender, EventArgs e)
        {
            Stop();
            Environment.Exit(0);
        }

        private void ServerInfoUpdater_Tick(object sender, EventArgs e)
        {
            switch (Utilitys.ServerKeyIsUsed)
            {
                case true:
                {
                    ServerInfoUpdater.Stop();
                    if (DialogResult.OK == MessageBox.Show(@"The provided server key is already in use. Shutting down.", @"VU Server", MessageBoxButtons.OK, MessageBoxIcon.Error))
                    {
                        Stop();
                    }
                    break;
                }
            }
            switch (_serverExitCode > 0)
            {
                case true:
                    ServerLogOutput.AppendText(Environment.NewLine + $"[Local] Server crashed with exit code {_serverExitCode}... restarting...");
                    _restartCounter++;
                    RestartServer();
                    break;
                default:
                {
                    if (_serverPid > 0)
                    {
                        _serverProcess.Refresh();
                       
                        ProcessInfoLbl.Text = $@"Server with PID {_serverPid} is running - Restarts since first execution: {_restartCounter} / Version: {Utilitys.ServerVersion}";
                        ServerCpuUsageLbl.Text = $@"CPU usage: {Utilitys.ServerCpuUsage(_serverPid):0.0}%";
                        try
                        {
                            ServerMemUsageLbl.Text = $@"Physical memory usage: {Utilitys.SizeSuffix(_serverProcess.WorkingSet64, 1)} / Peak: {Utilitys.SizeSuffix(_serverProcess.PeakWorkingSet64, 1)}";
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                        SlotUsageLbl.Text = $@"Players online: {PlayerCount} of {_maxPlayerCount}";
                        MapNameLbl.Text = $@"Map: {Map}";
                        ModeNameLbl.Text = $@"Mode: {Mode}";
                    }
                    break;
                }
            }
        }

        public async Task<IList<string>> SendCommandAsync(IList<string> words)
        {
            if (_rconClient == null || !_rconClient.IsOpen)
                return null;

            return await _rconClient.SendMessageAsync(words);
        }

        private async void Command_SendRCONCommand(IList<string> words)
        {
            try
            {
                switch (CanSendCommands)
                {
                    case false:
                        ServerLogOutput.AppendText(Environment.NewLine + "[Local] RCON unavailable!");
                        return;
                    default:
                    {
                        var responseWords = await SendCommandAsync(words);
                        ServerLogOutput.AppendText(Environment.NewLine + $"[Server] RCON: {string.Join(" ", responseWords)}");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ServerLogOutput.AppendText(Environment.NewLine + $"[Local] RCON: {ex.InnerException}");
            }
        }

        internal void SendCommand()
        {
            var words = Utilitys.SplitStringBySpace(textBox1.Text);
            Command_SendRCONCommand(words);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void UpdateTStrip_Click(object sender, EventArgs e)
        {
            frmGetUpdateInfo UpdateForm = new frmGetUpdateInfo();
            UpdateForm.ShowDialog();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            frmAbout AboutForm = new frmAbout();
            AboutForm.ShowDialog();
        }

        private void ServerLogOutput_TextChanged(object sender, EventArgs e)
        {
            ServerLogOutput.SelectionStart = ServerLogOutput.TextLength;
            ServerLogOutput.ScrollToCaret();
            if (((TextBox)sender).Text.Length <= 131068) return;
            ServerLogOutput.Clear();
            ServerLogOutput.AppendText("[Local] Maximum character length reached... Clear outpud window...");

        }

        private void ServerLogOutput_GotFocus(object sender, EventArgs e)
        {
            Utilitys.HideCaret(ServerLogOutput.Handle);
        }
    }
}
