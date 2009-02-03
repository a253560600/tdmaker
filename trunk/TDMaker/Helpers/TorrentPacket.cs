using System.IO;
using TDMaker;
using TDMaker.Properties;

namespace TDMakerLib
{
    public class TorrentPacket
    {

        public TDMaker.Tracker Tracker { get; private set; }
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

            if (!Settings.Default.TorrentFolderDefault &&
                Directory.Exists(Settings.Default.TorrentsCustomDir))
            {

                if (Settings.Default.TorrentsOrganize)
                {
                    dir = Path.Combine(Settings.Default.TorrentsCustomDir, Tracker.Name);
                }
                else
                {
                    dir = Settings.Default.TorrentsCustomDir;
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
