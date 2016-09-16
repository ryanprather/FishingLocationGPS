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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FishingLocationGPS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private UserControls.AddLocation ucAddLocation;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        async private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var clickedPanel = (StackPanel)sender;
            var name = clickedPanel.Name.ToUpper();
            var dialog = new MessageDialog(name);
            await dialog.ShowAsync();
            var controls = control_display.Children;
            foreach (var control in controls)
            {
                control_display.Children.Remove(control);
            }
            switch (name)
            {
                case "ADD":
                    if (ucAddLocation == null) ucAddLocation = new UserControls.AddLocation();
                    control_display.Children.Add(ucAddLocation);
                    break;
            }
        }
    }
}
