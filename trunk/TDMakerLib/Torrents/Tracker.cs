using System;
using System.Collections.Generic;
using System.Text;

namespace TDMakerLib
{
    [Serializable]
    public class Tracker
    {
        public Tracker()
        {

        }

        public Tracker(string name, string url, string groupName)
        {
            this.Name = name;
            this.AnnounceURL = url;
            this.GroupName = groupName;
        }

        public string Name { get; set; }
        public string AnnounceURL { get; set; }
        public string GroupName { get; set; }
    }
}
