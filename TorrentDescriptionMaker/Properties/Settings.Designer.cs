﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TDMaker.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    [System.Serializable]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mtn.exe")]
        public string MTNPath {
            get {
                return ((string)(this["MTNPath"]));
            }
            set {
                this["MTNPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("-P -w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97")]
        public string MTNArg {
            get {
                return ((string)(this["MTNArg"]));
            }
            set {
                this["MTNArg"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>-P -w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97</string>
  <string>-P -N _s.txt -w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97</string>
  <string>-P -N _s.txt -w1024 -c3 -r4 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97</string>
  <string>-w 0 -c 1 -r 3 -keeeeee -f arial.ttf -g8 -F 000000:12 -L4:2 -j 97</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection MTNArgs {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["MTNArgs"]));
            }
            set {
                this["MTNArgs"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UploadScreenshot {
            get {
                return ((bool)(this["UploadScreenshot"]));
            }
            set {
                this["UploadScreenshot"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UseFullPicture {
            get {
                return ((bool)(this["UseFullPicture"]));
            }
            set {
                this["UseFullPicture"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlignCenter {
            get {
                return ((bool)(this["AlignCenter"]));
            }
            set {
                this["AlignCenter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PreText {
            get {
                return ((bool)(this["PreText"]));
            }
            set {
                this["PreText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool LargerPreText {
            get {
                return ((bool)(this["LargerPreText"]));
            }
            set {
                this["LargerPreText"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public decimal FontSizeHeading2 {
            get {
                return ((decimal)(this["FontSizeHeading2"]));
            }
            set {
                this["FontSizeHeading2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public decimal FontSizeBody {
            get {
                return ((decimal)(this["FontSizeBody"]));
            }
            set {
                this["FontSizeBody"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal FontSizeIncr {
            get {
                return ((decimal)(this["FontSizeIncr"]));
            }
            set {
                this["FontSizeIncr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>DVD</string>
  <string>DVD-5</string>
  <string>DVD-9</string>
  <string>VHS</string>
  <string>HDTV</string>
  <string>SDTV</string>
  <string>LD</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Sources {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Sources"]));
            }
            set {
                this["Sources"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DVD")]
        public string Source {
            get {
                return ((string)(this["Source"]));
            }
            set {
                this["Source"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool KeepScreenshot {
            get {
                return ((bool)(this["KeepScreenshot"]));
            }
            set {
                this["KeepScreenshot"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool WebLink {
            get {
                return ((bool)(this["WebLink"]));
            }
            set {
                this["WebLink"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AnalyzeAuto {
            get {
                return ((bool)(this["AnalyzeAuto"]));
            }
            set {
                this["AnalyzeAuto"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int AnnounceURLIndex {
            get {
                return ((int)(this["AnnounceURLIndex"]));
            }
            set {
                this["AnnounceURLIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool CreateTorrent {
            get {
                return ((bool)(this["CreateTorrent"]));
            }
            set {
                this["CreateTorrent"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TorrentFolderDefault {
            get {
                return ((bool)(this["TorrentFolderDefault"]));
            }
            set {
                this["TorrentFolderDefault"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string SettingsDir {
            get {
                return ((string)(this["SettingsDir"]));
            }
            set {
                this["SettingsDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TorrentsCustomDir {
            get {
                return ((string)(this["TorrentsCustomDir"]));
            }
            set {
                this["TorrentsCustomDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TorrentsOrganize {
            get {
                return ((bool)(this["TorrentsOrganize"]));
            }
            set {
                this["TorrentsOrganize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5")]
        public decimal FontSizeHeading1 {
            get {
                return ((decimal)(this["FontSizeHeading1"]));
            }
            set {
                this["FontSizeHeading1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public decimal FontSizeHeading3 {
            get {
                return ((decimal)(this["FontSizeHeading3"]));
            }
            set {
                this["FontSizeHeading3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>Intact</string>
  <string>Shrunk</string>
  <string>Removed</string>
  <string>None on Source</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection Extras {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["Extras"]));
            }
            set {
                this["Extras"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>Untouched</string>\r\n  <string>Shrunk</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection SourceEdits {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["SourceEdits"]));
            }
            set {
                this["SourceEdits"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Untouched")]
        public string SourceEdit {
            get {
                return ((string)(this["SourceEdit"]));
            }
            set {
                this["SourceEdit"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Intact")]
        public string ExtrasMode {
            get {
                return ((string)(this["ExtrasMode"]));
            }
            set {
                this["ExtrasMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool bVideoEdits {
            get {
                return ((bool)(this["bVideoEdits"]));
            }
            set {
                this["bVideoEdits"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool bExtras {
            get {
                return ((bool)(this["bExtras"]));
            }
            set {
                this["bExtras"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool bSource {
            get {
                return ((bool)(this["bSource"]));
            }
            set {
                this["bSource"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool WritePublish {
            get {
                return ((bool)(this["WritePublish"]));
            }
            set {
                this["WritePublish"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>Intact</string>\r\n  <string>Removed</string>\r\n  <string>Shrunk</string>\r\n</" +
            "ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection DiscMenus {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["DiscMenus"]));
            }
            set {
                this["DiscMenus"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Intact")]
        public string DiscMenu {
            get {
                return ((string)(this["DiscMenu"]));
            }
            set {
                this["DiscMenu"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool bDiscMenu {
            get {
                return ((bool)(this["bDiscMenu"]));
            }
            set {
                this["bDiscMenu"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string TemplatesDir {
            get {
                return ((string)(this["TemplatesDir"]));
            }
            set {
                this["TemplatesDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool TemplatesMode {
            get {
                return ((bool)(this["TemplatesMode"]));
            }
            set {
                this["TemplatesMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int TemplateIndex {
            get {
                return ((int)(this["TemplateIndex"]));
            }
            set {
                this["TemplateIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool BrowseDir {
            get {
                return ((bool)(this["BrowseDir"]));
            }
            set {
                this["BrowseDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TakeScreenshot {
            get {
                return ((bool)(this["TakeScreenshot"]));
            }
            set {
                this["TakeScreenshot"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AutoCheckUpdates {
            get {
                return ((bool)(this["AutoCheckUpdates"]));
            }
            set {
                this["AutoCheckUpdates"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ScreenshotDestIndex {
            get {
                return ((int)(this["ScreenshotDestIndex"]));
            }
            set {
                this["ScreenshotDestIndex"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool UpdateCheckAuto {
            get {
                return ((bool)(this["UpdateCheckAuto"]));
            }
            set {
                this["UpdateCheckAuto"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ImageShakeRandomizeFileName {
            get {
                return ((bool)(this["ImageShakeRandomizeFileName"]));
            }
            set {
                this["ImageShakeRandomizeFileName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RunOnce {
            get {
                return ((bool)(this["RunOnce"]));
            }
            set {
                this["RunOnce"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowMTNWindow {
            get {
                return ((bool)(this["ShowMTNWindow"]));
            }
            set {
                this["ShowMTNWindow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string ImageShackRegCode {
            get {
                return ((string)(this["ImageShackRegCode"]));
            }
            set {
                this["ImageShackRegCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UseImageShackRegCode {
            get {
                return ((bool)(this["UseImageShackRegCode"]));
            }
            set {
                this["UseImageShackRegCode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool bTitle {
            get {
                return ((bool)(this["bTitle"]));
            }
            set {
                this["bTitle"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("arial.ttf")]
        public string MTNFont {
            get {
                return ((string)(this["MTNFont"]));
            }
            set {
                this["MTNFont"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection MTNFonts {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["MTNFonts"]));
            }
            set {
                this["MTNFonts"] = value;
            }
        }
    }
}
