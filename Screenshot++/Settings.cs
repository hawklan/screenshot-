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
            public SupportedFormats InternalFormat;
            public string Extension;
            public int DefaultQuality;
            public bool Quality;
            public EncoderParameters Parameters;

            public override string ToString()
            {
                return Description;
            }
        }

        public static string SavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Screenshot++");
        public static string SavePrefix = "Screenshot++";
        public static int SavePNGQuality = 100;
        public static int SaveJPGQuality = 75;
        public static List<ImageFormat> ImageFormats = new List<ImageFormat>();
        public static ImageFormat SelectedImageFormat;

        public const string Author = "Jason Hutton";

        public static string AppSavePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Screenshot++");
        public const string SettingsFile = "settings.cfg";

        public enum SupportedFormats
        {
            NONE = 0,
            JPG,
            PNG
        };

        public static string SaveImageFormat = SupportedFormats.PNG.ToString();

        private static ImageFormat BuildFormat(SupportedFormats desiredFormat, bool quality = false, int defaultQuality = -1)
        {
            ImageFormat format = new ImageFormat();
            format.Quality = quality;
            format.DefaultQuality = defaultQuality;

            switch (desiredFormat)
            {
                case SupportedFormats.JPG:
                    format.InternalFormat = SupportedFormats.JPG;
                    format.Description = "JPG";
                    format.Format = System.Drawing.Imaging.ImageFormat.Jpeg;
                    format.Extension = ".jpg";        
                    EncoderParameters encParams = new EncoderParameters(1);
                    encParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)format.DefaultQuality);
                    format.Parameters = encParams;
                    break;
                case SupportedFormats.PNG:
                    format.InternalFormat = SupportedFormats.PNG;
                    format.Description = "PNG";
                    format.Format = System.Drawing.Imaging.ImageFormat.Png;
                    format.Extension = ".png";
                    format.Parameters = null;
                    break;
                case SupportedFormats.NONE:
                default:
                    break;
            }

            return format;
        }

        public static void Init()
        {
            Settings.ImageFormats.Add(BuildFormat(SupportedFormats.JPG, 75));
            Settings.ImageFormats.Add(BuildFormat(SupportedFormats.PNG, -1));

            if (!LoadSettings())
            {
                SaveSettings();
            }

            foreach (ImageFormat format in ImageFormats)
            {
                if (format.InternalFormat.ToString().Equals(SaveImageFormat))
                {
                    SelectedImageFormat = format;
                    break;
                }
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
                            case "QUALITY":
                                {
                                    if(str.Length < 3)
                                        break;

                                    SupportedFormats checkFormat;
                                    if(!Enum.TryParse(str[1].ToUpper(), out checkFormat))
                                    {
                                        break; // Fails to parse.
                                    }

                                    double quality;
                                    if(!double.TryParse(str[2], out quality))
                                    {
                                        break; // Fails to parse.
                                    }

                                    switch(checkFormat)
                                    {
                                        case SupportedFormats.PNG:
                                            break;
                                        case SupportedFormats.JPG:
                                            break;
                                        case SupportedFormats.NONE:
                                        default:
                                            break;
                                    }
                                }
                                break;
                            case "PNGQUALITY":
                                {
                                    string str2 = "";
                                    for (int i = 1; i < str.Length; i++)
                                    {
                                        str2 += str[i] += " ";
                                    }
                                    str2 = str2.Trim();
                                    int result;
                                    if (!int.TryParse(str2, out result))
                                    {
                                        result = 0;
                                    }
                                    SavePNGQuality = result;
                                }
                                break;
                            case "JPGQUALITY":
                                {
                                    string str2 = "";
                                    for (int i = 1; i < str.Length; i++)
                                    {
                                        str2 += str[i] += " ";
                                    }
                                    str2 = str2.Trim();
                                    int result;
                                    if (!int.TryParse(str2, out result))
                                    {
                                        result = 0;
                                    }
                                    SaveJPGQuality = result;
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
                if (!Directory.Exists(AppSavePath))
                    Directory.CreateDirectory(AppSavePath);

                if (Directory.Exists(AppSavePath))
                {
                    try
                    {
                        tw = new StreamWriter(Path.Combine(AppSavePath, SettingsFile));
                        tw.WriteLine(string.Format("{0} {1}", "SavePath", SavePath));
                        tw.WriteLine(string.Format("{0} {1}", "SavePrefix", SavePrefix));
                        tw.WriteLine(string.Format("{0} {1}", "PNGQuality", SavePNGQuality));
                        tw.WriteLine(string.Format("{0} {1}", "JPGQuality", SaveJPGQuality));
                        tw.Close();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // Do nothing...
                    }
                }
            }
            
        }
    }
}
