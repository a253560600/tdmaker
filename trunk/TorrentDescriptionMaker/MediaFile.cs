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
    public class MediaFile
    {
        public string Bitrate { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// Duration in hours:minutes:seconds
        /// </summary>
        public string DurationString { get; set; }
        public string FileName { get; set; }
        /// <summary>
        /// Always a File Path of Media
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// File Size in Bytes
        /// </summary>
        public double FileSize { get; set; }
        /// <summary>
        /// File Size in XX.X MiB
        /// </summary>
        public string FileSizeString { get; set; }
        public string Format { get; set; }
        public string FormatInfo { get; set; }
        /// <summary>
        /// FilePath or DirectoryPath of the Media
        /// </summary>
        public string Location { get; private set; }
        public string Source { get; set; }
        public string Subtitles { get; set; }
        /// <summary>
        /// This is what you get for mi.Option("Complete");
        /// </summary>
        public string Summary { get; set; }
        public string WebLink { get; set; }

        public List<AudioInfo> Audio { get; private set; }
        public VideoInfo Video { get; private set; }

        private string[] mExt = new string[] { ".avi", ".divx", ".mkv", ".vob" };

        public MediaFile(string p)
        {
            // this could be a file path or a directory
            this.Location = p;

            this.Audio = new List<AudioInfo>();
            this.Video = new VideoInfo();

        }

        /// <summary>
        /// Function to populate MediaInfo class
        /// </summary>
        public void ReadMedia()
        {
            // if a folder then read all media files 
            // append all the durations and save in Duration

            if (File.Exists(Location))
            {
                this.FilePath = Location;
                this.FileName = Path.GetFileName(this.FilePath);
                ReadFile();
            }
            else if (Directory.Exists(Location))
            {

                // get largest file 
                string[] files = Directory.GetFiles(Location, "*.*", SearchOption.AllDirectories);
                if (files.Length > 0)
                {
                    string maxPath = "";
                    long maxSize = 0;
                    for (int i = 0; i < files.Length; i++)
                    {
                        FileInfo fi = new FileInfo(files[i]);
                        if (maxSize < fi.Length)
                        {
                            maxSize = fi.Length;
                            maxPath = fi.FullName;
                        }
                    }
                    this.FilePath = maxPath;
                    this.FileName = Path.GetFileName(this.FilePath);
                    ReadFile();
                }

                // DVD Video
                // Calculate Duration and File Size
                string[] vobFiles = Directory.GetFiles(Location, "*.vob", SearchOption.AllDirectories);
                if (vobFiles.Length > 0)
                {

                    // Guess File Name
                    this.FileName = Path.GetFileName(Location);
                    if (this.FileName.ToUpper().Equals("VIDEO_TS"))
                        this.FileName = Path.GetFileName(Path.GetDirectoryName(Location));

                    long dura = 0;
                    double size = 0;
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

                        // we are interested in combined file size only for VOB files 
                        // thats why we dont calculate FileSize in FileInfo while determining largest file
                        double sz = 0;
                        double.TryParse(mi.Get(0, 0, "FileSize"), out sz);
                        size += sz;

                        // close vob file
                        mi.Close();
                    }

                    this.FileSize = size; // override any previous file size
                    this.FileSizeString = string.Format("{0} MiB", (this.FileSize / 1024.0 / 1024.0).ToString("0.00"));

                    this.Duration = dura / 1000.0;

                    long hours = (long)this.Duration / 3600;
                    long secLeft = (long)this.Duration - hours * 3600;
                    long mins = secLeft / 60;
                    long sec = secLeft - mins * 60;

                    this.DurationString = string.Format("{0}:{1}:{2}",
                        hours.ToString("00"),
                        mins.ToString("00"),
                        sec.ToString("00"));
                }

                // Subtitles, Format: DVD Video using VTS_01_0.IFO
                string[] ifo = Directory.GetFiles(Location, "VTS_01_0.IFO", SearchOption.AllDirectories);
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

                    // close ifo file
                    mi.Close();
                }

            } // if Location is a directory

        }

        private void ReadFile()
        {
            if (File.Exists(FilePath))
            {
                //*********************
                //* General
                //********************* 

                MediaInfoLib.MediaInfo mMI = new MediaInfoLib.MediaInfo();
                mMI.Open(FilePath);
                mMI.Option("Complete");
                this.Summary = mMI.Inform();

                // Format Info
                if (string.IsNullOrEmpty(this.Format))
                    this.Format = mMI.Get(StreamKind.General, 0, "Format");
                this.FormatInfo = mMI.Get(StreamKind.General, 0, "Format/Info");

                // this.FileName = mMI.Get(0, 0, "FileName");
                if (0 == this.FileSize)
                {
                    double sz;
                    double.TryParse(mMI.Get(0, 0, "FileSize"), out sz);
                    this.FileSize = sz;
                }
                if (string.IsNullOrEmpty(FileSizeString))
                {
                    this.FileSizeString = string.Format("{0} MiB", (this.FileSize / 1024.0 / 1024.0).ToString("0.00"));
                }

                // Duration
                if (string.IsNullOrEmpty(this.DurationString))
                    this.DurationString = mMI.Get(0, 0, "Duration/String2");

                this.Bitrate = mMI.Get(StreamKind.General, 0, "OverallBitRate/String");

                if (string.IsNullOrEmpty(this.Subtitles))
                {
                    StringBuilder sbSubs = new StringBuilder();

                    int subCount = 0;
                    int.TryParse(mMI.Get(StreamKind.Text, 0, "StreamCount"), out subCount);

                    if (subCount > 0)
                    {

                        StringBuilder sbLang = new StringBuilder();
                        for (int i = 0; i < subCount; i++)
                        {
                            string lang = mMI.Get(StreamKind.Text, i, "Language/String");
                            if (!string.IsNullOrEmpty(lang))
                            {
                                // System.Windows.Forms.MessageBox.Show(lang);
                                sbLang.Append(lang);
                                if (i < subCount - 1)
                                    sbLang.Append(", ");
                            }
                        }
                        if (!string.IsNullOrEmpty(sbLang.ToString()))
                        {
                            sbSubs.Append(sbLang.ToString());
                        }
                        else
                        {
                            sbSubs.Append("N/A");
                        }
                    }
                    else
                    {
                        sbSubs.Append("None");
                    }

                    this.Subtitles = sbSubs.ToString();

                }

                //*********************
                //* Video
                //********************* 
                this.Video.Format = mMI.Get(StreamKind.Video, 0, "Format");
                this.Video.FormatVersion = mMI.Get(StreamKind.Video, 0, "Format_Version");

                if (Path.GetExtension(this.FilePath).ToLower().Equals(".mkv"))
                {
                    this.Video.Codec = mMI.Get(StreamKind.Video, 0, "Encoded_Library");
                }
                if (string.IsNullOrEmpty(this.Video.Codec))
                    this.Video.Codec = mMI.Get(StreamKind.Video, 0, "CodecID/Hint");
                if (string.IsNullOrEmpty(this.Video.Codec))
                    this.Video.Codec = mMI.Get(StreamKind.Video, 0, "CodecID");

                this.Video.Bitrate = mMI.Get(StreamKind.Video, 0, "BitRate/String");
                this.Video.Standard = mMI.Get(StreamKind.Video, 0, "Standard"); ;
                this.Video.FrameRate = mMI.Get(StreamKind.Video, 0, "FrameRate/String");
                this.Video.ScanType = mMI.Get(StreamKind.Video, 0, "ScanType/String");
                this.Video.Height = mMI.Get(StreamKind.Video, 0, "Height");
                this.Video.Width = mMI.Get(StreamKind.Video, 0, "Width");
                this.Video.Resolution = string.Format("{0}x{1}", this.Video.Width, this.Video.Height);
                this.Video.BitsPerPixelXFrame = mMI.Get(StreamKind.Video, 0, "Bits-(Pixel*Frame)");


                //*********************
                //* Audio
                //*********************  
                int audioCount;
                int.TryParse(mMI.Get(StreamKind.General, 0, "AudioCount"), out audioCount);

                for (int a = 0; a < audioCount; a++)
                {
                    AudioInfo ai = new AudioInfo();

                    ai.Format = mMI.Get(StreamKind.Audio, a, "Format");
                    ai.FormatVersion = mMI.Get(StreamKind.Audio, 0, "Format_Version");
                    ai.FormatProfile = mMI.Get(StreamKind.Audio, 0, "Format_Profile");

                    ai.Codec = mMI.Get(StreamKind.Audio, 0, "CodecID/Hint");
                    if (string.IsNullOrEmpty(ai.Codec))
                        ai.Codec = mMI.Get(StreamKind.Audio, 0, "CodecID");

                    ai.Bitrate = mMI.Get(StreamKind.Audio, a, "BitRate/String");
                    ai.BitrateMode = mMI.Get(StreamKind.Audio, a, "BitRate_Mode/String");

                    ai.Channels = mMI.Get(StreamKind.Audio, a, "Channel(s)/String");
                    ai.SamplingRate = mMI.Get(StreamKind.Audio, a, "SamplingRate/String");
                    ai.Resolution = mMI.Get(StreamKind.Audio, a, "Resolution/String");

                    this.Audio.Add(ai);

                }

                mMI.Close();

            }
        }

    }

    public class Info
    {
        public string Bitrate { get; set; }
        public string Codec { get; set; }
        public string Standard { get; set; }
        public string Format { get; set; }
        public string FormatProfile { get; set; }
        public string FormatVersion { get; set; }
        public string Resolution { get; set; }

    }

    public class AudioInfo : Info
    {
        //         
        public string BitrateMode { get; set; }
        public string Channels { get; set; }
        public string SamplingRate { get; set; }
    }

    public class VideoInfo : Info
    {        
        public string FrameRate { get; set; }
        public string Height { get; set; }
        public string ScanType { get; set; }
        public string Width { get; set; }
        public string BitsPerPixelXFrame { get; set; }
        // Bits-(Pixel*Frame)

    }

}
