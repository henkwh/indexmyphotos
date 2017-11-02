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

        public static int YEAR_STD = 1777, YEAR_ERR = 1776;
        public static string Message = "";
        public static List<Image> delete = new List<Image>();

        private static string KEYWORD_LOC = "location:";
        private static string KEYWORD_DATE = "date:";

        public static List<Image> sort2(string input, List<Image> imagelist) {
            if (input.Equals("")) {
                return imagelist;
            }

            List<Image> ret = new List<Image>();
            string[] inputs = input.ToLower().Replace(" ", "").Split(',');

            List<string> add = new List<string>();// inputs.ToList();
            List<string> subst = new List<string>();
            List<string> location = new List<string>();

            for (int i = 0; i < add.Count; i++) {
                bool minus = false;
                if (add[i].Length > 1 && add[i].ElementAt(0) == '-') {
                    subst.Add(add[i].Substring(1));
                    add[i] = add[i].Substring(1);
                } else if (add[i].Contains("location:") && i < add.Count - 1) {
                    string orttemp = add[i].Substring(4) + ", " + add[i + 1];
                    location.Add(orttemp);
                    add.RemoveAt(i + 1);
                    add.RemoveAt(i);
                    minus = true;
                    if (i >= add.Count) {
                        break;
                    }
                }
                if (add[i].Length == 0 || add[i].Equals("")) {
                    add.RemoveAt(i);
                    minus = true;
                }
                //Debug.WriteLine("Gesucht: " + add[i] + " Gültig: " + !minus + " subtrahiert: " + subst.Contains(add[i].Substring(1)));
                if (minus == true) {
                    i--;
                    if (i < 0) {
                        break;
                    }
                }
            }
            if (add.Count == 0 && location.Count == 0) {
                ret = imagelist;
            }

            foreach (Image i in imagelist) {
                string tags = i.getTags().ToLower();
                bool disable = false;
                foreach (string s in add) {
                    if (tags.Contains("#" + s + "#")) {
                        if (!ret.Contains(i)) {
                            ret.Add(i);
                        }
                        if (subst.Contains(s)) {
                            disable = true;
                        }
                    }
                }
                foreach (string l in location) {
                    if (i.getLocation().Equals(l)) {
                        ret.Add(i);
                    }
                }

                if (disable == true) {
                    ret.Remove(i);
                }
            }
            return ret;
        }



        public static List<Image> sort(string input, List<Image> imagelist) {
            if (input.Equals("")) {
                return imagelist;
            }

            List<Image> ret = new List<Image>();
            string[] inputs = input.ToLower().Replace(" ", "").Split(',');
            List<string> add = new List<string>();// inputs.ToList();
            List<string> subst = new List<string>();
            List<string> location = new List<string>();
            List<string> date = new List<string>();

            for (int i = 0; i < inputs.Count(); i++) {
                string s = inputs[i];
                if (s.StartsWith(KEYWORD_LOC) && i + 1 < inputs.Count()) {
                    string joinedloc = s.Substring(KEYWORD_LOC.Count()) + ", " + inputs[i + 1];
                    location.Add(joinedloc);
                    i++;
                } else if (s.StartsWith(KEYWORD_DATE)) {
                    string tmpdate = s.Substring(KEYWORD_DATE.Count());
                    date.Add(tmpdate);
                } else if (s.StartsWith("-")) {
                    subst.Add(s.Substring(1));
                } else if (!s.Equals("")) {
                    add.Add(s);
                }
            }

            if (add.Count == 0 && location.Count == 0 && date.Count == 0) {
                ret = imagelist;
            }

            foreach (Image i in imagelist) {
                string tags = i.getTags().ToLower();

                bool canceliteration = false;
                foreach (string s in subst) {
                    if (tags.Contains("#" + s + "#")) {
                        canceliteration = true;
                        break;
                    }
                }
                if (canceliteration) {
                    continue;
                }


                foreach (string s in add) {
                    if (tags.Contains("#" + s + "#")) {
                        if (!ret.Contains(i)) {
                            ret.Add(i);
                        }
                    }
                }
                foreach (string l in location) {
                    if (i.getLocation().Equals(l)) {
                        Debug.WriteLine("LOC COMP: " + i.getLocation() + "  " + l);
                        ret.Add(i);
                    }
                }
                foreach (string d in date) {
                    if (i.getDate().Equals(d)) {
                        Debug.WriteLine("DATE COMP: " + i.getDate() + "  " + d);
                        ret.Add(i);
                    }
                }
            }
            return ret;
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

        public static UpdateParemeters checkInputTags(Image i, string location, string tags, string description, DateTime dt) {//Jahr, Monat, Tag
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
                    up.setTags(JoinTags(tags, i.getTags()));
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (tags != null && !tags.Equals("")) {
                up.setTags(tags);
                if (tags.Equals("#")) {
                    up.setTags("");
                }
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

            if (dt.Year != YEAR_STD && i.getDate().Year != YEAR_STD && dt != i.getDate()) {
                TagAlert.uotnotification sol = showTagAlert(i, true, "Replace " + i.getDate().Day + "." + i.getDate().Month + "." + i.getDate().Year + "\r\nwith\r\n" + dt.Day + "." + dt.Month + "." + dt.Year + "?");
                if (sol == TagAlert.uotnotification.OVERWRITE) {
                    up.setDateTime(dt);
                } else if (sol == TagAlert.uotnotification.ABORT) {
                    return null;
                }
            } else if (dt.Year != YEAR_STD) {
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

        public static DateTime DateTimeIn(string[] datetime) {
            int[] conv = new int[3];
            if (datetime[0].Equals("") || datetime[0].Equals(" ")) {
                return new DateTime(YEAR_STD, 1, 1);
            }
            if (!datetime[0].Equals("") && datetime[1].Equals("") && datetime[2].Equals("")) {
                try {
                    conv[0] = Convert.ToInt32(datetime[0]);
                    conv[1] = 1;
                    conv[2] = 1;
                } catch {
                    return new DateTime(YEAR_ERR, 1, 1);
                }
            } else {


                try {
                    conv[0] = Convert.ToInt32(datetime[0]);
                    conv[1] = Convert.ToInt32(datetime[1]);
                    conv[2] = Convert.ToInt32(datetime[2]);
                } catch {
                    return new DateTime(YEAR_ERR, 1, 1);
                }
            }
            return new DateTime(conv[0], conv[1], conv[2]);
        }

        public static string JoinTags(string uno1, string duo2) {
            string[] uno = uno1.Split('#');
            string[] duo = duo2.Split('#');
            string ret = "#";
            foreach (string u in uno) {
                if (!u.Equals("")) {
                    ret += u + "#";
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
                    ret += d + "#";
                }
            }
            return ret;
        }


        public static string TagsIn(string s) {
            if (s.Equals("")) {
                return null;
            }
            s = ("#" + s.Replace(" ", "").Replace("\r\n", "").Replace(",", "#") + "#").Replace("##", "#");
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
