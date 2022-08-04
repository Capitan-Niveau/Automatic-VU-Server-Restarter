using System;
using System.Collections.Generic;
using Microsoft.Win32;
using INIReader;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace VU.Settings
{
    class SettingsManager
    {
        internal static INI OpenIni = new INI { Path = Application.StartupPath + "\\" + "settings.ini" };
        internal static string BattlefieldInstallDir = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\EA Games\Battlefield 3", "Install Dir", null);
        internal static string CustomGamePath;
        internal static string VuPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\VeniceUnleashed\\client";
        internal static string VuInstancePath;
        internal static string ProConPath;
        internal static bool UseCustomGamePath;
        internal static bool UseSkipChecksumValidation;
        internal static bool UseCutDownProCon;
        internal static bool UseDisableTerrainInterp;
        internal static bool UseHighResTerrain;
        internal static bool MakeUnlisted;
        internal static bool UseAutomaticUpdates;
        internal static bool UseWritePerfProfile;
        internal static bool UseSaveLoggingOutput;
        internal static bool UseProCon;
        internal static bool UseCustomRemoteAdress;
        internal static bool UseCustomServerAdress;
        internal static bool UseCustomHarmonyPort;
        internal static bool UseAutoStart;
        internal static bool AVUSRUpdates;
        internal static int ServerFrequency;
        internal static string HarmonyPort;
        internal static string ServerPort;
        internal static string RemoteAdminPort;
        internal static List<string> Languages = new List<string>();

        internal static void LoadSettings()
        {
            CustomGamePath = OpenIni.Read("Settings", "CustomGamePath");
            VuInstancePath = OpenIni.Read("Settings", "InstancePath");
            ProConPath = OpenIni.Read("Settings", "ProConPath");
            UseCustomGamePath = Convert.ToBoolean(OpenIni.Read("Settings", "UseCustomPath"));
            UseSkipChecksumValidation = Convert.ToBoolean(OpenIni.Read("Settings", "SkipChecksum"));
            UseCutDownProCon = Convert.ToBoolean(OpenIni.Read("Settings", "ProConCutDownVersion"));
            UseSaveLoggingOutput = Convert.ToBoolean(OpenIni.Read("Settings", "SaveLoggingOutput"));
            UseWritePerfProfile = Convert.ToBoolean(OpenIni.Read("Settings", "WritePerfProfile"));
            UseAutomaticUpdates = Convert.ToBoolean(OpenIni.Read("Settings", "DisableAutomaticUpdates"));
            MakeUnlisted = Convert.ToBoolean(OpenIni.Read("Settings", "MakeUnlisted"));
            UseHighResTerrain = Convert.ToBoolean(OpenIni.Read("Settings", "HighResTerrain"));
            UseDisableTerrainInterp = Convert.ToBoolean(OpenIni.Read("Settings", "DisableTerrainInterp"));
            UseProCon = Convert.ToBoolean(OpenIni.Read("Settings", "UseProCon"));
            ServerFrequency = Convert.ToInt32(OpenIni.Read("Settings", "ServerFrequency"));
            UseCustomRemoteAdress = Convert.ToBoolean(OpenIni.Read("Settings", "UseCustomRemotePort"));
            UseCustomServerAdress = Convert.ToBoolean(OpenIni.Read("Settings", "UseCustomServerPort"));
            UseCustomHarmonyPort = Convert.ToBoolean(OpenIni.Read("Settings", "UseCustomHarmonyPort"));
            CustomGamePath = OpenIni.Read("Settings", "CustomGamePath");
            VuInstancePath = OpenIni.Read("Settings", "InstancePath");
            ProConPath = OpenIni.Read("Settings", "ProConPath");
            HarmonyPort = OpenIni.Read("Settings", "HarmonyPort");
            ServerPort = OpenIni.Read("Settings", "ServerPort");
            RemoteAdminPort = OpenIni.Read("Settings", "RemotePort");
            UseAutoStart = Convert.ToBoolean(OpenIni.Read("Settings", "UseAutoStart"));
            AVUSRUpdates = Convert.ToBoolean(OpenIni.Read("Settings", "AVUSRUpdates"));
        }


        internal static string GetGamePath()
        {
            return UseCustomGamePath ? File.Exists(CustomGamePath + "\\bf3.exe") ? CustomGamePath : null :
                File.Exists(BattlefieldInstallDir + "\\bf3.exe") ? BattlefieldInstallDir : null;
        }

        internal static string GetVuPath()
        {
            return File.Exists(VuPath + "\\vu.exe") ? VuPath : null;
        }

        internal static string GetVuInstancePath()
        {
            return File.Exists(VuInstancePath + "\\server.key") ? VuInstancePath : null;
        }
    }
}
