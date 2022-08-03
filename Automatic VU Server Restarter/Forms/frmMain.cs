﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;
using System.IO;
using Rcon.Net;
using System.Net;
using System.Threading.Tasks;
using VU.Settings;
using VU.Server;

namespace VU.Forms
{
    public partial class FrmMain : Form
    {
        private int _serverExitCode;
        private int _serverPid;
        private int _restartCounter;
        private int _serverFps30SecMa;
        private int _serverFps;
        private Process _serverProcess;
        private Thread _serverThread;
        private Thread _updateControls;
        private string _rconPassword;
        private string _maxPlayerCount;
        private string _serverName;
        private string _line;
        private string[] _firstMapMode;
        private Client _rconClient;
        private Dictionary<string, string> _serverPassword;
        private Dictionary<string, string> _serverMaxPlayerCount;
        private Dictionary<string, string> _gameServerName;
        public int PlayerCount { get; private set; }
        public string Map { get; private set; }
        public string Mode { get; private set; }
        public bool CanSendCommands => _rconClient != null && _rconClient.IsOpen;

        public FrmMain()
        {
            InitializeComponent();
            Text = Properties.Resources.ProcName;
            Icon = Properties.Resources.AVUSR;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ProcessInfoLbl.Text = @"Server is not running";
            ServerCpuUsageLbl.Text = @"CPU usage: -";
            SlotUsageLbl.Text = @"Players online: -";
            MapNameLbl.Text = @"Map: -";
            ModeNameLbl.Text = @"Mode: -";
            ServerMemUsageLbl.Text = @"Physical memory usage: - / Peak: -";
            ServerNameLbl.Text = $@"Server name: -";
            ServerFpsLbl.Text = $@"FPS: - / Moving average (30s): -";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit(e);
        }

