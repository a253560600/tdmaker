﻿using System;
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
        private static string mMediaLoc = string.Empty;
        private static string mScreenshotDir = string.Empty;
        private static bool mScreenshotsCreate = false;
        private static string mTorrentsDir = string.Empty;
        private static bool mTorrentCreate = false;
        private static bool mXmlCreate = false;

        static void Main(string[] args)
        {
            string dirImages = string.Empty;
            string dirRoot = string.Empty;
            string mSettingsFile = string.Empty;
            string dirTorrents = string.Empty;

            bool mFileCollection = false;
            bool mShowHelp = false;

            var p = new OptionSet() 
            {
                { "c", "Treat multiple files as a collection", v => mFileCollection = v != null},
                { "m|media=", "Location of the media file/folder", v => mMediaLoc = v },
                { "o|options=", "Location of the settings file", v => mSettingsFile = v },
                { "rd=", "Root directory for screenshots, torrent and all other output files. Overrides all other custom folders.", v => dirRoot = v },
                { "s", "Create and upload screenshots", v => mScreenshotsCreate = v != null},
                { "sd=", "Create screenshots in a custom folder and upload", v => dirImages = v },
                { "t", "Create torrent file in the parent folder of the media file", v => mTorrentCreate = v != null},
                { "td=", "Create torrent file in a custom folder", v => dirTorrents = v},
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
                // set root folder for images or set images dir if set one
                mScreenshotDir = Directory.Exists(dirRoot) ? dirRoot : dirImages;
                // set root folder for torrents or set torrents dir if set one
                mTorrentsDir = Directory.Exists(dirRoot) ? dirRoot : dirTorrents;
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
                Engine.AppConf = AppSettings.Read();
                mSettingsFile = Engine.AppConf.XMLSettingsFile;
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
                mi.ReadMedia();

                TorrentInfo ti = new TorrentInfo(mi);
                CreateScreenshot(ti);
                CreatePublish(ti);
                CreateTorrent(ti);
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
            Console.WriteLine("Example:");
            Console.WriteLine(@"tdmakercli -m ""F:\Linux ISOs\Ubuntu"" -x -t");
            Console.WriteLine(@"tdmakercli -m ""F:\Linux ISOs\Ubuntu"" -x -t --rd ""F:\Linux ISOs\Ubuntu""");
            Console.WriteLine();
            //  Console.ReadLine();
        }

        static void CreateScreenshot(TorrentInfo ti)
        {
            if (mScreenshotsCreate)
            {
                if (Directory.Exists(mScreenshotDir))
                {
                    ti.CreateUploadScreenshots(mScreenshotDir);
                }
                else
                {
                    ti.CreateUploadScreenshots();
                }
            }
        }

        static void CreatePublish(TorrentInfo ti)
        {
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
        }

        static void CreateTorrent(TorrentInfo ti)
        {
            // create a torrent
            if (mTorrentCreate || Directory.Exists(mTorrentsDir))
            {
                ti.MediaMy.TorrentCreateInfoMy = new TorrentCreateInfo(Engine.conf.TrackerGroups[Engine.conf.TrackerGroupActive], mMediaLoc);
                if (Directory.Exists(mTorrentsDir))
                {
                    ti.MediaMy.TorrentCreateInfoMy.TorrentFolder = mTorrentsDir;
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
    }
}
