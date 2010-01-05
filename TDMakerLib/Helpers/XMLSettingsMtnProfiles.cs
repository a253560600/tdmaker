using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Specialized;
using UploadersLib;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace TDMakerLib
{
    [XmlRoot("Settings")]
    public class XMLSettingsMtnProfiles : XMLSettings
    {
        public static string XMLFileName = "MtnProfiles.xml"; 

        public int MtnProfileActive = 0;
        public List<XMLSettingsScreenshot> MtnProfiles = new List<XMLSettingsScreenshot>();
        
        public XMLSettingsMtnProfiles()
        {
            ApplyDefaultValues(this);
        }        
        
        public XMLSettingsScreenshot GetMtnProfileActive()
        {
        	if (MtnProfiles.Count > MtnProfileActive) {
        		return MtnProfiles[MtnProfileActive];
        	}
        	return new XMLSettingsScreenshot();
        }
        
        #region I/O Methods

        public void Write(string filePath)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                //Write XML file
                XmlSerializer serial = new XmlSerializer(typeof(XMLSettingsMtnProfiles));
                FileStream fs = new FileStream(filePath, FileMode.Create);
                serial.Serialize(fs, this);
                fs.Close();

                serial = null;
                fs = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Write()
        {
            Write(Engine.mAppSettings.GetSettingsFilePath(XMLFileName));
        }

        public static XMLSettingsMtnProfiles Read()
        {
            string settingsFile = Engine.mAppSettings.GetSettingsFilePath(XMLFileName);
            return Read(settingsFile);
        }

        public static XMLSettingsMtnProfiles Read(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                string settingsDir = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(settingsDir))
                {
                    Directory.CreateDirectory(settingsDir);
                }
                if (File.Exists(filePath))
                {
                    try
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(XMLSettingsMtnProfiles));
                        using (FileStream fs = new FileStream(filePath, FileMode.Open))
                        {
                            return xs.Deserialize(fs) as XMLSettingsMtnProfiles;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return new XMLSettingsMtnProfiles();
        }

        #endregion
    }
}
