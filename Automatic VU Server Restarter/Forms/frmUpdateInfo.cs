using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VU.Forms;
using VU.Updater;
using FormCollection = VU.Forms.FormCollection;

namespace VU
{
    public partial class frmUpdateInfo : Form
    {
        public frmUpdateInfo()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void UpdateInfoRBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmUpdateInfo_Load(object sender, EventArgs e)
        {
            UpdateInfoRBox.LoadFile(CheckUpdate.InfoPath, RichTextBoxStreamType.RichText);
        }
    }
}
