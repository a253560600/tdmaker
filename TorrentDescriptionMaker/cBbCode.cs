using System;
using System.Collections.Generic;
using System.Text;

namespace TorrentDescriptionMaker
{
    class cBbCode
    {
        public string img(string url){
            return string.Format("[img]{0}[/img]", url);
        }

        public string bold(string txt)
        {
            return string.Format("[b]{0}[/b]", txt);
        }
    }
}
