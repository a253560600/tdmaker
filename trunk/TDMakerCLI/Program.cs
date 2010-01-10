using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDMakerLib;
using Mono.Options;
using System.IO;

namespace TDMakerCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string mMediaLoc = string.Empty;
            string mSettingsFile = string.Empty;
            bool mScreenshotsCreate = false;
            bool mTorrentCreate = false;
            bool mFileCollection = false;

            var p = new OptionSet() 
            {
                { "c", "Treat multiple files as a collection", v => mFileCollection = v != null},
                { "m|media=", "Location of the media file/folder", v => mMediaLoc = v },
                { "o|options=", "Location of the settings file", v => mSettingsFile = v },
                { "s", "Create and upload screenshots", v => mScreenshotsCreate = v != null},
                { "t", "Create torrent file", v => mTorrentCreate = v != null}                
            };

            // give cli the ability to replace environment variables
            string[] args2 = new string[args.Length];
            int count = 0;
            foreach (string arg in args)
            {
                args2[count++] = arg.Replace("%appdata%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

            p.Parse(args2);

            if (!File.Exists(mSettingsFile))
            {
                Engine.mAppSettings = AppSettings.Read();
                mSettingsFile = Engine.mAppSettings.XMLSettingsFile;
            }

            if (File.Exists(mSettingsFile))
            {
                Engine.conf = XMLSettingsCore.Read(mSettingsFile);
            }
            if (Engine.conf != null)
            {
                Engine.InitializeDefaultFolderPaths();
                Engine.mtnProfileMgr = XMLSettingsMtnProfiles.Read();
                Console.WriteLine(string.Format("Media location: {0}", mMediaLoc));
                Console.WriteLine(string.Format("Settings file:  {0}", mSettingsFile));
                Console.WriteLine(string.Format("MTN Path:       {0}", Engine.conf.MTNPath));
                Console.WriteLine();

                List<string> listFileOrDir = new List<string>() { mMediaLoc };
                MediaWizardOptions mwo = Engine.GetMediaType(listFileOrDir, true);
                if (mwo.MediaTypeChoice == MediaType.MediaIndiv && mFileCollection)
                {
                    mwo.MediaTypeChoice = MediaType.MediaCollection;
                }
                MediaInfo2 mi = new MediaInfo2(mwo.MediaTypeChoice, mMediaLoc);
                TorrentInfo ti = new TorrentInfo(mi);
                mi.ReadMedia();
                if (mScreenshotsCreate)
                {
                    ti.CreateScreenshots();
                }

                if (mTorrentCreate)
                {
                    ti.MediaMy.TorrentCreateInfoMy = new TorrentCreateInfo(Engine.conf.TrackerGroups[Engine.conf.TrackerGroupActive], mMediaLoc);
                    ti.MediaMy.TorrentCreateInfoMy.CreateTorrent();
                }

            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }


    }
}
