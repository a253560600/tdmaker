using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TDMaker.Properties;
using TorrentDescriptionMaker;

namespace TDMaker
{
    /// <summary>
    /// Class that holds all the MediaInfo of a media file
    /// This can be a single .vob, .avi etc.
    /// </summary>
    public class MediaFile
    {
        public string Bitrate { get; set; }
        /// <summary>
        /// Duration in seconds
        /// </summary>
        public double Duration { get; set; }
        /// <summary>
        /// Duration in hours:minutes:seconds
        /// </summary>
        public string DurationString { get; set; }
        public string FileExtension { get; set; }
        public string FileName { get; set; }
        /// <summary>
        /// Always a File Path of Media
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// File Size in Bytes
        /// </summary>
        public double FileSize { get; set; }
        /// <summary>
        /// File Size in XX.X MiB
        /// </summary>
        public string FileSizeString { get; set; }
        public string Format { get; set; }
        public string FormatInfo { get; set; }
        /// <summary>
        /// FilePath or DirectoryPath of the Media
        /// </summary>
        public string Location { get; private set; }
        public string Source { get; set; }
        public string Subtitles { get; set; }
        /// <summary>
        /// This is what you get for mi.Option("Complete");
        /// </summary>
        public string Summary { get; set; }

        public List<AudioInfo> Audio { get; set; }
        public VideoInfo Video { get; set; }

        public MediaFile(string fp)
        {
            this.FilePath = fp;
            this.FileExtension = Path.GetExtension(fp);
            this.FileName = Path.GetFileName(fp);

            this.Audio = new List<AudioInfo>();
            this.Video = new VideoInfo();
        }

        /// <summary>
        /// Returns a Publish layout of Media Info
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            int fontSizeHeading3 = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
           Settings.Default.FontSizeHeading3 + Settings.Default.FontSizeIncr :
           Settings.Default.FontSizeHeading3);

            int fontSizeBody = (int)(Settings.Default.PreText && Settings.Default.LargerPreText == true ?
                Settings.Default.FontSizeBody + Settings.Default.FontSizeIncr :
                Settings.Default.FontSizeBody);


            BbCode bb = new BbCode();

            StringBuilder sbBody = new StringBuilder();

            //*********************
            //* General
            //*********************   
            StringBuilder sbGeneral = new StringBuilder();

            sbBody.AppendLine(bb.size(fontSizeHeading3, bb.bolditalic("General:")));
            sbBody.AppendLine();
            // File Name
            if (!string.IsNullOrEmpty(this.FileName))
            {
                sbGeneral.AppendLine(string.Format("         [u]File Name:[/u] {0}", this.FileName));
            }

            // Format
            sbGeneral.Append(string.Format("            [u]Format:[/u] {0}", this.Format));
            if (!string.IsNullOrEmpty(this.FormatInfo))
            {
                sbGeneral.Append(string.Format(" ({0})", this.FormatInfo));
            }
            sbGeneral.Append(Environment.NewLine);

            // File Size
            sbGeneral.AppendLine(string.Format("         [u]File Size:[/u] {0}", this.FileSizeString));
            // Duration
            sbGeneral.AppendLine(string.Format("          [u]Duration:[/u] {0}", this.DurationString));
            // Bitrate
            sbGeneral.AppendLine(string.Format("           [u]Bitrate:[/u] {0}", this.Bitrate));

            // Subtitles            
            if (!string.IsNullOrEmpty(this.Subtitles))
            {
                sbGeneral.AppendLine(string.Format("         [u]Subtitles:[/u] {0}", this.Subtitles));
            }


            sbBody.Append(bb.size(fontSizeBody, sbGeneral.ToString()));

            //*********************
            //* Video
            //*********************    
            VideoInfo vi = this.Video;

            sbBody.AppendLine();
            sbBody.AppendLine(bb.size(fontSizeHeading3, bb.bolditalic("Video:")));
            sbBody.AppendLine();

