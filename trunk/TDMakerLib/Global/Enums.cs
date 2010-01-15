using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TDMakerLib
{
    public enum MediaType
    {
        [Description("Media disc e.g. DVD")]
        MediaDisc,
        [Description("Single media file")]
        MediaIndiv,
        [Description("Media files collection")]
        MediaCollection,
        [Description("Music audio album")]
        MusicAudioAlbum
    }

    public enum LocationType
    {
        [Description("Parent folder of the media file")]
        ParentFolder,
        [Description("Default folder")]
        KnownFolder,
        [Description("Custom folder")]
        CustomFolder,
    }

    public enum PublishInfoType
    {
        [Description("Internal Template")]
        InternalTemplate,
        [Description("External Template")]
        ExternalTemplate,
        [Description("MediaInfo")]
        MediaInfo
    }

    public enum TakeScreenshotsType
    {
        NONE,
        TAKE_ALL_SCREENSHOTS,
        TAKE_ONE_SCREENSHOT
    }

    public enum ProgressType
    {
        INCREMENT_PROGRESS_WITH_MSG,
        PREVIEW_SCREENSHOT,
        REPORT_MEDIAINFO_SUMMARY,
        REPORT_TORRENTINFO,
        UPDATE_PROGRESSBAR_MAX,
        UPDATE_SCREENSHOTS_LIST,
        UPDATE_STATUSBAR_DEBUG
    }

    public enum TaskType
    {
        ANALYZE_MEDIA,
        CREATE_TORRENT
    }

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
        [Description("File")]
        FILE
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
