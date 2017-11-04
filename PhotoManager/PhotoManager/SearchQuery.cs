using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {
    class SearchQuery {

        private List<string> contains;
        private List<string> doesnotcontain;

        private List<string> locations;

        private List<string> date;


        private bool empty;

        public SearchQuery(string q) {
            contains = new List<string>();
            doesnotcontain = new List<string>();
            locations = new List<string>();
            date = new List<String>();
            empty = true;
            parseQuery(q);
        }

        public void parseQuery(string q) {
            empty = (q.Replace(" ", "").Equals("")) ? true : false;
            string[] inputs = q.ToLower().Replace(" ", "").Split(',');
            for (int i = 0; i < inputs.Count(); i++) {
                string s = inputs[i];
                if (s.StartsWith(Sorting.KEYWORD_LOC) && i + 1 < inputs.Count()) {
                    string joinedloc = s.Substring(Sorting.KEYWORD_LOC.Count()) + ", " + inputs[i + 1];
                    locations.Add(joinedloc);
                    i++;
                } else if (s.StartsWith(Sorting.KEYWORD_DATE)) {
                    string temps = s.Substring(Sorting.KEYWORD_DATE.Count());
                    date.Add(temps);
                } else if (s.StartsWith("-")) {
                    doesnotcontain.Add(s.Substring(1));
                } else {
                    contains.Add(s);
                }
            }
        }



        public string getQuery() {
            if (isEmpty()) {
                return "";
            }
            string s = "";

            bool insertAND = false;
            int c = 0;
            foreach (string keyword in contains) {
                s += " t.tag LIKE '" + keyword + "'";
                if (c != contains.Count() - 1) {
                    s += " OR";
                }
                c++;
                insertAND = true;
            }
            c = 0;
            s += (insertAND && locations.Count > 0) ? " OR " : "";
            foreach (string keyword in locations) {
                s += " f.location LIKE '" + keyword + "'";
                if (c != locations.Count() - 1) {
                    s += " AND";
                }
                c++;
                insertAND = true;
            }

            c = 0;
            s += (insertAND && date.Count > 0) ? " OR " : "";
            foreach (string keyword in date) {
                if(keyword.Length < 1) {
                    continue;
                }
                string tempkey = keyword;
                string restriction = "=";
                if (keyword[0].Equals('>') || keyword[0].Equals('<')) {
                    restriction = keyword[0]+restriction;
                    tempkey = keyword.Substring(1, keyword.Count() - 1);
                }
                s += " f.date " + restriction + "'" + tempkey + "'";
                if (c != date.Count() - 1) {
                    s += " AND";
                }
                c++;
                insertAND = true;
            }

            c = 0;
            s += (insertAND && doesnotcontain.Count > 0) ? " AND " : "";
            foreach (string keyword in doesnotcontain) {
                s += " f.id NOT IN(SELECT DISTINCT f.id FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE";
                s += " t.tag LIKE '" + keyword + "'";
                if (c != doesnotcontain.Count() - 1) {
                    s += " AND";
                }
                c++;
                insertAND = true;
            }
            s += (doesnotcontain.Count > 0) ? ")" : "";

            return s;
        }

        public bool isEmpty() {
            return empty;
        }
    }

}
