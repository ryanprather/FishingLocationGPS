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
        private Models.DbModels.FishingLocation FishingLocation;

        public cdEditLocation( Models.DbModels.FishingLocation location)
        {
            this.InitializeComponent();
            FishingLocation = location;
            this.LoadData();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.ClearFields();
            this.Hide();
        }

        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            try
            {
                var location = PageHelper.GetObject<Models.ViewModels.Location>(Grid_AddLocation);
                var isValid = await PageHelper.ValidateObject(location);
                if (isValid)
                {
                    var dbLocation = dataIO.ConvertViewModel(location);
                    dbLocation.LocationId = FishingLocation.LocationId;
                    using (var dbContext = new DbAppContext())
                    {
                        //dbContext.Locations.
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

        private void LoadData()
        {
            Name.Text = this.FishingLocation.Name;
            Longitude.Text = this.FishingLocation.Longitude.ToString();
            Latitude.Text = this.FishingLocation.Latitude.ToString();
            Notes.Text = this.FishingLocation.Notes;
        }

        private void ClearFields()
        {
            Name.Text = String.Empty;
            Longitude.Text = String.Empty;
            Latitude.Text = String.Empty;
            Notes.Text = String.Empty;
        }
    }
}
