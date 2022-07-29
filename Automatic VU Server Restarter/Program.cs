﻿using System;
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
                Settings.SettingsManager.OpenSettings.Write("Settings", "Unlisted", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "DisableAutomaticUpdates", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "WritePerfProfile", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "SaveLoggingOutput", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "ProConCutDownVersion", "false");
                Settings.SettingsManager.OpenSettings.Write("Settings", "ServerFrequency", "1");
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

