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

        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Engine.Load())
            {
                if (args.Length > 1 && Engine.IsUNIX)
                {
                    // we process the args
                    Console.WriteLine(Environment.CommandLine);
                }
                else
                {
                    Application.Run(new MainWindow());
                }
            }
            Engine.Unload();
        }


    }
}
