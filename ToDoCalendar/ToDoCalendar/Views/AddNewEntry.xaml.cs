using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ToDoCalendar.Views
{
    public partial class AddNewEntry : PhoneApplicationPage
    {
        public AddNewEntry()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            App.CurrentSetting.StoredEntries.Add(new Models.Entry() { Title = titleTextBox.Text, Content = detailTextBox.Text, CreateDate = DateTime.Now, LastEditDate = DateTime.Now });
            App.CurrentSetting.Save();
            this.NavigationService.GoBack();
        }
    }
}