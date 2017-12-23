using System.Collections.Generic;
using System.Linq;

namespace PhotoManager {
    class SearchQuery {

        /*
         * Parses the search string into a SQLite command
         */

        private string SQLCommand;

        public SearchQuery(string q, string sorting) {
            q = q.ToLower().Replace(" und ", " and ").Replace(" oder ", " or ").Replace(" not ", " -").Replace(" nicht ", " -").Replace("ort:", Utils.KEYWORD_LOC).Replace("datum:", Utils.KEYWORD_DATE).Replace("beschreibung:", Utils.KEYWORD_DESCRIPTION);
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
            contains.AddRange(q.Split(' '));
            string s = "";
            for (int i = 0; i < contains.Count(); i++) {
                string keyword = contains[i];
                keyword =
                keyword.Replace("-location:set", "location:0,0").
                Replace("location:set", "-location:0,0").
                Replace("-date=set", "date=" + Utils.YEAR_STD).
                Replace("date=set", "-date=" + Utils.YEAR_STD);
                bool not = false;
                if (keyword.Count() >= 1 && keyword[0].Equals('-')) {
                    not = true;
                    keyword = keyword.Substring(1);
                }
                if (keyword.StartsWith(Utils.KEYWORD_LOC)) {
                    keyword = keyword.Substring(Utils.KEYWORD_LOC.Count());
                    string[] split = keyword.Split(',');
                    if (split.Count() == 2) {
                        s += " f.loclat " + negate(not) + "= '" + split[0] + "'";
                        s += " AND";
                        s += " f.loclng " + negate(not) + "= '" + split[1] + "'";
                    } else {
                        System.Windows.Forms.MessageBox.Show("Syntax error - Location");
                    }
                } else if (keyword.StartsWith(Utils.KEYWORD_DATE)) {
                    keyword = keyword.Substring(Utils.KEYWORD_DATE.Count());
                    string connective = "";
                    if (keyword[0].Equals('>') || keyword[0].Equals('<')) {
                        connective += (negate(not) + keyword[0].ToString());
                        keyword = keyword.Substring(1);
                    }
                    if (keyword[0].Equals('=')) {
                        connective += negate(not) + keyword[0].ToString();
                        keyword = keyword.Substring(1);
                    }

                    string[] dottedformat = keyword.Split('.');
                    for (int indx = 0; indx < dottedformat.Count() - 1; indx++) { dottedformat[indx] = (dottedformat[indx].Count() == 1) ? "0" + dottedformat[indx] : dottedformat[indx]; }
                    if (dottedformat.Count() == 3) {
                        string temp = dottedformat[2] + dottedformat[1] + dottedformat[0];
                        keyword = temp;
                    } else if (dottedformat.Count() == 2) {
                        string temp = dottedformat[1] + dottedformat[0];
                        keyword = temp;
                    }

                    bool filled = false;
                    string keywordtemp = keyword;
                    while (keyword.Count() < 8) {
                        keyword += ((connective.Contains('>') && !connective.Contains("=")) || connective.Contains("<=")) ? "9" : "0";
                        filled = true;
                    }

                    if (filled && !connective.Contains('>') && !connective.Contains('<')) { //Date from X..X0..0 to X..X9..9
                        while (keywordtemp.Count() < 8) {
                            keywordtemp += "9";
                        }
                        s += " f.date >= '" + keyword + "' AND f.date <= '" + keywordtemp + "'";
                    } else {
                        s += " f.date " + connective + "'" + keyword + "'";
                    }

                } else if (keyword.StartsWith(Utils.KEYWORD_DESCRIPTION)) {
                    keyword = keyword.Substring(Utils.KEYWORD_DESCRIPTION.Count());
                    s += " f.description " + (not == true ? "NOT " : "") + "LIKE '%" + keyword + "%'";

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

        private static string negate(bool yesno) {
            if (yesno) {
                return "!";
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
