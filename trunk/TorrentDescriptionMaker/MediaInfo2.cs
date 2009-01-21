﻿using System.Collections.Generic;
using System.Text;
using System.IO;
using MediaInfoLib;
using TDMaker;
using TDMaker.Properties;
using System;

namespace TorrentDescriptionMaker
{
    /// <summary>
    /// Class that holds all Media Info: Genernal, Audio 1 to n, Video
    /// </summary>
    public class MediaInfo2
    {
        /// <summary>
        /// Disc property is set to true if the media is found to be DVD, BD, HDDVD source
        /// </summary>
        public bool IsDisc { get; private set; }
        /// <summary>
        /// Mode of taking screenshots for Media files
        /// </summary>
        public TakeScreenshotsType TakeScreenshots { get; set; }
        /// <summary>
        /// Packet that contains Tracker Information 
        /// </summary>
        public TorrentPacket TorrentPacketInfo { get; set; }
        /// <summary>
        /// FilePath or DirectoryPath of the Media
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// Title is same as Overall.FileName
        /// </summary>
        public string Title { get; private set; }
        public string Source { get; set; }
        public string Authoring { get; set; }
        public string Menu { get; set; }
        public string Extras { get; set; }
        public string WebLink { get; set; }

        /// <summary>
        /// Clickable Thumbnail to get full screenshot
        /// </summary>
        public ScreenshotsPacket Screenshot { get; set; }

        private string[] mExt = new string[] { ".*" }; // { ".avi", ".divx", ".mkv", ".vob", ".mov" };

        public MediaFile Overall { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        /// <summary>
        /// Folder Path of the Template
        /// </summary>
        public string TemplateLocation { get; set; }

        public MediaInfo2(string loc)
        {

            MediaFiles = new List<MediaFile>();

            // this could be a file path or a directory
            this.Location = loc;

        }

        /// <summary>
        /// Function to override Title
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Add Media to the Media List if the file has Audio or Video
        /// </summary>
        /// <param name="mf"></param>
        private void AddMedia(MediaFile mf)
        {

            if (mf.HasVideo || mf.HasAudio)
            {
                this.MediaFiles.Add(mf);
            }
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
                this.Overall = ReadFile(Location);
                if (string.IsNullOrEmpty(Title))
                    this.Title = Path.GetFileNameWithoutExtension(this.Overall.FilePath); // this.Overall.FileName;
                this.MediaFiles.Add(this.Overall);

            }
            else if (Directory.Exists(Location))
            {

                // get largest file 
                List<string> filePaths = new List<string>();
                foreach (string ext in mExt)
                {
                    filePaths.AddRange(Directory.GetFiles(Location, "*" + ext, SearchOption.AllDirectories));
                }

                if (filePaths.Count > 0)
                {
                    string maxPath = "";
                    long maxSize = 0;

                    for (int i = 0; i < filePaths.Count; i++)
                    {
                        string f = filePaths[i];

                        if (!Path.GetFileName(f).ToLower().Contains("sample"))
                        {

                            FileInfo fi = new FileInfo(f);

                            if (maxSize < fi.Length)
                            {
                                maxSize = fi.Length;
                                maxPath = fi.FullName;
                            }

                            AddMedia(ReadFile(f));
                        }
                    }

                    this.Overall = ReadFile(maxPath);

                    // Set Overall File Name                
                    this.Overall.FileName = Path.GetFileName(Location);
                    if (Overall.FileName.ToUpper().Equals("VIDEO_TS"))
                        Overall.FileName = Path.GetFileName(Path.GetDirectoryName(Location));
                    if (string.IsNullOrEmpty(Title))
                        this.Title = this.Overall.FileName;

                }

                // Subtitles, Format: DVD Video using VTS_01_0.IFO
                string[] ifo = Directory.GetFiles(Location, "VTS_01_0.IFO", SearchOption.AllDirectories);
                if (ifo.Length == 1)
                {
                    this.IsDisc = true;
                    MediaInfoLib.MediaInfo mi = new MediaInfoLib.MediaInfo();
                    mi.Open(ifo[0]);

                    // most prolly this will be: DVD Video
                    this.Overall.Format = mi.Get(StreamKind.General, 0, "Format");

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

                        this.Overall.Subtitles = sbLangs.ToString();
                    }

                    // close ifo file
                    mi.Close();
                }

                // DVD Video
                // Combined Duration and File Size
                if (IsDisc)
                {
                    string[] vobFiles = Directory.GetFiles(Location, "*.vob", SearchOption.AllDirectories);
                    if (vobFiles.Length > 0)
                    {
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

                        this.Overall.FileSize = size; // override any previous file size
                        this.Overall.FileSizeString = string.Format("{0} MiB", (this.Overall.FileSize / 1024.0 / 1024.0).ToString("0.00"));

                        this.Overall.Duration = dura;
                        this.Overall.DurationString = Program.getDurationString(dura);

                    }

                }

            } // if Location is a directory

        }

