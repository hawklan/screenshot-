using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;

namespace Screenshot__
{
    class Capture
    {
        public static bool Callback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WindowMessages.WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == Keys.PrintScreen) // 44
                {
                    //Rectangle rect = SystemInformation.VirtualScreen;
                    IntPtr hRegion = GetRegionWindow(true);
                    Rectangle rect = GetWindowRectangle(hRegion);
                    Bitmap bmp = CaptureRegion(hRegion, rect.Width, rect.Height);

                    EncoderParameters encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)75);
                    
                    if (!Directory.Exists(Settings.SavePath))
                        Directory.CreateDirectory(Settings.SavePath);

                    if (Directory.Exists(Settings.SavePath))
                    {
                        bmp.Save(GetNextFileName(AppendTimestamp(Settings.SavePrefix), Settings.SelectedImageFormat.Extension, Settings.SavePath), GetEncoder(Settings.SelectedImageFormat.Format), encParams);
                    }
                    bmp.Dispose();
                }
            }
            else if (nCode >= 0 && wParam == (IntPtr)WindowMessages.WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if ((Keys)vkCode == Keys.PrintScreen) // 44
                {
                    Rectangle rect = SystemInformation.VirtualScreen;
                    IntPtr hRegion = GetRegionWindow(false);
                    //Rectangle rect = GetWindowRectangle(hRegion);
                    Bitmap bmp = CaptureRegion(hRegion, rect.Width, rect.Height);

                    EncoderParameters encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)75);
                    
                    if (!Directory.Exists(Settings.SavePath))
                        Directory.CreateDirectory(Settings.SavePath);

                    if(Directory.Exists(Settings.SavePath))
                    {
                        bmp.Save(GetNextFileName(AppendTimestamp(Settings.SavePrefix), Settings.SelectedImageFormat.Extension, Settings.SavePath), GetEncoder(Settings.SelectedImageFormat.Format), encParams);
                    }
                    bmp.Dispose();
                }
            }
            
            return true;
        }

        public static string AppendTimestamp(string str)
        {
            DateTime date = DateTime.Now;
            return string.Format("{0} {1}-{2}-{3}_{4}h{5}m{6}s", str, date.Year.ToString("d4"), date.Month.ToString("d2"), date.Day.ToString("d2"), date.Hour, date.Minute, date.Second);
        }

        public static string GetNextFileName(string baseFilename, string extension, string path)
        {
            string combinedFilename = string.Format("{0}{1}", baseFilename, extension);
            string cPath = Path.Combine(path, combinedFilename);
            string pPath = cPath;

            for(int count = 2;File.Exists(pPath);count++) // Start at 2 for neatness' sake.
            {
                pPath = Path.Combine(path, string.Format("{0} ({1}){2}", Path.GetFileNameWithoutExtension(cPath), count, Path.GetExtension(cPath)));
            }
            return pPath;
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        public static IntPtr GetRegionWindow(bool bActiveOnly = false)
        {
            IntPtr hWnd = IntPtr.Zero;
            if (bActiveOnly)
                hWnd = GetForegroundWindow();
            if (hWnd == null || hWnd == IntPtr.Zero)
                hWnd = GetDesktopWindow();

            return hWnd;
        }

        public static Rectangle GetWindowRectangle(IntPtr hWnd)
        {
            RECT uRect;
            GetWindowRect(hWnd, out uRect);
            int error = Marshal.GetLastWin32Error();
            Rectangle rect = new Rectangle(uRect.Left, uRect.Top, uRect.Right - uRect.Left, uRect.Bottom - uRect.Top);
            return rect;
        }

        public static Bitmap CaptureRegion(IntPtr hWnd, int w, int h, int x = 0, int y = 0)
        {
            IntPtr hSourceDC = GetWindowDC(hWnd);
            IntPtr hDestinationDC = CreateCompatibleDC(hSourceDC);
            IntPtr hBitmap = CreateCompatibleBitmap(hSourceDC, w, h);
            IntPtr hOldBitmap = SelectObject(hDestinationDC, hBitmap);
            BitBlt(hDestinationDC, 0, 0, w, h, hSourceDC, x, y, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
            Bitmap bmp = Bitmap.FromHbitmap(hBitmap);
            SelectObject(hDestinationDC, hOldBitmap);
            DeleteObject(hBitmap);
            ReleaseDC(hWnd, hSourceDC);

            return bmp;
        }

        [DllImport("gdi32.dll")]
        static extern bool BitBlt(IntPtr hdcDest, int xDest, int yDest, int wDest, int hDest, IntPtr hdcSource, int xSrc, int ySrc, CopyPixelOperation rop);
        [DllImport("user32.dll")]
        static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteDC(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr DeleteObject(IntPtr hDc);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr ptr);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}
