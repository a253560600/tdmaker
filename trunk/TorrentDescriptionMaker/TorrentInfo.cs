using System;
using System.Collections.Generic;
using System.Diagnostics;
using TDMaker.Properties;
using System.IO;
using ZSS.ImageUploader;
using MediaInfoLib;
using System.Text;
using System.ComponentModel;

namespace TorrentDescriptionMaker
{
    class cTorrentInfo
    {
        private string mMovieFilePath = string.Empty;
        private BackgroundWorker mBwApp = null;

        public cTorrentInfo(BackgroundWorker bwApp, string filePath)
        {
            this.mBwApp = bwApp;
            this.mMovieFilePath = filePath;
            sGetMovieInfo();
            sGetScreenshotPath();
        }

        private void sReadMovie()
        {

        }

        /// <summary>
        /// Function to launch GSpot or MovieInfo to generate Movie Info
        /// </summary>      
        private void sGetMovieInfo()
        {
            BbCode bb = new BbCode();
            MediaInfoLib.MediaInfo mi = new MediaInfoLib.MediaInfo();
            mi.Open(mMovieFilePath);

            MediaInfo myMovie = new MediaInfo();
            myMovie.Format = mi.Get(StreamKind.General, 0, "Format");
            myMovie.FormatInfo = mi.Get(StreamKind.General, 0, "Format/Info");
            StringBuilder sbMediaInfo = new StringBuilder();

            //Console.WriteLine(mi.Option("Complete"));
            //Console.WriteLine(mi.Inform());

            sbMediaInfo.AppendLine(bb.bold("General:"));
            sbMediaInfo.AppendLine();
            // File Name
            sbMediaInfo.AppendLine(string.Format("    File Name: {0}.{1}",
                mi.Get(0, 0, "FileName"),
                mi.Get(0, 0, "FileExtension")));
            // Format
            if (!string.IsNullOrEmpty(myMovie.FormatInfo))
            {
                sbMediaInfo.AppendLine(string.Format("       Format: {0} ({1})",
                    myMovie.Format,
                    myMovie.FormatInfo));
            }
            else
            {
                sbMediaInfo.AppendLine(string.Format("       Format: {0}", myMovie.Format));
            }


            // File Size
            sbMediaInfo.AppendLine(string.Format("    File Size: {0}", mi.Get(0, 0, "FileSize/String4")));
            // Duration
            sbMediaInfo.AppendLine(string.Format("     Duration: {0}", mi.Get(0, 0, "Duration/String2")));
            // Bitrate
            sbMediaInfo.AppendLine(string.Format("      Bitrate: {0}", mi.Get(StreamKind.General, 0, "OverallBitRate/String")));

            int subCount = 0;
            int.TryParse(mi.Get(StreamKind.Text, 0, "Count"), out subCount);

            sbMediaInfo.Append("    Subtitles: ");
            if (subCount > 0)
            {

                for (int i = 0; i < subCount; i++)
                {
                    string lang = mi.Get(StreamKind.Text, i, "Language/String");
                    if (!string.IsNullOrEmpty(lang))
                    {
                        // System.Windows.Forms.MessageBox.Show(lang);
                        sbMediaInfo.Append(lang);
                        if (i < subCount - 1)
                            sbMediaInfo.Append(", ");
                    }
                }
            }
            else
            {
                sbMediaInfo.Append("None");
            }
            sbMediaInfo.Append(Environment.NewLine);



            //*********************
            //* Video
            //*********************
            VideoInfo vi = new VideoInfo();

            sbMediaInfo.AppendLine();
            sbMediaInfo.AppendLine(bb.bold("Video:"));
            sbMediaInfo.AppendLine();
            // Format
            vi.FormatVersion = mi.Get(StreamKind.Video, 0, "Format_Version");
            sbMediaInfo.Append(string.Format("       Format: {0}", mi.Get(StreamKind.Video, 0, "Format")));
            if (!string.IsNullOrEmpty(vi.FormatVersion))
            {
                sbMediaInfo.Append(string.Format(" {0}", vi.FormatVersion));
            }
            sbMediaInfo.Append(Environment.NewLine);

            // Codec
            this.VideoCodec = mi.Get(StreamKind.Video, 0, "CodecID/Hint");
            if (string.IsNullOrEmpty(VideoCodec))
                this.VideoCodec = mi.Get(StreamKind.Video, 0, "CodecID");
            if (!string.IsNullOrEmpty(VideoCodec))
                sbMediaInfo.AppendLine(string.Format("        Codec: {0}", this.VideoCodec));
            // Bitrate
            sbMediaInfo.AppendLine(string.Format("      Bitrate: {0}", mi.Get(StreamKind.Video, 0, "BitRate/String")));
            // Standard
            vi.Standard = mi.Get(StreamKind.Video, 0, "Standard");
            if (!string.IsNullOrEmpty(vi.Standard))
                sbMediaInfo.AppendLine(string.Format("     Standard: {0}", vi.Standard));
            // Frame Rate
            sbMediaInfo.AppendLine(string.Format("   Frame Rate: {0}", mi.Get(StreamKind.Video, 0, "FrameRate/String")));

            // Scan Type
            sbMediaInfo.AppendLine(string.Format("    Scan Type: {0}", mi.Get(StreamKind.Video, 0, "ScanType/String")));

            // Resolution
            sbMediaInfo.AppendLine(string.Format("   Resolution: {0}x{1}",
                mi.Get(StreamKind.Video, 0, "Width"),
                mi.Get(StreamKind.Video, 0, "Height")));

            int audioCount = 0;
            int.TryParse(mi.Get(StreamKind.General, 0, "AudioCount"), out audioCount);

            for (int a = 0; a < audioCount; a++)
            {
                AudioInfo ai = new AudioInfo();

                sbMediaInfo.AppendLine();
                sbMediaInfo.AppendLine(string.Format(bb.bold("Audio #{0}:"), a + 1));
                sbMediaInfo.AppendLine();
                // Format
                sbMediaInfo.Append(string.Format("       Format: {0}", mi.Get(StreamKind.Audio, a, "Format")));
                ai.FormatVersion = mi.Get(StreamKind.Audio, 0, "Format_Version");
                if (!string.IsNullOrEmpty(ai.FormatVersion))
                    sbMediaInfo.Append(string.Format(" {0}", ai.FormatVersion));
                ai.FormatProfile = mi.Get(StreamKind.Audio, 0, "Format_Profile");
                if (!string.IsNullOrEmpty(ai.FormatProfile))
                    sbMediaInfo.Append(string.Format(" {0}", ai.FormatProfile));
                sbMediaInfo.Append(Environment.NewLine);


                this.AudioCodec = mi.Get(StreamKind.Audio, 0, "CodecID/Hint");
                if (string.IsNullOrEmpty(this.AudioCodec))
                    this.AudioCodec = mi.Get(StreamKind.Audio, 0, "CodecID");
                if (!string.IsNullOrEmpty(this.AudioCodec))
                    sbMediaInfo.AppendLine(string.Format("        Codec: {0}", this.AudioCodec));
                // Bitrate
                sbMediaInfo.AppendLine(string.Format("      Bitrate: {0} ({1})",
                    mi.Get(StreamKind.Audio, a, "BitRate/String"),
                    mi.Get(StreamKind.Audio, a, "BitRate_Mode/String")));
                // Channels
                sbMediaInfo.AppendLine(string.Format("     Channels: {0}", mi.Get(StreamKind.Audio, a, "Channel(s)/String")));
                // Sampling Rate
                sbMediaInfo.AppendLine(string.Format("Sampling Rate: {0}", mi.Get(StreamKind.Audio, a, "SamplingRate/String")));
                // Resolution
                this.AudioResolution = mi.Get(StreamKind.Audio, a, "Resolution/String");
                if (!string.IsNullOrEmpty(AudioResolution))
                    sbMediaInfo.AppendLine(string.Format("   Resolution: {0}", this.AudioResolution));

                myMovie.Audio.Add(ai);

            }

            this.MediaInfo = sbMediaInfo.ToString();

            mBwApp.ReportProgress(0, this.MediaInfo);

        }

        private void sGetScreenshotPath()
        {

            Process p = new Process();
            ProcessStartInfo psi = new ProcessStartInfo(Settings.Default.MTNPath);
            psi.WindowStyle = ProcessWindowStyle.Minimized;
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

        public string AudioCodec { get; private set; }
        public string AudioFormat { get; private set; }
        public string AudioResolution { get; private set; }
        public string VideoCodec { get; private set; }
        public string VideoFormat { get; private set; }

    }
}
