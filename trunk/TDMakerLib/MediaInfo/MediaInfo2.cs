using System.Collections.Generic;
using System.Text;
using System.IO;
using MediaInfoLib;
using TDMakerLib;
using TDMakerLib.MediaInfo;
using TDMakerLib;

namespace TDMakerLib
{
    /// <summary>
    /// Class that holds all Media Info: Genernal, Audio 1 to n, Video
    /// </summary>
    public class MediaInfo2
    {
        /// <summary>
        /// Disc property is set to true if the media is found to be DVD, BD, HDDVD source
        /// </summary>
        public MediaType MediaType { get; private set; }

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
        public Screenshot Screenshot { get; set; }

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
            Screenshot = new Screenshot();

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
                this.Overall = new MediaFile(this.Location, this.Source);
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

                            this.AddMedia(new MediaFile(f, this.Source));
                        }
                    }

                    this.Overall = new MediaFile(maxPath, this.Source);

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
                    this.MediaType = MediaType.MEDIA_DISC;
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
                if (MediaType == MediaType.MEDIA_DISC)
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
                        this.Overall.DurationString = Program.GetDurationString(dura);

                    }

                }

            } // if Location is a directory

            // Set Media Type
            bool allAudio = true;
            foreach (MediaFile mf in MediaFiles)
            {
                allAudio = mf.IsAudioFile() && allAudio;
            }
            if (allAudio)
            {
                this.MediaType = MediaType.MUSIC_AUDIO_ALBUM;
            }

        } // Read Media

        /// <summary>
        /// Tracklist of all the Audio files in the MediaInfo. Also accessible using %Tracklist%
        /// </summary>
        /// <returns>String representation of Tracklist</returns>
        public string ToStringAudio()
        {
            List<string> lstAudioFiles = new List<string>();
            foreach (MediaFile mf in MediaFiles)
            {
                if (mf.IsAudioFile())
                {
                    lstAudioFiles.Add(mf.FilePath);
                }
            }
            return new NfoReport(this.Location, null).ToString();
        }

        private string ToStringMedia()
        {
            int fontSizeHeading1 = (int)(Program.conf.PreText && Program.conf.LargerPreText == true ?
        Program.conf.FontSizeHeading1 + Program.conf.FontSizeIncr :
        Program.conf.FontSizeHeading1);

            int fontSizeHeading2 = (int)(Program.conf.PreText && Program.conf.LargerPreText == true ?
                Program.conf.FontSizeHeading2 + Program.conf.FontSizeIncr :
                Program.conf.FontSizeHeading2);

            int fontSizeBody = (int)(Program.conf.PreText && Program.conf.LargerPreText == true ?
                Program.conf.FontSizeBody + Program.conf.FontSizeIncr :
                Program.conf.FontSizeBody);


            BbCode bb = new BbCode();

            StringBuilder sbBody = new StringBuilder();

            // Show Title
            if (Program.conf.bTitle)
            {
                sbBody.AppendLine(bb.Size(fontSizeHeading1, bb.Bold(this.Title)));
                sbBody.AppendLine();
            }

            StringBuilder sbTitleInfo = new StringBuilder();

            // Source 
            if (Program.conf.bSource && !string.IsNullOrEmpty(Program.conf.Source))
            {
                sbTitleInfo.AppendLine(string.Format("[u]Source:[/u] {0}", this.Source));
            }

            if (MediaType == MediaType.MEDIA_DISC)
            {
                // Authoring
                if (Program.conf.bAuthoring && !string.IsNullOrEmpty(this.Authoring))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Authoring:[/u] {0}", this.Authoring));
                }
                if (Program.conf.bDiscMenu && !string.IsNullOrEmpty(this.Menu))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Menu:[/u] {0}", this.Menu));
                }
                // Extras
                if (Program.conf.bExtras && !string.IsNullOrEmpty(this.Extras))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Extras:[/u] {0}", this.Extras));
                }
                // WebLink
                if (Program.conf.bWebLink && !string.IsNullOrEmpty(this.WebLink))
                {
                    sbTitleInfo.AppendLine(string.Format("[u]Web Link:[/u] {0}", this.WebLink));
                }
            }

            if (!string.IsNullOrEmpty(sbTitleInfo.ToString()))
            {
                sbBody.AppendLine(bb.Size(fontSizeBody, sbTitleInfo.ToString()));
                sbBody.AppendLine();
            }

            if (this.MediaFiles.Count > 1 && this.MediaType == MediaType.MEDIA_DISC)
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

        /// <summary>
        /// Default Publish String Representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";

            switch (this.MediaType)
            {
                case MediaType.MEDIA_DISC:
                case MediaType.SINGLE_MEDIA_FILE:
                    str = ToStringMedia();
                    break;
                case MediaType.MUSIC_AUDIO_ALBUM:
                    str = ToStringAudio();
                    break;
            }

            return str;

        }

    }

}
