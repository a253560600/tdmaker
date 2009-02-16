﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using ZSS.ImageUploader;
using ZSS.ImageUploader.Helpers;

namespace ZSS.ImageUploader
{
    public sealed class XsToUploader : HTTPUploader
    {
        public override string Name
        {
            get { return "xs.to"; }
        }

        /// <summary>
        /// Anonymous Method to upload screenshots to XsTo
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public override ImageFileManager UploadImage(Image image, ImageFormat format)
        {
            MemoryStream imgStream = new MemoryStream();
            image.Save(imgStream, format);
            imgStream.Position = 0;
            bool oldValue = ServicePointManager.Expect100Continue;
            string fullimage = "";
            string thumbnail = "";
            List<ImageFile> imageFiles = new List<ImageFile>();

            try
            {
                ServicePointManager.Expect100Continue = false;
                CookieContainer cookies = new CookieContainer();
                Dictionary<string, string> arguments = new Dictionary<string, string>()
                {
                   { "action", "doupload" },
                   { "acceptTOS", "Yes" },
                   { "prtype", "0" }, //0 = Private or not child safe, 1 = Public and child safe
                   { "submit", "Upload!" }
                };

                string imgSource = PostImage(imgStream, "http://xs.to/directupload.php", "userfile", GetMimeType(format), arguments, cookies, "");
                string imgLink = Regex.Match(imgSource, "(?<=value=\").+(?=\"><)").Value;

                fullimage = imgLink;
                if (!string.IsNullOrEmpty(fullimage))
                {
                    thumbnail = imgLink + ".xs.jpg";
                }

                if (string.IsNullOrEmpty(fullimage))
                {
                    throw new Exception("Image link empty");
                }
            }
            catch (Exception e)
            {
                Errors.Add(e.Message);
            }
            finally
            {
                ServicePointManager.Expect100Continue = oldValue;
            }

            imgStream.Dispose();

            if (!string.IsNullOrEmpty(fullimage)) imageFiles.Add(new ImageFile(fullimage, ImageFile.ImageType.FULLIMAGE));
            if (!string.IsNullOrEmpty(thumbnail)) imageFiles.Add(new ImageFile(thumbnail, ImageFile.ImageType.THUMBNAIL));

            ImageFileManager ifm = new ImageFileManager(imageFiles);
            return ifm;
        }
    }
}