using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using AMPClasses;

namespace AMPBackup
{
    class Program
    {
        static int Main(string[] args)
        {
            BackupInformation backupInformation = new BackupInformation();
            Console.Clear();
            // Get argument value
            if (args.Length > 0)
            {
                int argFlag = -1;
                int.TryParse(args[0], out argFlag);
                switch (argFlag)
                {
                    case 0: // Restore services backup
                        try
                        {
                            if (backupInformation != null)
                            {
                                backupInformation.Load();
                                if (backupInformation.ServiceList.Count > 0)
                                {
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 0);
                                    Console.WriteLine("The service restore started. Please wait...");
                                    foreach (ServiceInformation item in backupInformation.ServiceList)
                                    {
                                        ServiceController service = new ServiceController(item.Name);
                                        service.Refresh();

                                        if (!service.StartType.Equals(item.StartType))
                                            ServiceHelper.ChangeStartModeT(service, item.StartType);

                                        if (service.Status != item.Status)
                                        {
                                            Console.Clear();
                                            Console.SetCursorPosition(0, 0);
                                            Console.WriteLine(String.Format("Service {0} is under processing. Please wait...", item.Name));

                                            if (item.Status.Equals(ServiceControllerStatus.Running))
                                            {
                                                service.Start();

                                                TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
                                                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                                                service.Refresh();
                                            }                                                
                                            else if (item.Status.Equals(ServiceControllerStatus.Stopped))
                                            {
                                                service.Stop();

                                                TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
                                                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                                                service.Refresh();                                                
                                            }   
                                        }
                                    }
                                    Console.Clear();
                                    Console.SetCursorPosition(0, 0);
                                    Console.WriteLine("The service restore completed successfuly");
                                }
                            }
                            return -1;
                        }
                        catch (Exception E)
                        {
                            String exception = E.ToString();
                            return -1;
                        }
                    case 1: // Create services backup
                        try
                        {
                            if (backupInformation != null)
                            {
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("The service backup started. Please wait...");
                                ServiceController[] Services = ServiceController.GetServices();
                                foreach (ServiceController service in Services)
                                {
                                    backupInformation.ServiceList.Add(new ServiceInformation()
                                    {
                                        Name = service.ServiceName,
                                        StartType = service.StartType,
                                        Status = service.Status
                                    });
                                }
                                backupInformation.Save();
                                Console.Clear();
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("The service backup completed successfuly");
                                return 1;
                            }
                            return -1;
                        }
                        catch (Exception E)
                        {
                            String exception = E.ToString();
                            return -1;
                        }
                }
            }
            return -1;
        }
    }

    public class ServiceInformation
    {
        public String Name { get; set; }
        public ServiceControllerStatus Status { get; set; }
        public ServiceStartMode StartType { get; set; }
    }

    [Serializable]
    public class BackupInformation
    {
        [XmlElement("ServiceList")]
        public List<ServiceInformation> ServiceList { get; set; }
        public BackupInformation()
        {
            ServiceList = new List<ServiceInformation>();
        }
        public String SerializeToString()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                StringWriter textWriter = new StringWriter();

                xmlSerializer.Serialize(textWriter, this);
                return textWriter.ToString();
            }
            catch (Exception E)
            {
                String exception = E.ToString();
                return String.Empty;
            }
        }

        public void DeserializeFromString(String stringData)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                using (TextReader reader = new StringReader(stringData))
                {
                    BackupInformation temp = (BackupInformation)xmlSerializer.Deserialize(reader);
                    this.ServiceList = temp.ServiceList;
                }
            }
            catch (Exception E)
            {
                String exception = E.ToString();
            }
        }

        public void Load()
        {
            String backupFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "srvclist.backup");

            if (File.Exists(backupFile))
            {
                try
                {
                    String serializedString = System.IO.File.ReadAllText(backupFile);
                    this.DeserializeFromString(serializedString);
                }
                catch (Exception E)
                {
                    String exception = E.ToString();
                }
            }
        }

        public void Save()
        {
            try
            {
                String backupFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "srvclist.backup");
                String serializedString = this.SerializeToString();
                System.IO.File.WriteAllText(backupFile, serializedString);
            }
            catch (Exception E)
            {
                String exception = E.ToString();
            }
        }
    }
}
