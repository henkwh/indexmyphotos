using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {
    class SearchQuery {

        private string SQLCommand;

        public SearchQuery(string q) {
            SQLCommand = parseQuery(q);
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
                if (keyword.StartsWith(Sorting.KEYWORD_LOC) && i + 1 < contains.Count()) {
                    keyword = keyword.Substring(Sorting.KEYWORD_LOC.Count());
                    i++;
                    s += " f.location LIKE '" + keyword + " " + contains[i] + "'";
                } else if (keyword.StartsWith(Sorting.KEYWORD_DATE)) {
                    keyword = keyword.Substring(Sorting.KEYWORD_DATE.Count());
                    string restriction = "=";
                    string tempkey = "";
                    if (keyword[0].Equals('>') || keyword[0].Equals('<')) {
                        restriction = keyword[0] + restriction;
                        tempkey = keyword.Substring(1, keyword.Count() - 1);
                    }
                    s += " f.date " + restriction + "'" + tempkey + "'";
                } else if (keyword.StartsWith("-")) {
                    s += " f.id NOT IN(SELECT DISTINCT f.id FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE t.tag LIKE '" + keyword.Substring(1) + "')";
                } else {
                    //s += " t.tag LIKE '" + keyword + "'";
                    s += " EXISTS (SELECT DISTINCT fo.id FROM Foto fo LEFT JOIN FotoTag ft ON fo.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE f.id = fo.id AND t.tag LIKE '" + keyword + "')";
                }
                i++;
                if (i < contains.Count) {
                    if (!contains[i].Equals("or") && !contains[i].Equals("and")) {
                        System.Windows.Forms.MessageBox.Show("Syntax error - Expected 'AND' or 'OR' instead of '" + contains[i] + "'");
                        return " f.id IS NULL";
                    }
                    s += " " + contains[i];
                }
            }
            return s;
        }

        public string getQuery() {
            return SQLCommand;
        }

        public bool isEmpty() {
            return SQLCommand.Equals("");
        }
    }

}
