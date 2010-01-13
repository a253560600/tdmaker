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
            string mImagesDir = string.Empty;
            string mMediaLoc = string.Empty;
            string mRootDir = string.Empty;
            string mSettingsFile = string.Empty;
            string mTorrentDir = string.Empty;
            bool mScreenshotsCreate = false;
            bool mTorrentCreate = false;
            bool mFileCollection = false;
            bool mShowHelp = false;
            bool mXmlCreate = false;

            var p = new OptionSet() 
            {
                { "c", "Treat multiple files as a collection", v => mFileCollection = v != null},
                { "m|media=", "Location of the media file/folder", v => mMediaLoc = v },
                { "o|options=", "Location of the settings file", v => mSettingsFile = v },
                { "rd=", "Root directory for screenshots, torrent and all other output files. Overrides all other custom folders.", v => mRootDir = v },
                { "s", "Create and upload screenshots", v => mScreenshotsCreate = v != null},
                { "sd=", "Create screenshots in a custom folder and upload", v => mImagesDir = v },
                { "t", "Create torrent file in the parent folder of the media file", v => mTorrentCreate = v != null},
                { "td=", "Create torrent file in a custom folder", v => mTorrentDir = v},
                { "x|xml",  "Folder path of the XML torrent description file", v => mXmlCreate = v != null },
                { "h|help",  "Show this message and exit", v => mShowHelp = v != null }
            };

            if (args.Length == 0)
            {
                mShowHelp = true;
            }

            // give cli the ability to replace environment variables
            string[] args2 = new string[args.Length];
            int count = 0;
            foreach (string arg in args)
            {
                args2[count++] = arg.Replace("%appdata%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

            try
            {
                p.Parse(args2);
            }
            catch (Exception ex)
            {
                Console.Write("tdmakercli: ");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Try 'tdmakercli --help' for more information.");
                return;
            }

            if (mShowHelp)
            {
                ShowHelp(p);
                return;
            }

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

                Console.WriteLine("Media location:");
                Console.WriteLine(mMediaLoc);
                Console.WriteLine();

                Console.WriteLine("Settings file");
                Console.WriteLine(mSettingsFile);
                Console.WriteLine();

                Console.WriteLine("MTN Path:");
                Console.WriteLine(Engine.conf.MTNPath);
                Console.WriteLine();

                List<string> listFileOrDir = new List<string>() { mMediaLoc };
                MediaWizardOptions mwo = Adapter.GetMediaType(listFileOrDir, true);
                if (mwo.MediaTypeChoice == MediaType.MediaIndiv && mFileCollection)
                {
                    mwo.MediaTypeChoice = MediaType.MediaCollection;
                }
                MediaInfo2 mi = new MediaInfo2(mwo.MediaTypeChoice, mMediaLoc);
                TorrentInfo ti = new TorrentInfo(mi);
                mi.ReadMedia();

                // set root folder for images or set images dir if set one
                string ssDir = Directory.Exists(mRootDir) ? mRootDir : mImagesDir;
                if (mScreenshotsCreate)
                {
                    if (Directory.Exists(ssDir))
                    {
                        ti.CreateScreenshots(ssDir);
                    }
                    else
                    {
                        ti.CreateScreenshots();
                    }
                }

                PublishOptionsPacket pop = new PublishOptionsPacket()
                {
                    AlignCenter = Engine.conf.AlignCenter,
                    FullPicture = Engine.conf.UseFullPicture,
                    PreformattedText = Engine.conf.PreText,
                    PublishInfoTypeChoice = Engine.conf.PublishInfoTypeChoice,
                    TemplateLocation = Path.Combine(Engine.TemplatesDir, "Default")
                };

                ti.PublishString = Adapter.CreatePublish(ti, pop);
                Console.WriteLine();
                Console.WriteLine("Release Description: ");
                Console.WriteLine();
                Console.WriteLine(ti.PublishString);
                Console.WriteLine();

                string torrentDir = Directory.Exists(mRootDir) ? mRootDir : mTorrentDir;
                // create a torrent
                if (mTorrentCreate || Directory.Exists(torrentDir))
                {
                    ti.MediaMy.TorrentCreateInfoMy = new TorrentCreateInfo(Engine.conf.TrackerGroups[Engine.conf.TrackerGroupActive], mMediaLoc);
                    if (Directory.Exists(mTorrentDir))
                    {
                        ti.MediaMy.TorrentCreateInfoMy.TorrentFolder = torrentDir;
                    }
                    ti.MediaMy.TorrentCreateInfoMy.CreateTorrent();

                    // create xml file
                    if (mXmlCreate)
                    {
                        string fp = Path.Combine(ti.MediaMy.TorrentCreateInfoMy.TorrentFolder, Adapter.GetMediaName(ti.MediaMy.TorrentCreateInfoMy.MediaLocation)) + ".xml";
                        FileSystem.GetXMLTorrentUpload(ti.MediaMy).Write2(fp);
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: tdmakercli [OPTIONS]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
            Console.WriteLine();
        }
    }
}
