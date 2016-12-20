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
    public sealed partial class cdAddNote : ContentDialog
    {
        private DataIO dataIO = new DataIO();

        public cdAddNote()
        {
            this.InitializeComponent();
            this.LoadNotes();
        }

        private void LoadNotes()
        {

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cb_LocationID.SelectedItem == null) throw new Exception("Please select a location.");

                var location = (Models.PersonalGPSLocation)cb_LocationID.SelectedItem;
                var note = PageHelper.GetObject<Models.PersonalGPSLocationNote>(Grid_AddNote);
                note.PersonalGPSLocationID = location.PersonalGPSLocationID;
                var isAdded = await dataIO.AddNote(note);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void LocationID_Loaded(object sender, RoutedEventArgs e)
        {
            var locations = null as IEnumerable<Models.PersonalGPSLocation>;
            using (var dbContext = new DbAppContext())
            {
                locations = dbContext.PersonalGPSLocations
                    .Where(item => item.Name != String.Empty)
                    .OrderBy(item => item.PersonalGPSLocationID).ToList();
            }
            cb_LocationID.ItemsSource = locations;
            cb_LocationID.DisplayMemberPath = "Name";
        }

        private void ClearFields()
        {
            //Name.Text = String.Empty;
            //Longitude.Text = String.Empty;
            //Latitude.Text = String.Empty;
            //Description.Text = String.Empty;
            //WaterDepth.Text = String.Empty;
        }
    }
}
