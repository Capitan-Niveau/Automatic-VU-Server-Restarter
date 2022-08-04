using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VU.Forms
{
    internal class FormCollection
    {
        internal static frmAbout AboutForm = new frmAbout();
        internal static frmSettings SettingsForm = new frmSettings();
        internal static frmUpdateInfo UpdateInfo = new frmUpdateInfo();
        internal static frmDownloadUpdate DownloadFile = new frmDownloadUpdate();
    }
}
