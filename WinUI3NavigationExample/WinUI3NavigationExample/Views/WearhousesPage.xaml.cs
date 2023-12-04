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
    public sealed partial class WearhousesPage : Page
    {
        public WearhousesPage()
        {
            this.InitializeComponent();
            WearhousesList.Items.Add(new Wearhouse() { ID = 1, Status = true, Area = 200.15f, Addres = "Улица Пушкиа, дом Колотушкина", Type = "Як Гараж", Price = 300 });
            WearhousesList.Items.Add(new Wearhouse() { ID = 2, Status = false, Area = 15.15f, Addres = "Где-где, в Караганде", Type = "Дырка в полу", Price = 100500 });
            WearhousesList.Items.Add(new Wearhouse() { ID = 3, Status = true, Area = 0.30f, Addres = "Вулиця М.Грушевського будинок 5, місто Київ, Україна", Type = "Ячейка", Price = 14.88f });
        }

        public void FreeOnlyBtnClick(object sender, RoutedEventArgs e)
        {

        }

        public void MinAreaBoxValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs e)
        {
            
        }

        public void MaxCostBoxValueChanged(NumberBox sender, NumberBoxValueChangedEventArgs e)
        {

        }


        private void WearhousesListItemClick(object sender, ItemClickEventArgs e)
        {

        }
        
        
        private void WearhouseTypeBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OnlyMineBtnClick(object sender, RoutedEventArgs e)
        {

        }
    }
    //Чисто для теста
    public class Wearhouse
    {
        public ulong ID;
        public bool Status;
        public float Area;
        public string Addres;
        public string Type;
        public float Price;

        public Wearhouse() { }
    }
}
