﻿using FishingLocationGPS.Client.DataIO.Context;
using FishingLocationGPS.Helpers;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class AddLocation : UserControl
    {
        private DataIO.DataIO dataIO = new DataIO.DataIO();

        public AddLocation()
        {
            this.InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var location = PageHelper.GetObject<Models.ViewModels.Location>(Grid_AddLocation);
                var dbLocation = dataIO.ConvertViewModel(location);
                using (var dbContext = new DbAppContext())
                {
                    dbContext.Locations.Add(dbLocation);
                    dbContext.SaveChanges();
                }
                // Clear all fields //
            }
            catch (Exception ex)
            {

            }
             
        }
    }
}
