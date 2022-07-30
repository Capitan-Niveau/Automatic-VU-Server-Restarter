using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace VU.Server
{
    internal class Utilitys
    {
        private static DateTime _lastTime;
        private static TimeSpan _lastTotalProcessorTime;
        private static DateTime _curTime;
        private static TimeSpan _curTotalProcessorTime;
        private static readonly Regex GetBuildNumber = new Regex(@"\(.*\)");
        private static readonly NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
        internal static string ServerVersion { get; set; }
        internal static bool ServerKeyIsUsed { get; set; }

        [DllImport("user32.dll", EntryPoint = "HideCaret")]
        internal static extern long HideCaret(IntPtr hWnd);

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
            if (!Regex.Match(line, @"\[.+\] \[.+\] The provided server key is already in use. Shutting down.").Success) return;
            {
                ServerKeyIsUsed = true;
            }
        }

        internal static string AssemblyCopyright
        {
            get
            {
                var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                return attributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
    }
}