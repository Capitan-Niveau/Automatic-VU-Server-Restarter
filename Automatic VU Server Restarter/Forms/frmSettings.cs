using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VU.Settings;

namespace VU.Forms
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();

            SettingsManager.LoadSettings();

            VuInstancePathTBox.Text = SettingsManager.GetVuInstancePath();
            BattlefieldInstallDirTBox.Text = SettingsManager.GetGamePath();
            VuPathTBox.Text = SettingsManager.GetVuPath();
            UseCustomGamePathCBox.Checked = SettingsManager.UseCustomGamePath;
            UseMiniProConCBox.Checked = SettingsManager.UseCutDownProCon;
            ProConPathTBox.Text = SettingsManager.ProConPath;

            switch (SettingsManager.ServerFrequency)
            {
                case 1:
                    ServerFrequency30HzRBtn.Checked = true;
                    break;
                case 2:
                    ServerFrequency60HzRBtn.Checked = true;
                    break;
                case 3:
                    ServerFrequency120HzRBtn.Checked = true;
                    break;
                default:
                    ServerFrequency30HzRBtn.Checked = true;
                    break;
            }
            
            DisableTerrainInterpCBox.Checked = SettingsManager.UseDisableTerrainInterp;
            HighResTerrainCBox.Checked = SettingsManager.UseHighResTerrain;
            SkipChecksumCBox.Checked = SettingsManager.UseSkipChecksumValidation;
            DisableAutomaticUpdatesCBox.Checked = SettingsManager.UseAutomaticUpdates;
            UnlistedCBox.Checked = SettingsManager.MakeUnlisted;
            WritePerfProfileCBox.Checked = SettingsManager.UseWritePerfProfile;
            SaveLoggingOutputCBox.Checked = SettingsManager.UseSaveLoggingOutput;
            ProconWithServerStartupCBox.Checked = SettingsManager.UseProCon;
            ServerPortCBox.Checked = SettingsManager.UseCustomServerAdress;
            MonitoredHarmonyCBox.Checked = SettingsManager.UseCustomHarmonyPort;
            RemoteAdminPortCBox.Checked = SettingsManager.UseCustomRemoteAdress;
            RemotePortTBox.Text = SettingsManager.RemoteAdminPort;
            HarmonyPortTBox.Text = SettingsManager.HarmonyPort;
            ServerPortTBox.Text = SettingsManager.ServerPort;
        }

        internal Button SearchVuPathBtn = new Button();
        internal Button SearchVuInsatncePathBtn = new Button();
        internal Button SearchGamePathBtn = new Button();
        internal Button SearchProConPathBtn = new Button();


        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        internal FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

        protected override void OnLoad(EventArgs e)
        {
            SearchVuPathBtn.Size = new Size(24, VuPathTBox.ClientSize.Height + 1);
            SearchVuPathBtn.Location = new Point(VuPathTBox.ClientSize.Width - SearchVuPathBtn.Width, -1);
            SearchVuPathBtn.Cursor = Cursors.Default;
            SearchVuPathBtn.FlatStyle = FlatStyle.System;
            SearchVuPathBtn.Text = "...";
            SearchVuPathBtn.Click += SearchVuPath_Click;
            VuPathTBox.Controls.Add(SearchVuPathBtn);

            SearchVuInsatncePathBtn.Size = new Size(24, VuInstancePathTBox.ClientSize.Height + 1);
            SearchVuInsatncePathBtn.Location = new Point(VuInstancePathTBox.ClientSize.Width - SearchVuInsatncePathBtn.Width, -1);
            SearchVuInsatncePathBtn.Cursor = Cursors.Default;
            SearchVuInsatncePathBtn.FlatStyle = FlatStyle.System;
            SearchVuInsatncePathBtn.Text = "...";
            SearchVuInsatncePathBtn.Click += SearchVuInsatncePath_Click;
            VuInstancePathTBox.Controls.Add(SearchVuInsatncePathBtn);

            SearchGamePathBtn.Size = new Size(24, BattlefieldInstallDirTBox.ClientSize.Height + 1);
            SearchGamePathBtn.Location = new Point(BattlefieldInstallDirTBox.ClientSize.Width - SearchGamePathBtn.Width, -1);
            SearchGamePathBtn.Cursor = Cursors.Default;
            SearchGamePathBtn.FlatStyle = FlatStyle.System;
            SearchGamePathBtn.Text = "...";
            SearchGamePathBtn.Click += SearchGamePath_Click;
            BattlefieldInstallDirTBox.Controls.Add(SearchGamePathBtn);
            SearchGamePathBtn.Enabled = false;

            SearchProConPathBtn.Size = new Size(24, ProConPathTBox.ClientSize.Height + 1);
            SearchProConPathBtn.Location = new Point(ProConPathTBox.ClientSize.Width - SearchProConPathBtn.Width, -1);
            SearchProConPathBtn.Cursor = Cursors.Default;
            SearchProConPathBtn.FlatStyle = FlatStyle.System;
            SearchProConPathBtn.Text = "...";
            SearchProConPathBtn.Click += SearchProConPat_Click;
            ProConPathTBox.Controls.Add(SearchProConPathBtn);

            SendMessage(VuPathTBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(SearchVuPathBtn.Width << 16));
            base.OnLoad(e);

            SendMessage(VuInstancePathTBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(SearchVuInsatncePathBtn.Width << 16));
            base.OnLoad(e);

            SendMessage(BattlefieldInstallDirTBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(SearchGamePathBtn.Width << 16));
            base.OnLoad(e);

            SendMessage(ProConPathTBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(SearchProConPathBtn.Width << 16));
            base.OnLoad(e);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            SearchVuPathBtn.Enabled = false;
            SearchProConPathBtn.Enabled = false;
        }

        private void SearchVuPath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = SettingsManager.VuPath;
            if (DialogResult.OK == FolderBrowser.ShowDialog())
                VuPathTBox.Text = FolderBrowser.SelectedPath;
        }

        private void SearchVuInsatncePath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = SettingsManager.VuInstancePath;
            if (DialogResult.OK == FolderBrowser.ShowDialog())
                VuInstancePathTBox.Text = FolderBrowser.SelectedPath;
        }

        private void SearchGamePath_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = SettingsManager.BattlefieldInstallDir;
            if (DialogResult.OK == FolderBrowser.ShowDialog())
                BattlefieldInstallDirTBox.Text = FolderBrowser.SelectedPath;
        }

        private void SearchProConPat_Click(object sender, EventArgs e)
        {
            FolderBrowser.SelectedPath = SettingsManager.ProConPath;
            if (DialogResult.OK == FolderBrowser.ShowDialog())
                ProConPathTBox.Text = FolderBrowser.SelectedPath;
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            SettingsManager.OpenSettings.Write("Settings", "ProConPath", ProConPathTBox.Text);
            SettingsManager.OpenSettings.Write("Settings", "InstancePath", VuInstancePathTBox.Text);
            SettingsManager.OpenSettings.Write("Settings", "ServerPort", ServerPortTBox.Text);
            SettingsManager.OpenSettings.Write("Settings", "HarmonyPort", HarmonyPortTBox.Text);
            SettingsManager.OpenSettings.Write("Settings", "RemotePort", RemotePortTBox.Text);
            Close();
        }

        private void UseCustomGamePathCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (UseCustomGamePathCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomPath", "true");
                    SearchGamePathBtn.Enabled = true;
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomPath", "false");
                    SearchGamePathBtn.Enabled = false;
                    break;
            }
        }

        private void UseMiniProConCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (UseMiniProConCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "ProConCutDownVersion", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "ProConCutDownVersion", "false");
                    break;
            }
        }

        private void ServerFrequency30HzRBtn_CheckedChanged(object sender, EventArgs e)
        {
            switch (ServerFrequency30HzRBtn.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "ServerFrequency", "1");
                    break;
            }
        }

        private void ServerFrequency60HzRBtn_CheckedChanged(object sender, EventArgs e)
        {
            switch (ServerFrequency60HzRBtn.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "ServerFrequency", "2");
                    break;
            }
        }

        private void ServerFrequency120HzRBtn_CheckedChanged(object sender, EventArgs e)
        {
            switch (ServerFrequency120HzRBtn.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "ServerFrequency", "3");
                    break;
            }
        }

        private void DisableTerrainInterpCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (DisableTerrainInterpCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "DisableTerrainInterp", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "DisableTerrainInterp", "false");
                    break;
            }
        }

        private void HighResTerrainCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (HighResTerrainCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "HighResTerrain", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "HighResTerrain", "false");
                    break;
            }
        }

        private void SkipChecksumCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (SkipChecksumCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "SkipChecksum", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "SkipChecksum", "false");
                    break;
            }
        }

        private void UnlistedCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (UnlistedCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "MakeUnlisted", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "MakeUnlisted", "false");
                    break;
            }
        }

        private void DisableAutomaticUpdatesCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (DisableAutomaticUpdatesCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "DisableAutomaticUpdates", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "DisableAutomaticUpdates", "false");
                    break;
            }
        }

        private void WritePerfProfileCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (WritePerfProfileCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "WritePerfProfile", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "WritePerfProfile", "false");
                    break;
            }

        }

        private void SaveLoggingOutputCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (SaveLoggingOutputCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "SaveLoggingOutput", "true");
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "SaveLoggingOutput", "false");
                    break;
            }
        }

        private void ProconWithServerStartupCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (ProconWithServerStartupCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "UseProCon", "true");
                    UseMiniProConCBox.Enabled = true;
                    SearchProConPathBtn.Enabled = true;
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "UseProCon", "false");
                    UseMiniProConCBox.Enabled = false;
                    SearchProConPathBtn.Enabled = false;
                    break;
            }
        }

        private void ServerPortTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void HarmonyPortTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void RemotePortTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void ServerPortCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (ServerPortCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomServerAdress", "true");
                    ServerPortTBox.Enabled = true;
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomServerAdress", "false");
                    ServerPortTBox.Enabled = false;
                    break;
            }
        }

        private void MonitoredHarmonyCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (MonitoredHarmonyCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomHarmonyPort", "true");
                    HarmonyPortTBox.Enabled = true;
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomHarmonyPort", "false");
                    HarmonyPortTBox.Enabled = false;
                    break;
            }
        }

        private void RemoteAdminPortCBox_CheckedChanged(object sender, EventArgs e)
        {
            switch (RemoteAdminPortCBox.Checked)
            {
                case true:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomRemoteAdress", "true");
                    RemotePortTBox.Enabled = true;
                    break;
                default:
                    SettingsManager.OpenSettings.Write("Settings", "UseCustomRemoteAdress", "false");
                    RemotePortTBox.Enabled = false;
                    break;
            }
        }
    }
}