        /// <summary>
        /// Reads a media file and creates a MediaFile object
        /// </summary>
        /// <param name="fp">File Path of the Media File</param>
        /// <returns>MediaFile object</returns>
        private MediaFile ReadFile(string fp)
        {
            MediaFile mf = new MediaFile(fp);
            mf.Source = this.Source;

            if (File.Exists(fp))
            {
                //*********************
                //* General
                //********************* 

                System.Console.WriteLine("Current Dir1: " + System.Environment.CurrentDirectory);
                System.Environment.CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                System.Console.WriteLine("Current Dir2: " + System.Environment.CurrentDirectory);
                System.Console.WriteLine("OSVersion: {0}", System.Environment.OSVersion.ToString());

                MediaInfoLib.MediaInfo mMI = null;
                try
                {
                    Console.WriteLine("Loaded MediaInfo.dll");
                    mMI = new MediaInfoLib.MediaInfo();
                    Console.WriteLine("Loading MediaInfo.dll");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                if (mMI != null)
                {
                    Console.WriteLine(string.Format("Opening {0}", fp));
                    mMI.Open(fp);
                    Console.WriteLine(string.Format("Opened {0}", fp));
                    mMI.Option("Complete");
                    mf.Summary = mMI.Inform();
                    Console.WriteLine(string.Format("Summary: {0}", mf.Summary));

                    // Format Info
                    if (string.IsNullOrEmpty(mf.Format))
                        mf.Format = mMI.Get(StreamKind.General, 0, "Format");
                    mf.FormatInfo = mMI.Get(StreamKind.General, 0, "Format/Info");

                    // mf.FileName = mMI.Get(0, 0, "FileName");
                    if (0 == mf.FileSize)
                    {
                        double sz;
                        double.TryParse(mMI.Get(0, 0, "FileSize"), out sz);
                        mf.FileSize = sz;
                    }
                    if (string.IsNullOrEmpty(mf.FileSizeString))
                    {
                        mf.FileSizeString = string.Format("{0} MiB", (mf.FileSize / 1024.0 / 1024.0).ToString("0.00"));
                    }

                    // Duration
                    if (string.IsNullOrEmpty(mf.DurationString))
                        mf.DurationString = mMI.Get(0, 0, "Duration/String2");

                    mf.Bitrate = mMI.Get(StreamKind.General, 0, "OverallBitRate/String");

                    if (string.IsNullOrEmpty(mf.Subtitles))
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

                        mf.Subtitles = sbSubs.ToString();

                    }

                    //*********************
                    //* Video
                    //********************* 

                    int videoCount;
                    int.TryParse(mMI.Get(StreamKind.General, 0, "VideoCount"), out videoCount);
                    mf.HasVideo = videoCount > 0;

                    mf.Video.Format = mMI.Get(StreamKind.Video, 0, "Format");
                    mf.Video.FormatVersion = mMI.Get(StreamKind.Video, 0, "Format_Version");

                    if (Path.GetExtension(mf.FilePath).ToLower().Equals(".mkv"))
                    {
                        mf.Video.Codec = mMI.Get(StreamKind.Video, 0, "Encoded_Library");
                    }
                    if (string.IsNullOrEmpty(mf.Video.Codec))
                        mf.Video.Codec = mMI.Get(StreamKind.Video, 0, "CodecID/Hint");
                    if (string.IsNullOrEmpty(mf.Video.Codec))
                        mf.Video.Codec = mMI.Get(StreamKind.Video, 0, "CodecID");

                    mf.Video.Bitrate = mMI.Get(StreamKind.Video, 0, "BitRate/String");
                    mf.Video.Standard = mMI.Get(StreamKind.Video, 0, "Standard"); ;
                    mf.Video.FrameRate = mMI.Get(StreamKind.Video, 0, "FrameRate/String");
                    mf.Video.ScanType = mMI.Get(StreamKind.Video, 0, "ScanType/String");
                    mf.Video.Height = mMI.Get(StreamKind.Video, 0, "Height");
                    mf.Video.Width = mMI.Get(StreamKind.Video, 0, "Width");
                    mf.Video.Resolution = string.Format("{0}x{1}", mf.Video.Width, mf.Video.Height);
                    mf.Video.BitsPerPixelXFrame = mMI.Get(StreamKind.Video, 0, "Bits-(Pixel*Frame)");


                    //*********************
                    //* Audio
                    //*********************  
                    int audioCount;
                    int.TryParse(mMI.Get(StreamKind.General, 0, "AudioCount"), out audioCount);
                    mf.HasAudio = audioCount > 0;

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

                        mf.Audio.Add(ai);

                    }

                    mMI.Close();

                }

            }

