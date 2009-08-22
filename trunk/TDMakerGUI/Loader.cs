using System;
using System.Windows.Forms;
using TDMakerLib;

namespace TDMaker
{
    static class Loader
    {
        /// <summary>
        /// Application Version
        /// </summary>
        public static McoreSystem.AppInfo gAppInfo = new McoreSystem.AppInfo(Application.ProductName, Application.ProductVersion, McoreSystem.AppInfo.SoftwareCycle.Final);
        public static TaskType CurrentTask { get; set; }

        public static string LogsDir { get; set; }

        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.Load();

            if (args.Length > 1 && Program.IsUNIX)
            {
                // we process the args
                Console.WriteLine(Environment.CommandLine);
            }
            else
            {
                Application.Run(new MainWindow());
            }

            Program.Unload();
        }


    }
}
