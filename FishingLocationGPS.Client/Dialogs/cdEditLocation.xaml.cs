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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FishingLocationGPS.Dialogs
{
    public sealed partial class cdEditLocation : ContentDialog
    {
        private DataIO dataIO = new DataIO();
        private Models.DbModels.PersonalGPSLocation Location;

        public cdEditLocation(Models.DbModels.PersonalGPSLocation location)
        {
            this.InitializeComponent();
            Location = location;
            this.LoadData();
        }
        
        private void LoadData()
        {
            Name.Text = this.Location.Name;
            Longitude.Text = this.Location.Longitude.ToString();
            Latitude.Text = this.Location.Latitude.ToString();
            WaterDepth.Text = this.Location.WaterDepth.ToString();
            Notes.Text = this.Location.Notes;
        }

        private void ClearFields()
        {
            Name.Text = String.Empty;
            Longitude.Text = String.Empty;
            Latitude.Text = String.Empty;
            Notes.Text = String.Empty;
            WaterDepth.Text = String.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.ClearFields();
            this.Hide();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WaterDepth.Text == String.Empty) WaterDepth.Text = "0";
                var location = PageHelper.GetObject<Models.DbModels.PersonalGPSLocation>(Grid_EditLocation);
                var isValid = await PageHelper.ValidateObject(location);
                location = dataIO.ValidateGPSCoordinates(location);
                if (isValid)
                {
                    using (var dbContext = new DbAppContext())
                    {
                        var editItem = dbContext.PersonalGPSLocations.First(item => item.PersonalGPSLocationID == Location.PersonalGPSLocationID);
                        if (editItem != null)
                        {
                            editItem.Name = location.Name;
                            editItem.Latitude = location.Latitude;
                            editItem.Longitude = location.Longitude;
                            editItem.Notes = location.Notes;
                            editItem.WaterDepth = location.WaterDepth;
                            editItem.ModifiedDate = DateTime.Now;
                            dbContext.SaveChanges();
                        }
                    }
                    this.Hide();
                    this.ClearFields();
                }
            }
            catch (Exception ex)
            {
                var dailog = new MessageDialog(ex.Message);
                await dailog.ShowAsync();
            }
        }
    }
}
