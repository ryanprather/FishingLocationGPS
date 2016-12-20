using FishingLocationGPS.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FishingLocationGPS.UserControls
{
    public sealed partial class ucManageNotes : UserControl
    {
        private DataIO dataIO = new DataIO();
        private List<Models.PersonalGPSLocationNote> Notes { get; set; }

        public ucManageNotes()
        {
            this.InitializeComponent();
            this.LoadListData();
        }

        private void LoadListData()
        {
            Notes = dataIO.GetNotes();
            lstNotes.ItemsSource = Notes;
        }

        private async void btnView_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Models.PersonalGPSLocationNote)lstNotes.SelectedItem;
            if (selectedItem != null)
            {
                var dialog = new Dialogs.cdViewNote(selectedItem);
                await dialog.ShowAsync();
            }
            else
            {
                var dailog = new MessageDialog("Please select a location to view.");
                await dailog.ShowAsync();
            }
        }
        
        private void btnSearchOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Models.PersonalGPSLocationNote)lstNotes.SelectedItem;
            if (selectedItem != null)
            {
                var dialog = new Dialogs.cdDeleteNote(selectedItem);
                await dialog.ShowAsync();
                LoadListData();
            }
            else
            {
                var dailog = new MessageDialog("Please select a location to edit.");
                await dailog.ShowAsync();
            }
        }
        

        private void btnOrderByCreated_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOrderByName_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.cdAddNote();
            await dialog.ShowAsync();
            LoadListData();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
