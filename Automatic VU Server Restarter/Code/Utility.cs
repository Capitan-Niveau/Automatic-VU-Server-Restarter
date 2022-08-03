using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VU.Settings;
using INIReader;

namespace VU.Server
{
    internal class Utilitys
    {
        private static DateTime _lastTime;
        private static TimeSpan _lastTotalProcessorTime;
        private static DateTime _curTime;
        private static TimeSpan _curTotalProcessorTime;
        private static readonly Regex GetBuildNumber = new Regex(@"\(.*\)");
        internal static string ServerVersion { get; set; }
        internal static bool ServerKeyIsUsed { get; set; }

        internal static Process ProConProcess;

        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        internal static extern long HideCaret(IntPtr hWnd);

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lparam);

        internal static double ServerCpuUsage(int pid)
        {
            try
            {
                switch (pid > 0)
                {
                    case true:
                    {
                        while (true)
                        {
                            Process pp = Process.GetProcessById(pid);

                            if (_lastTime == null || _lastTime == new DateTime())
                            {
                                _lastTime = DateTime.Now;
                                _lastTotalProcessorTime = pp.TotalProcessorTime;
                            }
                            else
                            {
                                _curTime = DateTime.Now;
                                _curTotalProcessorTime = pp.TotalProcessorTime;

                                double cpuUsage =
                                    (_curTotalProcessorTime.TotalMilliseconds -
                                     _lastTotalProcessorTime.TotalMilliseconds) /
                                    _curTime.Subtract(_lastTime).TotalMilliseconds /
                                    Convert.ToDouble(Environment.ProcessorCount);

                                _lastTime = _curTime;
                                _lastTotalProcessorTime = _curTotalProcessorTime;
                                return cpuUsage * 100;
                            }
                        }
                    }
                    default:
                        return 0.0;
                }
            }
            catch (Exception e)
            {
                return 0.0;
            }
        }


        internal static List<string> SplitStringBySpace(string str)
        {
            return Regex.Matches(str, @"[\""].+?[\""]|[^ ]+").Cast<Match>().Select(m => m.Value).ToList();
        }