            return mf;
        }

        /// <summary>
        /// Default Publish String Representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            int fontSizeHeading1 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
       Settings.Default.FontSizeHeading1 + Settings.Default.FontSizeIncr :
       Settings.Default.FontSizeHeading1);

            int fontSizeHeading2 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeHeading2 + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeHeading2);

            int fontSizeBody = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeBody + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeBody);


            BbCode bb = new BbCode();

            StringBuilder sbBody = new StringBuilder();

            // Show Title
            sbBody.AppendLine(bb.Size(fontSizeHeading1, bb.Bold(this.Title)));
            sbBody.AppendLine();

            StringBuilder sbTitleInfo = new StringBuilder();

            // Source 
            if (Settings.Default.bSource && !string.IsNullOrEmpty(Settings.Default.Source))
            {
                sbTitleInfo.AppendLine(string.Format("[u]Source:[/u] {0}", this.Source));
            }

            if (IsDisc)
            {
                // Authoring
                if (Settings.Default.bVideoEdits && !string.IsNullOrEmpty(this.Authoring))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Authoring:[/u] {0}", this.Authoring));
                }
                if (Settings.Default.bDiscMenu && !string.IsNullOrEmpty(this.Menu))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Menu:[/u] {0}", this.Menu));
                }
                // Extras
                if (Settings.Default.bExtras && !string.IsNullOrEmpty(this.Extras))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Extras:[/u] {0}", this.Extras));
                }
                // WebLink
                if (Settings.Default.WebLink && !string.IsNullOrEmpty(this.WebLink))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Web Link:[/u] {0}", this.WebLink));
                }
            }

            sbBody.AppendLine(bb.Size(fontSizeBody, sbTitleInfo.ToString()));
            sbBody.AppendLine();

            if (this.MediaFiles.Count > 1 && this.IsDisc)
            // is a DVD so need Overall Info only
            {
                sbBody.AppendLine(this.Overall.ToString());
            }
            else
            // If the loaded folder is not a Disc but individual ripped files
            {
                foreach (MediaFile mf in this.MediaFiles)
                {

                    sbBody.AppendLine(bb.Size(fontSizeHeading2, bb.BoldItalic(mf.FileName)));
                    sbBody.AppendLine();
                    sbBody.AppendLine(mf.ToString());

                }
            }

            return sbBody.ToString();

        }

    }

}
