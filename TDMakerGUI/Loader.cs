using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TDMakerLib;

namespace TDMaker
{
    internal static class Loader
    {
        /// <summary>
        /// Application Version
        /// </summary>
        public static McoreSystem.AppInfo gAppInfo = new McoreSystem.AppInfo(Application.ProductName, Application.ProductVersion, McoreSystem.AppInfo.SoftwareCycle.Final);

        public static List<string> ExplorerFilePaths = new List<string>();

        public static TaskType CurrentTask { get; set; }

        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                foreach (string arg in args)
                {
                    if (File.Exists(arg))
                    {
                        ExplorerFilePaths.Add(arg);
                    }
                }
            }

            if (Engine.TurnOn())
            {
                Engine.LoadSettings();
                Application.Run(new MainWindow());
                Engine.TurnOff();
            }
        }
    }
}