using Windows.Graphics.Display;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Threading.Tasks;
using Windows.Globalization.Fonts;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3NavigationExample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public static string defaultFontFamalySource = "";
        private bool _isScaled = false;
        private bool _isContrast = false;
        private bool _isFonted = false;
        public SettingsPage()
        {
            this.InitializeComponent();
            
        }


        private async void GoToHighContrast_Click(object sender, RoutedEventArgs e)
        {
            if (_isContrast)
            {
                HighContrast.Disable();
                _isContrast = false;
            }
            else
            {
                HighContrast.Enable();
                _isContrast = true;
            }
            //bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:easeofaccess-highcontrast"));
        }

        private async void GoToScale_Click(object sender, RoutedEventArgs e)
        {
            if (_isScaled)
            {
                Scaler.SetDefault();
                _isScaled = false;
            }
            else
            {
                Scaler.SetBig();
                _isScaled = true;
            }
            //bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:display-advanced "));
        }

        private async void GoToFontScale_Click(object sender, RoutedEventArgs e)
        {
            if (defaultFontFamalySource == "")
            {
                defaultFontFamalySource = FontFamily.Source;
            }

            if (_isFonted)
            {
                var ff = new FontFamily("arial");

            }
            else
            {
                var ff = new FontFamily("Times New Roman");

                var rootFrame = Window.Current.Content as Frame;

                if (rootFrame != null)
                {
                    rootFrame.FontFamily = ff;
                }
                
            }



            //bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:easeofaccess-display"));
        }
    }
}
