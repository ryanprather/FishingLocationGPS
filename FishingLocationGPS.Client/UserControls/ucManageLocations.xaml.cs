﻿using FishingLocationGPS.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

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
            var dialog = new ContentDialog()
            {
                Title = "Add Location",
                Content = new AddLocation(),
            };

            await dialog.ShowAsync();




            if (popAdd.IsOpen) { popAdd.IsOpen = false; }
            else { popAdd.IsOpen = true; }
        }
    }
}
