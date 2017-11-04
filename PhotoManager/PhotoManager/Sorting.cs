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

        public const string YEAR_STD = "17770101", YEAR_ERR = "1776";
        public static string Message = "";
        public static List<Image> delete = new List<Image>();

        //Identify extendsd commands in search
        public const string KEYWORD_LOC = "location:";
        public const string KEYWORD_DATE = "date:";

        public const int WORKER_FILL_INTERVAL = 10;
        public const int WORKER_SLEEP_TIME = 20;



          public static string getToolTipTextForImage(Image i) {
            string s = i.getName()+i.getFileType()+"\n";
            s += "Location: "+i.getLocation()+ "\n";
            s += "Date: "+i.getDate() +"\n";
            s += "tags: " + i.getTags() +"\n";
            s += "Description: " + i.getDescription();
            return s;
        }


        public static string getHash(string filepath) {
            FileStream fop = File.OpenRead(filepath);
            return BitConverter.ToString(System.Security.Cryptography.SHA1.Create().ComputeHash(fop));

        }

        public static void addMessage(string text, Image i) {
            Message += text + "\n";
            delete.Add(i);
        }

        public static void showMessageBox() {
            if (Message.Equals("")) {
                return;
            }

            //AlertBox a = new AlertBox("Error", Message);
            //a.show();
            //a.getDel().Click += DeleteEntrys;


            var dialogTypeName = "System.Windows.Forms.PropertyGridInternal.GridErrorDlg";
            var dialogType = typeof(Form).Assembly.GetType(dialogTypeName);

            // Create dialog instance.
            var dialog = (Form)Activator.CreateInstance(dialogType, new PropertyGrid());
            // Populate relevant properties on the dialog instance.
            dialog.Width = 300;
            dialog.Height = 100;
            dialog.Text = "Error";
            dialogType.GetProperty("Details").SetValue(dialog, Message, null);
            dialogType.GetProperty("Message").SetValue(dialog, "Error", null);

            // Display dialog.
            var result = dialog.ShowDialog();
            Message = "";
        }

        private static void DeleteEntrys(object sender, EventArgs e) {
            foreach (Image i in delete) {
                i.Image = null;
                i.Dispose();
                delete.Remove(i);
            }
        }


        private static TagAlert ta;
        public static bool JoinForAll = false, DisposeForAll = false;
        private static TagAlert.uotnotification isChosenJoin, isChosenDispose;

        public static UpdateParemeters checkInputTags(Image i, string location, string tags, string description, string dt) {//Jahr, Monat, Tag
            UpdateParemeters up = new UpdateParemeters();
            if (!location.Equals("") && !i.getLocation().Equals("") && !location.Equals(i.getLocation())) {
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
            bool ImagetagEmptyOrHash = i.getTags().Equals("") || i.getTags().Equals("#");
            if (tags != null && !tags.Equals("") && !ImagetagEmptyOrHash && !tags.Equals(i.getTags())) {
                TagAlert.uotnotification sol = showTagAlert(i, false, "Replace " + i.getTags() + "\r\nwith\r\n" + tags + "?");
                if (sol == TagAlert.uotnotification.OVERWRITE) {
                    up.setTags(tags);
                } else if (sol == TagAlert.uotnotification.JOIN) {
                    up.setTags(tags+i.getTags());
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (tags != null && !tags.Equals("")) {
                up.setTags(tags);
            }
            if (!description.Equals("") && !i.getDescription().Equals("") && !description.Equals(i.getDescription())) {
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

            if (dt != YEAR_STD && i.getDate() != YEAR_STD && dt != i.getDate()) {
                TagAlert.uotnotification sol = showTagAlert(i, true, "Replace " + i.getDate().Substring(6,2) + "." + i.getDate().Substring(4,2) + "." + i.getDate().Substring(0,4) + "\r\nwith\r\n" + dt.Substring(6, 2) + "." + dt.Substring(4, 2) + "." + dt.Substring(0, 4) + "?");
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

       
        public static string JoinTags(string uno1, string duo2) {
            string[] uno = uno1.Split(',');
            string[] duo = duo2.Split(',');
            string ret = "";
            foreach (string u in uno) {
                if (!u.Equals("")) {
                    ret += u + ",";
                }
            }
            foreach (string d in duo) {
                bool add = true;
                foreach (string u in uno) {
                    if (d.Equals("") || d.Equals(u)) {
                        add = false;
                        break;
                    }
                }
                if (add == true) {
                    ret += d + ",";
                }
            }
            return ret;
        }


        public static string TagsIn(string s) {
            if (s.Equals("")) {
                return "";
            }
            s = (s.Replace(" ", "").Replace("\r\n", ""));
            return s;
        }

        public static string LocationIn(string s) {
            if (s.Equals("") || s.Equals(" ")) {
                return "";
            }

            if (s.Length > 19) {
                if (s.Contains(",") && s.Contains(".")) {
                    return s;
                }
            }

            return YEAR_ERR.ToString();
        }

        public static string parseLocation(string location) {
            string temp = location.Replace(",", ";").Replace(" ", "");
            temp = temp.Replace(".", ",");
            return temp;
        }
    }
}
