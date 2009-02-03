using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TDMaker.Properties;
using TorrentDescriptionMaker;
using MediaInfoLib;
using TDMakerLib;

namespace TDMaker
{
    /// <summary>
    /// Class that holds all the MediaInfo of a media file
    /// This can be a single .vob, .avi etc.
    /// </summary>
    public class MediaFile
    {
        public bool HasAudio { get; set; }
        public bool HasVideo { get; set; }

        public string Bitrate { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// Duration in hours:minutes:seconds
        /// </summary>
        public string DurationString { get; set; }
        public string FileExtension { get; set; }
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
        public string Source { get; set; }
        private string mSubtitles = "None";
        public string Subtitles { get { return mSubtitles; } set { mSubtitles = value; } }
        /// <summary>
        /// This is what you get for mi.Option("Complete");
        /// </summary>
        public string Summary { get; set; }
        public List<AudioInfo> Audio { get; set; }
        public VideoInfo Video { get; set; }

        /// <summary>
        /// Constructor for Media File
        /// </summary>
        /// <param name="fp">File Path of the Media File</param>
        /// <param name="src">Source of the Media File (HDTV, DVD, BD, etc.)</param>
        public MediaFile(string fp, string src)
        {
            this.FilePath = fp;
            this.FileExtension = Path.GetExtension(fp);
            this.FileName = Path.GetFileName(fp);
            this.Source = src;

            this.Audio = new List<AudioInfo>();
            this.Video = new VideoInfo();

            this.ReadFile();
        }

        /// <summary>
        /// Reads a media file and creates a MediaFile object
        /// </summary>
        /// <param name="fp">File Path of the Media File</param>
        /// <returns>MediaFile object</returns>
        public void ReadFile()
        {
            this.Source = Source;

            if (File.Exists(FilePath))
            {
                //*********************
                //* General
                //********************* 

                //System.Console.WriteLine("Current Dir1: " + System.Environment.CurrentDirectory);
                //System.Environment.CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //System.Console.WriteLine("Current Dir2: " + System.Environment.CurrentDirectory);

                MediaInfoLib.MediaInfo mMI = null;
                try
                {
                    Console.WriteLine("Loading MediaInfo.dll");
                    mMI = new MediaInfoLib.MediaInfo();
                    Console.WriteLine("Loaded MediaInfo.dll");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                if (mMI != null)
                {
                    Console.WriteLine(string.Format("MediaInfo Opening {0}", FilePath));
                    mMI.Open(FilePath);
                    Console.WriteLine(string.Format("MediaInfo Opened {0}", FilePath));
                    mMI.Option("Complete");
                    this.Summary = mMI.Inform();

                    if (Program.IsUNIX)
                    {
                        Console.WriteLine(string.Format("MediaInfo Summary Length: {0}", this.Summary.Length.ToString()));
                        Console.WriteLine(string.Format("MediaInfo Summary: {0}", this.Summary));
                    }

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
                    if (string.IsNullOrEmpty(this.FileSizeString))
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

                    int videoCount;
                    int.TryParse(mMI.Get(StreamKind.General, 0, "VideoCount"), out videoCount);
                    this.HasVideo = videoCount > 0;

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
                    this.HasAudio = audioCount > 0;

                    for (int a = 0; a < audioCount; a++)
                    {
                        AudioInfo ai = new AudioInfo();

                        ai.Format = mMI.Get(StreamKind.Audio, a, "Format");
                        ai.FormatVersion = mMI.Get(StreamKind.Audio, 0, "Format_Version");
                        ai.FormatProfile = mMI.Get(StreamKind.Audio, 0, "Format_Profile");

                        ai.Codec = mMI.Get(StreamKind.Audio, 0, "CodecID/Hint");
                        if (string.IsNullOrEmpty(ai.Codec))
                            ai.Codec = mMI.Get(StreamKind.Audio, 0, "CodecID/Info");
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

                    //// Analyse Audio only files using TagLib

                    //if (this.HasAudio && !this.HasVideo)
                    //{
                    //    TagLib.File f = TagLib.File.Create(this.FilePath);
                    //    this.TagLibFile = f;
                    //}

                }

            }
        }
        /// <summary>
        /// Method to determine if the Media File is actually an audio file
        /// </summary>
        /// <returns></returns>
        public bool IsAudioFile()
        {
            return this.HasAudio && !this.HasVideo;
        }

        /// <summary>
        /// String representation of an Audio file
        /// </summary>
        /// <returns></returns>
        public string ToStringAudio()
        {
            return "";
        }

        /// <summary>
        /// Returns a Publish layout of Media Info that has Audio and Video
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            int fontSizeHeading3 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
           Settings.Default.FontSizeHeading3 + Settings.Default.FontSizeIncr :
           Settings.Default.FontSizeHeading3);

            int fontSizeBody = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeBody + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeBody);


            BbCode bb = new BbCode();

            StringBuilder sbBody = new StringBuilder();

            //*********************
            //* General
            //*********************   
            StringBuilder sbGeneral = new StringBuilder();

            sbBody.AppendLine(bb.Size(fontSizeHeading3, bb.BoldItalic("General:")));
            sbBody.AppendLine();

            // Format
            sbGeneral.Append(string.Format("            [u]Format:[/u] {0}", this.Format));
            if (!string.IsNullOrEmpty(this.FormatInfo))
            {
                sbGeneral.Append(string.Format(" ({0})", this.FormatInfo));
            }
            sbGeneral.Append(Environment.NewLine);

            // File Size
            sbGeneral.AppendLine(string.Format("         [u]File Size:[/u] {0}", this.FileSizeString));
            // Duration
            sbGeneral.AppendLine(string.Format("          [u]Duration:[/u] {0}", this.DurationString));
            // Bitrate
            sbGeneral.AppendLine(string.Format("           [u]Bitrate:[/u] {0}", this.Bitrate));

            // Subtitles            
            if (!string.IsNullOrEmpty(this.Subtitles))
            {
                sbGeneral.AppendLine(string.Format("         [u]Subtitles:[/u] {0}", this.Subtitles));
            }


            sbBody.Append(bb.Size(fontSizeBody, sbGeneral.ToString()));

            //*********************
            //* Video
            //*********************    
            VideoInfo vi = this.Video;

            sbBody.AppendLine();
            sbBody.AppendLine(bb.Size(fontSizeHeading3, bb.BoldItalic("Video:")));
            sbBody.AppendLine();

            StringBuilder sbVideo = new StringBuilder();
            // Format            
            sbVideo.Append(string.Format("            [u]Format:[/u] {0}", this.Video.Format));
            if (!string.IsNullOrEmpty(this.Video.FormatVersion))
            {
                sbVideo.Append(string.Format(" {0}", this.Video.FormatVersion));
            }
            sbVideo.Append(Environment.NewLine);

            // Codec
            if (!string.IsNullOrEmpty(vi.Codec))
                sbVideo.AppendLine(string.Format("             [u]Codec:[/u] {0}", vi.Codec));
            // Bitrate
            sbVideo.AppendLine(string.Format("           [u]Bitrate:[/u] {0}", this.Video.Bitrate));
            // Standard            
            if (!string.IsNullOrEmpty(vi.Standard))
                sbVideo.AppendLine(string.Format("          [u]Standard:[/u] {0}", this.Video.Standard));
            // Frame Rate
            sbVideo.AppendLine(string.Format("        [u]Frame Rate:[/u] {0}", vi.FrameRate));

            // Scan Type
            sbVideo.AppendLine(string.Format("         [u]Scan Type:[/u] {0}", vi.ScanType));
            sbVideo.AppendLine(string.Format("[u]Bits/(Pixel*Frame):[/u] {0}", vi.BitsPerPixelXFrame));

            // Resolution
            sbVideo.AppendLine(string.Format("        [u]Resolution:[/u] {0}x{1}",
                vi.Width,
                vi.Height));

            sbBody.Append(bb.Size(fontSizeBody, sbVideo.ToString()));

            //*********************
            //* Audio
            //*********************          

            int audioCount = this.Audio.Count;

            for (int a = 0; a < audioCount; a++)
            {
                AudioInfo ai = this.Audio[a];

                sbBody.AppendLine();
                sbBody.AppendLine(string.Format(bb.Size(fontSizeHeading3, bb.BoldItalic("Audio #{0}:")), a + 1));
                sbBody.AppendLine();

                StringBuilder sbAudio = new StringBuilder();
                // Format
                sbAudio.Append(string.Format("            [u]Format:[/u] {0}", ai.Format));
                if (!string.IsNullOrEmpty(ai.FormatVersion))
                    sbAudio.Append(string.Format(" {0}", ai.FormatVersion));
                if (!string.IsNullOrEmpty(ai.FormatProfile))
                    sbAudio.Append(string.Format(" {0}", ai.FormatProfile));
                sbAudio.Append(Environment.NewLine);

                // Codec     
                if (!string.IsNullOrEmpty(ai.Codec))
                    sbAudio.AppendLine(string.Format("             [u]Codec:[/u] {0}", ai.Codec));
                // Bitrate
                sbAudio.AppendLine(string.Format("           [u]Bitrate:[/u] {0} ({1})", ai.Bitrate, ai.BitrateMode));
                // Channels
                sbAudio.AppendLine(string.Format("          [u]Channels:[/u] {0}", ai.Channels));
                // Sampling Rate
                sbAudio.AppendLine(string.Format("     [u]Sampling Rate:[/u] {0}", ai.SamplingRate));
                // Resolution
                if (!string.IsNullOrEmpty(ai.Resolution))
                    sbAudio.AppendLine(string.Format(("        [u]Resolution:[/u] {0}"), ai.Resolution));

                sbBody.Append(bb.Size(fontSizeBody, sbAudio.ToString()));
                sbBody.AppendLine();
            }

            return sbBody.ToString();
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

    }
}
