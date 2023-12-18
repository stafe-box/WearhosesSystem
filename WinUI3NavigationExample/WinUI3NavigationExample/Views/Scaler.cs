using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Windows.Graphics.Display;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace WinUI3NavigationExample.Views
{
    public class Scaler
    {
        public static int screenWidth;
        public static int screenHeight;
        public enum DMDO
        {
            DEFAULT = 0,
            D90 = 1,
            D180 = 2,
            D270 = 3
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct DEVMODE
        {
            public const int DM_PELSWIDTH = 0x80000;
            public const int DM_PELSHEIGHT = 0x100000;
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;

            public int dmPositionX;
            public int dmPositionY;
            public DMDO dmDisplayOrientation;
            public int dmDisplayFixedOutput;

            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);

        static string[] GetMonitorNamesFromRegistry()
        {
            try
            {
                string registryPath = @"Control Panel\Desktop\PerMonitorSettings";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath))
                {
                    if (key != null)
                    {
                        // Получаем имена всех подключенных мониторов
                        return key.GetSubKeyNames();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred while accessing the registry: " + e.Message);
            }

            return new string[0];
        }

        static void getResolution()
        {
            Window.Current.Activate();
            CoreDispatcher dispatcher = CoreApplication.MainView.CoreWindow.Dispatcher;

            // Выполнение кода в контексте потока пользовательского интерфейса
            dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                DisplayInformation displayInformation = DisplayInformation.GetForCurrentView();

                // Получение разрешения экрана
                screenWidth = (int)((int)Window.Current.Bounds.Width * displayInformation.RawPixelsPerViewPixel);
                screenHeight = (int)((int)Window.Current.Bounds.Height * displayInformation.RawPixelsPerViewPixel);
            }).AsTask().Wait();
        }

        void ChangeDPI(int dpi)
        {
            //getResolution();
            var monitorNames = GetMonitorNamesFromRegistry();

            if (monitorNames.Any())
            {
                foreach (var monitorName in monitorNames)
                {
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel", true);

                    key = key.OpenSubKey("Desktop", true);
                    key = key.OpenSubKey("PerMonitorSettings", true);
                    Console.WriteLine(monitorName);
                    key = key.OpenSubKey(monitorName, true); // my second monitor here

                    key.SetValue("DpiValue", dpi);
                    

                    SetResolution(800, 600); // this sets the resolution on primary screen
                    SetResolution(1920, 1200); // returning back to my primary screens default resolution
                }
            }
            else
            {
                Console.WriteLine("No monitors found in the registry.");
            }
        }


        private static void SetResolution(int w, int h)
        {
            long RetVal = 0;

            DEVMODE dm = new DEVMODE();

            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));

            dm.dmPelsWidth = w;
            dm.dmPelsHeight = h;

            dm.dmFields = DEVMODE.DM_PELSWIDTH | DEVMODE.DM_PELSHEIGHT;


            RetVal = ChangeDisplaySettings(ref dm, 0);
        }


        public static void SetBig()
        {
            var pr = new Scaler();
            pr.ChangeDPI(2); // 100%
        }

        public static void SetDefault()
        {
            var pr = new Scaler();
            pr.ChangeDPI(0);
        }
    }
}
