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
        private UserControls.ucDashBoard ucDashboard;
        private UserControls.ucManageNotes ucManageNotes;
        private UserControls.ucUserOptions ucUserOptions;

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
                        case "HOME":
                            ucDashboard = new UserControls.ucDashBoard();
                            control_display.Children.Add(ucDashboard);
                            break;

                        case "MANAGE_LOCATIONS":
                            ucManageLocations = new UserControls.ucManageLocations();
                            control_display.Children.Add(ucManageLocations);
                            break;

                        case "VIEW":
                            ucMapLocations = new UserControls.ucMapLocations();
                            control_display.Children.Add(ucMapLocations);
                            break;

                        case "MANAGE_NOTES":
                            ucManageNotes = new UserControls.ucManageNotes();
                            control_display.Children.Add(ucManageNotes);
                            break;

                        case "USER_OPTIONS":
                            ucUserOptions = new UserControls.ucUserOptions();
                            await ucUserOptions.LoadData();
                            control_display.Children.Add(ucUserOptions);
                            break;
                    }
                    await Task.Delay(3000);
                }); 
            }
            finally
            {
                prLoading.IsActive = false;
                prLoading.Visibility = Visibility.Collapsed;
            }
        }
        

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ucDashboard = new UserControls.ucDashBoard();
            control_display.Children.Add(ucDashboard);
        }
    }
}
