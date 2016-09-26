using FishingLocationGPS.Client;
using FishingLocationGPS.Client.Helpers;
using Microsoft.EntityFrameworkCore;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FishingLocationGPS.UserControls
{
    public sealed partial class AddLocation : UserControl
    {
        private DataIO dataIO = new DataIO();

        public AddLocation()
        {
            this.InitializeComponent();
        }

        private async void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prWait.IsActive = true;
                var location = PageHelper.GetObject<Models.ViewModels.Location>(Grid_AddLocation);
                var isValid = await PageHelper.ValidateObject(location);
                if (isValid)
                {
                    var dbLocation = dataIO.ConvertViewModel(location);
                    using (var dbContext = new DbAppContext())
                    {
                        dbContext.Locations.Add(dbLocation);
                        dbContext.SaveChanges();
                    }

                    this.ClearFields();
                }
                prWait.IsActive = false;
            }
            catch (Exception ex)
            {
                var dailog = new MessageDialog(ex.Message);
                await dailog.ShowAsync();
            }
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
