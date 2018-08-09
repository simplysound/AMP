using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Security.Permissions;

namespace AMPClient
{
    static class Program
    {
        static Mutex mutex = new Mutex(false, "{992CC011-1A7C-4BA2-9AA1-0187BC7E6BA6}");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main()
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Application already started!", "", MessageBoxButtons.OK);
                return;
            }
            try
            {
                Application.ThreadException += new ThreadExceptionEventHandler(CommonExceptionHandlingMethod);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());
            }
            finally { mutex.ReleaseMutex(); }
        }

        private static void CommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = MessageBox.Show(t.Exception.ToString());
            }
            catch
            {
                try
                {
                    MessageBox.Show("Application Fatal Windows Error",
                        "Fatal Windows Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }
    }
}
