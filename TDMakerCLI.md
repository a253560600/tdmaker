# Introduction #
TDMakerCLI will provide a Command Line Interface for the TDMaker. It is recommended to first customize your settings using TDMakerGUI prior to using TDMakerCLI.

# Options #
When tdmakercli is run without any options, it will show its usage:
```
D:\Users\Mike\Local Settings\Application Data\TDMaker>tdmakercli.exe
Usage: tdmakercli [OPTIONS]

Options:
  -c                         Treat multiple files as a collection
  -m, --media=VALUE          Location of the media file/folder
  -o, --options=VALUE        Location of the settings file
  -s                         Create and upload screenshots
  -t                         Create torrent file
  -h, --help                 Show this message and exit

D:\Users\Mike\Local Settings\Application Data\TDMaker>
```

By default torrents are saved in the location determined by the Settings file.