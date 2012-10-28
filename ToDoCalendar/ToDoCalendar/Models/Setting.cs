using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Phone.Controls;

namespace ToDoCalendar.Models
{
    public class Setting
    {
        const string filename = "setting.xml";
        public List<Entry> StoredEntries;

        // Default setting
        public Setting()
        {
            StoredEntries = new List<Entry>();
        }

        // Save the setting to xml file to later use.
        public void Save()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                IsolatedStorageFileStream stream = storage.CreateFile(filename);
                XmlSerializer xml = new XmlSerializer(GetType());
                xml.Serialize(stream, this);
                if (storage.AvailableFreeSpace >= stream.Length)
                {
                    stream.Close();
                    stream.Dispose();
                }
                else
                {
                    string msg = "Your memory is not enough to create save file, please delete some other contents to gain space.";
                    MessageBox.Show(msg, "Warning", MessageBoxButton.OK);
                }
            }
        }

        // Load method, can be called without create new Setting.
        public static Setting Load()
        {
            Setting setting;
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                // Check if we have exiting settings.
                if (storage.FileExists(filename))
                {
                    IsolatedStorageFileStream stream = storage.OpenFile(filename, FileMode.OpenOrCreate);
                    XmlSerializer xml = new XmlSerializer(typeof(Setting));
                    //setting = xml.Deserialize(stream) as Setting;

                    try
                    {
                        setting = xml.Deserialize(stream) as Setting;
                    }
                    catch
                    {
                        setting = new Setting();
                    }

                    stream.Close();
                    stream.Dispose();
                }
                // If not we will restore to default setting.
                else
                {
                    setting = new Setting();
                }
            }
            return setting;
        }
    }
}
