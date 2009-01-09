using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization;
using TDMaker.Properties;

namespace TDMaker
{
    [Serializable]
   public class TrackerManager
    {

        public List<Tracker> Trackers { get; set; }

        public string TrackersXML { get; private set; }

        public TrackerManager()
        {
            Trackers = new List<Tracker>();
            this.TrackersXML = Path.Combine(Settings.Default.SettingsDir, "trackers.xml");
        }

        public List<Tracker> Read()
        {
            if (File.Exists(TrackersXML))
            {

                object obj = new object();
                try
                {
                    using (FileStream fs = new FileStream(TrackersXML, FileMode.Open, FileAccess.Read))
                    {

                        XmlSerializer xs = new XmlSerializer(Trackers.GetType());
                        obj = xs.Deserialize(fs);
                        fs.Close();

                    }

                    if (obj != null)
                    {
                        Trackers = (List<Tracker>)obj;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }

                // Declare the hashtable reference.


                //// Open the file containing the data that you want to deserialize.
                //FileStream fs = new FileStream(TrackersXML, FileMode.Open);
                //try
                //{
                //    SoapFormatter formatter = new SoapFormatter();

                //    // Deserialize the hashtable from the file and 
                //    // assign the reference to the local variable.
                //    Trackers = (List<Tracker>)formatter.Deserialize(fs);
                //}
                //catch (SerializationException e)
                //{
                //    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                //}

                //finally
                //{
                //    fs.Close();
                //}

            }

            return Trackers;
        }

        public void Write(List<Tracker> tr)
        {
            try
            {
                if (tr.Count > 0)
                {
                    using (FileStream fs = new FileStream(TrackersXML, FileMode.Create))
                    {
                        XmlSerializer xs = new XmlSerializer(tr.GetType());
                        xs.Serialize(fs, tr);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
               // fs.Close();
            }
            

            //FileStream fs = new FileStream(TrackersXML, FileMode.Create);

            //// Construct a SoapFormatter and use it 
            //// to serialize the data to the stream.
            //SoapFormatter formatter = new SoapFormatter();
            //try
            //{
            //    formatter.Serialize(fs, Trackers);
            //}
            //catch (SerializationException e)
            //{
            //    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
            //    throw;
            //}
            //finally
            //{
            //    fs.Close();
            //}
            
        }

    }
}
