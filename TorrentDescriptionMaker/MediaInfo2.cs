using System;
using System.Collections.Generic;
using System.Text;
using TorrentDescriptionMaker;
using System.IO;

namespace TDMaker
{
    public class MediaInfo2
    {

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
        /// File Size in Bytes
        /// </summary>
        public double FileSize { get; set; }
        /// <summary>
        /// File Size in XX.X MiB
        /// </summary>
        public string FileSizeString { get; set; }
        /// <summary>
        /// List of Media Files (*.avi, *.mkv, *.vob etc.)
        /// </summary>
        public List<MediaFile> MediaFiles { get; set; }
        /// <summary>
        /// FilePath or DirectoryPath of the Media
        /// </summary>
        public string Location { get; set; }

        private string[] mExt = new string[] { "avi", "divx", "mkv", "vob", "mov" };


        public MediaInfo2(string fd)
        {
            this.MediaFiles = new List<MediaFile>();
            this.Location = fd;


        }

        /// <summary>
        /// Function to populate MediaInfo class/classes
        /// </summary>
        public void ReadMedia()
        {
            if (File.Exists(Location))
            {
                MediaFile mf = new MediaFile(Location);
                mf.ReadFile();
                this.MediaFiles.Add(mf);
            }

            else if (Directory.Exists(Location))
            {
                List<string> files = new List<string>();
                foreach (string ext in mExt)
                {
                    files.AddRange(Directory.GetFiles(Location, "*." + ext, SearchOption.AllDirectories));
                }
                foreach (string p in files)
                {
                    MediaFile mf = new MediaFile(p);
                    mf.ReadFile();
                    this.MediaFiles.Add(mf);
                }
            }

            // Update Duration and File Names
            if (MediaFiles.Count > 0)
            {
                // Gotta make sure sample files are skipped
                // Sort fileSizes in descending order
                // If the 2nd last is more 10 times bigger than the last file this is the sample              
                foreach (MediaFile mf in MediaFiles)
                {
          


                }

            }
            else if (MediaFiles.Count == 1)
            {
                this.Duration = this.MediaFiles[0].Duration;
                this.DurationString = this.MediaFiles[0].DurationString;
                this.FileName = this.MediaFiles[0].FileName;
            }


        }

    }
}
