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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FishingLocationGPS
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //private UserControls.ViewLocation ucViewLocation;
        private UserControls.ucMapLocations ucMapLocations;
        private UserControls.ucManageLocations ucManageLocations;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private async void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var clickedPanel = (StackPanel)sender;
            var name = clickedPanel.Name.ToUpper();
            var controls = control_display.Children;
            foreach (var control in controls)
            {
                control_display.Children.Remove(control);
            }

            
            try
            {
                prLoading.IsActive = true;
                prLoading.Visibility = Visibility.Visible;

                 await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () => 
                {
                    
                    switch (name)
                    {
                        case "MANAGE":
                            ucManageLocations = new UserControls.ucManageLocations();
                            control_display.Children.Add(ucManageLocations);
                            break;

                        case "VIEW":
                            ucMapLocations = new UserControls.ucMapLocations();
                            control_display.Children.Add(ucMapLocations);
                            break;
                    }
                    await Task.Delay(3000);
                }); 
                //await SetUserControl(name);

                ////switch (name)
                ////{
                ////    case "MANAGE":
                ////        ucManageLocations = new UserControls.ucManageLocations();
                ////        control_display.Children.Add(ucManageLocations);
                ////        break;

                ////    case "VIEW":
                ////        ucMapLocations = new UserControls.ucMapLocations();
                ////        control_display.Children.Add(ucMapLocations);
                ////        break;
                ////}
            }
            finally
            {
                prLoading.IsActive = false;
                prLoading.Visibility = Visibility.Collapsed;
            }

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        //private 

        //private async Task SetUserControl(string name)
        //{
        //    prLoading.IsActive = true;
        //    prLoading.Visibility = Visibility.Visible;
        //    switch (name)
        //    {
        //        case "MANAGE":
        //            ucManageLocations = new UserControls.ucManageLocations();
        //            control_display.Children.Add(ucManageLocations);
        //            break;

        //        case "VIEW":
        //            ucMapLocations = new UserControls.ucMapLocations();
        //            control_display.Children.Add(ucMapLocations);
        //            break;
        //    }
        //}
    }
}
