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
        private static string AppFolderPath { get; } = @"C:\Users\brend\OneDrive\Desktop\216\DataManager\Production\";
        private static string AppInstallerFullPath { get; } = @"C:\Users\brend\OneDrive\Desktop\216\DataManager\Production\";
        public static void UpdateThisApp(string AppName)
        {
            string NewestVersion = GetNewestAppVersion();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string CurrentVersion = fvi.FileVersion;

            if (NewestVersion != null && CurrentVersion != NewestVersion)
            {
                if(System.IO.File.Exists(AppInstallerFullPath))
                {
                    string NewVersionAppInstallerFormat = "";
                    string[] args = { AppName, NewVersionAppInstallerFormat };
                    RunCommandInCMD(AppInstallerFullPath, args);
                }
                else
                {
                    MessageBox.Show("AppInstaller was not found. Your application will not be updated. Please reach out for technical support.");
                }
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
            List<int[]> dirVersions = new List<int[]>();
            foreach (string dir in filesInDirectory)
            {
                string[] version = dir.Split('_');
                if(version.Length >= 4)
                {
                    bool failed = false;
                    if(Int32.TryParse(version.ElementAt(version.Length - 4), out int IntVersion0) == false)
                    {
                        failed = true;
                    }

                    if (Int32.TryParse(version.ElementAt(version.Length - 3), out int IntVersion1) == false)
                    {
                        failed = true;
                    }

                    if (Int32.TryParse(version.ElementAt(version.Length - 2), out int IntVersion2) == false)
                    {
                        failed = true;
                    }

                    if (Int32.TryParse(version.ElementAt(version.Length - 1), out int IntVersion3) == false)
                    {
                        failed = true;
                    }


                    if (failed == false)
                    {
                        int[] versionTruncated = { IntVersion0, IntVersion1, IntVersion2, IntVersion3};
                        dirVersions.Add(versionTruncated);
                    }
                }
            }

            int[] MaxVersion = FindMaxVersion(dirVersions);

            if(MaxVersion.Length >= 1)
            {
                return string.Join(".", MaxVersion);
            }
            else
            {
                return null;
            }
            
        }

        private static int[] FindMaxVersion(List<int[]> dirVersions)
        {
            int MaxVersionIndex = -1;
            int Max_0 = 0;
            int Max_1 = 0;
            int Max_2 = 0;
            int Max_3 = 0;

            foreach (int[] version in dirVersions)
            {
                //Find index value 0
                if(version.ElementAt(0) > Max_0)
                {
                    Max_0 = version.ElementAt(0);
                }

                //Find index value 1
                if (version.ElementAt(1) > Max_1)
                {
                    Max_1 = version.ElementAt(1);
                }

                //Find index value 2
                if (version.ElementAt(2) > Max_2)
                {
                    Max_2 = version.ElementAt(2);
                }

                //Find index value 3
                if (version.ElementAt(3) > Max_3)
                {
                    Max_3 = version.ElementAt(3);
                }

            }

            int[] model = { Max_0, Max_1, Max_2, Max_3 };
            MaxVersionIndex = dirVersions.FindIndex(x => x.SequenceEqual(model));
            if(MaxVersionIndex >= 0)
            {
                return dirVersions[MaxVersionIndex];
            }
            else
            {
                return null;
            }
        }


        private static void RunCommandInCMD(string ProgramFullPath, string[] parameters)
        {
            string strCmdText;
            string parameterString = string.Join(" ", parameters);
            strCmdText = "/C " + ProgramFullPath+ " " + parameterString;
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}
