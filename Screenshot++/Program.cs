using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Screenshot__
{
    // http://blogs.msdn.com/b/toub/archive/2006/05/03/589423.aspx

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InterceptKeys keyHook = new InterceptKeys(Capture.Callback);
            Application.Run(new NotifyApplicationContext());
        }
    }
}
