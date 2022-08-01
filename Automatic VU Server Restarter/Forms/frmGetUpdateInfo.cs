using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using INIReader;
using VU.Updater;

namespace VU.Forms
{
    public partial class frmGetUpdateInfo : Form
    {
        public frmGetUpdateInfo()
        {
            InitializeComponent();
        }

        private void AbortBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmGetUpdateInfo_Load(object sender, EventArgs e)
        {
            timer1.Start();
            InfoProgress.MarqueeAnimationSpeed = 40;
            CheckUpdate.CheckForUpdate(this);
   
        }

        internal void WC_GetCheckList_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            var UpdateInfo = new INI { Path = $"{Path.GetTempPath()}avusr_update.ini" };
            CheckUpdate.Version = UpdateInfo.Read("Updater", "Version");
            CheckUpdate.Md5Hash = UpdateInfo.Read("Updater", "MD5");
            CheckUpdate.UpdateUrl = new Uri(UpdateInfo.Read("Updater", "FileUrl"));
            CheckUpdate.UpdateInfoUrl = new Uri(UpdateInfo.Read("Updater", "InfoUrl"));
            CheckUpdate.IsNewerVersion = Application.ProductVersion.Equals(CheckUpdate.Version);
            CheckUpdate.IsBetaVersion = Convert.ToBoolean(UpdateInfo.Read("Updater", "BetaVersion"));
            if (CheckUpdate.IsNewerVersion)
            {
                CheckUpdate.DownloadInfoFile(this);
            }
            else
            {
                MessageBox.Show("No new updates could be found.", "No new Updates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        internal void WC_GetFile_DownloadInfoFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.Hide();
            FormCollection.UpdateInfo.ShowDialog();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
