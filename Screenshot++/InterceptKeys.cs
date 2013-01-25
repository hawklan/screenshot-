using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Screenshot__
{
    class InterceptKeys
    {
        private LowLevelKeyboardProc m_proc; // Just keeps a reference alive so the garbage collector doesn't kill it while unmanaged code is at work.
        private Func<int, IntPtr, IntPtr, bool> Callback;
        private IntPtr _hookID = IntPtr.Zero;

        public InterceptKeys(Func<int, IntPtr, IntPtr, bool> callback/*LowLevelKeyboardProc callback*/)
        {
            Callback = callback;
            this._hookID = SetHook(HookCallback);
        }

        ~InterceptKeys()
        {
            UnhookWindowsHookEx(this._hookID);
            m_proc = null;
        }

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            {
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    m_proc = proc;
                    return SetWindowsHookEx(WindowHooks.WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private /*static*/ IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            Callback(nCode, wParam, lParam);

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
