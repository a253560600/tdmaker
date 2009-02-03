using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TDMakerLib
{
    public class TorrentCreator
    {

        private TorrentPacket tp;
        public string Publisher { get; set; }
        public string TorrentPath { get; private set; }

        public TorrentCreator(TorrentPacket tp)
        {
            this.tp = tp;
        }

        public bool Create()
        {
            bool success = true;

            string p = tp.MediaLocation;
            if (File.Exists(p) || Directory.Exists(p))
            {
                MonoTorrent.Common.TorrentCreator tc = new MonoTorrent.Common.TorrentCreator();
                tc.Private = true;
                tc.Comment = Program.GetMediaName(p);
                tc.Path = p;
                tc.PublisherUrl = "http://code.google.com/p/tdmaker";
                if (!string.IsNullOrEmpty(this.Publisher))
                {
                    tc.Publisher = this.Publisher;
                }
                tc.StoreMD5 = true;
                List<string> temp = new List<string>();
                temp.Add(tp.Tracker.AnnounceURL);
                tc.Announces.Add(temp);

                string torrentFileName = (File.Exists(p) ? Path.GetFileName(p) : Program.GetMediaName(p)) + ".torrent";
                this.TorrentPath = Path.Combine(tp.TorrentFolder, torrentFileName);

                if (!Directory.Exists(tp.TorrentFolder))
                    Directory.CreateDirectory(Path.GetDirectoryName(TorrentPath));
                
                tc.Create(TorrentPath);
            }

            return success;
        }
    }
}
