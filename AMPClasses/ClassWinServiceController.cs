using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.ComponentModel;
using System.Management;
using System.IO;

namespace AMPClasses
{
    public class WinServiceController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isDebugEnabled;
                
        public Dictionary<string, string> ServiceStartupLog = new Dictionary<string, string>();
        /// <summary>
        /// isDebugEnabled - if TRUE - all functions results will be logged
        /// </summary>
        public bool isDebugEnabled
        {
            get { return _isDebugEnabled; }
            set { _isDebugEnabled = value; OnPropertyChanged("isDebugEnabled"); }
        }
        /// <summary>
        /// Wait interval in sec.
        /// </summary>
        public int waitInterval;

        public ApplicationLog appLog;

        /// <summary>
        /// Default constructor
        /// isDebugEnabled - false;
        /// waitInterval - 60 sec;
        /// </summary>
        public WinServiceController()
        {
            // Default constants
            _isDebugEnabled = false;
            waitInterval = 10;
            // Application log object creation
            appLog = new ApplicationLog();
            appLog.isDebugEnabled = isDebugEnabled;
        }

        public string GetStartupType(String ServiceName)
        {
            if (ServiceName != null)
            {
                // Construct the management path
                string path = "Win32_Service.Name='" + ServiceName + "'";
                ManagementPath p = new ManagementPath(path);
                // Construct the management object
                ManagementObject ManagementObj = new ManagementObject(p);
                return ManagementObj["StartMode"].ToString();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Start service by name
        /// </summary>
        /// <param name="serviceName">Service name to be stopped</param>
        public string StartService(string serviceName)
        {
            //Boolean serviceEnabled = isServiceEnabled(serviceName);
            //if (serviceEnabled == false)
            //{
            //    appLog.WriteLog(String.Format("StartService({0}): Disabled", serviceName));
            //    return;
            //}

            //Boolean canStop = isCanStop(serviceName);
            //if (canStop == false)
            //{
            //    return "Passed";
            //}

            try
            {
                ServiceController service = new ServiceController(serviceName);

                if ((ServiceStartupLog != null) && (ServiceStartupLog.Count > 0))
                {
                    if (ServiceStartupLog.ContainsKey(serviceName))
                    {
                        if (ServiceStartupLog[serviceName].ToLower().StartsWith("manual") == true)
                        {
                            try
                            {
                                ServiceHelper.ChangeStartModeT(service, ServiceStartMode.Manual);
                            }
                            catch { }
                            appLog.WriteLog(String.Format("Service: {0} Change StartupMode to Manual", serviceName));
                        }
                        else if (ServiceStartupLog[serviceName].ToLower().StartsWith("auto") == true)
                        {
                            try
                            {
                                ServiceHelper.ChangeStartModeT(service, ServiceStartMode.Automatic);
                            }
                            catch { }
                            appLog.WriteLog(String.Format("Service: {0} Change StartupMode to Automatic", serviceName));
                        }

                        if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                        {
                            service.Start();
                            TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * waitInterval);
                            service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                            service.Refresh();
                            appLog.WriteLog(String.Format("StartService({0}): {1}", serviceName, service.Status.ToString()));
                        }
                        else
                            return "Passed - Service already started";
                    }
                    else
                        return "Passed - Service was not stopped by AMP";
                }
                else
                {
                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) || (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        try
                        {
                            ServiceHelper.ChangeStartModeT(service, ServiceStartMode.Automatic);
                        }
                        catch { }

                        service.Start();
                        TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * waitInterval);
                        service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                        service.Refresh();
                        appLog.WriteLog(String.Format("StartService({0}): {1}", serviceName, service.Status.ToString()));
                    }
                    else
                        return "Passed - Service already started";
                }
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                appLog.WriteLog(String.Format("StartService({0}): Timeout exception", serviceName));
                return "Timeout exception";
            }
            catch (System.InvalidOperationException)
            {
                appLog.WriteLog(String.Format("StartService({0}): Access is denied", serviceName));
                return "Access is denied";
            }
            catch (Exception E)
            {
                appLog.WriteLog(String.Format("StartService({0}): {1}", serviceName, E.ToString()));
                return E.ToString();
            }
            return "Success";
        }
        /// <summary>
        /// Stop service by name
        /// </summary>
        /// <param name="serviceName">Service name to be stopped</param>
        public string StopService(string serviceName)
        {
            Boolean serviceEnabled = isServiceEnabled(serviceName);
            if (serviceEnabled == false)
            {
                appLog.WriteLog(String.Format("StopService({0}): Disabled", serviceName));
                return "Passed";
            }

            //Boolean canStop = isCanStop(serviceName);
            //if (canStop == false)
            //{
            //    appLog.WriteLog(String.Format("StopService({0}): Could not be stopped", serviceName));
            //    return "Passed";
            //}

            try
            {
                ServiceController service = new ServiceController(serviceName);                

                if ((service.Status.Equals(ServiceControllerStatus.Running)) || (service.Status.Equals(ServiceControllerStatus.StartPending)))
                {
                    String startupType = GetStartupType(serviceName);
                    appLog.WriteLog(String.Format("Service: {0} StartupMode - {1}", serviceName, startupType));

                    try
                    {
                        if (!ServiceStartupLog.ContainsKey(serviceName))
                            ServiceStartupLog.Add(serviceName, startupType);
                        else ServiceStartupLog[serviceName] = startupType;

                        try
                        {
                            ServiceHelper.ChangeStartModeT(service, ServiceStartMode.Disabled);
                        }
                        catch { }
                    }
                    catch { }

                    service.Stop();
                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * waitInterval);
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    service.Refresh();
                    appLog.WriteLog(String.Format("StopService({0}): {1}", serviceName, service.Status.ToString()));                    
                }
                else
                    return "Passed";
            }
            catch (System.ServiceProcess.TimeoutException)
            {
                appLog.WriteLog(String.Format("StopService({0}): Timeout exception", serviceName));
                return "Timeout exception";
            }
            catch (System.InvalidOperationException)
            {
                appLog.WriteLog(String.Format("StopService({0}): Access is denied", serviceName));
                return "Access is denied";
            }
            catch (Exception E)
            {
                appLog.WriteLog(String.Format("StopService({0}): {1}", serviceName, E.ToString()));
                return E.ToString();
            }
            return "Success";
        }
        /// <summary>
        /// Restrat service by name
        /// </summary>
        /// <param name="serviceName">Service name to be restarted</param>
        public void RestartService(string serviceName)
        {
            if (isServiceEnabled(serviceName) && isCanStop(serviceName))
            {
                try
                {
                    ServiceController service = new ServiceController(serviceName);
                    TimeSpan timeout = TimeSpan.FromMilliseconds(1000 * waitInterval);
                    if (service.Status != ServiceControllerStatus.Stopped)
                    {
                        service.Stop();
                        service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                    }
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                    //service.Refresh();
                    appLog.WriteLog(String.Format("RestartService({0}): {1}", serviceName, service.Status.ToString()));
                }
                catch (Exception E)
                {
                    appLog.WriteLog(String.Format("RestartService({0}): {1}", serviceName, E.ToString()));
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
                if (propertyName == "isDebugEnabled")
                    appLog.isDebugEnabled = isDebugEnabled;
            }
        }

        private Boolean isServiceEnabled(String ServiceName)
        {
            try
            {
                string wmiQuery = @"SELECT * FROM Win32_Service WHERE Name='" + ServiceName + @"'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery);
                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject service in results)
                {
                    if (service["StartMode"].ToString().ToUpper() == "DISABLED")
                        return false;
                    else
                        return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private Boolean isCanStop(String ServiceName)
        {
            try
            {
                ServiceController service = new ServiceController(ServiceName);
                return service.CanStop;
            }
            catch
            {
                return false;
            }
        }

        public void ServiceStartupLogToFile()
        {
            if ((ServiceStartupLog != null) && (ServiceStartupLog.Count > 0))
            {
                using (StreamWriter startuplog = new StreamWriter("ServiceStartupLog.csv"))
                {
                    for(int i = 0; i < ServiceStartupLog.Count; i++)
                        startuplog.WriteLine(String.Format("{0},{1}", ServiceStartupLog.ElementAt(i).Key, ServiceStartupLog.ElementAt(i).Value));
                }
            }
        }

        public void ServiceStartupLogFromFile()
        {
            try
            {
                if ((ServiceStartupLog != null) && (ServiceStartupLog.Count > 0))
                {
                    ServiceStartupLog.Clear();
                    string[] startuplog = System.IO.File.ReadAllLines("ServiceStartupLog.csv");
                    string[] data;
                    foreach (string item in startuplog)
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            data = item.Split(',');
                            if (data.Count() == 2)
                                ServiceStartupLog.Add(data[0], data[1]);
                        }
                    }
                }
            }
            catch { }
        }
    }
}