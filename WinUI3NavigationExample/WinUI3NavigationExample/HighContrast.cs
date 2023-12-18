using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinUI3NavigationExample
{
    public static class HighContrast
    {
        const int SPI_SETHIGHCONTRAST = 0x0043;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDCHANGE = 0x02;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct HIGHCONTRAST
        {
            public int cbSize;
            public int dwFlags;
            public string lpszDefaultScheme;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(int uiAction, int uiParam, ref HIGHCONTRAST pvParam, int fWinIni);

        public static void Enable()
        {
            // Включение режима высокой контрастности
            EnableHighContrast();

        }
        public static void Disable()
        {

            // Отключение режима высокой контрастности
            DisableHighContrast();
        }

        static void EnableHighContrast()
        {
            HIGHCONTRAST hc = new HIGHCONTRAST
            {
                cbSize = Marshal.SizeOf(typeof(HIGHCONTRAST)),
                dwFlags = 1,  // Включение режима
                lpszDefaultScheme = null
            };

            SystemParametersInfo(SPI_SETHIGHCONTRAST, 0, ref hc, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        static void DisableHighContrast()
        {
            HIGHCONTRAST hc = new HIGHCONTRAST
            {
                cbSize = Marshal.SizeOf(typeof(HIGHCONTRAST)),
                dwFlags = 0,  // Отключение режима
                lpszDefaultScheme = null
            };

            SystemParametersInfo(SPI_SETHIGHCONTRAST, 0, ref hc, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
    }
}
