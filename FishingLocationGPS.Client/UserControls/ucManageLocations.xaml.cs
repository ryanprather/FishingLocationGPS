using FishingLocationGPS.Client;
using FishingLocationGPS.Client.Helpers;
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
    public sealed partial class ucManageLocations : UserControl
    {
        private List<Models.DbModels.PersonalGPSLocation> Locations { get; set; }

        public ucManageLocations()
        {
            this.InitializeComponent();
            this.LoadListData();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != String.Empty)
            {
                using (var dbContext = new DbAppContext())
                {
                    Locations = dbContext.PersonalGPSLocations
                        .Where(item => item.Name.Contains(txtName.Text))
                        .OrderBy(item => item.PersonalGPSLocationID).ToList();
                }

                grdLocations.ItemsSource = Locations;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            LoadListData();
        }

        private void LoadListData()
        {
            using (var dbContext = new DbAppContext())
            {
                Locations = dbContext.PersonalGPSLocations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item => item.PersonalGPSLocationID).ToList();
            }

            grdLocations.ItemsSource = Locations;
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.cdAddLocation();
            await dialog.ShowAsync();
            LoadListData();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Models.DbModels.PersonalGPSLocation)grdLocations.SelectedItem;
            if (selectedItem != null)
            {
                var dialog = new Dialogs.cdEditLocation(selectedItem);
                await dialog.ShowAsync();
                LoadListData();
            }
            else
            {
                var dailog = new MessageDialog("Please select a location to edit.");
                await dailog.ShowAsync();
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Models.DbModels.PersonalGPSLocation)grdLocations.SelectedItem;
            if (selectedItem != null)
            {
                var dialog = new Dialogs.cdDeleteLocation(selectedItem);
                await dialog.ShowAsync();
                LoadListData();
            }
            else
            {
                var dailog = new MessageDialog("Please select a location to delete.");
                await dailog.ShowAsync();
            }
        }

        private void btnSearchOpen_Click(object sender, RoutedEventArgs e)
        {
            svSearch.IsPaneOpen = !svSearch.IsPaneOpen;
        }

        private void btnOrderByCreated_Click(object sender, RoutedEventArgs e)
        {


        }

        private void btnOrderByName_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
