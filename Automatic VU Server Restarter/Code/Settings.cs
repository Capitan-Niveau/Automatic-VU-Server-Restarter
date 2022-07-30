using System;
using Microsoft.Win32;
using INIReader;
using System.Windows.Forms;
using System.IO;

namespace VU.Settings
{
    class SettingsManager
    {
        internal static INI OpenSettings = new INI { Path = Environment.CurrentDirectory + "\\settings.ini" };
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
        internal static bool UseAutomaticUpdates = true;
        internal static bool UseWritePerfProfile;
        internal static bool UseSaveLoggingOutput;
        internal static bool UseProCon;
        internal static int ServerFrequency;

        internal static void LoadSettings()
        {
            CustomGamePath = OpenSettings.Read("Settings", "CustomGamePath");
            VuInstancePath = OpenSettings.Read("Settings", "InstancePath");
            ProConPath = OpenSettings.Read("Settings", "ProConPath");
            UseCustomGamePath = Convert.ToBoolean(OpenSettings.Read("Settings", "UseCustomPath"));
            UseSkipChecksumValidation = Convert.ToBoolean(OpenSettings.Read("Settings", "SkipChecksum"));
            UseCutDownProCon = Convert.ToBoolean(OpenSettings.Read("Settings", "ProConCutDownVersion"));
            UseSaveLoggingOutput = Convert.ToBoolean(OpenSettings.Read("Settings", "SaveLoggingOutput"));
            UseWritePerfProfile = Convert.ToBoolean(OpenSettings.Read("Settings", "WritePerfProfile"));
            UseAutomaticUpdates = Convert.ToBoolean(OpenSettings.Read("Settings", "DisableAutomaticUpdates"));
            MakeUnlisted = Convert.ToBoolean(OpenSettings.Read("Settings", "MakeUnlisted"));
            UseHighResTerrain = Convert.ToBoolean(OpenSettings.Read("Settings", "HighResTerrain"));
            UseDisableTerrainInterp = Convert.ToBoolean(OpenSettings.Read("Settings", "DisableTerrainInterp"));
            UseProCon = Convert.ToBoolean(OpenSettings.Read("Settings", "UseProCon"));
            ServerFrequency = Convert.ToInt32(OpenSettings.Read("Settings", "ServerFrequency"));
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
            return VuInstancePath;
        }
    }
}
