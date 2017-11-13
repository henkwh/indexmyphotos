using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {
    class SearchQuery {

        private string SQLCommand;

        public SearchQuery(string q, string sorting) {
            SQLCommand += parseQuery(q);
            if (SQLCommand.Equals("")) {
                SQLCommand += "/";
            }
            SQLCommand += sorting;
        }

        private string parseQuery(string q) {
            if (q.Equals("")) {
                return "";
            }
            List<string> contains = new List<string>();
            contains.AddRange(q.ToLower().Split(' '));
            string s = "";
            for (int i = 0; i < contains.Count(); i++) {
                string keyword = contains[i];
                keyword =
                keyword.Replace(Utils.KEYWORD_LOCATION_DEFAULT, "0,0").
                Replace(Utils.KEYWORD_DATE_DEFAULT, Utils.YEAR_STD);

                bool not = false;
                if (keyword.Count() >= 1 && keyword[0].Equals('-')) {
                    not = true;
                    keyword = keyword.Substring(1);
                }
                if (keyword.StartsWith(Utils.KEYWORD_LOC)) {
                    keyword = keyword.Substring(Utils.KEYWORD_LOC.Count());
                    string[] split = keyword.Split(',');
                    if (split.Count() == 2) {
                        s += " f.loclat " + negate(not, "!") + "= '" + split[0] + "'";
                        s += " AND";
                        s += " f.loclng " + negate(not, "!") + "= '" + split[1] + "'";
                    } else {
                        System.Windows.Forms.MessageBox.Show("Syntax error - Location");
                    }
                } else if (keyword.StartsWith(Utils.KEYWORD_DATE)) {
                    keyword = keyword.Substring(Utils.KEYWORD_DATE.Count());
                    string connective = "";
                    if (keyword[0].Equals('>') || keyword[0].Equals('<')) {
                        connective += (negate(not, "!") + keyword[0].ToString());
                        keyword = keyword.Substring(1);
                    }
                    if (keyword[0].Equals('=')) {
                        connective += negate(not, "!") + keyword[0].ToString();
                        keyword = keyword.Substring(1);
                    }
                    s += " f.date " + connective + "'" + keyword + "'";
                } else if (not == true) {
                    s += " f.id NOT IN(SELECT DISTINCT f.id FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE t.tag LIKE '" + keyword + "')";
                } else {
                    s += " EXISTS (SELECT DISTINCT fo.id FROM Foto fo LEFT JOIN FotoTag ft ON fo.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE f.id = fo.id AND t.tag LIKE '" + keyword + "')";
                }
                i++;
                if (i < contains.Count) {
                    if (!contains[i].Equals("or") && !contains[i].Equals("and")) {
                        System.Windows.Forms.MessageBox.Show("Syntax error - Expected 'AND' or 'OR' instead of '" + contains[i] + "'");
                        return " f.id IS NULL";
                    } else if (i == contains.Count() - 1) {
                        System.Windows.Forms.MessageBox.Show("Syntax error - Paramater after '" + contains[i] + "' expected");
                        return " f.id IS NULL";
                    }
                    s += " " + contains[i];
                }
            }
            return s;
        }

        private static string negate(bool yesno, string text) {
            if (yesno) {
                return text;
            } else {
                return "";
            }
        }

        public string getQuery() {
            return SQLCommand;
        }

        public bool isEmpty() {
            return SQLCommand.Equals("");
        }
    }

}
