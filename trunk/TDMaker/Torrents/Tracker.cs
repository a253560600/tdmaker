using System;
using System.Collections.Generic;
using System.Text;

namespace TDMaker
{
    [Serializable]
   public class Tracker
    {
        public Tracker()
        {

        }

        public Tracker(string name, string url)
        {
            this.Name = name;
            this.AnnounceURL = url;
        }

        public string Name { get; set; }
        public string AnnounceURL { get; set; }
    }
}
