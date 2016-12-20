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
    public sealed partial class cdViewLocation : ContentDialog
    {
        private Models.PersonalGPSLocation Location;

        public cdViewLocation(Models.PersonalGPSLocation location)
        {
            this.InitializeComponent();
            Location = location;
            this.LoadLocation();
        }

        private void LoadLocation()
        {
            this.Title = Location.Name;
            txtLatitude.Text = Location.Latitude.ToString();
            txtLongitude.Text = Location.Longitude.ToString();
            txtWaterDepth.Text = Location.WaterDepth.ToString();
            Description.Text = Location.Description.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
