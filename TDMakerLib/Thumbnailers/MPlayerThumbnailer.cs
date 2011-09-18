using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace TDMakerLib
{
    public class MPlayerThumbnailer : Thumbnailer
    {
        private const string MplayerScreenshotFileName = "00000001.png";

        private MPlayerThumbnailer()
        {

        }

        public MPlayerThumbnailer(MediaFile mf, string ssDir)
        {
            this.MediaFile = mf;
            this.ScreenshotDir = ssDir;
        }

        public override void TakeScreenshot()
        {
            string tempFp = Path.Combine(ScreenshotDir, MplayerScreenshotFileName);
            int time_slice = (int)(MediaFile.Duration / 4000);

            if (File.Exists(tempFp))
            {
                File.Delete(tempFp); 
            }
            for (int i = 0; i < 3; i++)
            {
                int time_slice_elapsed = time_slice * (i + 1);
                string arg = string.Format("-nosound -ss {0} -vf screenshot -frames 1 -vo png:z=9:outdir=\\\"{1}\\\" \"{2}\"", time_slice_elapsed,
                                                                                                                                 ScreenshotDir,
                                                                                                                                 MediaFile.FilePath);
                ProcessStartInfo psi = new ProcessStartInfo(Engine.conf.MPlayerPath);
                psi.WindowStyle = ProcessWindowStyle.Minimized;
                psi.Arguments = arg;

                Process p = new Process();
                p.StartInfo = psi;
                p.Start();
                p.WaitForExit(1000 * 30);

                string ssPath = Path.Combine(ScreenshotDir, string.Format("{0}-{1}.png", Path.GetFileNameWithoutExtension(MediaFile.FilePath), time_slice_elapsed));
                if (File.Exists(ssPath)) File.Delete(ssPath);

                if (File.Exists(tempFp))
                {
                    File.Move(tempFp, ssPath);
                    Screenshots.Add(new Screenshot() { 
                        Args = arg,
                        LocalPath = ssPath });
                }
            }

        }
    }
}
