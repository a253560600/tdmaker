using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TDMakerLib
{
    public enum MediaType
    {
        [Description("Single media file")]
        SINGLE_MEDIA_FILE,
        [Description("Part of media files collection")]
        PART_OF_MEDIA_FILES_COLLECTION,
        [Description("Media disc")]
        MEDIA_DISC,
        [Description("Music audio album")]
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
}
