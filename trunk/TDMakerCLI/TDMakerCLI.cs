using System;

namespace TDMaker
{
    public class TDMakerCLI
    {
        #region "Args"
        private const string FLAG_INPUT =  "-i";
        private const string FLAG_TORRENT = "-t";
        #endregion

        #region "Properties"
        public bool CreateTorrent { get; private set; }
        public string[] Locations { get; private set; }
        public string MTNArg { get; private set; }
        #endregion"

        public TDMakerCLI()
        {
            if (Environment.GetCommandLineArgs().Length > 1)
            {
                CommandLineParser.CommandLineParser parser = new CommandLineParser.CommandLineParser();
                SetupCommandLineEntries(parser);
                
                string strArgs = Environment.CommandLine;                 
            }

        }

        private void SetupCommandLineEntries(CommandLineParser.CommandLineParser parser)
        {
            
        }

    }
}
