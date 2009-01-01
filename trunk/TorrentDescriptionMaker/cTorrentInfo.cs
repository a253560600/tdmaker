using System;
using System.Collections.Generic;
using System.Diagnostics;
using TorrentDescriptionMaker.Properties;
using System.IO;
using ZSS.ImageUploader;

namespace TorrentDescriptionMaker
{
    class cTorrentInfo
    {
        private string mMovieFilePath = string.Empty;

        public cTorrentInfo(string filePath)
        {
            this.mMovieFilePath = filePath;
            // fGetMovieInfo(); 
            sGetScreenshotPath();
        }

        /// <summary>
        /// Function to launch GSpot or MovieInfo to generate Movie Info
        /// </summary>
        private void sGetMovieInfo()
        {
            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.MovieInfoPath);
            psi.Arguments = string.Format("{0}", mMovieFilePath);
            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();

        }

        private void sGetScreenshotPath()
        {

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.MTNPath);
            string tempPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MTN");
            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            psi.Arguments = string.Format("{0} -O \"{1}\" \"{2}\"",
                Settings.Default.MTNArg,
                tempPath,
                this.mMovieFilePath);

            p.StartInfo = psi;
            p.Start();
            p.WaitForExit();

            string screenshot = Path.Combine(tempPath, Path.GetFileNameWithoutExtension(mMovieFilePath) + "_s.jpg");

            if (File.Exists(screenshot))
            {
                ImageShackUploader su = new ImageShackUploader();                             

                int retry = 1;
                List<ZSS.ImageUploader.ImageFile> lstScreenshots = null;
                while (retry <= 3 && lstScreenshots == null)
                {
                    Program.Status = string.Format("Uploading screenshot to ImageShack... Attempt {0}", retry);
                    lstScreenshots = su.UploadImage(screenshot);                    
                }

                if (lstScreenshots != null)
                {
                    foreach (ImageFile imf in lstScreenshots)
                    {
                        if (imf.Type == ImageFile.ImageType.FULLIMAGE)
                        {
                            this.ScreenshotURLFull = imf.URI;
                        }
                        else if (imf.Type == ImageFile.ImageType.THUMBNAIL_FORUMS1)
                        {
                            this.ScreenshotURLForums = imf.URI;
                        }
                    }
                }
                else
                {
                    Program.Status = "Failed uploading screenshot to ImageShack. Try again later.";
                }
            }

        }

        public string ScreenshotURLForums { get; private set; }
        public string ScreenshotURLFull { get; private set; }


    }
}
