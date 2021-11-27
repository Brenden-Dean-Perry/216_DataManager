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
        private static string AppFolderPath { get; } = @"C:\Users\brend\OneDrive\Desktop\216\DataManager_216\";
        private static string AppFolderPath_Production = AppFolderPath + @"Production\";
        private static string AppFolderPath_CurrentInstall = AppFolderPath + @"Current Install\";
        private static string AppInstallerFullPath { get; } = @"C:\Users\brend\OneDrive\Desktop\216\AppInstaller\AppInstaller.exe";
        enum AppVersionFormat
        {
            DotSeperator,
            UnderscoreSeperator
        }

        public static void UpdateThisApp(string AppName)
        {
            if (!System.IO.Directory.Exists(AppFolderPath_Production))
            {
                MessageBox.Show("Folder path does not exist: " + AppFolderPath_Production);
                return;
            }

            string NewestVersion_Underscore = GetNewestAppVersion(AppVersionFormat.UnderscoreSeperator);
            string versionFilePath = AppFolderPath_CurrentInstall + "version.txt";
            string CurrentVersion = "1_0_0_0"; //If not found set to early version to force update
            if (System.IO.File.Exists(versionFilePath))
            {
                CurrentVersion = System.IO.File.ReadAllText(versionFilePath).Trim();
            }

            if (NewestVersion_Underscore != null && CurrentVersion != NewestVersion_Underscore)
            {
                if(System.IO.File.Exists(AppInstallerFullPath))
                {
                    string[] args = { AppName, NewestVersion_Underscore};
                    RunCommandInCMD(AppInstallerFullPath, args);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("AppInstaller was not found. Your application will not be updated. Please reach out for technical support.");
                }
            }
        }

        private static string GetNewestAppVersion(AppVersionFormat versionFormat = AppVersionFormat.DotSeperator)
        {
            if (!System.IO.Directory.Exists(AppFolderPath_Production))
            {
                MessageBox.Show("Directory not found: " + AppFolderPath_Production);
                return null;
            }

            string[] filesInDirectory = System.IO.Directory.GetDirectories(AppFolderPath_Production);
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
                if(versionFormat == AppVersionFormat.UnderscoreSeperator)
                {
                    return string.Join("_", MaxVersion);
                }
                else
                {
                    return string.Join(".", MaxVersion);
                }
                
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
