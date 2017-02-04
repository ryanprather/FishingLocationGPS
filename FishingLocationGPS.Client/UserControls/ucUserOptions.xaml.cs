using FishingLocationGPS.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class ucUserOptions : UserControl
    {
        private DataIO dataIO = new DataIO();
        private IEnumerable<Models.NOAALocation> Stations;
        private IEnumerable<Models.MonitoredNOAALocation> MonitoredStations;
        public ucUserOptions()
        {
            this.InitializeComponent();
        }

        public async Task<bool> LoadData()
        {
            Stations = (Stations == null) ? await dataIO.GetNoaaActiveLocations() : Stations;
            lstNoaaLocations.ItemsSource = Stations;

            MonitoredStations = dataIO.GetMonitoredNoaaLocations();
            lstMonitoredNoaaLocations.ItemsSource = MonitoredStations;
            return true;
        }

        private void btnMonitoredStationDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void btnMonitoredStationAdd_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (Models.NOAALocation)lstNoaaLocations.SelectedItem;

            var alreadyMonitoring = (MonitoredStations != null) ? MonitoredStations.Any(item => item.MonitoredNOAALocationID.ToString() == selectedItem.LocationId) : false;
            if (selectedItem != null && !alreadyMonitoring)
            {
                var dialog = new Dialogs.cdAddMonitoredNoaaLocation(selectedItem);
                await dialog.ShowAsync();
                await this.LoadData();
            }
            else if (alreadyMonitoring)
            {
                var dailog = new MessageDialog("You are already monitoring this station.");
                await dailog.ShowAsync();
            }
            else
            {
                var dailog = new MessageDialog("Please select a Noaa Location to Add.");
                await dailog.ShowAsync();
            }
        }
    }
}
