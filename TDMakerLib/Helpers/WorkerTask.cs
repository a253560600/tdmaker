using System.Collections.Generic;
using TDMakerLib;
using System.ComponentModel;

namespace TDMakerLib
{
    public class WorkerTask
    {
        public TaskType Task { get; private set; }
        public List<MediaInfo2> MediaFiles { get; set; }
        public BackgroundWorker MyWorker { get; private set; }
        public List<TorrentPacket> TorrentPackets { get; set; }
        /// <summary>
        /// A string array of File or Directory paths
        /// </summary>
        public List<string> FileOrDirPaths { get; set; }

        public WorkerTask(BackgroundWorker worker, TaskType task)
        {
            this.MyWorker = worker;
            this.Task = task;
            this.FileOrDirPaths = new List<string>();
        }

        public bool IsSingleTask()
        {
            return FileOrDirPaths.Count == 1;
        }
    }
}
