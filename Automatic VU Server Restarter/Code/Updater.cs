using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using VU.Forms;
using VU.Server;

namespace VU.Updater
{
    internal class CheckUpdate
    {
        internal static WebClient _client;
        internal static readonly string InfoPath = $@"{Path.GetTempPath()}update_info.rtf";
        internal static readonly string UpdatePath = $@"{Path.GetTempPath()}update.exe";
        internal static readonly string CheckListPath = $"{Path.GetTempPath()}avusr_update.ini";
        internal static bool IsNewerVersion { get;  set; }
        internal static bool IsBetaVersion { get;  set; }
        internal static string Version { get;  set; }
        internal static string Md5Hash { get;  set; }
        internal static Uri UpdateInfoUrl { get; set; }
        internal static Uri UpdateUrl { get; set; }
        internal static int FileSize { get; set; }
        internal static Thread _md5Worker;

        internal static void CheckForUpdate(frmGetUpdateInfo target)
        {
            using (_client = new WebClient())
            {
                _client.DownloadFileCompleted += target.WC_GetCheckList_DownloadFileCompleted;
                try
                {
                    _client.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1R4JEuCdxT1_fgH4epeiWSLDtFpXsY0r-"), CheckListPath);
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
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target.Close();
                }
            }
        }

        internal static void DownloadFile(frmDownloadUpdate target)
        {
            using (_client = new WebClient())
            {
                _client.DownloadFileCompleted += target.WC_GetFile_DownloadFileCompleted;
                _client.DownloadProgressChanged += target.WC_GetFile_ProgressChanged;
                try
                {
                    _client.DownloadFileAsync(UpdateUrl, UpdatePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target.Close();
                }
            }
        }

        internal static void CheckUpdateFile(Label label = null, ProgressBar progressBar = null)
        {
            void Check()
            {
                Md5Check(label, progressBar);
            }

            _md5Worker = new Thread(Check)
            {
                Name = "MD5::Checker",
                IsBackground = true,
            };
            _md5Worker.Start();
        }

        private static void Md5Check(Label label, ProgressBar progressBar)
        {

            MessageBox.Show(Utilitys.GetMd5Hash(UpdatePath, label, progressBar));
        }
    }
}
