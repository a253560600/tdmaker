using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorrentDescriptionMaker;

namespace TDMaker
{

    public class WorkerTask
    {
        public TaskType Task { get; private set; }
        public List<MediaInfo2> MediaFiles { get; set; }
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
