using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataManager_216
{
    public static class ApplicationUpdater
    {
        private static string AppFolderPath { get; } =  @"C:\Program Files\DataManager_216\";
        public static void UpdateThisApp()
        {

            string NewestVersion = GetNewestAppVersion(); 

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string CurrentVersion = fvi.FileVersion;
            MessageBox.Show(CurrentVersion);

            if (NewestVersion != null && CurrentVersion != NewestVersion)
            {
                MessageBox.Show("Update needed");
            }

            MessageBox.Show(assembly.Location);
        }

        private static string GetNewestAppVersion()
        {
            if (!System.IO.Directory.Exists(AppFolderPath))
            {
                MessageBox.Show("Directory not found: " + AppFolderPath);
                return null;
            }

            string[] filesInDirectory = System.IO.Directory.GetDirectories(AppFolderPath);
            foreach (string dir in filesInDirectory)
            {
                MessageBox.Show(dir);
            }

            return "";
        }
    }
}
