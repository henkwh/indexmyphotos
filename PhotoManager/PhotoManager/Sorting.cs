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
    static class Sorting {

        //Default date
        public const string YEAR_STD = "17770101";

        //Identify extended commands in search
        public const string KEYWORD_LOC = "location:";
        public const string KEYWORD_DATE = "date:";

        //Defines the images that are added to the panel at once
        public const int WORKER_FILL_INTERVAL = 20;
        //Defines the time the worker waits during the evoke processs
        public const int WORKER_SLEEP_TIME = 50;

        //Defines the min/max/default scale of the preview images
        public const int SCALE_MIN = 50;
        public const int SCALE_MAX = 200;
        public const int SCALE_DEF = 100;
        //Defines the ticks tha size can be changed
        public const int SCALE_TICKS = 5;

        /*
         * Creates Hash value from file
         */
        public static string getHash(string filepath) {
            FileStream fop = File.OpenRead(filepath);
            return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));

        }

        private static TagAlert ta;
        public static bool JoinForAll = false, DisposeForAll = false;
        private static TagAlert.uotnotification isChosenJoin, isChosenDispose;

        public static UpdateParemeters checkInputTags(Image i, string location, string tags, string description, string dt) {//
            UpdateParemeters up = new UpdateParemeters();
            if (!location.Equals(i.getLocation())) {
                TagAlert.uotnotification sol = showTagAlert(i, true, "Replace " + i.getLocation() + "\r\nwith\r\n" + location + "?");
                if (sol == TagAlert.uotnotification.OVERWRITE) {
                    up.setLocation(location);
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (!location.Equals("")) {
                up.setLocation(location);
                if (location.Equals(" ")) {
                    up.setLocation("");
                }
            }
            tags = tags.ToLower();
            if (tags != null && !i.getTags().Equals("") && !tags.Equals(i.getTags())) {
                TagAlert.uotnotification sol = showTagAlert(i, false, "Replace " + i.getTags() + "\r\nwith\r\n" + tags + "?");
                if (sol == TagAlert.uotnotification.OVERWRITE) {
                    up.setTags(tags);
                } else if (sol == TagAlert.uotnotification.JOIN) {
                    up.setTags(tags +","+ i.getTags());
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (tags != null) {
                up.setTags(tags);
            }
            if (!i.getDescription().Equals("") && !description.Equals(i.getDescription())) {
                TagAlert.uotnotification sol = showTagAlert(i, false, "Replace " + i.getDescription() + "\r\nwith\r\n" + description + "?");
                if (sol == TagAlert.uotnotification.OVERWRITE) {
                    up.setDescription(description);
                } else if (sol == TagAlert.uotnotification.JOIN) {
                    up.setDescription(description + " " + i.getDescription());
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (!description.Equals("")) {
                up.setDescription(description);
                if (description.Equals(" ")) {
                    up.setDescription("");
                }
            }

            if (i.getDate() != YEAR_STD && dt != i.getDate()) {
                TagAlert.uotnotification sol = showTagAlert(i, true, "Replace " + i.getDate() + "\r\nwith\r\n" + dt + "?");
                if (sol == TagAlert.uotnotification.OVERWRITE) {
                    up.setDateTime(dt);
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (dt != YEAR_STD) {
                up.setDateTime(dt);
            }
            return up;
        }

        private static TagAlert.uotnotification showTagAlert(Image i, bool dispose, string message) {
            if (JoinForAll && dispose == false) {
                return isChosenJoin;
            }
            if (DisposeForAll && dispose == true) {
                return isChosenDispose;
            }

            ta = new TagAlert(i.getPreview(), message, dispose);
            ta.ShowDialog();
            if (ta.DialogResult == DialogResult.OK) {
                TagAlert.uotnotification input = ta.ReturnValue;
                if (input == TagAlert.uotnotification.JOINALL) {
                    JoinForAll = true;
                    isChosenJoin = TagAlert.uotnotification.JOIN;
                    Debug.WriteLine(input.ToString());
                    return TagAlert.uotnotification.JOIN;
                } else if (input == TagAlert.uotnotification.DISPOSEALL) {
                    DisposeForAll = true;
                    Debug.WriteLine(input.ToString());
                    isChosenDispose = TagAlert.uotnotification.DISPOSE;
                    return TagAlert.uotnotification.DISPOSE;
                } else if (input == TagAlert.uotnotification.OVERWRITEALL) {
                    JoinForAll = true;
                    DisposeForAll = true;
                    Debug.WriteLine(input.ToString());
                    isChosenJoin = TagAlert.uotnotification.OVERWRITE;
                    isChosenDispose = TagAlert.uotnotification.OVERWRITE;
                    return TagAlert.uotnotification.OVERWRITE;
                }

                return input;
            }
            return TagAlert.uotnotification.ABORT;
        }

        /*
         * Checks weather Textfield tags is empty or not
         */
        public static string TagsIn(string s) {
            if (s.Equals("")) {
                return "";
            }
            s = (s.Replace(" ", "").Replace("\r\n", ""));
            return s;
        }

        /*
     * Checks weather Textfield location is empty or not
     */
        public static string LocationIn(string s) {
            if (s.Length > 19) {
                if (s.Contains(",") && s.Contains(".")) {
                    return s;
                }
            }
            return "";
        }

        /*
     * Converts location string into string that can be read by GMap
     */
        public static string parseLocation(string location) {
            string temp = location.Replace(",", ";").Replace(" ", "");
            temp = temp.Replace(".", ",");
            return temp;
        }



        /*
         * Creates text showing in tooltip 
         */
        public static string getToolTipTextForImage(Image i) {
            string s = i.getName() + i.getFileType() + "\n";
            s += "Location: " + i.getLocation() + "\n";
            s += "Date: " + i.getDate() + "\n";
            s += "tags: " + i.getTags() + "\n";
            s += "Description: " + i.getDescription();
            return s;
        }
    }
}
