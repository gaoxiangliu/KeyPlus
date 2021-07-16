using System;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace KeyboardHook01
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            bool ok;
            string strAppName = "KeyPlus";
            string strMutex = WindowsIdentity.GetCurrent().Name.ToString();
            strMutex = strMutex.Split('\\')[1];
            strMutex += strAppName;
            Mutex m = new Mutex(true, strMutex, out ok);
            if (!ok)
            {
                Application.Exit();
            }
            else
            {
                Application.Run(new Form1());
                GC.KeepAlive(m);
            }
        }
    }
}