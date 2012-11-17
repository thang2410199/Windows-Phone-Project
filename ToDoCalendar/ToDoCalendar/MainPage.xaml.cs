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
using ToDoCalendar.Models;

namespace ToDoCalendar
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            this.TaskListBox.ItemsSource = App.CurrentSetting.StoredEntries;
            base.OnNavigatedTo(e);
        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Views/AddNewEntry.xaml", UriKind.Relative));
        }

        private void Menu_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string header = (sender as MenuItem).Header.ToString();

            ListBoxItem selectedListBoxItem = this.TaskListBox.ItemContainerGenerator.ContainerFromItem((sender as MenuItem).DataContext) as ListBoxItem;
            if (selectedListBoxItem == null)
            {
                return;
            }
            Entry choisendOne = (Entry)selectedListBoxItem.Content;

            if (header == "Edit")
            {
                App.CommonEntry = choisendOne;
                this.NavigationService.Navigate(new Uri("/Views/EditEntry.xaml", UriKind.Relative));
            }
            else if (header == "Delete")
            {
                App.CurrentSetting.StoredEntries.Remove(choisendOne);
                this.TaskListBox.ItemsSource = App.CurrentSetting.StoredEntries;
            }
        }
    }
}