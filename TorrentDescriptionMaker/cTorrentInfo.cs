﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using TorrentDescriptionMaker.Properties;
using System.IO;
using ZSS.ImageUploader;
using MediaInfoLib;
using System.Text;

namespace TorrentDescriptionMaker
{
    class cTorrentInfo
    {
        private string mMovieFilePath = string.Empty;
        public cTorrentInfo(string filePath)
        {
            this.mMovieFilePath = filePath;
            sGetMovieInfo();
            // sGetScreenshotPath();
        }

        /// <summary>
        /// Function to launch GSpot or MovieInfo to generate Movie Info
        /// </summary>
        private void sGetMovieInfo()
        {

            MediaInfoLib.MediaInfo mi = new MediaInfoLib.MediaInfo();
            mi.Open(mMovieFilePath);

            StringBuilder sbMediaInfo = new StringBuilder();

            //Console.WriteLine(mi.Option("Complete"));
            //Console.WriteLine(mi.Inform());

            sbMediaInfo.AppendLine("General");
            sbMediaInfo.AppendLine();
            // File Name
            sbMediaInfo.Append(string.Format(" File Name: {0}", mi.Get(0, 0, "FileName")));
            sbMediaInfo.AppendLine(string.Format(".{0}", mi.Get(0, 0, "FileExtension")));
            // Format
            sbMediaInfo.AppendLine(string.Format("    Format: {0} ({1})",
                mi.Get(StreamKind.General, 0, "Format"),
                mi.Get(StreamKind.General, 0, "Format/Info")));
            // File Size
            sbMediaInfo.AppendLine(string.Format(" File Size: {0}", mi.Get(0, 0, "FileSize/String4")));
            // Duration
            sbMediaInfo.AppendLine(string.Format("  Duration: {0}", mi.Get(0, 0, "Duration/String2")));
            // Bitrate
            sbMediaInfo.AppendLine(string.Format("   Bitrate: {0}", mi.Get(StreamKind.General, 0, "OverallBitRate/String")));

            sbMediaInfo.AppendLine();
            sbMediaInfo.AppendLine("Video");
            sbMediaInfo.AppendLine();
            // Format
            sbMediaInfo.AppendLine(string.Format("    Format: {0}", mi.Get(StreamKind.Video, 0, "Format")));
            sbMediaInfo.AppendLine(string.Format("     Codec: {0}", mi.Get(StreamKind.Video, 0, "CodecID")));
            // Resolution
            sbMediaInfo.AppendLine(string.Format("Resolution: {0}x{1}",
                mi.Get(StreamKind.Video, 0, "Width"),
                mi.Get(StreamKind.Video, 0, "Height")));

            int audioCount = 0; 
            int.TryParse(mi.Get(StreamKind.General, 0, "AudioCount"), out audioCount);

            for (int a = 0; a < audioCount; a++)
            {
                sbMediaInfo.AppendLine();
                sbMediaInfo.AppendLine(string.Format("Audio #{0}", a+1));
                sbMediaInfo.AppendLine();
                // Format
                sbMediaInfo.AppendLine(string.Format("    Format: {0}", mi.Get(StreamKind.Audio, a, "Format")));
                sbMediaInfo.AppendLine(string.Format("     Codec: {0}", mi.Get(StreamKind.Audio, 0, "CodecID/Hint")));
                // Bitrate
                sbMediaInfo.AppendLine(string.Format("   Bitrate: {0} ({1})",
                    mi.Get(StreamKind.Audio, a, "BitRate/String"),
                    mi.Get(StreamKind.Audio, a, "BitRate_Mode/String")));

            }

            this.MediaInfo = sbMediaInfo.ToString();

            Console.WriteLine(sbMediaInfo.ToString());




            //Process p = new Process();
            //ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.MovieInfoPath);
            //psi.Arguments = string.Format("\"{0}\" /X", mMovieFilePath);
            //p.StartInfo = psi;
            //p.Start();
            //p.WaitForExit();

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
        public string MediaInfo { get; private set; }

        public string GeneralFileName { get; private set; }
        public string GeneralFileSize { get; private set; }
        public string VideoFormat{ get; private set; }
        public string VideoCodec { get; private set; }


    }
}
