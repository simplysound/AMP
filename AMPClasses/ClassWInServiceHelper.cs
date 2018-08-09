using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.IO;

namespace AMPClasses
{
    public static class ClassWinServiceHelper
    {
        /// <summary>
        /// Get all installed windows services
        /// </summary>
        /// <param name="FullServiceList"></param>
        /// <returns>Installed services count</returns>
        public static int GetFullServiceList(List<ServiceItem> FullServiceList)
        {
            if (FullServiceList != null)
                FullServiceList.Clear();
            else
                FullServiceList = new List<ServiceItem>();

            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            foreach (ServiceController item in scServices)
            {
                FullServiceList.Add (new ServiceItem
                {
                    DisplayName = item.DisplayName,
                    ServiceAction = EnumServiceAction.UNDEFINED,
                    ServiceName = item.ServiceName
                });
            }
            return FullServiceList.Count;
        }
        /// <summary>
        /// Get whitelisted service list
        /// </summary>
        /// <param name="WWinServiceList">Whitelisted service list</param>
        /// <param name="appSet">Application settings object</param>
        /// <param name="WinVersion">Windows version</param>
        /// <returns>Whitelisted services count</returns>
        public static int GetWWinServiceList(List<ServiceItem> WWinServiceList, ApplicationSettings appSet, EnumWinVersion WinVersion)
        {
            if (WWinServiceList != null)
                WWinServiceList.Clear();
            else
                WWinServiceList = new List<ServiceItem>();

            ///////////////////////////////////////////////////////////////////
            // Load whiteliste services from settings file
            if ((appSet != null) && (appSet.ServiceList.Count > 0))
                foreach (var item in appSet.ServiceList)
                    WWinServiceList.Add(new ServiceItem() { ServiceName = item.ServiceName, DisplayName = item.DisplayName, ServiceAction = item.ServiceAction });
            else
            {
                ///////////////////////////////////////////////////////////////
                // Parse whitelisted service list from the config file
                String profileName = String.Format("{0}.profile", WinVersion);                
                if (File.Exists(profileName))
                {
                    String[] data = File.ReadAllLines(profileName);

                    foreach (string line in data)
                    {
                        string[] d = line.Split('\t');

                        Int32 ActionCode;
                        Int32.TryParse(d[2].ToString(), out ActionCode);

                        WWinServiceList.Add(new ServiceItem()
                        {
                            ServiceName = d[0].ToString(),
                            DisplayName = d[1].ToString(),
                            ServiceAction = (EnumServiceAction)ActionCode
                        });
                    }

                    ///////////////////////////////////////////////////////////
                    // Save parsed whitelist in settings file
                    foreach (var item in WWinServiceList)
                        appSet.ServiceList.Add(new ServiceItem() { ServiceName = item.ServiceName, DisplayName = item.DisplayName, ServiceAction = item.ServiceAction });
                    appSet.Save();
                }
            }
            return WWinServiceList.Count;
        }
    }
}
