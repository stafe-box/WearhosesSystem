using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3NavigationExample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            this.InitializeComponent();
        }

        public void PutMoneyBtnClick(object sender, RoutedEventArgs e)
        {

        }
        public void GetMoneyBtnClick(object sender, RoutedEventArgs e) 
        {
            
        }

        public void AddWearhouseBtnClick(object sender, RoutedEventArgs e)
        {

        }

        public void LogInBtnClick(object sender, RoutedEventArgs e)
        {

        }

        public void SignUpBtnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Views.SingUpStartPage), null);
        }

        public void LogOutBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
