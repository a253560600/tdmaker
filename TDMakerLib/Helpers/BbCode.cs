using System;
using System.Collections.Generic;
using System.Text;

namespace TDMakerLib
{
    class BbCode
    {
        public string Img(string url)
        {
            return string.Format("[img]{0}[/img]", url);
        }

        public string Bold(string txt)
        {
            return string.Format("[b]{0}[/b]", txt);
        }

        public string BoldItalic(string txt)
        {
            return string.Format("[b]{0}[/b]", Italic(txt));
        }

        public string Pre(string txt)
        {
            return string.Format("[pre]{0}[/pre]", txt);
        }

        public string Italic(string txt)
        {
            return string.Format("[i]{0}[/i]", txt);
        }

        public string Underline(string txt)
        {
            return string.Format("[u]{0}[/u]", txt);
        }

        public string Size(int size, string txt)
        {
            return string.Format("[size={0}]{1}[/size]", size, txt);
        }

        public string AlignCenter(string txt)
        {
            return string.Format("[align=center]{0}[/align]", txt);
        }

    }
}
