using System.IO;

namespace TDMakerLib
{
    public class TorrentPacket
    {
        public Tracker Tracker { get; private set; }
        public string MediaLocation { get; private set; }
        public string TorrentFolder { get; private set; }

        public TorrentPacket(Tracker tracker, string mediaLoc)
        {
            this.Tracker = tracker;
            this.MediaLocation = mediaLoc;
            this.TorrentFolder = getTorrentFolderPath();
        }

        string getTorrentFolderPath()
        {
            string dir = "";

            if (!Program.conf.TorrentFolderDefault &&
                Directory.Exists(Program.conf.TorrentsCustomDir))
            {

                if (Program.conf.TorrentsOrganize)
                {
                    dir = Path.Combine(Program.conf.TorrentsCustomDir, Tracker.Name);
                }
                else
                {
                    dir = Program.conf.TorrentsCustomDir;
                }
            }
            else
            {
                dir = Path.GetDirectoryName(MediaLocation);
            }

            return dir;

        }

    }
}
