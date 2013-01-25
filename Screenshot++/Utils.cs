using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Screenshot__
{
    class Utils
    {
        public static Bitmap GetBitmap(Icon icon)
        {
            Bitmap bmp = new Bitmap(icon.Width, icon.Height);
            Graphics gxMem = Graphics.FromImage(bmp);
            gxMem.DrawIcon(icon, 0, 0);
            gxMem.Dispose();

            return bmp;
        }
    }
}
