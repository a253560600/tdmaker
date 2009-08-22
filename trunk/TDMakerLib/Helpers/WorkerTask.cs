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
        public string[] FilePaths { get; set; }

        public WorkerTask(TaskType task)
        {
            this.Task = task;
        }

        public bool IsSingleTask()
        {
            return FilePaths.Length == 1;
        }
    }
}
