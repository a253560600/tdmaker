using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace TDMakerLib
{
    public class TorrentCreateInfo
    {
        public TrackerGroup TrackerGroupActive { get; private set; }
        public string MediaLocation { get; private set; }
        public string TorrentFolder { get; private set; }
        public string TorrentFilePath { get; private set; }

        public TorrentCreateInfo(TrackerGroup tracker, string mediaLoc)
        {
            this.TrackerGroupActive = tracker;
            this.MediaLocation = mediaLoc;
            this.TorrentFolder = GetTorrentFolderPath();
        }

        public string GetTorrentFolderPath()
        {
            string dir = "";

            switch (Engine.conf.TorrentLocationChoice)
            {
                case LocationType.CustomFolder:
                    if (Directory.Exists(Engine.conf.CustomTorrentsDir) && Engine.conf.TorrentsOrganize)
                    {
                        dir = Path.Combine(Engine.conf.CustomTorrentsDir, this.TrackerGroupActive.Name);
                    }
                    else
                    {
                        dir = Engine.conf.CustomTorrentsDir;
                    }
                    break;
                case LocationType.KnownFolder:
                    dir = Engine.TorrentsDir;
                    break;
                case LocationType.ParentFolder:
                    dir = Path.GetDirectoryName(this.MediaLocation);
                    break;
            }

            return dir;
        }

        public void SetTorrentFilePath(string fileName)
        {
            TorrentFilePath = Path.Combine(TorrentFolder, fileName);
        }

        /// <summary>
        /// Create torrent without progress
        /// </summary>
        public void CreateTorrent()
        {
            CreateTorrent(null);
        }

        /// <summary>
        /// Create torrent with progress
        /// </summary>
        /// <param name="workerMy"></param>
        public void CreateTorrent(BackgroundWorker workerMy)
        {
            string p = this.MediaLocation;
            if (File.Exists(p) || Directory.Exists(p))
            {
                foreach (Tracker myTracker in this.TrackerGroupActive.Trackers)
                {
                    MonoTorrent.Common.TorrentCreator tc = new MonoTorrent.Common.TorrentCreator();
                    tc.Private = true;
                    tc.Comment = Engine.GetMediaName(p);
                    tc.Path = p;
                    tc.PublisherUrl = "http://code.google.com/p/tdmaker";
                    tc.Publisher = Application.ProductName;
                    tc.StoreMD5 = true;
                    List<string> temp = new List<string>();
                    temp.Add(myTracker.AnnounceURL);
                    tc.Announces.Add(temp);

                    string torrentFileName = string.Format("{0} - {1}.torrent", (File.Exists(p) ? Path.GetFileName(p) : Engine.GetMediaName(p)), myTracker.Name);
                    this.SetTorrentFilePath(torrentFileName);

                    if (!Directory.Exists(this.TorrentFolder))
                        Directory.CreateDirectory(Path.GetDirectoryName(this.TorrentFilePath));

                    ReportProgress(workerMy, ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Creating {0}", this.TorrentFilePath));
                    tc.Create(this.TorrentFilePath);
                    ReportProgress(workerMy, ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Created {0}", this.TorrentFilePath));
                }
            }
        }

        public void ReportProgress(BackgroundWorker worker, ProgressType progress, object userState)
        {
            if (worker != null)
            {
                worker.ReportProgress((int)progress, userState);
            }
            else
            {
                switch (progress)
                {
                    case ProgressType.UPDATE_STATUSBAR_DEBUG:
                        Console.WriteLine(userState as string);
                        break;
                }
            }
        }

    }
}
