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

        /*
         * Creates Hash value from file
         */
        public static string getHash(string filepath) {
            FileStream fop = File.OpenRead(filepath);
            return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));

        }

        public static UpdateParameter[] checkInputTags(Image i, string _location, string _tags, string _dbtags, string _description, string _datetime, TagAlert ta) {
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
                        /*TagAlert.uotnotification input;
                        if (ta.alreadyChosen(p == tags) == TagAlert.uotnotification.NONE) {
                            ta.showInfo(i.getPreview(), "Replace " + p.OldEntry + "\r\nwith\r\n" + p.NewEntry + " ? ", (p == tags));
                            input = ta.ReturnValue;
                        } else {
                            input = ta.alreadyChosen(p == tags);
                        }
                        //Debug.WriteLine(p.NewEntry + ":" + p.OldEntry + ":" + input);
                        */
                        TagAlert.uotnotification input = TagAlert.uotnotification.OVERWRITE;
                        switch (input) {
                            case TagAlert.uotnotification.KEEP_OLD:
                                p.setReturnValue(p.OldEntry);
                                break;
                            case TagAlert.uotnotification.JOIN:
                                p.setReturnValue(p.OldEntry + "," + p.NewEntry);
                                break;
                            case TagAlert.uotnotification.OVERWRITE:
                                p.setReturnValue(p.NewEntry);
                                break;
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
    }
}
