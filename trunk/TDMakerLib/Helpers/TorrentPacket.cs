using System.IO;

namespace TDMakerLib
{
    public class TorrentPacket
    {
        public TrackerGroup TrackerGroupActive { get; private set; }
        public string MediaLocation { get; private set; }
        public string TorrentFolder { get; private set; }

        public TorrentPacket(TrackerGroup tracker, string mediaLoc)
        {
            this.TrackerGroupActive = tracker;
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
                    dir = Path.Combine(Program.conf.TorrentsCustomDir, TrackerGroupActive.Name);
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
