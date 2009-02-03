using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDMakerLib
{
    public enum MediaType
    {
        SINGLE_MEDIA_FILE,
        MEDIA_DISC,
        MUSIC_AUDIO_ALBUM
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
        UPDATE_PROGRESSBAR_MAX,
        UPDATE_SCREENSHOTS_LIST,
        UPDATE_STATUSBAR_DEBUG
    }

    /// <summary>
    /// Options regard Publish
    /// </summary>
    public struct PublishOptionsPacket
    {
        public bool AlignCenter { get; set; }
        public bool PreformattedText { get; set; }
        public bool FullPicture { get; set; }
        public bool TemplatesMode { get; set; }
        public string TemplateLocation { get; set; }
    }


    public enum TaskType
    {
        ANALYZE_MEDIA,
        CREATE_TORRENT
    }

}
