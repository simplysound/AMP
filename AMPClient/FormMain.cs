using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.ServiceProcess;
using System.Management;
using System.Runtime.InteropServices;
using System.Diagnostics;

using AMPClasses;

namespace AMPClient
{
    public partial class FormMain : Form
    {
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        public ApplicationSettings appSet;
        Boolean isStart = true;
        private string VersionBuildNumber = "0";
        private string VersionNumber = String.Empty;

        private List<ServiceItem> FullServiceList;
        private List<ServiceItem> WWinServiceList;
        private List<ServiceItem> ProcServiceList;

        private WinServiceController serviceCtrl;

        Boolean isDebugEnabled = true;

        public FormMain()
        {
            InitializeComponent();

            appSet = new ApplicationSettings();
            appSet.Load();

            ampControlPanel.Close_Click += new EventHandler(ampControlPanel_Close_Click);
            ampControlPanel.Minimize_Click += new EventHandler(ampControlPanel_Minimize_Click);
            ampControlPanel.Switcher_Click += new EventHandler(ampControlPanel_Switcher_Click);
            ampControlPanel.Logo_Click += new EventHandler(ampControlPanel_Logo_Click);
            ampControlPanel.Mouse_Down += new MouseEventHandler(ampControlPanel_Mouse_Down);

            serviceCtrl = new WinServiceController();
            serviceCtrl.PropertyChanged += OnPropertyChanged;
            serviceCtrl.isDebugEnabled = isDebugEnabled;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////////
            // Check .NET Framework version
            int FWVersion = Utils.GetFrameworkVersion();
            if (FWVersion < 378389) // Less than .NET Framework 4.0
            {
                MessageBox.Show("The application requires .NET Framework version = 4.5.2\nApplication will be stopped. Please update your .NET Framework and try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            ///////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////
            // Version number
            ///////////////////////////////////////////////////////////////////            
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("AMPClient.version.txt"))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    VersionBuildNumber = reader.ReadToEnd();
                }
            }
            try
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                VersionNumber = String.Format("{0}.{1}.{2}", version.Major, version.Minor, VersionBuildNumber);
            }
            catch (Exception E)
            {
                String S = E.ToString();
            }
            ///////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////
            // Get operation system version
            EnumWinVersion WinVersion = Utils.GetWinVersionNumber();
            if (WinVersion != EnumWinVersion.WIN7)
                WinVersion = EnumWinVersion.WIN10;

            ///////////////////////////////////////////////////////////////////
            // Get full service list
            FullServiceList = new List<ServiceItem>();
            ClassWinServiceHelper.GetFullServiceList(FullServiceList);

            ///////////////////////////////////////////////////////////////////
            // Get service list for current operation system
            WWinServiceList = new List<ServiceItem>();
            ClassWinServiceHelper.GetWWinServiceList(WWinServiceList, appSet, WinVersion);

            ///////////////////////////////////////////////////////////////////
            // Get service list to be processed
            // ProcServiceList = FullServiceList - WWinServiceList

            if (WWinServiceList.Count > 0)
                ProcServiceList = FullServiceList.Except(WWinServiceList, new ServiceItemComparer()).ToList();

            ///////////////////////////////////////////////////////////////////
            // FOR DEBUG ONLY
            //ProcServiceList = new List<ServiceItem>();
            //ProcServiceList.Add(new ServiceItem() { DisplayName = "Print Spooler", ServiceName = "Spooler", ServiceAction = EnumServiceAction.STOP });

