using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace TDMakerLib
{
    public static class FileSystem
    {
        public static StringBuilder mDebug = new StringBuilder();
        public static string DebugLogFilePath { get; set; }

        public static void AppendDebug(Exception ex)
        {
            AppendDebug(ex.ToString());
        }

        public static void AppendDebug(string msg)
        {
            // a modified http://iso.org/iso/en/prods-services/popstds/datesandtime.html - McoreD
            string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss - ") + msg;
            Console.WriteLine(line);
            mDebug.AppendLine(line);
        }

        public static void OpenDirTorrents()
        {
            if (Directory.Exists(Program.conf.TorrentsCustomDir))
            {
                Process.Start(Program.conf.TorrentsCustomDir);
            }
        }

        public static void OpenDirScreenshots()
        {
            if (Directory.Exists(Program.GetScreenShotsDir()))
            {
                Process.Start(Program.GetScreenShotsDir());
            }
        }

        public static void OpenDirTemplates()
        {
            if (Directory.Exists(Program.conf.TemplatesDir))
            {
                Process.Start(Program.conf.TemplatesDir);
            }
        }

        public static void OpenDirLogs()
        {
            if (Directory.Exists(Program.LogsDir))
            {
                Process.Start(Program.LogsDir);
            }
        }

        public static void OpenDirSettings()
        {
            if (Directory.Exists(Program.conf.SettingsDir))
            {
                Process.Start(Program.conf.SettingsDir);
            }
        }

        public static void OpenFileDebug()
        {
            if (File.Exists(FileSystem.DebugLogFilePath))
            {
                Process.Start(FileSystem.DebugLogFilePath);
            }
        }

        public static void WriteDebugLog()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(DebugLogFilePath, true))
                {
                    sw.WriteLine(mDebug.ToString());
                }
                mDebug = new System.Text.StringBuilder();
                // clear
                GC.Collect();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Function to move a directory with overwriting existing files
        /// </summary>
        /// <param name="dirOld"></param>
        /// <param name="dirNew"></param>
        public static void MoveDirectory(string dirOld, string dirNew)
        {
            if (Directory.Exists(dirOld) && dirOld != dirNew)
            {
                if (MessageBox.Show("Would you like to move old Root folder content to the new location?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(dirOld, dirNew, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
