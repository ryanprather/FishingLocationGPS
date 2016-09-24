using FishingLocationGPS.Client.DataIO.Context;
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
using FishingLocationGPS.Client.Models.DbModels;
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FishingLocationGPS.UserControls
{
    public sealed partial class SearchLocation : UserControl
    {
        private List<FishingLocation> FishingLocations { get; set; }
        
        public SearchLocation()
        {
            this.InitializeComponent();
            using (var dbContext = new DbAppContext())
            {
                FishingLocations = dbContext.Locations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item=>item.LocationId).ToList();
            }
        }

    }
}
