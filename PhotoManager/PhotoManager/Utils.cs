using PhotoManager.CustomControls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoManager {
    static class Utils {

        //Default date
        public const string YEAR_STD = "10000000";

        //Identify extended commands in search
        public const string KEYWORD_LOC = "location:";
        public const string KEYWORD_DATE = "date";


        /*
         * Creates Hash value from file
         */
        public static string getHash(string filepath) {
            FileStream fop = File.OpenRead(filepath);
            return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));

        }

        /*
         * Add selection possibilities for sorting, background color, and selection color
         */
        public static void addSelectionObects(ComboBox combobox_sorting, ComboBox combobox_MapPovider, ComboBox comboBox_bgColor, ComboBox comboBox_selectionColor) {
            combobox_sorting.Items.Add(new OrderElement("Date ascending", " ORDER BY f.date ASC"));
            combobox_sorting.Items.Add(new OrderElement("Date descending", " ORDER BY f.date DESC"));
            combobox_sorting.Items.Add(new OrderElement("Location N to S", " ORDER BY f.loclat DESC"));
            combobox_sorting.Items.Add(new OrderElement("Location S to N", " ORDER BY f.loclat ASC"));
            combobox_sorting.Items.Add(new OrderElement("Location W to E", " ORDER BY f.loclng ASC"));
            combobox_sorting.Items.Add(new OrderElement("Location E to W", " ORDER BY f.loclng DESC"));
            combobox_sorting.Items.Add(new OrderElement("Filetype", " ORDER BY f.filetype ASC"));
            combobox_sorting.SelectedIndex = 1;

            combobox_MapPovider.Items.Add(new OrderElement("Google Maps", GMap.NET.MapProviders.GoogleMapProvider.Instance));
            combobox_MapPovider.Items.Add(new OrderElement("Open Cycle Maps", GMap.NET.MapProviders.OpenCycleMapProvider.Instance));
            combobox_MapPovider.Items.Add(new OrderElement("Open Cycle Landscape Map", GMap.NET.MapProviders.OpenCycleLandscapeMapProvider.Instance));
            combobox_MapPovider.Items.Add(new OrderElement("Bing Maps", GMap.NET.MapProviders.BingMapProvider.Instance));
            combobox_MapPovider.Items.Add(new OrderElement("Open Street Maps", GMap.NET.MapProviders.OpenStreet4UMapProvider.Instance));
            combobox_MapPovider.Items.Add(new OrderElement("ArcGIS Physical Map", GMap.NET.MapProviders.ArcGIS_World_Physical_MapProvider.Instance));
            combobox_MapPovider.Items.Add(new OrderElement("ArcGIS Topologic Map", GMap.NET.MapProviders.ArcGIS_World_Topo_MapProvider.Instance));
            combobox_MapPovider.SelectedIndex = 0;
            foreach (OrderElement oe in combobox_MapPovider.Items) {
                if (oe.ToString().Equals(Properties.Settings.Default.MAPPROVIDER)) {
                    combobox_MapPovider.SelectedItem = oe;
                    break;
                }
            }

            comboBox_bgColor.Items.Add(new ColorSetting("Light yellow", Color.PapayaWhip));
            comboBox_bgColor.Items.Add(new ColorSetting("Light blue", Color.LightSteelBlue));
            comboBox_bgColor.Items.Add(new ColorSetting("Light Red", Color.LightCoral));
            comboBox_bgColor.Items.Add(new ColorSetting("Light Green", Color.DarkSeaGreen));
            comboBox_bgColor.Items.Add(new ColorSetting("Red", Color.Red));
            comboBox_bgColor.Items.Add(new ColorSetting("White", Color.White));
            comboBox_bgColor.Items.Add(new ColorSetting("Black", Color.Black));
            comboBox_selectionColor.Items.AddRange(comboBox_bgColor.Items.Cast<ColorSetting>().ToArray());
            foreach (ColorSetting cs in comboBox_bgColor.Items) {
                if (cs.Color == Properties.Settings.Default.BGCOLOR) {
                    comboBox_bgColor.SelectedIndex = comboBox_bgColor.Items.IndexOf(cs);
                }
                if (cs.Color == Properties.Settings.Default.SELCOLOR) {
                    ImageGenerator.selectionColor = cs.Color;
                    comboBox_selectionColor.SelectedIndex = comboBox_selectionColor.Items.IndexOf(cs);
                }
            }
        }

        /*
         * Parses the location string to fill into the database
         */
        public static double[] parseLocation(string location) {
            if (location.Equals("")) {
                return new double[] { 0, 0 };
            }
            string[] locsplit = location.Replace(" ", "").Split(',');
            double[] loclatlng = new double[2];
            bool parsed = false;
            if (locsplit.Count() == 2) {
                try {
                    loclatlng[0] = double.Parse(locsplit[0].Replace(".", ","));
                    loclatlng[1] = double.Parse(locsplit[1].Replace(".", ","));
                    parsed = true;
                } catch { }
            }
            return (parsed == true) ? loclatlng : null;
        }

        /*
         * Creates text showing in tooltip 
         */
        public static string getToolTipTextForImage(Image i) {
            string location = i.getLocationString();
            string s = i.getName() + i.getFileType() + "\n";
            s += "Location: " + location.Replace("0,0", "") + "\n";
            if (i.getDate().Equals(YEAR_STD)) {
                s += "Date:\n";
            } else {
                s += "Date: " + i.getDate().Substring(6, 2) + "." + i.getDate().Substring(4, 2) + "." + i.getDate().Substring(0, 4) + "\n";
            }
            s += "tags: " + i.getTags() + "\n";
            s += "Description: " + i.getDescription();
            return s;
        }

        /*
         * Replaces , and . to match with Google Maps Styled Latitude/Longitude
         */
        public static string getWorkingLocation(double[] l) {
            return l[0].ToString().Replace(",", ".") + "," + l[1].ToString().Replace(",", ".");
        }

        public static string getSQLLocation(double lat, double lng) {
            return lat.ToString().Replace(".", ",") + "," + lng.ToString().Replace(".", ",");
        }

        /*
      * Deletes files that are accidently not listed in Database
      */
        public static int deleteImagesNotInDB(string cwd, string dir_full, string dir_preview, List<Image> list, CustomControls.MessageBoxInfo mbinfo) {
            int counter = 0;
            string[] folderfiles = Directory.GetFiles(cwd + dir_full);
            foreach (string s in folderfiles) {
                string t = Path.GetFileNameWithoutExtension(s);
                bool delete = true;
                foreach (Image i in list) {
                    if (i.getName().Equals(t)) {
                        delete = false;
                    }
                }
                if (delete) {
                    try {
                        mbinfo.addText("Delete: " + dir_full + t);
                        File.Delete(s);
                        counter++;
                    } catch {
                        mbinfo.addText("      Error deleting: " + dir_full + t);
                    }
                }
            }
            string[] folderfiles2 = Directory.GetFiles(cwd + dir_preview);
            foreach (string s in folderfiles2) {
                string t = Path.GetFileNameWithoutExtension(s);
                bool delete = true;
                foreach (Image i in list) {
                    if (i.getName().Equals(t)) {
                        delete = false;
                    }
                }
                if (delete) {
                    try {
                        mbinfo.addText("Delete: " + dir_preview + t);
                        File.Delete(s);
                        counter++;
                    } catch {
                        mbinfo.addText("      Error deleting: " + dir_preview + t);
                    }
                }
            }
            mbinfo.addText("Deleted: " + counter + " files!");
            return counter;
        }

        /*
         * Checks if directories exist
         */
        public static void createDirectories(string currentworkingdirectory, string dir_full, string dir_preview) {
            if (!System.IO.Directory.Exists(currentworkingdirectory + dir_full)) {
                System.IO.Directory.CreateDirectory(currentworkingdirectory + dir_full);
            }
            if (!System.IO.Directory.Exists(currentworkingdirectory + dir_preview)) {
                System.IO.Directory.CreateDirectory(currentworkingdirectory + dir_preview);
            }
        }

        /*
         * Parses the input date set in tag edit page
         */
        public static string parseDate(string d, bool year) {
            if (d.Equals("")) {
                if (year == true) {
                    return YEAR_STD.Substring(0, 4);
                } else {
                    return "00";
                }
            } else {
                int n;
                bool isNumeric = int.TryParse(d, out n);
                if (!isNumeric) {
                    return "ERRORERROR";
                }
                int fill = year == true ? 4 : 2;
                while (d.Count() < fill) {
                    d = "0" + d;
                }
                return d;
            }
        }

        public static string getDateFromFile(string path) {
            DateTime dt = new DateTime(Math.Min(File.GetCreationTime(path).Ticks, Math.Min(File.GetLastWriteTime(path).Ticks, File.GetLastAccessTime(path).Ticks)));
            return dt.Year + Utils.parseDate(dt.Month + "", false) + Utils.parseDate(dt.Day + "", false);
        }

    }
}

