using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using INIReader;
using VU.Forms;
using VU.Server;
using VU.Settings;

namespace VU.Updater
{
    internal class CheckUpdate
    {
        private static WebClient _client;
        internal static readonly string InfoPath = $@"{Path.GetTempPath()}update_info.rtf";
        internal static bool IsNewerVersion { get;  set; }
        internal static bool IsBetaVersion { get;  set; }
        internal static string Version { get;  set; }
        internal static string Md5Hash { get;  set; }
        internal static Uri UpdateInfoUrl { get; set; }
        internal static Uri UpdateUrl { get; set; }
        internal static Thread _md5Worker;

        internal static void CheckForUpdate(frmGetUpdateInfo target )
        {
            using (_client = new WebClient())
            {
                _client.DownloadFileCompleted += target.WC_GetCheckList_DownloadFileCompleted;
                try
                {
                    _client.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1R4JEuCdxT1_fgH4epeiWSLDtFpXsY0r-"), $"{Path.GetTempPath()}avusr_update.ini");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target.Close();
                }
            }
        }

        internal static void DownloadInfoFile(frmGetUpdateInfo target)
        {
            using (_client = new WebClient())
            {
                _client.DownloadFileCompleted += target.WC_GetFile_DownloadInfoFileCompleted;
                try
                {
                    _client.DownloadFileAsync(UpdateInfoUrl, InfoPath);
                }
                catch (Exception e)
                {
                    _client.Dispose();
                }
            }
        }

        internal static void DownloadFile(Form target)
        {
            using (_client = new WebClient())
            {
                _client.DownloadFileCompleted += WC_GetFile_DownloadFileCompleted;
                try
                {
                    _client.DownloadFileAsync(UpdateUrl, $@"{Path.GetTempPath()}update.exe");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _client.Dispose();
                    target.Close();
                }
            }
        }

        private static void WC_GetFile_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
    }
}