            if (isDebugEnabled == true)
            {
                String fileFullServiceList = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "FullServiceList.csv");
                File.WriteAllLines(fileFullServiceList, FullServiceList.Select(x => String.Format("{0},{1}", x.ServiceName, x.DisplayName)).ToArray());
                String fileWWinServiceList = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "WWinServiceList.csv");
                File.WriteAllLines(fileWWinServiceList, WWinServiceList.Select(x => String.Format("{0},{1}", x.ServiceName, x.DisplayName)).ToArray());
                String fileProcServiceList = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ProcServiceList.csv");
                File.WriteAllLines(fileProcServiceList, ProcServiceList.Select(x => String.Format("{0},{1}", x.ServiceName, x.DisplayName)).ToArray());
            }

            ///////////////////////////////////////////////////////////////////
            // Set previous state indication
            switch (appSet.PreviousState)
            {
                case EnumSwitcherState.OFF:
                    ampControlPanel.SwitcherState = EnumSwitcherState.OFF;
                    break;
                case EnumSwitcherState.ON:
                    ampControlPanel.SwitcherState = EnumSwitcherState.ON;
                    break;
                default:
                    ampControlPanel.SwitcherState = EnumSwitcherState.OFF;
                    break;
            }
            InitializeGUI_ON_OFF();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            if (appSet != null)
            {
                if ((isStart == true) && (appSet.DontShowMeAgain == false))
                {
                    isStart = false;
                    FormSplashScreen frmSplashScreen = new FormSplashScreen();                    
                    frmSplashScreen.VersionNumber = VersionNumber;
                    frmSplashScreen.ShowDialog();
                    if (appSet.DontShowMeAgain != frmSplashScreen.DontShowMeAgain)
                    {
                        appSet.DontShowMeAgain = frmSplashScreen.DontShowMeAgain;
                        appSet.Save();
                    }
                }
            }
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
            }
            else
            {
                notifyIcon.Visible = false;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            appSet.PreviousState = ampControlPanel.SwitcherState;
            appSet.Save();
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black,
                new Rectangle(
                    this.ClientRectangle.X,
                    this.ClientRectangle.Y,
                    this.ClientRectangle.Width - 1,
                    this.ClientRectangle.Height - 1));
        }

        private void ampControlPanel_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ampControlPanel_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to close AMP application?",
                "Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
                ) == DialogResult.OK)
            {
                this.Close();
            }            
        }

        private void ampControlPanel_Switcher_Click(object sender, EventArgs e)
        {
            if (ampControlPanel.IsBusy == true)
                return;

            ONOFF();
        }

        private void ampControlPanel_Logo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://simplysound.co/");
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ampControlPanel_Close_Click(sender, e);
        }

        private void ONOFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ampControlPanel.IsBusy == true)
                return;

            ONOFF();
        }        

        private void InitializeGUI_ON_OFF()
        {
            if (ampControlPanel.SwitcherState == EnumSwitcherState.OFF)
            {
                ampControlPanel.SwitcherState = EnumSwitcherState.OFF;
                ampControlPanel.LightState = EnumLightState.RED;
                notifyIcon.Icon = Properties.Resources.bullet_red_icon;
                ONOFFToolStripMenuItem.Text = "ON";
                ONOFFToolStripMenuItem.Image = Properties.Resources.bullet_green;
            }
            else
            {
                ampControlPanel.SwitcherState = EnumSwitcherState.ON;
                ampControlPanel.LightState = EnumLightState.GREEN;
                notifyIcon.Icon = Properties.Resources.bullet_green_icon;
                ONOFFToolStripMenuItem.Text = "OFF";
                ONOFFToolStripMenuItem.Image = Properties.Resources.bullet_red;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSplashScreen frmSplashScreen = new FormSplashScreen();
            frmSplashScreen.VersionNumber = VersionNumber;
            frmSplashScreen.ShowDontShowMeAgain = false;
            frmSplashScreen.ShowDialog();
        }
        ///////////////////////////////////////////////////////////////////////
        // SET SWITCHER STATE
        delegate void DelegateSetSwitcherState(EnumSwitcherState switcherState);
        private void SetSwitcherState(EnumSwitcherState switcherState)
        {
            if (ampControlPanel.InvokeRequired)
            {
                DelegateSetSwitcherState delegateSSS = new DelegateSetSwitcherState(SetSwitcherState);
                this.Invoke(delegateSSS, new object[] { switcherState });
            }
            else
            {
                ampControlPanel.SwitcherState = switcherState;
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // SET LIGHT STATE
        delegate void DelegateSetLightState(EnumLightState lightState);
        private void SetLightState(EnumLightState lightState)
        {
            if (ampControlPanel.InvokeRequired)
            {
                DelegateSetLightState delegateSLS = new DelegateSetLightState(SetLightState);
                this.Invoke(delegateSLS, new object[] { lightState });
            }
            else
            {
                ampControlPanel.LightState = lightState;
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // SET NOTIFY ICON
        delegate void DelegateSetNotifyIcon(Icon icon);
        private void SetNotifyIcon(Icon icon)
        {
            if (ampControlPanel.InvokeRequired)
            {
                DelegateSetNotifyIcon delegateSNI = new DelegateSetNotifyIcon(SetNotifyIcon);
                this.Invoke(delegateSNI, new object[] { icon });
            }
            else
            {
                notifyIcon.Icon = icon;
            }
        }
        ///////////////////////////////////////////////////////////////////////
        // UPDATE SYSTRAY MENU
        delegate void DelegateUpdateSysTrayMenu(EnumSwitcherState ONOFF);
        private void UpdateSysTrayMenu(EnumSwitcherState ONOFF)
        {
            if (this.sysTrayMenu.InvokeRequired)
            {
                DelegateUpdateSysTrayMenu delegateUSTM = new DelegateUpdateSysTrayMenu(UpdateSysTrayMenu);
                this.Invoke(delegateUSTM, new object[] { ONOFF });
            }
            else
            {
                switch (ONOFF)
                {
                    case EnumSwitcherState.ON:
                        ONOFFToolStripMenuItem.Text = "ON";
                        ONOFFToolStripMenuItem.Image = Properties.Resources.bullet_green;
                        break;
                    case EnumSwitcherState.OFF:
                        ONOFFToolStripMenuItem.Text = "OFF";
                        ONOFFToolStripMenuItem.Image = Properties.Resources.bullet_red;
                        break;
                }
            }
        }

        private async void ONOFF()
        {
            switch (ampControlPanel.SwitcherState)
            {
                case EnumSwitcherState.ON:

                    SetSwitcherState(EnumSwitcherState.OFF);
                    SetLightState(EnumLightState.YELLOW_BLINK);
                    SetNotifyIcon(Properties.Resources.bullet_yellow_icon);
                    ampControlPanel.IsBusy = true;

                    await Task.Run(() =>
                    {
                        STARTServices();
                    });

                    SetLightState(EnumLightState.RED);
                    SetNotifyIcon(Properties.Resources.bullet_red_icon);
                    UpdateSysTrayMenu(EnumSwitcherState.ON);
                    ampControlPanel.IsBusy = false;

                    break;

                case EnumSwitcherState.OFF:

                    SetSwitcherState(EnumSwitcherState.ON);
                    SetLightState(EnumLightState.YELLOW_BLINK);
                    SetNotifyIcon(Properties.Resources.bullet_yellow_icon);
                    ampControlPanel.IsBusy = true;

                    await Task.Run(() =>
                    {
                        STOPServices();
                    });

                    SetLightState(EnumLightState.GREEN);
                    SetNotifyIcon(Properties.Resources.bullet_green_icon);
                    UpdateSysTrayMenu(EnumSwitcherState.OFF);
                    ampControlPanel.IsBusy = false;
                    break;
            }
        }

        private void STARTServices()
        {
            List<ServiceStartStopProtocolItem> protocol = new List<ServiceStartStopProtocolItem>();

            foreach (ServiceItem item in ProcServiceList)
            {
                ServiceStartStopProtocolItem protocolItem = new ServiceStartStopProtocolItem() { Name = item.ServiceName };
                ServiceController scBefore = new ServiceController(item.ServiceName);
                protocolItem.StatusBefore = scBefore.Status.ToString();

                protocolItem.Result = serviceCtrl.StartService(item.ServiceName);
                serviceCtrl.ServiceStartupLogFromFile();

                ServiceController scAfter = new ServiceController(item.ServiceName);
                protocolItem.StatusAfter = scAfter.Status.ToString();
                protocolItem.DT = DateTime.Now;

                protocol.Add(protocolItem);
            }

            if (isDebugEnabled == true)
            {
                String fileServiceProtocol = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ServiceProtocol.csv");
                File.WriteAllLines(
                    fileServiceProtocol,
                    protocol.Select(x => String.Format("{0},{1},{2},{3},{4}", x.DT, x.Name, x.StatusBefore, x.StatusAfter, x.Result)).ToArray());
            }
            ///////////////////////////////////////////////////////////////////
            // TODO: In some reason a few services could be disabled
            STARTServicePatch();
            LocalNetworkConnectionONOFF(true);
            WirelessConnectionONOFF(true);
        }

        private void STOPServices()
        {
            List<ServiceStartStopProtocolItem> protocol = new List<ServiceStartStopProtocolItem>();

            if (serviceCtrl.ServiceStartupLog != null)
                serviceCtrl.ServiceStartupLog.Clear();

            foreach (ServiceItem item in ProcServiceList)
            {
                ServiceStartStopProtocolItem protocolItem = new ServiceStartStopProtocolItem() { Name = item.ServiceName };
                ServiceController scBefore = new ServiceController(item.ServiceName);
                protocolItem.StatusBefore = scBefore.Status.ToString();

                serviceCtrl.ServiceStartupLogToFile();
                protocolItem.Result = serviceCtrl.StopService(item.ServiceName);

                ServiceController scAfter = new ServiceController(item.ServiceName);
                protocolItem.StatusAfter = scAfter.Status.ToString();
                protocol.Add(protocolItem);
            }

            if (isDebugEnabled == true)
            {
                String fileServiceProtocol = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "ServiceProtocol.csv");
                File.WriteAllLines(
                    fileServiceProtocol,
                    protocol.Select(x => String.Format("{0},{1},{2},{3},{4}", x.DT, x.Name, x.StatusBefore, x.StatusAfter, x.Result)).ToArray());
            }
            LocalNetworkConnectionONOFF(false);
            WirelessConnectionONOFF(false);
            STOPServicePatch();
        }

        private void STARTServicePatch()
        {
            List<string> serviceList = new List<string>() { "Wlansvc", "WwanSvc", "MpsSvc", "WinDefend", "wcncsvc", "WinHttpAutoProxySvc" };

            foreach (string item in serviceList)
            {
                try
                {
                    ServiceController service = new ServiceController(item);
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        service.Start();
                        TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                        service.Refresh();
                    }
                }
                catch (Exception E) { String msg = E.ToString(); }
            }

            Utils.RestartExplorer();
        }

        private void STOPServicePatch()
        {
            List<string> serviceList = new List<string>() { "Wlansvc", "WwanSvc", "WinHttpAutoProxySvc" };

            foreach (string item in serviceList)
            {
                try
                {
                    ServiceController service = new ServiceController(item);
                    if ((service.Status.Equals(ServiceControllerStatus.Running)) || (service.Status.Equals(ServiceControllerStatus.StartPending)))
                    {
                        service.Stop();
                        TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
                        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                        service.Refresh();
                    }
                }
                catch (Exception E) { String msg = E.ToString(); }
            }
        }

        private void LocalNetworkConnectionONOFF(bool isEnabled)
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (item["NetConnectionId"].ToString() == "Local Network Connection")
                {
                    if (isEnabled == true)
                        item.InvokeMethod("Disable", null);
                    else
                        item.InvokeMethod("Enable", null);
                }
            }
        }
        
        private void WirelessConnectionONOFF(bool isEnabled)
        {
            if (isEnabled == true)
            {
                try
                {
                    string arguments = "netsh interface set interface name=\"Wireless Network Connection\" admin=ENABLED";
                    ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;
                    procStartInfo.CreateNoWindow = true;

                    Process.Start(procStartInfo);
                }
                catch (Exception E)
                {
#if DEBUG
                    MessageBox.Show(E.ToString());
#endif
                }
            }
                
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ; // RESERVED
        }

        private void ampControlPanel_Mouse_Down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
