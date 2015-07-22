

# Introduction #

If known folders are preferred, Templates are located in
```
\%AppData%\TDMaker\Templates
```

By default there will 3 Templates installed: Default, Minimal and MTN.

# Supported Syntax #

## Styles ##

  * %FontSize\_Heading1%
  * %FontSize\_Heading2%
  * %FontSize\_Heading3%
  * %FontSize\_Body%

## Disc.txt and File.txt ##

  * **%Title%** = Place holder for Title
  * **%Source%** = Place holder for Source
  * **%Disc\_Authoring%** = Place holder
  * **%Disc\_Menu%** = Place holder for
  * **%Disc\_Extras%** = Place holder for GeneralInfo.txt
  * **%WebLink%** = Place holder for DiscAudioInfo.txt

  * **%General\_Info%** = Place holder for GeneralInfo.txt
  * **%Audio\_Info%** = Place holder for DiscAudioInfo.txt
  * **%Video\_Info%** = Place holder for FileVideoInfo.txt or DiscVideoInfo.txt

  * **%ScreenshotFull%** = Place holder for Full Screenshot
  * **%ScreenshotForums%** = Place holder for Linked Thumbnail Screenshot

Apart from these syntaxes both files support all the syntaxes listed below. However when Audio syntaxes are used, the syntaxes match to the first available audio stream of the media file.

  * **%Audio\_Format%**
  * **%Audio\_Bitrate%**
  * **%Audio\_Channels%**
  * **%Audio\_SamplingRate%**
  * **%Audio\_Resolution%**

  * **%Video\_Format%**
  * **%Video\_Bitrate%**
  * **%Video\_Standard%**
  * **%Video\_FrameRate%**
  * **%Video\_ScanType%**
  * **%Video\_BitsPerPixelFrame%**
  * **%Video\_DisplayAspectRatio%**
  * **%Video\_Width%**
  * **%Video\_Height%**
  * **%Video\_EncodedLibrarySettings%**

  * **%Format%**
  * **%Bitrate%**
  * **%FileSize%**
  * **%Subtitles%**
  * **%Duration%**

## FileAudioInfo.txt and DiscAudioInfo.txt ##

  * **%AudioID%** = Stream number of Audio - useful for sources with multiple audio

  * **%Audio\_Format%**
  * **%Audio\_Bitrate%**
  * **%Audio\_Channels%**
  * **%Audio\_SamplingRate%**
  * **%Audio\_Resolution%**

## FileVideoInfo.txt and DiscVideoInfo.txt ##

  * **%Video\_Format%**
  * **%Video\_Bitrate%**
  * **%Video\_Standard%**
  * **%Video\_FrameRate%**
  * **%Video\_ScanType%**
  * **%Video\_BitsPerPixelFrame%**
  * **%Video\_Width%**
  * **%Video\_Height%**

## GeneralInfo.txt ##

  * **%General\_Format%**
  * **%General\_Bitrate%**
  * **%General\_FileSize%**
  * **%General\_Subtitles%**
  * **%General\_Duration%**
  * **%General\_EncodedApplication%**
  * **%General\_EncodedDate%**

# Creating a new Template #

  1. Easiest way to do is to copy one of the existing folders in Templates folder.
  1. Rename the folder to reflect the description of the new template you are creating.
  1. Edit each file to suit your needs.