using FishingLocationGPS.Client;
using FishingLocationGPS.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FishingLocationGPS.UserControls
{
    public sealed partial class ucMapLocations : UserControl
    {
        private List<Models.PersonalGPSLocation> Locations { get; set; }

        public ucMapLocations()
        {
            this.InitializeComponent();
            this.InitPage();
        }

        private void InitPage()
        {
            mcViewLocations.MapServiceToken = ConfigHelper.MapKey;

            using (var dbContext = new DbAppContext())
            {
                Locations = dbContext.PersonalGPSLocations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item => item.PersonalGPSLocationID).ToList();
            }
            lvLocations.ItemsSource = Locations;
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            var iconList = mcViewLocations.MapElements.ToList();
            foreach (var icon in iconList)
            {
                mcViewLocations.MapElements.Remove(icon);
            }

            foreach (var item in lvLocations.SelectedItems)
            {
                var location = (Models.PersonalGPSLocation)item;
                BasicGeoposition snPosition = new BasicGeoposition() { Latitude = (double)location.Latitude, Longitude = (double)location.Longitude };
                Geopoint snPoint = new Geopoint(snPosition);

                // Create a MapIcon.
                MapIcon mapIcon1 = new MapIcon();
                mapIcon1.Location = snPoint;
                mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
                mapIcon1.Title = location.Name;
                mapIcon1.ZIndex = 0;

                // Add the MapIcon to the map.
                mcViewLocations.MapElements.Add(mapIcon1);
                mcViewLocations.Center = snPoint;
            }
            

            // Center the map over the POI.
            
            mcViewLocations.ZoomLevel = 10;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            var iconList = mcViewLocations.MapElements.ToList();
            foreach (var icon in iconList)
            {
                mcViewLocations.MapElements.Remove(icon);
            }

            lvLocations.SelectedItems.Clear();
        }
    }
}
