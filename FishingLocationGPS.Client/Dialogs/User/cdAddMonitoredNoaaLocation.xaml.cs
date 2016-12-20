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

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FishingLocationGPS.Dialogs
{
    public sealed partial class cdAddMonitoredNoaaLocation : ContentDialog
    {
        private Models.NOAALocation NoaaLocation;
        private DataIO dataIO = new DataIO();

        public cdAddMonitoredNoaaLocation(Models.NOAALocation noaaLocation)
        {
            this.InitializeComponent();
            NoaaLocation = noaaLocation;
            this.LoadData();
        }

        private void LoadData()
        {
            txtName.Text = NoaaLocation.Name;
            txtLocationID.Text = NoaaLocation.LocationId.ToString();
            txtLatitude.Text = NoaaLocation.Latitude.ToString();
            txtLongitude.Text = NoaaLocation.Longitude.ToString();
            txtType.Text = NoaaLocation.Type;
        }

        private void ClearFields()
        {
            txtName.Text = String.Empty;
            txtLocationID.Text = String.Empty;
            txtLatitude.Text = String.Empty;
            txtLongitude.Text = String.Empty;
            txtType.Text = String.Empty;
            chkIsDefault.IsChecked = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var monitoredNoaaLocation = new Models.MonitoredNOAALocation()
                {
                    Name = txtName.Text,
                    Type = txtType.Text,
                    Latitude = Decimal.Parse(txtLatitude.Text),
                    Longitude = Decimal.Parse(txtLongitude.Text),
                    StationID = int.Parse(txtLocationID.Text),
                    IsDefault = (bool)chkIsDefault.IsChecked,
                };

                var isAdded = await dataIO.AddMonitoredNoaaStation(monitoredNoaaLocation);
                if (isAdded == true)
                {
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
