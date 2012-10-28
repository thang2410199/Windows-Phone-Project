using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using ToDoCalendar.Models;
using System.Collections.ObjectModel;

namespace ToDoCalendar.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Entry> ListStoredEntries { get; set; }
        public ObservableCollection<Entry> ListRecentEntries { get; set; }

        public int EntryCount
        {
            get
            {
                return ListStoredEntries.Count;
            }
        }

        public MainPageViewModel()
        {
            ListStoredEntries = new ObservableCollection<Entry>();
            ListRecentEntries = new ObservableCollection<Entry>();
        }

        public void PolluteData()
        {
            foreach (Entry entry in App.CurrentSetting.StoredEntries)
            {
                ListStoredEntries.Add(entry);
            }
            if (App.CurrentSetting.StoredEntries.Count >= 8)
            {
                var last8entries = App.CurrentSetting.StoredEntries.OrderBy(x => x.LastEditDate).Take(8);
                foreach (Entry entry in last8entries)
                {
                    ListRecentEntries.Add(entry);
                }
            }
            else
            {
                var last8entries = App.CurrentSetting.StoredEntries.OrderBy(x => x.LastEditDate);
                foreach (Entry entry in last8entries)
                {
                    ListRecentEntries.Add(entry);
                }
            }
        }
    }
}
