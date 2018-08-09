using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMPClient
{
    public partial class FormSplashScreen : Form
    {
        private Boolean _DontShowMeAgain = false;
        private String _VersionNumber = String.Empty;

        public Boolean DontShowMeAgain { get { return _DontShowMeAgain; } }
        public String VersionNumber { set { _VersionNumber = value; } }

        public Boolean ShowDontShowMeAgain { set { checkBoxDontShowMeAgain.Visible = value; } }
        public FormSplashScreen()
        {
            InitializeComponent();
            toolTipURL.SetToolTip(pbAMPLogo, "Visit our website");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            _DontShowMeAgain = checkBoxDontShowMeAgain.Checked;
            Close();
        }

        private void FormSplashScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black,
                new Rectangle(
                    this.ClientRectangle.X,
                    this.ClientRectangle.Y,
                    this.ClientRectangle.Width - 1,
                    this.ClientRectangle.Height - 1));
        }

        private void FormSplashScreen_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_VersionNumber))
                labelAppVersion.Text = String.Format("Client version: {0}", _VersionNumber);
        }

        private void pbAMPLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://simplysound.co/");
        }
    }
}
