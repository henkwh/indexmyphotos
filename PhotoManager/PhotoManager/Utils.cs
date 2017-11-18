using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager {
    static class Utils {

        //Default date
        public const string YEAR_STD = "17770101";

        //Identify extended commands in search
        public const string KEYWORD_LOC = "location:";
        public const string KEYWORD_DATE = "date";
        public const string KEYWORD_DATE_DEFAULT = "ddef";
        public const string KEYWORD_LOCATION_DEFAULT = "ldef";

        //Defines the images that are added to the panel at once
        public const int WORKER_FILL_INTERVAL = 20;
        //Defines the time the worker waits during the evoke processs
        public const int WORKER_SLEEP_TIME = 50;

        public const int SCALE_MAP_DEF = 75;

        public const int GAP = 10;

        /*
         * Creates Hash value from file
         */
        public static string getHash(string filepath) {
            FileStream fop = File.OpenRead(filepath);
            return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));

        }

        public static UpdateParameter[] checkInputTags(Image i, string _location, string _tags, string _dbtags, string _description, string _datetime, TagAlert ta, bool joinTags) {
            UpdateParameter location = new UpdateParameter(_location, getWorkingLocation(new double[] { i.getLocation()[0], i.getLocation()[1] }));
            UpdateParameter tags = new UpdateParameter(_tags, _dbtags);
            UpdateParameter description = new UpdateParameter(_description, i.getDescription());
            UpdateParameter datetime = new UpdateParameter(_datetime.Equals(" ") ? YEAR_STD : _datetime, i.getDate());

            UpdateParameter[] list = { location, tags, description, datetime };
            foreach (UpdateParameter p in list) {
                if (p.requestedChange()) {
                    if (p.isOldEntryEmpty()) {
                        p.setReturnValue(p.NewEntry);
                    } else if (!p.isEqual()) {
                        if (p == tags && joinTags) {
                            p.setReturnValue(p.NewEntry + "," + p.OldEntry);
                        } else {
                            p.setReturnValue(p.NewEntry);
                        }
                    }
                }
            }

            return list;
        }

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
         * Checks weather Textfield tags is empty or not
         */
        public static string TagsIn(string s) {
            if (s.Equals("")) {
                return "";
            } else if (s.Equals(" ")) {
                return s;
            }
            s = (s.Replace(" ", "").Replace("\r\n", ""));
            return s;
        }

        /*
     * Checks weather Textfield location is empty or not
     */
        public static string LocationIn(string s) {
            if (s.Contains(",")) {
                return s.Replace(" ", "");
            }
            return "";
        }

        /*
         * Creates text showing in tooltip 
         */
        public static string getToolTipTextForImage(Image i) {
            string location = i.getLocationString();
            string s = i.getName() + i.getFileType() + "\n";
            s += "Location: " + location + "\n";
            s += "Date: " + i.getDate() + "\n";
            s += "tags: " + i.getTags() + "\n";
            s += "Description: " + i.getDescription();
            return s;
        }


        public static string getWorkingLocation(double[] l) {
            return l[0].ToString().Replace(",", ".") + "," + l[1].ToString().Replace(",", ".");
        }

        public static string getSQLLocation(double lat, double lng) {
            return lat.ToString().Replace(".", ",") + "," + lng.ToString().Replace(".", ",");
        }

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
    }
}
