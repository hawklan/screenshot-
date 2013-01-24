using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Screenshot__
{
    class Capture
    {
        public static bool Callback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WindowMessages.WM_SYSKEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //if((Keys)vkCode == 44) // Printscreen
                if ((Keys)vkCode == Keys.PrintScreen)
                {
                    Console.WriteLine((Keys)vkCode);
                }
            }
            else if (nCode >= 0 && wParam == (IntPtr)WindowMessages.WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //if((Keys)vkCode == 44) // Printscreen
                if ((Keys)vkCode == Keys.PrintScreen)
                {
                    Console.WriteLine((Keys)vkCode);
                }
            }
            
            return true; // This gets discarded anyway.
        }
    }
}
