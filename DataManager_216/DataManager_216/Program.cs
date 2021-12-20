using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManager_216
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

            //Update check
            string ApplicationName = "DataManager_216";
            ApplicationUpdater.UpdateThisApp(ApplicationName);
            Application.Run(new frmLogin());
        }
    }
}
