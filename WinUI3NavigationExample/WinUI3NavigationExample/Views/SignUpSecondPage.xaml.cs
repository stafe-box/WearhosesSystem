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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3NavigationExample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpSecondPage : Page
    {
        public SignUpSecondPage()
        {
            this.InitializeComponent();
        }

        private void StatusCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //в документ комбо пихаем только документы соответсвующие статусу
            DocumentPanel.Visibility = Visibility.Visible;
        }

        private void DocumentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //подгружаем маску
            DocumentBox.IsEnabled = true;
        }

        private void DocumentBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
