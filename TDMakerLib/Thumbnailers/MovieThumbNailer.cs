using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TDMakerLib
{
    public class MovieThumbNailer : Thumbnailer
    {
        private MovieThumbNailer()
        {

        }

        public MovieThumbNailer(MediaFile mf, string ssDir)
        {
            this.MediaFile = mf;
            this.ScreenshotDir = ssDir;
        }

        public override void TakeScreenshot()
        {
            try
            {
                Debug.WriteLine("Creating a MTN process...");
                string assemblyMTN = (Engine.IsUNIX ? Engine.conf.MTNPath.Replace(".exe", "") : Engine.conf.MTNPath);
                if (string.IsNullOrEmpty(Path.GetDirectoryName(assemblyMTN)))
                {
                    assemblyMTN = Path.Combine(System.Windows.Forms.Application.StartupPath, assemblyMTN);
                    Engine.conf.MTNPath = assemblyMTN;
                }

                string args = string.Format("{0} \"{1}\"", Adapter.GetMtnArg(ScreenshotDir, Engine.mtnProfileMgr.GetMtnProfileActive()), MediaFile.FilePath);

                Process p = new Process();
                ProcessStartInfo psi = new ProcessStartInfo(assemblyMTN);

                if (Engine.IsUNIX)
                {
                    psi.UseShellExecute = false;
                }

                Debug.WriteLine("MTN Path: " + assemblyMTN);
                Debug.WriteLine("MTN Args: " + args);

                psi.WindowStyle = (Engine.conf.ShowMTNWindow ? ProcessWindowStyle.Normal : ProcessWindowStyle.Normal);
                Debug.WriteLine("MTN Window: " + psi.WindowStyle.ToString());
                psi.Arguments = args;

                p.StartInfo = psi;
                p.Start();
                p.WaitForExit(1000 * 30);

                string ssPath = Path.Combine(ScreenshotDir, Path.GetFileNameWithoutExtension(MediaFile.FilePath) + Engine.mtnProfileMgr.GetMtnProfileActive().o_OutputSuffix);
                Screenshots.Add(new Screenshot()
                {
                    LocalPath = ssPath,
                    Args = args
                });

                if (Engine.IsUNIX)
                {
                    string info = Path.Combine(FileSystem.GetScreenShotsDir(MediaFile.FilePath), Path.GetFileNameWithoutExtension(MediaFile.FilePath) + Engine.mtnProfileMgr.GetMtnProfileActive().N_InfoSuffix);

                    using (StreamReader sr = new StreamReader(info))
                    {
                        MediaSummary = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
