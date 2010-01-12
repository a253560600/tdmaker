using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace TDMakerLib
{
    public static class FileSystem
    {
        public delegate void DebugLogEventHandler(string line);
        public static event DebugLogEventHandler DebugLogChanged;
        public static StringBuilder DebugLog = new StringBuilder();
        public static string DebugLogFilePath = Path.Combine(Engine.LogsDir, string.Format("{0}-{1}-debug.txt", Application.ProductName, DateTime.Now.ToString("yyyyMMdd")));

        private static void OnDebugLogChanged(string line)
        {
            if (DebugLogChanged != null)
            {
                DebugLogChanged(line);
            }
        }

        public static void AppendDebug(Exception ex)
        {
            AppendDebug(ex.ToString());
        }

        public static void AppendDebug(string msg)
        {
            if (!string.IsNullOrEmpty(msg))
            {
                // a modified http://iso.org/iso/en/prods-services/popstds/datesandtime.html - McoreD
                string line = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss - ") + msg;
                Debug.WriteLine(line);
                DebugLog.AppendLine(line);
                OnDebugLogChanged(line);
            }
        }

        public static void OpenDirTorrents()
        {
            if (Directory.Exists(Engine.TorrentsDir))
            {
                Process.Start(Engine.TorrentsDir);
            }
        }

        public static void OpenDirScreenshots()
        {
            if (Directory.Exists(GetScreenShotsDir()))
            {
                Process.Start(GetScreenShotsDir());
            }
        }

        public static void OpenDirTemplates()
        {
            if (Directory.Exists(Engine.TemplatesDir))
            {
                Process.Start(Engine.TemplatesDir);
            }
        }

        public static void OpenDirLogs()
        {
            if (Directory.Exists(Engine.LogsDir))
            {
                Process.Start(Engine.LogsDir);
            }
        }

        public static void OpenDirSettings()
        {
            if (Directory.Exists(Engine.SettingsDir))
            {
                Process.Start(Engine.SettingsDir);
            }
        }

        public static void OpenFileDebug()
        {
            if (File.Exists(FileSystem.DebugLogFilePath))
            {
                Process.Start(FileSystem.DebugLogFilePath);
            }
        }

        public static void WriteDebugFile()
        {
            if (!string.IsNullOrEmpty(Engine.LogsDir))
            {
            	string dir = Engine.LogsDir;
            	if (Engine.Portable)
            	{
            		dir = Path.Combine(Application.StartupPath, Engine.LogsDir);
            	}
                string fpDebug = Path.Combine(dir, string.Format("{0}-{1}-debug.txt", Application.ProductName, DateTime.Now.ToString("yyyyMMdd")));
                AppendDebug("Writing Debug file: " + fpDebug);                                
                if (Engine.conf.WriteDebugFile)
                {
                    if (DebugLog.Length > 0)
                    {
                        using (StreamWriter sw = new StreamWriter(fpDebug, true))
                        {
                            sw.WriteLine(DebugLog.ToString());
                            DebugLog = new StringBuilder();
                        }
                    }
                }
            }
        }



        /// <summary>
        /// Used to browse the defaule Screneshots folder only
        /// </summary>
        /// <returns></returns>
        public static string GetScreenShotsDir()
        {
            return GetScreenShotsDir("");
        }

        public static string GetScreenShotsDir(string mediaFilePath)
        {
            switch (Engine.conf.ScreenshotsLoc)
            {
                case LocationType.CustomFolder:
                    return Directory.Exists(Engine.conf.CustomScreenshotsDir) ? Engine.conf.CustomScreenshotsDir : Engine.PicturesDir;
                case LocationType.ParentFolder:
                    if (string.IsNullOrEmpty(mediaFilePath))
                    {
                        if (Engine.conf.ScreenshotsLoc == LocationType.CustomFolder && Directory.Exists(Engine.conf.CustomScreenshotsDir))
                        {
                            return Engine.conf.CustomScreenshotsDir;
                        }
                        else
                        {
                            return Engine.PicturesDir;
                        }
                    }
                    else
                    {
                        return Path.GetDirectoryName(mediaFilePath);
                    }
                case LocationType.KnownFolder:
                default:
                    return Engine.conf.KeepScreenshots ? Engine.PicturesDir : Engine.zTempDir;
            }
        }

        public static XMLTorrentUpload GetXMLTorrentUpload(MediaInfo2 mi)
        {
            string format = string.Empty;
            string res = string.Empty;
            string media = mi.Source;

            bool isMkv = false;
            if (mi.MediaTypeChoice == MediaType.MediaDisc)
            {
                format = mi.Source;
                res = mi.Overall.Video.Standard;
                if (format == "DVD-5" || format == "DVD-9")
                {
                    media = "DVD";
                }
            }
            else if (!string.IsNullOrEmpty(mi.Overall.Video.Codec))
            {
                string codec = mi.Overall.Video.Codec.ToLower();
                if (codec.Contains("divx"))
                {
                    format = "DivX";
                }
                else if (codec.Contains("xvid"))
                {
                    format = "XviD";
                }
                else if (codec.Contains("avc") || codec.Contains("x264"))
                {
                    format = "H.264";
                    isMkv = true;
                }
            }


            if (string.IsNullOrEmpty(res) && !string.IsNullOrEmpty(mi.Overall.Video.Height) && !string.IsNullOrEmpty(mi.Overall.Video.Width))
            {
                string height = mi.Overall.Video.Height;
                double dblWidth = 0.0;
                double dblHeight = 0.0;
                double.TryParse(mi.Overall.Video.Width, out dblWidth);
                double.TryParse(height, out dblHeight);

                if (dblWidth > 1900)
                {
                    res = "1080p";
                }
                else if (dblWidth > 1200)
                {
                    res = "720p";
                }
                else if (dblHeight > 480)
                {
                    res = "576p";
                }
                else if (dblWidth > 700)
                {
                    res = "480p";
                }
                else
                {
                    res = mi.Overall.Video.Resolution;
                }
            }

            string fileType = string.Empty;
            string ext = mi.Overall.FileExtension.ToLower();
            string[] exts = new string[] { "avi", "mpg", "mpeg", "mkv", "mp4", "vob", "iso" };
            if (!string.IsNullOrEmpty(ext))
            {
                foreach (string exMy in exts)
                {
                    if (ext.Contains(exMy))
                    {
                        fileType = exMy.ToUpper();
                        fileType = fileType.Replace("MPEG", "MPG");
                        fileType = fileType.Replace("VOB", "VOB IFO");
                        break;
                    }
                }
            }

            XMLTorrentUpload xmlUpload = new XMLTorrentUpload()
            {
                TorrentFilePath = mi.TorrentCreateInfoMy.TorrentFilePath,
                ReleaseDescription = mi.ReleaseDescription,
                Format = format,
                Resolution = res,
                Media = media,
                FileType = fileType
            };

            foreach (MediaFile mf in mi.MediaFiles)
            {
                xmlUpload.Screenshots.Add(mf.Screenshot.Full);
            }

            return xmlUpload;
        }

        /// <summary>
        /// Function to move a directory with overwriting existing files
        /// </summary>
        /// <param name="dirOld"></param>
        /// <param name="dirNew"></param>
        public static void MoveDirectory(string dirOld, string dirNew)
        {
            if (Directory.Exists(dirOld) && dirOld != dirNew)
            {
                if (MessageBox.Show("Would you like to move old Root folder content to the new location?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        Microsoft.VisualBasic.FileIO.FileSystem.MoveDirectory(dirOld, dirNew, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
