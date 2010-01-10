using System.IO;

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
            this.TorrentFolder = FileSystem.GetTorrentFolderPath(this);
        }

        public void SetTorrentFilePath(string fileName)
        {
            TorrentFilePath = Path.Combine(TorrentFolder, fileName);
        }
    }
}
