using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.ServiceProcess;

using AMPClasses;

namespace AMPUtility
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonEnableWiFi_Click(object sender, EventArgs e)
        {
            try
            {
                string arguments = "interface set interface name=\"Wireless Network Connection\" admin=ENABLED";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                Process.Start(procStartInfo);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void buttonDisableWiFi_Click(object sender, EventArgs e)
        {
            try
            {
                string arguments = "interface set interface name=\"Wireless Network Connection\" admin=DISABLED";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                Process.Start(procStartInfo);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void buttonConnectWiFi_Click(object sender, EventArgs e)
        {
            try
            {
                string arguments = "wlan connect";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                Process.Start(procStartInfo);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void buttonDisconnectWiFi_Click(object sender, EventArgs e)
        {
            try
            {
                string arguments = "wlan disconnect";
                ProcessStartInfo procStartInfo = new ProcessStartInfo("netsh", arguments);

                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.CreateNoWindow = true;

                Process.Start(procStartInfo);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
            }
        }

        private void buttonWLANService_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("Wlansvc");
            ServiceHelper.ChangeStartModeT(service, ServiceStartMode.Automatic);
            if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
            {
                service.Start();
                TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                service.Refresh();
            }
        }

        private void buttonGetWLANStatus_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("Wlansvc");

            String ServiceStatus = "Undefined";
            String ServiceStartType = "Undefined";

            if (service.Status.Equals(ServiceControllerStatus.ContinuePending))
                ServiceStatus = "ContinuePending";
            if (service.Status.Equals(ServiceControllerStatus.Paused))
                ServiceStatus = "Paused";
            if (service.Status.Equals(ServiceControllerStatus.PausePending))
                ServiceStatus = "PausePending";
            if (service.Status.Equals(ServiceControllerStatus.Running))
                ServiceStatus = "Running";
            if (service.Status.Equals(ServiceControllerStatus.StartPending))
                ServiceStatus = "StartPending";
            if (service.Status.Equals(ServiceControllerStatus.Stopped))
                ServiceStatus = "Stopped";
            if (service.Status.Equals(ServiceControllerStatus.StopPending))
                ServiceStatus = "StopPending";

            if (service.StartType.Equals(ServiceStartMode.Automatic))
                ServiceStartType = "Automatic";
            if (service.StartType.Equals(ServiceStartMode.Boot))
                ServiceStartType = "Boot";
            if (service.StartType.Equals(ServiceStartMode.Disabled))
                ServiceStartType = "Disabled";
            if (service.StartType.Equals(ServiceStartMode.Manual))
                ServiceStartType = "Manual";
            if (service.StartType.Equals(ServiceStartMode.System))
                ServiceStartType = "System";

            MessageBox.Show(String.Format("WLAN AutoConfig\nStatus:\t{0}\nStartType:\t{1}", ServiceStatus, ServiceStartType));
        }
    }
}
