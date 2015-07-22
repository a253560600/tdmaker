

# Introduction #

Using Mono this Wiki page shows attempts taken to run TDMaker in Linux and Mac OS X.

![http://i34.tinypic.com/73jp6g.png](http://i34.tinypic.com/73jp6g.png)

## What's working so far? ##
  * Creating Torrents using MonoTorrent
  * Taking screenshots using MTN
  * Creating Description using MediaInfo (or MTN)

## What's not working so far? ##
**Unknown**

# Getting Started #
  * Download Mono Framework from http://www.go-mono.com/mono-downloads/download.html
    * Mac OS X: the assemblies will be in /Library/Frameworks/Mono.framework

## TDMaker ##
  * Download latest zip file for Linux: http://code.google.com/p/tdmaker/downloads/list?q=label:OpSys-Linux
  * Extract it to somewhere like:
```
~\Applications\TDMaker
```

## MediaInfo ##
  * Download appropriate MediaInfo library and its dependencies from http://mediainfo.sourceforge.net/en/Download
    * for Mac OS X:
      1. http://downloads.sourceforge.net/mediainfo/MediaInfo_DLL_0.7.27_Mac_Universal.tar.bz2
    * for Ubuntu:
      1. http://downloads.sourceforge.net/mediainfo/libmediainfo0_0.7.27-1_amd64.Ubuntu_9.10.deb
      1. http://downloads.sourceforge.net/zenlib/libzen0_0.4.10-1_amd64.Ubuntu_9.10.deb

## Setting up TDMaker.exe.config ##
To map MediaInfo.dll to the relevant Linux library, you need to create a TDMaker.exe.config file and have the following. The following file needs to be in the same directory TDMaker.exe is in. This file is already included in the zip file downloaded. So extracting all files would have this file in the right place.

### Linux and Mac OS X ###
Thanks to mhutch:
```
    <configuration>
            <dllmap os="osx" dll="MediaInfo.dll" target="libmediainfo.dylib"/>
            <dllmap os="linux" dll="MediaInfo.dll" target="libmediainfo.so.0" />
    </configuration>
```

## Running TDMaker in Mono Terminal ##
Execute TDMaker:
```
mono --debug TDMaker.exe
```

## Troubleshooting ##
  * If mtn does not execute properly then in Terminal, try:
```
chmod +x mtn
```
  * If you get the following error try installing **libmono-winforms2.0-cil**:
```
** (TDMaker.exe:29543): WARNING **: The following assembly referenced from /home/ajt/Downloads/TDMAKER/TDMaker.exe could not be loaded:
 Assembly:   System.Windows.Forms    (assemblyref_index=1)
 Version:    2.0.0.0
 Public Key: b77a5c561934e089
 The assembly was not found in the Global Assembly Cache, a path listed in the MONO_PATH environment variable, or in the location of the executing assembly (/home/ajt/Downloads/TDMAKER/).
```
Using Terminal, type:
```
apt-get install libmono-winforms2.0-cil
```
**If MediaInfo is not generating, try
```
MONO_LOG_MASK=dll MONO_LOG_LEVEL=debug mono --debug TDMaker.exe
```**

# Screenshots #

## Ubuntu 8.10 ##
### Info tab ###
![http://i36.tinypic.com/qmywxx.png](http://i36.tinypic.com/qmywxx.png)
### Publish tab ###
#### Using MediaInfo ####
![http://i34.tinypic.com/2ivk9kj.png](http://i34.tinypic.com/2ivk9kj.png)
#### Using MTN info ####
![http://i35.tinypic.com/2n82zxe.png](http://i35.tinypic.com/2n82zxe.png)
### Screenshots tab ###
![http://i36.tinypic.com/29dk0ug.png](http://i36.tinypic.com/29dk0ug.png)
### About Window ###
![http://img259.imageshack.us/img259/1637/screenshotabouttdmakerrh2.png](http://img259.imageshack.us/img259/1637/screenshotabouttdmakerrh2.png)
### Version History Window ###
![http://i37.tinypic.com/263fu2w.png](http://i37.tinypic.com/263fu2w.png)

## Mac OS X ##
### Main Window ###
Thanks to ameeps:
![http://img172.imageshack.us/img172/4189/picture1cv5.png](http://img172.imageshack.us/img172/4189/picture1cv5.png)

# IRC #
[irc://irc.what.cd/TDMaker](irc://irc.what.cd/TDMaker)

# Updates #
  * 22:37 2009-01-27 MediaInfo for Mac DLL released: https://sourceforge.net/forum/message.php?msg_id=6267211
  * 15:11 2009-01-25 TDMaker compiled successfully in MonoDevelop
  * 08:28 2009-01-22 Posted http://sourceforge.net/forum/message.php?msg_id=6210216