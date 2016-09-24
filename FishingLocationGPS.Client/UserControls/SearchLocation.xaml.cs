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
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FishingLocationGPS.UserControls
{
    public sealed partial class SearchLocation : UserControl
    {
        private List<Models.DbModels.FishingLocation> FishingLocations { get; set; }
        
        public SearchLocation()
        {
            this.InitializeComponent();
            this.LoadListData();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text != String.Empty)
            {
                using (var dbContext = new DbAppContext())
                {
                    FishingLocations = dbContext.Locations
                        .Where(item => item.Name.Contains(txtName.Text))
                        .OrderBy(item => item.LocationId).ToList();
                }

                lvLocations.ItemsSource = FishingLocations;
            }
            
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName.Text = String.Empty;
            this.LoadListData();
        }

        private void LoadListData()
        {
            using (var dbContext = new DbAppContext())
            {
                FishingLocations = dbContext.Locations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item => item.LocationId).ToList();
            }

            lvLocations.ItemsSource = FishingLocations;
        }
    }
}
