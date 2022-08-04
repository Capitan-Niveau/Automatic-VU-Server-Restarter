using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VU.Forms;
using VU.Updater;

namespace VU.Forms
{
    public partial class frmUpdateInfo : Form
    {
        public frmUpdateInfo()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            File.Delete(CheckUpdate.CheckListPath);
            File.Delete(CheckUpdate.UpdatePath);
            Close();
        }

        private void frmUpdateInfo_Load(object sender, EventArgs e)
        {
            UpdateInfoRBox.LoadFile(CheckUpdate.InfoPath, RichTextBoxStreamType.RichText);
            Icon = Properties.Resources.Update;
        }

        private void UpdateNowBtn_Click(object sender, EventArgs e)
        {
            frmDownloadUpdate showDownloadForm = new frmDownloadUpdate();
            showDownloadForm.Show();
            Close();
        }
    }
}
