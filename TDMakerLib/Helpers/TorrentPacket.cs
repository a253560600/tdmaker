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

            switch (Engine.conf.TorrentLocationChoice)
            {
                case LocationType.CustomFolder:
                    if (Directory.Exists(Engine.conf.CustomTorrentsDir) && Engine.conf.TorrentsOrganize)
                    {
                        dir = Path.Combine(Engine.conf.CustomTorrentsDir, TrackerGroupActive.Name);
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
                    dir = Path.GetDirectoryName(MediaLocation);
                    break;
            }

            return dir;

        }

    }
}