            StringBuilder sbVideo = new StringBuilder();
            // Format            
            sbVideo.Append(string.Format("            [u]Format:[/u] {0}", this.Video.Format));
            if (!string.IsNullOrEmpty(this.Video.FormatVersion))
            {
                sbVideo.Append(string.Format(" {0}", this.Video.FormatVersion));
            }
            sbVideo.Append(Environment.NewLine);

            // Codec
            if (!string.IsNullOrEmpty(vi.Codec))
                sbVideo.AppendLine(string.Format("             [u]Codec:[/u] {0}", vi.Codec));
            // Bitrate
            sbVideo.AppendLine(string.Format("           [u]Bitrate:[/u] {0}", this.Video.Bitrate));
            // Standard            
            if (!string.IsNullOrEmpty(vi.Standard))
                sbVideo.AppendLine(string.Format("          [u]Standard:[/u] {0}", this.Video.Standard));
            // Frame Rate
            sbVideo.AppendLine(string.Format("        [u]Frame Rate:[/u] {0}", vi.FrameRate));

            // Scan Type
            sbVideo.AppendLine(string.Format("         [u]Scan Type:[/u] {0}", vi.ScanType));
            sbVideo.AppendLine(string.Format("[u]Bits/(Pixel*Frame):[/u] {0}", vi.BitsPerPixelXFrame));

            // Resolution
            sbVideo.AppendLine(string.Format("        [u]Resolution:[/u] {0}x{1}",
                vi.Width,
                vi.Height));

            sbBody.Append(bb.size(fontSizeBody, sbVideo.ToString()));

            //*********************
            //* Audio
            //*********************          

            int audioCount = this.Audio.Count;

            for (int a = 0; a < audioCount; a++)
            {
                AudioInfo ai = this.Audio[a];

                sbBody.AppendLine();
                sbBody.AppendLine(string.Format(bb.size(fontSizeHeading3, bb.bolditalic("Audio #{0}:")), a + 1));
                sbBody.AppendLine();

                StringBuilder sbAudio = new StringBuilder();
                // Format
                sbAudio.Append(string.Format("            [u]Format:[/u] {0}", ai.Format));
                if (!string.IsNullOrEmpty(ai.FormatVersion))
                    sbAudio.Append(string.Format(" {0}", ai.FormatVersion));
                if (!string.IsNullOrEmpty(ai.FormatProfile))
                    sbAudio.Append(string.Format(" {0}", ai.FormatProfile));
                sbAudio.Append(Environment.NewLine);

                // Codec     
                if (!string.IsNullOrEmpty(ai.Codec))
                    sbAudio.AppendLine(string.Format("             [u]Codec:[/u] {0}", ai.Codec));
                // Bitrate
                sbAudio.AppendLine(string.Format("           [u]Bitrate:[/u] {0} ({1})", ai.Bitrate, ai.BitrateMode));
                // Channels
                sbAudio.AppendLine(string.Format("          [u]Channels:[/u] {0}", ai.Channels));
                // Sampling Rate
                sbAudio.AppendLine(string.Format("     [u]Sampling Rate:[/u] {0}", ai.SamplingRate));
                // Resolution
                if (!string.IsNullOrEmpty(ai.Resolution))
                    sbAudio.AppendLine(string.Format(("        [u]Resolution:[/u] {0}"), ai.Resolution));

                sbBody.Append(bb.size(fontSizeBody, sbAudio.ToString()));
                sbBody.AppendLine();
            }

            return sbBody.ToString();
        }
    }

    public class Info
    {
        public string Bitrate { get; set; }
        public string Codec { get; set; }
        public string Standard { get; set; }
        public string Format { get; set; }
        public string FormatProfile { get; set; }
        public string FormatVersion { get; set; }
        public string Resolution { get; set; }

    }

    public class AudioInfo : Info
    {
        //         
        public string BitrateMode { get; set; }
        public string Channels { get; set; }
        public string SamplingRate { get; set; }
    }

    public class VideoInfo : Info
    {
        public string FrameRate { get; set; }
        public string Height { get; set; }
        public string ScanType { get; set; }
        public string Width { get; set; }
        public string BitsPerPixelXFrame { get; set; }

    }
}
