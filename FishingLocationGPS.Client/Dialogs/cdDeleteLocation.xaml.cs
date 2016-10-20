using FishingLocationGPS.Client;
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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FishingLocationGPS.Dialogs
{
    public sealed partial class cdDeleteLocation : ContentDialog
    {

        private DataIO dataIO = new DataIO();
        private Models.DbModels.PersonalGPSLocation Location;

        public cdDeleteLocation(Models.DbModels.PersonalGPSLocation location)
        {
            this.InitializeComponent();
            Location = location;
            tbDeleteMessage.Text = "Are you sure you would like to Delete " + Location.Name + " ?";
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            tbDeleteMessage.Text = "";
            this.Hide();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            using (var dbContext = new DbAppContext())
            {
                var deleteItem = dbContext.PersonalGPSLocations.First(item => item.PersonalGPSLocationID == Location.PersonalGPSLocationID);
                if (deleteItem != null)
                {
                    dbContext.PersonalGPSLocations.Remove(deleteItem);
                    dbContext.SaveChanges();
                }
            }
        }

    }
}
