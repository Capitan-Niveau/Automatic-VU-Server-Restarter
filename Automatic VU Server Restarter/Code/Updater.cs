using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using VU.Forms;
using VU.Tools;

namespace VU.Updater
{
    internal class CheckUpdate
    {
        internal static WebClient Client;
        internal static readonly string InfoPath = $@"{Path.GetTempPath()}update_info.rtf";
        internal static readonly string UpdatePath = $@"{Application.StartupPath}\\update.exe";
        internal static readonly string CheckListPath = $"{Path.GetTempPath()}avusr_update.ini";
        internal static bool IsNewerVersion { get;  set; }
        internal static bool IsBetaVersion { get;  set; }
        internal static string Version { get;  set; }
        internal static string Md5Hash { get;  set; }
        internal static Uri UpdateInfoUrl { get; set; }
        internal static Uri UpdateUrl { get; set; }
        internal static int FileSize { get; set; }

        internal static Thread Md5Worker;

        internal static void CheckForUpdate(frmGetUpdateInfo target)
        {
            using (Client = new WebClient())
            {
                Client.DownloadFileCompleted += target.WC_GetCheckList_DownloadFileCompleted;
                try
                {
                    Client.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1R4JEuCdxT1_fgH4epeiWSLDtFpXsY0r-"), CheckListPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target.Close();
                }
            }
        }

        internal static void CheckForUpdateBg(FrmMain siletForm)
        {
            using (Client = new WebClient())
            {
                Client.DownloadFileCompleted += siletForm.WC_GetCheckList_DownloadFileCompleted;
                try
                {
                    Client.DownloadFileAsync(new Uri("https://drive.google.com/uc?export=download&id=1R4JEuCdxT1_fgH4epeiWSLDtFpXsY0r-"), CheckListPath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        internal static void DownloadInfoFile(frmGetUpdateInfo target)
        {
            using (Client = new WebClient())
            {
                Client.DownloadFileCompleted += target.WC_GetFile_DownloadInfoFileCompleted;
                try
                {
                    Client.DownloadFileAsync(UpdateInfoUrl, InfoPath);
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
            using (Client = new WebClient())
            {
                Client.DownloadFileCompleted += target.WC_GetFile_DownloadFileCompleted;
                Client.DownloadProgressChanged += target.WC_GetFile_ProgressChanged;
                try
                {
                    Client.DownloadFileAsync(UpdateUrl, UpdatePath);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    target.Close();
                }
            }
        }

        internal static void CheckUpdateFile(frmDownloadUpdate target, Label label = null, ProgressBar progressBar = null)
        {
            void Check()
            {
                InstallUpdate(target, label, progressBar);
            }

            Md5Worker = new Thread(Check)
            {
                Name = "Updater",
                IsBackground = true,
            };
            Md5Worker.Start();
        }

        private static void InstallUpdate(Form target, Label label, ProgressBar progressBar)
        {
            if (!string.Equals(Md5Hash,  Utilitys.GetMd5Hash(UpdatePath, label, progressBar)))
            {
                MessageBox.Show(@"The file has been modified or is corrupt. The update is aborted.", @"MD5 error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                File.Delete(CheckListPath);
                File.Delete(UpdatePath);
                File.Delete(UpdatePath);

                void CloseUpdaterAborted()
                {
                    target.Close();
                }
                target.Invoke((Action)CloseUpdaterAborted);
                return;
            }
            MessageBox.Show(@"The update will be applied when exiting the application.", @"Updater", MessageBoxButtons.OK, MessageBoxIcon.Information);
            target.BeginInvoke(new Action(() => target.Close()));
        }
    }
}
