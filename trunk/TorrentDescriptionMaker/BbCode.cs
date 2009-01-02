using System;
using System.Collections.Generic;
using System.Text;

namespace TorrentDescriptionMaker
{
    class BbCode
    {
        public string img(string url){
            return string.Format("[img]{0}[/img]", url);
        }

        public string bold(string txt)
        {
            return string.Format("[b]{0}[/b]", txt);
        }

        public string pre(string txt)
        {
            return string.Format("[pre]{0}[/pre]", txt);
        }

        public string italic(string txt)
        {
            return string.Format("[i]{0}[/i]", txt);
        }

        public string underline(string txt)
        {
            return string.Format("[u]{0}[/u]", txt);
        }

        public string size(int size, string txt)
        {
            return string.Format("[size={0}]{1}[/size]", size, txt);
        }

        public string alignCenter(string txt)
        {
            return string.Format("[align=center]{0}[/align]", txt);
        }

    }
}