        private void Exit(FormClosingEventArgs e = null)
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                var stopServer = MessageBox.Show(@"The server is still running, do you want to shut it down?",
                    @"Server", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (stopServer)
                {
                    case DialogResult.Yes:
                        Stop();
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
            Stop();
            if (StartVuServerBtn.Visible)
            {
                StartVuServerBtn.Visible = false;
                StopVuServerBtn.Visible = true;
            }

            _serverThread = new Thread(Start)
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
        }

        private void Stop()
        {
            _serverPid = 0;
            _serverExitCode = 0;

            if (Utilitys.ServerKeyIsUsed)
                Utilitys.ServerKeyIsUsed = false;

            if (Utilitys.ProConProcess != null && !Utilitys.ProConProcess.HasExited)
                Utilitys.ProConProcess.Kill();

            if (_rconClient != null && _rconClient.IsOpen)
                _rconClient.Close();

            if (_serverProcess != null && !_serverProcess.HasExited)
                _serverProcess.Kill();

            if (_serverThread != null && _serverThread.IsAlive)
                _serverThread.Abort();

            if (_updateControls != null && _updateControls.IsAlive)
                _updateControls.Abort();

            //void ResetControlsOnStop()
            //{
                ServerNameLbl.Text = $@"Server name: {_serverName}";
                ProcessInfoLbl.Text = $@"Server is not running - Restarts since first execution: {_restartCounter}";
                ServerCpuUsageLbl.Text = @"CPU usage: -";
                SlotUsageLbl.Text = @"Players online: -";
                MapNameLbl.Text = @"Map: -";
                ModeNameLbl.Text = @"Mode: -";
                ServerMemUsageLbl.Text = @"Physical memory usage: - / Peak: -";
                ServerFpsLbl.Text = $@"FPS: - / Moving average (30s): -";
                StartVuServerBtn.Visible = true;
                StopVuServerBtn.Visible = false;
            //}
            //Invoke((Action)ResetControlsOnStop);

            //ServerNameLbl.Text = $@"Server name: {_serverName}";
            //ProcessInfoLbl.Text = $@"Server is not running - Restarts since first execution: {_restartCounter}";
            //ServerCpuUsageLbl.Text = @"CPU usage: -";
            //SlotUsageLbl.Text = @"Players online: -";
            //MapNameLbl.Text = @"Map: -";
            //ModeNameLbl.Text = @"Mode: -";
            //ServerMemUsageLbl.Text = @"Physical memory usage: - / Peak: -";
            //ServerFpsLbl.Text = $@"FPS: - / Moving average (30s): -";

            _serverFps = 0;
            _serverFps30SecMa = 0;
            _serverThread = null;
            _updateControls = null; 
            _serverProcess = null;
            Utilitys.ProConProcess = null;
            _rconClient = null;
            PlayerCount = 0;
        }


        private void Start()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                MessageBox.Show(@"Server is already running", @"Server", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if (!string.IsNullOrEmpty(SettingsManager.VuInstancePath))
                {
                    if (!File.Exists(SettingsManager.VuInstancePath + "\\server.key"))
                    {
                        if (DialogResult.OK == MessageBox.Show(
                                $@"The server key file could not be found in the specified path:" +
                                Environment.NewLine + $@"{SettingsManager.VuInstancePath}\server.key",
                                @"File not fount", MessageBoxButtons.OK, MessageBoxIcon.Error))
                        {
                            if (StartVuServerBtn.InvokeRequired && StopVuServerBtn.InvokeRequired)
                            {
                                void ShowHideBtn()
                                {
                                    StartVuServerBtn.Visible = true;
                                    StopVuServerBtn.Visible = false;
                                }

                                StartVuServerBtn.Invoke((Action)ShowHideBtn);
                                StopVuServerBtn.Invoke((Action)ShowHideBtn);
                            }

                            return;
                        }
                    }
                }

                LoadConfig();
                _rconClient = new Client();
                _rconClient.WordsReceived += RconClient_WordsReceived;
                _rconPassword = _serverPassword["admin.password"];
                _maxPlayerCount = _serverMaxPlayerCount["vars.maxPlayers"];
                _serverName = _gameServerName["vars.serverName"];
                _serverProcess = new Process();
                _serverProcess.StartInfo.FileName = SettingsManager.VuPath + "\\vu.exe";
                _serverProcess.StartInfo.WorkingDirectory = SettingsManager.VuPath;
                _serverProcess.StartInfo.CreateNoWindow = false;
                _serverProcess.StartInfo.RedirectStandardOutput = true;
                _serverProcess.StartInfo.RedirectStandardError = true;
                _serverProcess.StartInfo.UseShellExecute = false;
                _serverProcess.StartInfo.Arguments = "-server -dedicated -headless";

                _serverProcess.StartInfo.Arguments += $" -listen 0.0.0.0:{SettingsManager.ServerPort}";
                _serverProcess.StartInfo.Arguments += $" -mHarmonyPort {SettingsManager.HarmonyPort}";
                _serverProcess.StartInfo.Arguments += $" -RemoteAdminPort 0.0.0.0:{SettingsManager.RemoteAdminPort}";

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

                _serverProcess.OutputDataReceived += ServerProcess_DataReceived;
                _serverProcess.Start();
                _serverProcess.BeginErrorReadLine();
                _serverProcess.BeginOutputReadLine();
                _serverPid = _serverProcess.Id;
                _serverProcess.WaitForExit();
                _serverExitCode = _serverProcess.ExitCode;
            }
        }

        private async void ServerProcess_DataReceived(object sender, DataReceivedEventArgs e)
        {
            _line = e.Data;

            if (string.IsNullOrWhiteSpace(_line))
                return;

            Utilitys.GetServerBuild(_line);
            Utilitys.CheckIfKeyIsInUse(_line);

            if (ServerLogOutput.InvokeRequired)
            {
                void WriteLog()
                {
                    ServerLogOutput.Text += Environment.NewLine + _line;
                }

                ServerLogOutput.Invoke((Action)WriteLog);
            }

            if (!Regex.Match(_line, @"\[.+\] \[.+\] Monitored Harmony server listening on 0.0.0.0:\d+").Success) return;
            _rconClient.Open(IPAddress.Loopback, Convert.ToInt32(SettingsManager.RemoteAdminPort));

            await _rconClient.SendMessageAsync("login.plainText", _rconPassword);
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
                case "server.onLevelLoaded":
                    Map = words[1];
                    Mode = words[2];
                    break;
                default:
                    break;
            }
        }

