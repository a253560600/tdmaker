﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TDMaker.Helpers
{

    public enum ScreenshotDestType
    {
        [Description("ImageShack")]
        IMAGESHACK,
        [Description("TinyPic")]
        TINYPIC,
        [Description("ImageShack (Anonymous)")]
        IMAGESHACK_LEGACY_METHOD,
        [Description("xs.to")]
        XSTO
    }

    public static class ScreenshotDestTypeExtensions
    {
        public static string ToDescriptionString(this ScreenshotDestType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val.GetType().GetField(val.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}