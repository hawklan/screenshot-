using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;

namespace Screenshot__
{
    class Settings
    {
        public struct ImageFormat
        {
            public string Description;
            public System.Drawing.Imaging.ImageFormat Format;
            public string Extension;
            public EncoderParameters Parameters;
        }

        public static string SavePath = "./";
        public static string FilePrefix = "Screenshot++";
        public static List<ImageFormat> ImageFormats = new List<ImageFormat>();
        public static ImageFormat SelectedImageFormat;

        public static void Init()
        {
            ImageFormat jpg75;
            jpg75.Description = "JPG";
            jpg75.Format = System.Drawing.Imaging.ImageFormat.Jpeg;
            jpg75.Extension = ".jpg";
            EncoderParameters encParamsjpg75 = new EncoderParameters(1);
            encParamsjpg75.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)75);
            jpg75.Parameters = encParamsjpg75;
            Settings.ImageFormats.Add(jpg75);

            ImageFormat png;
            png.Description = "PNG";
            png.Format = System.Drawing.Imaging.ImageFormat.Png;
            png.Extension = ".png";
            EncoderParameters encParamspng = null;
            png.Parameters = encParamspng;
            Settings.ImageFormats.Add(png);

            foreach (ImageFormat format in ImageFormats)
            {
                if (format.Format.Equals(System.Drawing.Imaging.ImageFormat.Png))
                {
                    SelectedImageFormat = format;
                    break;
                }
            }
            if (SelectedImageFormat.Extension.Length == 0)
            {
                if (ImageFormats.Count > 0)
                {
                    SelectedImageFormat = ImageFormats[0];
                }
            }
        }
    }
}
