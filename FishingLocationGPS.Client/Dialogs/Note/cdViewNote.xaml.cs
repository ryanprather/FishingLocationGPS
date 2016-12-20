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
    public sealed partial class cdViewNote : ContentDialog
    {
        private DataIO dataIO = new DataIO();
        private Models.PersonalGPSLocationNote Note;

        public cdViewNote(Models.PersonalGPSLocationNote note)
        {
            this.InitializeComponent();
            Note = note;
            this.LoadLocation();
        }

        private void LoadLocation()
        {
            this.Title = Note.Title;
            txtLocation.Text = dataIO.GetLocations().First(item=>item.PersonalGPSLocationID == Note.PersonalGPSLocationID).Name;
            txtFishingDate.Text = Note.FishingDate.ToString();
            txtDescription.Text = Note.Description.ToString();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
