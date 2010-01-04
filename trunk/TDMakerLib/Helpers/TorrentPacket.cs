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

            if (!Engine.conf.TorrentFolderDefault &&
                Directory.Exists(Engine.conf.CustomTorrentsDir))
            {

                if (Engine.conf.TorrentsOrganize)
                {
                    dir = Path.Combine(Engine.conf.CustomTorrentsDir, TrackerGroupActive.Name);
                }
                else
                {
                    dir = Engine.conf.CustomTorrentsDir;
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
