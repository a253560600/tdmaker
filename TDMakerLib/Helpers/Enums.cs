using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TDMakerLib
{
	public enum ImageDestType2
    {
        [Description("ImageShack - www.imageshack.us")]
        IMAGESHACK,
        [Description("TinyPic - www.tinypic.com")]
        TINYPIC,
        [Description("ImageBin - www.imagebin.ca")]
        IMAGEBIN,
        [Description("Imgur - www.imgur.com")]
        IMGUR,
    }

    public static class ImageDestType2Extensions
    {
        public static string ToDescriptionString(this ImageDestType2 val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
