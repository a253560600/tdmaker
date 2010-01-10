﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace TDMakerLib
{
    [Serializable]
    [XmlRoot("TorrentInfo")]
    public class XMLTorrentUpload
    {
        /// <summary>
        /// Local file path of the torrent file
        /// </summary>
        public string TorrentFilePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //public string Type { get; set; }
        //public string IMDBID { get; set; }
        //public bool Scene { get; set; }
        /// <summary>
        /// XviD, DivX, H.264, DVD-5 or DVD-9
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 480p, 576p, 720p, 1080i, 1080p, custom
        /// </summary>
        public string Resolution { get; set; }
        /// <summary>
        /// Source: CAM, TS, HD-DVD etc.
        /// </summary>
        public string Media { get; set; }
        /// <summary>
        /// AVI, MKV
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// TDMaker Release Description
        /// </summary>
        public string ReleaseDescription { get; set; }
        public List<string> Screenshots { get; set; }

        public XMLTorrentUpload()
        {
            Screenshots = new List<string>();
        }

        #region I/O Methods

        /// <summary>
        /// Similar to Write() but does not write to file if certain properties are not populated
        /// </summary>
        /// <param name="filePath"></param>
        public void Write2(string filePath)
        {
            if (!string.IsNullOrEmpty(TorrentFilePath))
            {
                Write(filePath);
            }
        }

        public void Write(string filePath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                //Write XML file
                XmlSerializer serial = new XmlSerializer(typeof(XMLTorrentUpload));
                FileStream fs = new FileStream(filePath, FileMode.Create);
                serial.Serialize(fs, this);
                fs.Close();

                serial = null;
                fs = null;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public static XMLTorrentUpload Read(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string settingsDir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }
                if (File.Exists(filePath))
                {
                    try
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(XMLTorrentUpload));
                        using (FileStream fs = new FileStream(filePath, FileMode.Open))
                        {
                            return xs.Deserialize(fs) as XMLTorrentUpload;
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }
            }

            return new XMLTorrentUpload();
        }

        #endregion
    }
}
