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

            MessageBox.Show(String.Format("{0}\nStatus:\t{1}\nStartType:\t{2}", service.DisplayName, ServiceStatus, ServiceStartType));
        }

        private void buttonEnableAudioSrv_Click(object sender, EventArgs e)
        {
            string serviceName = "AudioSrv";
            ServiceController sc = new ServiceController(serviceName);
            if (sc.Status.Equals(ServiceControllerStatus.Stopped))
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
            MessageBox.Show(sc.Status.ToString());
        }

        private void buttonDisableAudioSrv_Click(object sender, EventArgs e)
        {
            string serviceName = "AudioSrv";
            ServiceController sc = new ServiceController(serviceName);
            if (sc.Status.Equals(ServiceControllerStatus.Running))
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            MessageBox.Show(sc.Status.ToString());
        }

        private void buttonGetAudioSrvStatus_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("AudioSrv");

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

            MessageBox.Show(String.Format("{0}\nStatus:\t{1}\nStartType:\t{2}", service.DisplayName, ServiceStatus, ServiceStartType));
        }
        public List<string> GetServicesDependedOnList(string serviceName)
        {
            List<string> servicesDepenededOnList = new List<string>();
            ServiceController sc = new ServiceController(serviceName);
            ServiceController[] scServices = sc.ServicesDependedOn;
            foreach (ServiceController service in scServices)
            {
                servicesDepenededOnList.Add(service.DisplayName);
                servicesDepenededOnList.AddRange(GetServicesDependedOnList(service.ServiceName));
            }
            return servicesDepenededOnList;
        }

        public List<string> GetDependentServicesList(string serviceName)
        {
            List<string> dependServicesList = new List<string>();
            ServiceController sc = new ServiceController(serviceName);
            ServiceController[] scServices = sc.DependentServices;
            foreach (ServiceController service in scServices)
            {
                dependServicesList.Add(service.DisplayName);
                dependServicesList.AddRange(GetDependentServicesList(service.ServiceName));
            }
            return dependServicesList;
        }

        private void buttonAudioSrvDependecyList_Click(object sender, EventArgs e)
        {
            string serviceName = "AudioSrv";

            StringBuilder strDependency = new StringBuilder();
            strDependency.AppendLine("This service depends on the following system components");
            List<string> DependentOnList = GetServicesDependedOnList(serviceName);
            if (DependentOnList.Count == 0)
                strDependency.AppendLine("Not found");
            foreach (string item in DependentOnList)
                strDependency.AppendLine(item);

            strDependency.AppendLine(String.Empty);
            strDependency.AppendLine("The following system components depend on this service");
            List<string> DependentServicesList = GetDependentServicesList(serviceName);
            if (DependentServicesList.Count == 0)
                strDependency.AppendLine("Not found");
            foreach (string item in DependentServicesList)
                strDependency.AppendLine(item);

            MessageBox.Show(strDependency.ToString());
        }
    }
}
