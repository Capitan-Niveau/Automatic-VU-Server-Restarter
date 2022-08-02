using System;
using System.IO;
using System.Windows.Forms;
using VU.Forms;
using System.Threading.Tasks;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists("settings.ini") == false)
            {
                File.Create("settings.ini").Close();
                Settings.SettingsManager.OpenIni.Write("Settings", "CustomGamePath", "");
                Settings.SettingsManager.OpenIni.Write("Settings", "InstancePath", "");
                Settings.SettingsManager.OpenIni.Write("Settings", "ProConPath", "");
                Settings.SettingsManager.OpenIni.Write("Settings", "UseCustomPath", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "DisableTerrainInterp", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "HighResTerrain", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "SkipChecksum", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "MakeUnlisted", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "DisableAutomaticUpdates", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "WritePerfProfile", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "SaveLoggingOutput", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "ProConCutDownVersion", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "UseProCon", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "ServerFrequency", "1");
                Settings.SettingsManager.OpenIni.Write("Settings", "UseCustomRemotePort", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "UseCustomServerPort", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "UseCustomHarmonyPort", "false");
                Settings.SettingsManager.OpenIni.Write("Settings", "ServerPort", "25200");
                Settings.SettingsManager.OpenIni.Write("Settings", "HarmonyPort", "7948");
                Settings.SettingsManager.OpenIni.Write("Settings", "RemoteAdminPort", "47200");
                Settings.SettingsManager.LoadSettings();
                Application.Run(new FrmMain());
            }
            else
            {
                Settings.SettingsManager.LoadSettings();
                Application.Run(new FrmMain());
            }

        }
    }
}

