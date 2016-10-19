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
        private List<Models.DbModels.FishingLocation> FishingLocations { get; set; }

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
                    FishingLocations = dbContext.Locations
                        .Where(item => item.Name.Contains(txtName.Text))
                        .OrderBy(item => item.LocationId).ToList();
                }

                grdLocations.ItemsSource = FishingLocations;
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
                FishingLocations = dbContext.Locations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item => item.LocationId).ToList();
            }

            grdLocations.ItemsSource = FishingLocations;
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.cdAddLocation();
            await dialog.ShowAsync();
            LoadListData();
        }

        private async void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Models.DbModels.FishingLocation)grdLocations.SelectedItem;
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
            var selectedItem = (Models.DbModels.FishingLocation)grdLocations.SelectedItem;
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
    }
}
