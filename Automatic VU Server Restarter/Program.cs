using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VU.Forms;
using VU.Settings;
using VU.Tools;

namespace VU
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (AllRequiredFilesAvailable())
                Environment.Exit(1);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OnStartUpCheck();
            if (File.Exists(Application.StartupPath + "\\" + "settings.ini") == false)
            {
                File.Create(Application.StartupPath + "\\" + "settings.ini").Close();
                SettingsManager.OpenIni.Write("Settings", "CustomGamePath", "");
                SettingsManager.OpenIni.Write("Settings", "InstancePath", "");
                SettingsManager.OpenIni.Write("Settings", "ProConPath", "");
                SettingsManager.OpenIni.Write("Settings", "UseCustomPath", "false");
                SettingsManager.OpenIni.Write("Settings", "DisableTerrainInterp", "false");
                SettingsManager.OpenIni.Write("Settings", "HighResTerrain", "false");
                SettingsManager.OpenIni.Write("Settings", "SkipChecksum", "false");
                SettingsManager.OpenIni.Write("Settings", "MakeUnlisted", "false");
                SettingsManager.OpenIni.Write("Settings", "DisableAutomaticUpdates", "false");
                SettingsManager.OpenIni.Write("Settings", "WritePerfProfile", "false");
                SettingsManager.OpenIni.Write("Settings", "SaveLoggingOutput", "false");
                SettingsManager.OpenIni.Write("Settings", "ProConCutDownVersion", "false");
                SettingsManager.OpenIni.Write("Settings", "UseProCon", "false");
                SettingsManager.OpenIni.Write("Settings", "ServerFrequency", "1");
                SettingsManager.OpenIni.Write("Settings", "UseCustomRemotePort", "false");
                SettingsManager.OpenIni.Write("Settings", "UseCustomServerPort", "false");
                SettingsManager.OpenIni.Write("Settings", "UseCustomHarmonyPort", "false");
                SettingsManager.OpenIni.Write("Settings", "UseAutoStart", "false");
                SettingsManager.OpenIni.Write("Settings", "AVUSRUpdates", "false");
                SettingsManager.OpenIni.Write("Settings", "ServerPort", "25200");
                SettingsManager.OpenIni.Write("Settings", "HarmonyPort", "7948");
                SettingsManager.OpenIni.Write("Settings", "RemotePort", "47200");
                SettingsManager.LoadSettings();
                Application.Run(new FrmMain());
            }
            else
            {
                OnStartUpCheck();
                SettingsManager.LoadSettings();
                Application.Run(new FrmMain());
            }

        }

        private static bool IsFileAvailable(string fileName)
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar;
            if (!File.Exists(path + fileName))
            {
                MessageBox.Show($@"The following file could not be found: {fileName}" + "\n" + @"Please repair or reinstall the program.", @"File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                return false;
            }
            return false;
        }

        private static bool AllRequiredFilesAvailable()
        {
            if (!IsFileAvailable("ini.dll"))
                return false;
            return true;
        }

        private static void OnStartUpCheck()
        {
            if (!Utilitys.CheckIfVuInstalled())
            {
                var vuNotInstalled = MessageBox.Show(@"Venice Unleashed is not installed, do you want to download it now?", @"Missing VU", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (vuNotInstalled)
                {
                    case DialogResult.Yes:
                        Process.Start("https://veniceunleashed.net/");
                        Environment.Exit(0);
                        break;
                    case DialogResult.No:
                        Environment.Exit(0);
                        return;
                }
            }

            if (!Utilitys.CheckIfBfInstalled())
            {
                MessageBox.Show(@"The battlefield 3 installation could not be found. Please select the path to the installation in the settings.", @"Missing BF3", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            SettingsManager.LoadSettings();
            Application.Run(new FrmMain());
        }
    }
}


