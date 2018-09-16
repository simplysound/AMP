using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AMPClasses;

namespace AMPClient
{
    public partial class AMPControlPanel : UserControl
    {
        public event EventHandler Close_Click;
        public event EventHandler Minimize_Click;
        public event EventHandler Switcher_Click;
        public event EventHandler Logo_Click;

        private EnumSwitcherState _SwitcherState = EnumSwitcherState.OFF;
        private EnumLightState _LightState = EnumLightState.RED;

        public Boolean IsBusy { get; set; }

        public EnumSwitcherState SwitcherState
        {
            get
            {
                return _SwitcherState;
            }
            set
            {
                if (IsBusy == true)
                    return;

                _SwitcherState = value;
                switch (_SwitcherState)
                {
                    case EnumSwitcherState.OFF:
                        pbSwitcher.Image = Properties.Resources.SwitcherOFF;
                        break;
                    case EnumSwitcherState.ON:
                        pbSwitcher.Image = Properties.Resources.SwitcherON;
                        break;                    
                }
            }
        }

        public EnumLightState LightState
        {
            get
            {
                return _LightState;
            }
            set
            {
                _LightState = value;
                switch (_LightState)
                {
                    case EnumLightState.GREEN:
                        pbLight.Image = Properties.Resources.LightGreen;
                        break;
                    case EnumLightState.RED:
                        pbLight.Image = Properties.Resources.LightRed;
                        break;
                    case EnumLightState.YELLOW:
                        pbLight.Image = Properties.Resources.LightYellow;
                        break;
                    case EnumLightState.YELLOW_BLINK:
                        pbLight.Image = Properties.Resources.LightYellowBlink_500;
                        break;
                }
            }
        }

        public AMPControlPanel()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            pbMainForm.Image = Properties.Resources.MainForm;
            pbMainForm.Controls.Add(pbClose);
            pbMainForm.Controls.Add(pbMinimize);
            pbMainForm.Controls.Add(pbLight);
            pbMainForm.Controls.Add(pbAMPLogo);
            pbMainForm.Controls.Add(pbSwitcher);

            pbMinimize.Location = new Point(153, 7);
            pbMinimize.BackColor = Color.Transparent;
            pbMinimize.Image = Properties.Resources.MinimizeOFF;

            pbClose.Location = new Point(173, 7);
            pbClose.BackColor = Color.Transparent;
            pbClose.Image = Properties.Resources.CloseOFF;

            pbLight.Location = new Point(9, 33);
            pbLight.BackColor = Color.Transparent;
            pbLight.Image = Properties.Resources.LightYellow;

            pbAMPLogo.Location = new Point(55, 303);
            pbAMPLogo.BackColor = Color.Transparent;
            pbAMPLogo.Image = Properties.Resources.AMPLogo;

            pbSwitcher.Location = new Point(17, 220);
            pbSwitcher.BackColor = Color.Transparent;
            pbSwitcher.Image = Properties.Resources.SwitcherOFF;

            toolTipURL.SetToolTip(pbAMPLogo, "Visit our website");
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            if (this.Close_Click != null) this.Close_Click(this, e);
        }

        private void pbMinimize_Click(object sender, EventArgs e)
        {
            if (this.Minimize_Click != null) this.Minimize_Click(this, e);
        }

        private void pbMinimize_MouseHover(object sender, EventArgs e)
        {
            pbMinimize.Image = Properties.Resources.MinimizeON;
        }

        private void pbClose_MouseHover(object sender, EventArgs e)
        {
            pbClose.Image = Properties.Resources.CloseON;
        }

        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
            pbMinimize.Image = Properties.Resources.MinimizeOFF;
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.Image = Properties.Resources.CloseOFF;
        }

        private void pbSwitcher_Click(object sender, EventArgs e)
        {
            if (this.Switcher_Click != null) this.Switcher_Click(this, e);
        }

        private void pbAMPLogo_Click(object sender, EventArgs e)
        {
            if (this.Logo_Click != null) this.Logo_Click(this, e);
        }
    }
}
