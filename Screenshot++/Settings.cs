using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.IO;

namespace Screenshot__
{
    class Settings
    {
        public class ImageFormat
        {
            public string Description;
            public System.Drawing.Imaging.ImageFormat Format;
            public string Extension;
            public EncoderParameters Parameters;

            public override string ToString()
            {
                return Description;
            }
        }

        public static string SavePath = Environment.CurrentDirectory;
        public static string SavePrefix = "Screenshot++";
        public static List<ImageFormat> ImageFormats = new List<ImageFormat>();
        public static ImageFormat SelectedImageFormat;

        public const string Author = "Jason Hutton";

        public const string AppSavePath = "./";
        public const string SettingsFile = "settings.cfg";

        public static void Init()
        {
            ImageFormat jpg75 = new ImageFormat();
            jpg75.Description = "JPG";
            jpg75.Format = System.Drawing.Imaging.ImageFormat.Jpeg;
            jpg75.Extension = ".jpg";
            EncoderParameters encParamsjpg75 = new EncoderParameters(1);
            encParamsjpg75.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)75);
            jpg75.Parameters = encParamsjpg75;
            Settings.ImageFormats.Add(jpg75);

            ImageFormat png = new ImageFormat();
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

            if (!LoadSettings())
            {
                SaveSettings();
            }
        }

        public static bool LoadSettings()
        {
            TextReader tr;
            try
            {
                tr = new StreamReader(Path.Combine(AppSavePath, SettingsFile));
                string line = null;
                while ((line = tr.ReadLine()) != null)
                {
                    string[] str = line.Split(null);
                    if (str.Length > 1)
                    {
                        switch (str[0].ToUpper())
                        {
                            case "//":
                            case "#":
                                break;
                            case "SAVEPATH":
                                {
                                    string str2 = "";
                                    for (int i = 1; i < str.Length; i++)
                                    {
                                        str2 += str[i] += " ";
                                    }
                                    str2 = str2.Trim();
                                    if(str2.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1)
                                    {
                                        SavePath = str2;
                                    }
                                }
                                break;
                            case "SAVEPREFIX":
                                {
                                    string str2 = "";
                                    for (int i = 1; i < str.Length; i++)
                                    {
                                        str2 += str[i] += " ";
                                    }
                                    str2 = str2.Trim();
                                    if (str2.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) == -1)
                                    {
                                        SavePrefix = str2;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                tr.Close();
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            return true;
        }

        public static void SaveSettings()
        {
            TextWriter tw;
            //try
            {
                tw = new StreamWriter(Path.Combine(AppSavePath, SettingsFile));
                tw.WriteLine(string.Format("{0} {1}", "SavePath", SavePath));
                tw.WriteLine(string.Format("{0} {1}", "SavePrefix", SavePrefix));
                tw.Close();
            }
            
        }
    }
}
