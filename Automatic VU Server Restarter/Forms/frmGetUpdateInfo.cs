using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            InfoProgress.MarqueeAnimationSpeed = 40;
        }
    }
}