        private void LoadConfig()
        {
            _serverPassword = new Dictionary<string, string>();
            _serverMaxPlayerCount = new Dictionary<string, string>();
            _gameServerName = new Dictionary<string, string>();

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
                            _gameServerName.Add(configParts[0], configParts[1].Replace("\"", string.Empty));
                            break;
                    }

                }
            }

            Map = _firstMapMode[0];
            Mode = _firstMapMode[1];
        }

        private void StartServer_Click(object sender, EventArgs e)
        {
            _serverThread = new Thread(Start)
            {
                Name = "Server::Logging",
                IsBackground = true
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
            StartVuServerBtn.Visible = false;
            StopVuServerBtn.Visible = true;
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
            if (DialogResult.OK == FormCollection.SettingsForm.ShowDialog())
            {
                SettingsManager.LoadSettings();
            }
        }

        private async Task GetServerFps(IList<string> command)
        {
            switch (CanSendCommands)
            {
                case false:
                    return;
                default:
                {
                    var responseWords = await SendCommandAsync(command);
                    _serverFps = int.Parse(responseWords[0]);
                    break;
                }
            }

        }

        private async Task GetServerFps30SecMa(IList<string> command)
        {
            switch (CanSendCommands)
            {
                case false:
                    return;
                default:
                {
                    var responseWords = await SendCommandAsync(command);
                    _serverFps30SecMa = int.Parse(responseWords[0]);
                    break;
                }
            }
        }


        internal async void GetServerFps()
        {
            if (!CanSendCommands) return;
            await GetServerFps(Utilitys.SplitStringBySpace("vu.Fps")).ConfigureAwait(false);
            await GetServerFps30SecMa(Utilitys.SplitStringBySpace("vu.FpsMa")).ConfigureAwait(false);
        }


        private void UpdateControls()
        {
            do
            {
                Thread.Sleep(1000);
                switch (Utilitys.ServerKeyIsUsed)
                {
                    case true:
                    {
                        if (DialogResult.OK == MessageBox.Show(@"The provided server key is already in use. Shutting down.", @"VU Server", MessageBoxButtons.OK, MessageBoxIcon.Error))
                        {
                            Invoke((Action)Stop);
                        }
                        break;
                    }
                }

                if (_serverExitCode > 0)
                {
                    if (ServerLogOutput.InvokeRequired)
                    {
                        void WriteCrashLog()
                        {
                            ServerLogOutput.AppendText(Environment.NewLine + $"[Local] Server crashed with exit code {_serverExitCode}... restarting...");
                            RestartServer();
                        }
                        Invoke((Action)WriteCrashLog);
                    }
                    _restartCounter++;
                }
                else
                {
                    if (_serverPid < 0) return;
                    _serverProcess?.Refresh();

                    GetServerFps();

                    if (ProcessInfoLbl.InvokeRequired)
                    {
                        void WriteProcInfo()
                        {
                            ProcessInfoLbl.Text = $@"Server with PID {_serverPid} is running - Restarts since first execution: {_restartCounter} / Version: {Utilitys.ServerVersion}";
                        }
                        ProcessInfoLbl.Invoke((Action)WriteProcInfo);
                    }

                    if (ServerCpuUsageLbl.InvokeRequired)
                    {
                        void WriteCpuUsage()
                        {
                            ServerCpuUsageLbl.Text = $@"CPU usage: {Utilitys.ServerCpuUsage(_serverPid):0.0}%";
                        }
                        ServerCpuUsageLbl.Invoke((Action)WriteCpuUsage);
                    }


                    if (ServerMemUsageLbl.InvokeRequired && !_serverProcess.HasExited)
                    {
                        void WriteMemUsage()
                        {
                            ServerMemUsageLbl.Text = $@"Physical memory usage: {Utilitys.SizeSuffix(_serverProcess.WorkingSet64, 2)} / Peak: {Utilitys.SizeSuffix(_serverProcess.PeakWorkingSet64, 2)}";
                        }
                        ServerMemUsageLbl.Invoke((Action)WriteMemUsage);
                    }

                    if (ServerNameLbl.InvokeRequired)
                    {
                        void WriteServerName()
                        {
                            ServerNameLbl.Text = $@"Server name: {_serverName}";
                        }
                        ServerNameLbl.Invoke((Action)WriteServerName);
                    }

                    if (SlotUsageLbl.InvokeRequired)
                    {
                        void WriteSlotUsage()
                        {
                            SlotUsageLbl.Text = $@"Players online: {PlayerCount} of {_maxPlayerCount}";
                        }
                        SlotUsageLbl.Invoke((Action)WriteSlotUsage);
                    }

                    if (MapNameLbl.InvokeRequired)
                    {
                        void WriteMapName()
                        {
                            MapNameLbl.Text = $@"Map: {Utilitys.RealMapName(Map)}";
                        }
                        MapNameLbl.Invoke((Action)WriteMapName);
                    }

                    if (ModeNameLbl.InvokeRequired)
                    {
                        void WriteModeName()
                        {
                            ModeNameLbl.Text = $@"Mode: {Utilitys.RealModeName(Mode)}";
                        }
                        ModeNameLbl.Invoke((Action)WriteModeName);
                    }

                    if (ServerFpsLbl.InvokeRequired)
                    {
                        void WriteServerFps()
                        {
                            ServerFpsLbl.Text = $@"FPS: {_serverFps} / Moving average (30s): {_serverFps30SecMa}";
                        }
                        ServerFpsLbl.Invoke((Action)WriteServerFps);
                    }
                }
            } while (!_serverProcess.HasExited);
        }

        //private void ServerInfoUpdater_Tick(object sender, EventArgs e)
        //{
        //    switch (Utilitys.ServerKeyIsUsed)
        //    {
        //        case true:
        //        {
        //            ServerInfoUpdater.Stop();
        //            if (DialogResult.OK == MessageBox.Show(@"The provided server key is already in use. Shutting down.", @"VU Server", MessageBoxButtons.OK, MessageBoxIcon.Error))
        //            {
        //                Stop();
        //            }
        //            break;
        //        }
        //    }

        //    switch (_serverExitCode > 0)
        //    {
        //        case true:
        //            ServerLogOutput.AppendText(Environment.NewLine + $"[Local] Server crashed with exit code {_serverExitCode}... restarting...");
        //            _restartCounter++;
        //            RestartServer();
        //            break;
        //        default:
        //        {
        //            if (_serverPid > 0)
        //            {
        //                _serverProcess.Refresh();

        //                ProcessInfoLbl.Text = $@"Server with PID {_serverPid} is running - Restarts since first execution: {_restartCounter} / Version: {Utilitys.ServerVersion}";
        //                ServerCpuUsageLbl.Text = $@"CPU usage: {Utilitys.ServerCpuUsage(_serverPid):0.0}%";
        //                ServerNameLbl.Text = $@"Server name: {_serverName}";
        //                SlotUsageLbl.Text = $@"Players online: {PlayerCount} of {_maxPlayerCount}";
        //                MapNameLbl.Text = $@"Map: {Utilitys.RealMapName(Map)}";
        //                ModeNameLbl.Text = $@"Mode: {Utilitys.RealModeName(Mode)}";
        //                GetServerFps();
        //                ServerFpsLbl.Text = $@"FPS: {_serverFps} / Moving average (30s): {_serverFps30SecMa}";
        //                try
        //                {
        //                    ServerMemUsageLbl.Text = $@"Physical memory usage: {Utilitys.SizeSuffix(_serverProcess.WorkingSet64, 1)} / Peak: {Utilitys.SizeSuffix(_serverProcess.PeakWorkingSet64, 1)}";
        //                }
        //                catch (Exception)
        //                {
        //                    // ignored
        //                }
        //            }

        //            break;
        //        }
        //    }
        //}

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
                        ServerLogOutput.AppendText(Environment.NewLine +
                                                   $"[Server] RCON: {string.Join(" ", responseWords)}");
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
            FormCollection.GetUpdateInfo.Show();
        }

        private void AboutBtn_Click(object sender, EventArgs e)
        {
            FormCollection.AboutForm.ShowDialog();
        }

        private void ServerLogOutput_TextChanged(object sender, EventArgs e)
        {
            Utilitys.ScrollTextBoxEnd(ServerLogOutput);
            //ServerLogOutput.ScrollToEnd;
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