        internal static string SizeSuffix(long value, int decimalPlaces = 0)
        {
            var norm = new[] { "B", "kB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            const int factor = 1024;
            var count = norm.Length - 1;
            decimal size = value;
            var x = 0;

            while (size >= factor && x < count)
            {
                size /= factor;
                x++;
            }

            return $"{Math.Round(size, decimalPlaces, MidpointRounding.AwayFromZero)} {norm[x]}";
        }

        internal static void GetServerBuild(string line)
        {
            if (string.IsNullOrEmpty(ServerVersion))
            {
                switch (Regex.Match(line, @"\[.+\] \[.+\] Initializing Venice Unleashed Server \(.*\)").Success)
                {
                    case false:
                        return;
                    default:
                    {
                        var matches = GetBuildNumber.Matches(line);
                        ServerVersion = matches[0].Value.Replace('(', ' ').Replace(')', ' ').Remove(0, 7);
                        break;
                    }
                }
            }
        }

        internal static void CheckIfKeyIsInUse(string line)
        {
            if (!Regex.Match(line, @"\[.+\] \[.+\] The provided server key is already in use. Shutting down.")
                    .Success) return;
            {
                ServerKeyIsUsed = true;
            }
        }

        internal static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly()
                    .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        internal static void StartProCon(bool useCutDownVersion = false)
        {
            if (ProConProcess != null && !ProConProcess.HasExited)
            {
                MessageBox.Show(@"ProCon is already running", @"ProCon", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                if (useCutDownVersion)
                {
                    if (File.Exists(SettingsManager.ProConPath + "\\PRoCon.Console.exe"))
                    {
                        ProConProcess = new Process();
                        ProConProcess.StartInfo.FileName = SettingsManager.ProConPath + "\\PRoCon.Console.exe";
                        ProConProcess.StartInfo.WorkingDirectory = SettingsManager.ProConPath;
                        ProConProcess.StartInfo.CreateNoWindow = true;
                        ProConProcess.StartInfo.UseShellExecute = false;
                        ProConProcess.Start();
                    }
                }
                else
                {
                    if (File.Exists(SettingsManager.ProConPath + "\\PRoCon.exe"))
                    {
                        ProConProcess = new Process();
                        ProConProcess.StartInfo.FileName = SettingsManager.ProConPath + "PRoCon.exe";
                        ProConProcess.StartInfo.WorkingDirectory = SettingsManager.ProConPath;
                        ProConProcess.Start();
                    }
                }
            }
        }

        internal static string RealMapName(string map)
        {
            switch (map)
            {
                //BF3 Default Maps
                case "MP_001":
                    return "Grand Bazar";
                case "MP_003":
                    return "Teheran Highway";
                case "MP_007":
                    return "Caspian Border";
                case "MP_011":
                    return "Seine Crossing";
                case "MP_012":
                    return "Operation Firestorm";
                case "MP_013":
                    return "Damavand Peak";
                case "MP_017":
                    return "Noshahr Canals";
                case "MP_018":
                    return "Kharg Island";
                case "MP_Subway":
                    return "Operation Metro";
                //Back to Karkand Maps
                case "XP1_001":
                    return "Strike at Karkand";
                case "XP1_002":
                    return "Gulf of Oman";
                case "XP1_003":
                    return "Sharqi Peninsula";
                case "XP1_004":
                    return "Wake Island";
                //Close Quarters Maps
                case "XP2_Factory":
                    return "Scrapmetal";
                case "XP2_Office":
                    return "Operation 925";
                case "XP2_Palace":
                    return "Donya Fortress";
                case "XP2_Skybar":
                    return "Ziba Tower";
                //Armored Kill Maps
                case "XP3_Desert":
                    return "Bandar Desert";
                case "XP3_Alborz":
                    return "Alborz Mountains";
                case "XP3_Shield":
                    return "Armored Shield";
                case "XP3_Valley":
                    return "Death Valley";
                //Aftermath Maps
                case "XP4_FD":
                    return "Markaz Monolith";
                case "XP4_Parl":
                    return "Azadi Palace";
                case "XP4_Quake":
                    return "Epicenter";
                case "XP4_Rubbel":
                    return "Talah Market";
                //End Game
                case "XP5_01":
                    return "Operation Riverside";
                case "XP5_02":
                    return "Nebandan Flats";
                case "XP5_03":
                    return "Kiasar Railroad";
                case "XP5_04":
                    return "Sabalan Pipeline";
                default:
                    return null;
            }
        }

        internal static string RealModeName(string mode)
        {
            switch (mode)
            {
                case "ConquestLarge0":
                    return "Conquest Large";
                case "ConquestAssaultLarge0":
                    return "Conquest Assault Large";
                case "ConquestSmall0":
                    return "Conquest Small";
                case "ConquestAssaultSmall0":
                    return "Conquest Assault Small";
                case "ConquestAssaultSmall1":
                    return "Conquest Assault Small #2";
                case "RushLarge0":
                    return "Rush Large";
                case "SquadRush0":
                    return "Squad Rush";
                case "SquadDeathMatch0":
                    return "Squad Death Match";
                case "TeamDeathMatch0":
                    return "Team Death Match";
                case "TeamDeathMatchC0":
                    return "Team Death Match Close Quarters";
                case "GunMaster0":
                    return "Gun master";
                case "Domination0":
                    return "Domination";
                case "TankSuperiority0":
                    return "Tank Superiority";
                case "Scavenger0":
                    return "Scavenger";
                case "CaptureTheFlag0":
                    return "Capture The Flag";
                case "AirSuperiority0":
                    return "Air Superiority";
                default:
                    return null;
            }
        }

        internal static DateTime GetLinkerTime(string assembly, TimeZoneInfo target = null)
        {
            const int cPeHeaderOffset = 60;
            const int cLinkerTimestampOffset = 8;
            var buffer = new byte[2048];
            using (var stream = new FileStream(assembly, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);
            var offset = BitConverter.ToInt32(buffer, cPeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + cLinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);
            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);
            return localTime;
        }


        private static string MakeHashString(byte[] hashBytes)
        {
            var sb = new StringBuilder(32);
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        internal static string GetMd5Hash(string sFile, Label label, ProgressBar progressBar)
        {
            long totalyBytesRead = 0;
            try
            {
                using (Stream fStream = File.OpenRead(sFile))
                {
                    var size = fStream.Length;
                    using (HashAlgorithm hasher = MD5.Create())
                    {
                        byte[] buffer;
                        int bytesRead;
                        do
                        {
                            buffer = new byte[1024 * 8];
                            bytesRead = fStream.Read(buffer, 0, buffer.Length);
                            totalyBytesRead += bytesRead;
                            hasher.TransformBlock(buffer, 0, bytesRead, null, 0);
                            var hashProgress = (int)((double)totalyBytesRead / size * 100);
                            if (hashProgress > 100)
                            {
                                void UpdateControls()
                                    {
                                        label.Text = @"Generate the MD5 hash... 100%";
                                        progressBar.Value = 100;
                                    }

                                    label.Invoke((Action)UpdateControls);
                                    progressBar.Invoke((Action)UpdateControls);
                            }
                            else
                            {
                                void UpdateControls()
                                    {
                                        label.Text = $@"Generate the MD5 hash... {hashProgress}%";
                                        progressBar.Value = hashProgress;
                                    }
                                label.Invoke((Action)UpdateControls);
                                    progressBar.Invoke((Action)UpdateControls);
                            }
                        } while (bytesRead != 0);

                        hasher.TransformFinalBlock(buffer, 0, 0);
                        return MakeHashString(hasher.Hash);
                    }
                }
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }

        }

        internal static void ScrollTextBoxEnd(TextBox tb)
        {
            const uint EM_LINESCROLL = 0x00B6;
            const uint EM_GETFIRSTVISIBLELINE = 0x00CE;
            const uint EM_GETLINECOUNT = 0x00BA;

            var line = SendMessage(tb.Handle, EM_GETFIRSTVISIBLELINE, 0, 0);
            var linecount = SendMessage(tb.Handle, EM_GETLINECOUNT, 0, 0);
            SendMessage(tb.Handle, EM_LINESCROLL, 0, (uint)(linecount - line - 2));
            tb.Refresh();
        }
    }
}