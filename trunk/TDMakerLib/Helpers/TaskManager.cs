using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace TDMakerLib.Helpers
{
    public class TaskManager
    {
        private WorkerTask mTask = null;

        public TaskManager(WorkerTask task)
        {
            this.mTask = task;
        }

        public TorrentCreateInfo WorkerCreateTorrent(TorrentCreateInfo tci)
        {
            string p = tci.MediaLocation;
            if (File.Exists(p) || Directory.Exists(p))
            {
                foreach (Tracker myTracker in tci.TrackerGroupActive.Trackers)
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
                    tci.SetTorrentFilePath(torrentFileName);

                    if (!Directory.Exists(tci.TorrentFolder))
                        Directory.CreateDirectory(Path.GetDirectoryName(tci.TorrentFilePath));

                    mTask.MyWorker.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Creating {0}", tci.TorrentFilePath));
                    tc.Create(tci.TorrentFilePath);
                    mTask.MyWorker.ReportProgress((int)ProgressType.UPDATE_STATUSBAR_DEBUG, string.Format("Created {0}", tci.TorrentFilePath));
                }
            }

            return tci;
        }
    }
}
