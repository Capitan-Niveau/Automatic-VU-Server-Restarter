using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rcon.Net;
using VU.Settings;
using VU.Tools;

namespace VU.Server
{
    internal class HostServer
    {

        internal TextBox OutPudBox;
        internal Form MainForm;
        private Process _serverProcess;
        private Client _rconClient;
        private Dictionary<string, string> _serverPassword;
        private Dictionary<string, string> _serverMaxPlayerCount;
        private Dictionary<string, string> _gameServerName;

        private string RConPassword { get; set; }
        private bool CanSendCommands => _rconClient != null && _rconClient.IsOpen;
        private string _line;

        internal int ServerExitCode { get; set; }
        internal int ServerPid { get; set; }
        internal int ServerFps { get; private set; }
        internal int PlayerCount { get; set; }
        internal int MemUsage { get; set; }
        internal string MaxPlayerCount { get; private set; }
        internal string ServerName { get; private set; }
        internal string MapName { get; private set; }
        internal string ModeName { get; private set; }
        internal string ServerStatus { get; set; }
        internal bool ServerKeyInUse { get; set; }

        internal bool IsRunning()
        {
            return _serverProcess != null && !_serverProcess.HasExited;
        }

        internal void DisposeServer()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
                _serverProcess.Kill();

            if (Utilitys.ProConProcess != null && !Utilitys.ProConProcess.HasExited)
                Utilitys.ProConProcess.Kill();

            if (_rconClient != null && _rconClient.IsOpen)
                _rconClient.Close();
        }

        private void LoadServerConfig()
        {
            _serverPassword = new Dictionary<string, string>();
            _serverMaxPlayerCount = new Dictionary<string, string>();
            _gameServerName = new Dictionary<string, string>();

            var configLines = File.ReadAllLines(SettingsManager.VuInstancePath + "\\Admin\\Startup.txt");
            var mapLines = File.ReadAllLines(SettingsManager.VuInstancePath + "\\Admin\\Maplist.txt");
            var trim = Regex.Replace(mapLines[0], @"\s+", ",");

            var firstMapMode = trim.Split(',');

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
            MapName = Utilitys.RealMapName(firstMapMode[0]);
            ModeName = Utilitys.RealModeName(firstMapMode[1]);
        }

        internal void Start()
        {
            if (_serverProcess != null && !_serverProcess.HasExited)
            {
                MessageBox.Show(@"Server is already running", @"Server", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LoadServerConfig();
                _rconClient = new Client();
                _rconClient.WordsReceived += RconClient_WordsReceived;
                RConPassword = _serverPassword["admin.password"];
                MaxPlayerCount = _serverMaxPlayerCount["vars.maxPlayers"];
                ServerName = _gameServerName["vars.serverName"];
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
                ServerPid = _serverProcess.Id;
                _serverProcess.WaitForExit();
                ServerExitCode = _serverProcess.ExitCode;
            }
        }

        internal void RefreshMemUsage()
        {
            if (_serverProcess.HasExited)
            {
                return;
            }
            _serverProcess.Refresh();
            MemUsage = _serverProcess.WorkingSet;
        }



        private async void ServerProcess_DataReceived(object sender, DataReceivedEventArgs e)
        {
            _line = e.Data;

            if (string.IsNullOrWhiteSpace(_line))
                return;

            Utilitys.GetServerBuild(_line);

            if (OutPudBox.InvokeRequired)
            {
                void LogOutPudWindow()
                {
                    OutPudBox.AppendText(Environment.NewLine + _line);
                }
                OutPudBox.Invoke((Action)LogOutPudWindow);
            }

            if (!Utilitys.CheckIfKeyIsInUse(_line))
            {
                ServerKeyInUse = true;
                MessageBox.Show(@"The provided server key is already in use. Shutting down.", @"VU Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.Match(_line, @"\[.+\] \[.+\] Monitored Harmony server listening on 0.0.0.0:\d+").Success) return;

            _rconClient.Open(IPAddress.Loopback, Convert.ToInt32(SettingsManager.RemoteAdminPort));
            await _rconClient.SendMessageAsync("login.plainText", RConPassword);
            ServerStatus = "Server: Online";
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
                    MapName = Utilitys.RealMapName(words[1]);
                    ModeName = Utilitys.RealModeName(words[2]);
                    break;
                default:
                    break;
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
                    ServerFps = int.Parse(responseWords[0]);
                    break;
                }
            }

        }

        internal async void GetServerFps()
        {
            if (!CanSendCommands) return;
            await GetServerFps(Utilitys.SplitStringBySpace("vu.Fps")).ConfigureAwait(false);
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

                        if (OutPudBox.InvokeRequired)
                        {
                            void LogOutPudWindow()
                            {
                                OutPudBox.AppendText(Environment.NewLine + "[Local] RCON unavailable!");
                            }
                            OutPudBox.Invoke((Action)LogOutPudWindow);
                        }
                        return;
                    default:
                    {
                        var responseWords = await SendCommandAsync(words);
                        if (OutPudBox.InvokeRequired)
                        {
                            void LogOutPudWindow()
                            {
                                OutPudBox.AppendText(Environment.NewLine + $"[Server] RCON: {string.Join(" ", responseWords)}");
                                }
                            OutPudBox.Invoke((Action)LogOutPudWindow);
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (OutPudBox.InvokeRequired)
                {
                    void LogOutPudWindow()
                    {
                        OutPudBox.AppendText(Environment.NewLine + $"[Local] RCON: {ex.InnerException}");
                    }
                    OutPudBox.Invoke((Action)LogOutPudWindow);
                }
            }
        }

        internal void SendRConCommand(string command)
        {
            Command_SendRCONCommand(Utilitys.SplitStringBySpace(command));
        }
    }
}
