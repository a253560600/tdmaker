using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDMakerLib;
using Mono.Options;

namespace TDMakerCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string mMediaLoc = string.Empty;
            string mSettingsFile = string.Empty;

            var p = new OptionSet() 
            {
                { "loc|location=", "Location of the media file/folder", v => mMediaLoc = v },
                { "s|settings=", "Location of the settings file", v => mSettingsFile = v }
            };

            p.Parse(args);


        }
    }
}
