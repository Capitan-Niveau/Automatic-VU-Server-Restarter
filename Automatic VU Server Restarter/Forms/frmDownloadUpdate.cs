using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using VU.Server;
using VU.Updater;

namespace VU.Forms
{
    public partial class frmDownloadUpdate : Form
    {

        private readonly Stopwatch _sw = new Stopwatch();

        public frmDownloadUpdate()
        {
            InitializeComponent();
        }

        private void frmDownloadUpdate_Load(object sender, EventArgs e)
        {
            CheckUpdate.DownloadFile(this);
            DownloadProgressProgBar.Maximum = CheckUpdate.FileSize;
            _sw.Start();
        }

        internal void WC_GetFile_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadProgressProgBar.Minimum = 0;
            DownloadProgressProgBar.Maximum = 100;
            DownloadSpeedLbl.Text = null;
            _sw.Stop();
            CheckUpdate.CheckUpdateFile(DownloadProgressLbl, DownloadProgressProgBar);
        }

        internal void WC_GetFile_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            var bytesec = e.BytesReceived / _sw.Elapsed.TotalSeconds;
            DownloadSpeedLbl.Text = $@"{Utilitys.SizeSuffix(Convert.ToInt64(bytesec), 2)} /s";
            DownloadProgressProgBar.Value = (int)e.BytesReceived;
            DownloadProgressLbl.Text = $@"Downloading update: {Utilitys.SizeSuffix(e.BytesReceived)} of {Utilitys.SizeSuffix(CheckUpdate.FileSize)} downloaded...";
        }

        private void frmDownloadUpdate_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
