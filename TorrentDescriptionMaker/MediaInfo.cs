using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MediaInfoLib;

namespace TorrentDescriptionMaker
{
    /// <summary>
    /// Class that holds all Media Info: Genernal, Audio 1 to n, Video
    /// </summary>
    public class MediaInfo
    {
        /// <summary>
        /// Duration in seconds
        /// </summary>
        public long Duration { get; set; }
        /// <summary>
        /// Duration in hours:minutes:seconds
        /// </summary>
        public string DurationString { get; set; }
        public string FileName { get; set; }
        /// <summary>
        /// File Size in Bytes
        /// </summary>
        public string FileSize { get; set; }
        public string Format { get; set; }
        public string FormatInfo { get; set; }
        public string Subtitles { get; set; }

        public List<AudioInfo> Audio { get; set; }
        public VideoInfo Video { get; set; }

        private string[] mExt = new string[] { ".avi", ".divx", ".mkv", ".vob" };

        public MediaInfo(string p)
        {
            this.Audio = new List<AudioInfo>();
            this.Video = new VideoInfo();

            sReadMovie(p);

        }

        /// <summary>
        /// Function to populate MediaInfo class
        /// </summary>
        private void sReadMovie(string p)
        {
            // if a folder then read all media files 
            // append all the durations and save in Duration

            if (Directory.Exists(p))
            {

                // Guess File Name
                this.FileName = Path.GetFileName(p);
                if (this.FileName.ToUpper().Equals("VIDEO_TS"))
                    this.FileName = Path.GetFileName(Path.GetDirectoryName(p));

                // Calculate Duration
                string[] vobFiles = Directory.GetFiles(p, "*.vob", SearchOption.AllDirectories);               
                if (vobFiles.Length > 0)
                {
                    long dura = 0;
                    foreach (string vob in vobFiles)
                    {
                        MediaInfoLib.MediaInfo mi = new MediaInfoLib.MediaInfo();
                        mi.Open(vob);
                        string temp = mi.Get(0, 0, "Duration");
                        if (!string.IsNullOrEmpty(temp))
                        {
                            long d = 0;
                            long.TryParse(temp, out d);
                            dura += d;
                        }
                    }
                    this.Duration = dura / 1000;

                    long hours = this.Duration / 3600;
                    long secLeft = this.Duration - hours * 3600;
                    long mins = secLeft / 60;
                    long sec = secLeft - mins * 60;

                    this.DurationString = string.Format("{0}:{1}:{2}", hours.ToString("00"), mins.ToString("00"), sec.ToString("00"));
                }
                
                // Subtitles, Format
                // VTS_01_0.IFO
                string[] ifo = Directory.GetFiles(p, "VTS_01_0.IFO", SearchOption.AllDirectories);
                if (ifo.Length == 1)
                {
                    MediaInfoLib.MediaInfo mi = new MediaInfoLib.MediaInfo();
                    mi.Open(ifo[0]);

                    // most prolly this will be: DVD Video
                    this.Format = mi.Get(StreamKind.General, 0, "Format");

                    int subCount = 0;
                    int.TryParse(mi.Get(StreamKind.Text, 0, "StreamCount"), out subCount);

                    if (subCount > 0)
                    {

                        List<string> langs = new List<string>();
                        for (int i = 0; i < subCount; i++)
                        {
                            string lang = mi.Get(StreamKind.Text, i, "Language/String");
                            if (!string.IsNullOrEmpty(lang))
                            {
                                // System.Windows.Forms.MessageBox.Show(lang);
                                if (!langs.Contains(lang))
                                    langs.Add(lang);
                            }
                        }
                        StringBuilder sbLangs = new StringBuilder();
                        for (int i = 0; i < langs.Count; i++)
                        {
                            sbLangs.Append(langs[i]);
                            if (i < langs.Count - 1)
                                sbLangs.Append(", ");
                        }

                        this.Subtitles = sbLangs.ToString();
                    }

                    mi.Close();
                }

            }

        }

    }

    public class AudioInfo
    {
        public string FormatProfile { get; set; }
        public string FormatVersion { get; set; }
    }

    public class VideoInfo
    {
        public string Standard { get; set; }
        public string FormatVersion { get; set; }

    }

}
