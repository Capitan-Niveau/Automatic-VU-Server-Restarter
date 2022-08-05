using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VU.Tools;

namespace VU.Forms
{
    public partial class frmAbout : Form
    {

        private readonly Pen _separator = new Pen(Color.Gray, 1);

        public frmAbout()
        {
            InitializeComponent();
            Text = $@"{Properties.Resources.ProcName} - About";
            Icon sizedIcon = new Icon(Properties.Resources.AVUSR, new Size(64, 64));
            LogoPBox.Image = sizedIcon.ToBitmap();
            CopyrightLbl.Text = Utilitys.AssemblyCopyright;
            Icon = Properties.Resources.About;
            BuildDateLbl.Text = string.Format($@"Build date: {Utilitys.GetLinkerTime(Application.StartupPath + "\\avusr.exe", TimeZoneInfo.Local).ToString()} Version: {Application.ProductVersion}");
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
       
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAbout_Paint(object sender, PaintEventArgs e)
        {
            Point p1 = new Point(0, 220);
            Point p2 = new Point(500, 220);
            e.Graphics.DrawLine(_separator, p1, p2);
        }

        private void ImposterLlbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Imposter/Rcon.Net/tree/a5a89e35a66a0cd172a865ecbbb48c1309c395ce");
        }
    }
}
