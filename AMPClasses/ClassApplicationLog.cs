using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace AMPClasses
{
    public class ApplicationLog
    {        
        public string LogFileName;
        public bool isDebugEnabled;
        private static object fileLock = new object();

        public ApplicationLog()
        {
            LogFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), String.Format(@"{0}.log", Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().Location)));
            isDebugEnabled = true;
        }
        /// <summary>
        /// Write empty string to the logfile
        /// </summary>
        public void WriteLog()
        {
            if (isDebugEnabled == false)
                return;
            lock (fileLock)
            {
                if (!File.Exists(LogFileName))
                {
                    using (StreamWriter sw = File.CreateText(LogFileName))
                    {
                        sw.WriteLine(String.Format("{0} {1}:", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(LogFileName))
                    {
                        sw.WriteLine(String.Format("{0} {1}:", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString()));
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Write message to the logfile
        /// </summary>
        /// <param name="message"></param>
        public void WriteLog(String message)
        {
            lock (fileLock)
            {
                if (isDebugEnabled == false)
                    return;

                if (!File.Exists(LogFileName))
                {
                    using (StreamWriter sw = File.CreateText(LogFileName))
                    {
                        sw.WriteLine(String.Format("{0} {1}:\t{2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), message));
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(LogFileName))
                    {
                        sw.WriteLine(String.Format("{0} {1}:\t{2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), message));
                        sw.Flush();
                        sw.Close();
                    }
                }
            }
        }
        /// <summary>
        /// Write message to the logfile
        /// </summary>
        /// <param name="functionName"></param>
        /// <param name="message"></param>
        public void WriteLog(String functionName, String message)
        {
            if (isDebugEnabled == false)
                return;
            lock (fileLock)
            {
                if (!File.Exists(LogFileName))
                {
                    using (StreamWriter sw = File.CreateText(LogFileName))
                    {
                        sw.WriteLine(String.Format("{0} {1}:\t{2}:\t{3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), functionName, message));
                        sw.WriteLine();
                        sw.Flush();
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(LogFileName))
                    {
                        lock (fileLock)
                        {
                            sw.WriteLine(String.Format("{0} {1}:\t{2}:\t{3}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString(), functionName, message));
                            sw.WriteLine();
                            sw.Flush();
                            sw.Close();
                        }
                    }
                }
            }
        }
    }
}
