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
using System.Resources;
using Windows.Globalization;
using System.Text.RegularExpressions;
using Windows.Devices.Power;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUI3NavigationExample.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SingUpStartPage : Page
    {
        private string _phoneNumber = "";
        private int _pnPrev = 0;
        public SingUpStartPage()
        {
            this.InitializeComponent();
        }

        private void EmailBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PhoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string inputText = textBox.Text;
            if (inputText.Length < _phoneNumber.Length) 
            { 
                _phoneNumber = inputText;
                return;
            }

            // Очищаем от всех символов, кроме цифр
            string cleanText = Regex.Replace(inputText, @"[^\d]", "");

            // Формируем строку согласно маске
            string formattedText = FormatPhoneNumber(cleanText);

            // Обновляем текст в TextBox
            textBox.Text = formattedText;

            // Устанавливаем курсор в конец текста
            textBox.SelectionStart = formattedText.Length;
            _phoneNumber = formattedText;

        }
        private string FormatPhoneNumber(string digits)
        {
            string formattedNumber = "";

            // Применяем маску к введенным цифрам
            int index = 0;
            foreach (char c in "+X(XXX)XXX-XX-XX")
            {
                if (c == 'X')
                {
                    if (index < digits.Length)
                    {
                        formattedNumber += digits[index];
                        index++;
                    }
                    else
                    {
                        // Если цифры закончились, выходим из цикла
                        break;
                    }
                }
                else
                {
                    // Добавляем символы формата, если они не являются цифрами
                    if (!char.IsDigit(c))
                    {
                        formattedNumber += c;
                    }
                }
            }

            return formattedNumber;
        }

        private void SurnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PatronymicBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EmailBox_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
