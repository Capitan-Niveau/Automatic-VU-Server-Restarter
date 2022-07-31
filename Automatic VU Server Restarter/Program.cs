using System;
using System.IO;
using System.Windows.Forms;
using VU.Forms;

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
                Settings.SettingsManager.OpenSettings.Write("Settings", "CustomGamePath", "");
                Settings.SettingsManager.OpenSettings.Write("Settings", "InstancePath", "");
                Settings.SettingsManager.OpenSettings.Write("Settings", "ProConPath", "");
                Settings.SettingsManager.OpenSettings.Write("Settings", "UseCustomPath", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "DisableTerrainInterp", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "HighResTerrain", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "SkipChecksum", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "MakeUnlisted", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "DisableAutomaticUpdates", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "WritePerfProfile", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "SaveLoggingOutput", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "ProConCutDownVersion", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "UseProCon", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "ServerFrequency", "1");
                Settings.SettingsManager.OpenSettings.Write("Settings", "UseCustomRemoteAdress", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "UseCustomServerAdress", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "UseCustomHarmonyPort", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "ServerPort", "25200");
                Settings.SettingsManager.OpenSettings.Write("Settings", "HarmonyPort", "7948");
                Settings.SettingsManager.OpenSettings.Write("Settings", "RemoteAdminPort", "47200");
                Settings.SettingsManager.LoadSettings();
                Application.Run(new FrmSettings());
            }
            else
            {
                Settings.SettingsManager.LoadSettings();
                Application.Run(new FrmMain());
            }

        }
    }
}

