using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using SHDocVw;
using System.IO;

namespace AMPClasses
{
    public static class Utils
    {
        public static EnumWinVersion GetWinVersionNumber()
        {
            OperatingSystem os = Environment.OSVersion;
            EnumWinVersion versionNumber = EnumWinVersion.UNKNOWN;

            switch (os.Version.Major)
            {
                case 4:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            versionNumber = EnumWinVersion.WIN95;
                            break;
                        case 10:
                            versionNumber = EnumWinVersion.WIN98;
                            break;
                        case 90:
                            versionNumber = EnumWinVersion.WINME;
                            break;
                        default:
                            versionNumber = EnumWinVersion.WIN98;
                            break;
                    }
                    break;
                case 5:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            versionNumber = EnumWinVersion.WIN2000;
                            break;
                        case 1:
                            versionNumber = EnumWinVersion.WINXP;
                            break;
                        case 2:
                            versionNumber = EnumWinVersion.WIN2003;
                            break;
                        default:
                            versionNumber = EnumWinVersion.WINXP;
                            break;
                    }
                    break;
                case 6:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            versionNumber = EnumWinVersion.WINVISTA;
                            break;
                        case 1:
                            versionNumber = EnumWinVersion.WIN7;
                            break;
                        case 2:
                            versionNumber = EnumWinVersion.WIN8;
                            break;
                        case 3:
                            versionNumber = EnumWinVersion.WIN81;
                            break;
                        default:
                            versionNumber = EnumWinVersion.WIN7;
                            break;
                    }
                    break;
                case 10:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            versionNumber = EnumWinVersion.WIN10;
                            break;
                        default:
                            versionNumber = EnumWinVersion.WIN10;
                            break;
                    }
                    break;
                default:
                    versionNumber = EnumWinVersion.UNKNOWN;
                    break;
            }

            return versionNumber;
        }
        /// <summary>
        /// 378389 - .NET Framework 4.5
        /// 378675 - .NET Framework 4.5.1 (Windows 8.1 OR Windows Server 2012 R2)
        /// 378758 - .NET Framework 4.5.1 (Windows 8 OR Windows 7 OR Windows Vista)
        /// 379893 - .NET Framework 4.5.2
        /// 393295 - .NET Framework 4.6 (Windows 10)
        /// 393297 - .NET Framework 4.6 (all other Windows versions)
        /// 394254 - .NET Framework 4.6.1 (Windows 10)
        /// 394271 - .NET Framework 4.6.1 (all other Windows versions)
        /// 394802 - .NET Framework 4.6.2 (Windows 10)
        /// 460798 - .NET Framework 4.7 (Windows 10)
        /// 460805 - .NET Framework 4.7 (all other Windows versions)
        /// 461308 - .NET framework 4.7.1 (Windows 10)
        /// 461310 - .NET framework 4.7.1 (all other Windows versions)
        /// </summary>
        /// <returns></returns>
        public static int GetFrameworkVersion()
        {
            try
            {
                using (RegistryKey NDPKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                    RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
                {
                    if (NDPKey != null && NDPKey.GetValue("Release") != null)
                    {
                        return Convert.ToInt32(NDPKey.GetValue("Release"));
                    }
                }
                return 0;
            }
            catch { return 0; };
        }

        public static void RestartExplorer()
        {
            try
            {
                bool must_restart = false;

                foreach (var process in Process.GetProcessesByName("explorer"))
                {
                    process.Kill();
                    must_restart = true;
                }
                if (must_restart)
                {
                    Process.Start("explorer");

                    ShellWindows windows;
                    int counter = 0;
                    while ((windows = new SHDocVw.ShellWindows()).Count == 0)
                    {
                        Thread.Sleep(1000);
                        counter++;
                        if (counter > 5)
                            break;
                    }

                    foreach (InternetExplorer p in windows)
                    {
                        if (Path.GetFileNameWithoutExtension(p.FullName.ToLower()) == "explorer")
                            p.Quit();
                    }
                }

            }
            catch { }
        }
    }
}
