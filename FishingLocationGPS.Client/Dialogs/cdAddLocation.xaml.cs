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
    public sealed partial class cdAddLocation : ContentDialog
    {
        private DataIO dataIO = new DataIO();

        public cdAddLocation()
        {
            this.InitializeComponent();
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
            this.Hide();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (WaterDepth.Text == String.Empty) WaterDepth.Text = "0";
                var location = PageHelper.GetObject<Models.DbModels.PersonalGPSLocation>(Grid_AddLocation);
                var isValid = await PageHelper.ValidateObject(location);
                location = dataIO.ValidateGPSCoordinates(location);
                if (isValid)
                {
                    location.CreatedDate = DateTime.Now;
                    using (var dbContext = new DbAppContext())
                    {
                        dbContext.PersonalGPSLocations.Add(location);
                        dbContext.SaveChanges();
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
