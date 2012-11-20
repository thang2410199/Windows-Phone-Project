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

namespace ToDoCalendar.ViewModels
{
    public partial class EditEntry : PhoneApplicationPage
    {
        public EditEntry()
        {
            InitializeComponent();
            titleTextBox.Text = App.CommonEntry.Title;
            detailTextBox.Text = App.CommonEntry.Content;
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            App.CommonEntry.Title = titleTextBox.Text;
            App.CommonEntry.Content = detailTextBox.Text;
            App.CurrentSetting.Save();
            this.NavigationService.GoBack();
        }
    }
}