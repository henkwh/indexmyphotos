using PhotoManager.CustomControls;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoManager {
    class DBHandler {

        private string currentworkingdirectory;
        private string connection;

        private int entryCount;

        private SQLiteConnection con;

        private const string DBNAME = "Database.db3";


        public DBHandler(string workingdirectory) {
            currentworkingdirectory = workingdirectory;
            connection = "Data Source=" + DBNAME;
            con = new SQLiteConnection(connection);
            if (!File.Exists(workingdirectory + @"\" + DBNAME)) {
                SQLiteConnection.CreateFile(DBNAME);
            }
            open();
            createTable();
            SQLiteConnection.ClearAllPools();
            removeUnusedTags();
            entryCount = countEntrys();
            close();
        }

        public void open() {
            con.Open();
        }

        public void close() {
            con.Close();
        }

        /*
   * Creates required tables Foto, Tag, FotoTag
   */
        private void createTable() {
            try {
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE Foto(id VARCHAR(59) PRIMARY KEY, filetype VARCHAR(255),loclat DECIMAL(9,6),loclng DECIMAL(9,6),date INTEGER,description VARCHAR(255));", con)) {
                    command.ExecuteNonQuery();
                    Debug.WriteLine("Table created.");
                }
            } catch {
                Debug.WriteLine("Table Foto not created.");
            }

            try {
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE FotoTag(FotoID VARCHAR(59),TagID UNIQUEIDENTIFIER, PRIMARY KEY(FotoID, TagID));", con)) {
                    command.ExecuteNonQuery();
                    Debug.WriteLine("Table created.");
                }
            } catch {
                Debug.WriteLine("Table Tag not created.");
            }

            try {
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE Tag(id UNIQUEIDENTIFIER PRIMARY KEY,tag VARCHAR(255));", con)) {
                    command.ExecuteNonQuery();
                    Debug.WriteLine("Table created.");
                }
            } catch {
                Debug.WriteLine("Table Fototag not created.");
            }

            try {
                using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE Favs(search VARCHAR(255) PRIMARY KEY);", con)) {
                    command.ExecuteNonQuery();
                    Debug.WriteLine("Table created.");
                }
            } catch {
                Debug.WriteLine("Table Fototag not created.");
            }
        }

        /*
      * Adds a connection between image and tag
      */
        public void connectTag(string id, string[] tags, bool inserttag) {
            if (inserttag) {
                foreach (string t in tags) {
                    insertTag(t);
                }
            }
            List<string> addTag = new List<string>();
            string comstring = "";
            foreach (string t in tags) {
                if (!t.Equals(" ") && !t.Equals("")) {
                    if (addTag.Count() == 0) {
                        comstring += "INSERT OR IGNORE INTO FotoTag SELECT @id AS FotoID, t.id AS TagID FROM Tag t WHERE t.tag LIKE @tag0 ";
                    } else {
                        comstring += "UNION ALL SELECT @id, id FROM Tag WHERE tag LIKE @tag" + (addTag.Count()) + " ";
                    }
                    addTag.Add(t);
                }

            }
            //string comm = "INSERT INTO FotoTag(FotoID, TagID) SELECT f.id, t.id FROM Foto f, Tag t WHERE f.id LIKE @id AND t.tag LIKE @tag";
            try {
                using (SQLiteCommand command = new SQLiteCommand(comstring, con)) {
                    command.Parameters.AddWithValue("@id", id);
                    int i = 0;
                    foreach (string t in addTag) {
                        command.Parameters.AddWithValue("@tag" + (i++), t);
                        Debug.WriteLine("tag: " + t);
                    }
                    command.ExecuteNonQuery();
                    Debug.WriteLine(comstring + ";  " + id);
                }
            } catch {
                Debug.WriteLine("ERROR: " + comstring + ";  " + id);
            }
        }


        /*
         * Inserts a new entry
         */
        public Image addImage(string hash, string filetype) {
            Image f = null;
            try {
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Foto (id, filetype, loclat, loclng, date, description) VALUES(@id, @filetype, 0, 0, @stddate, '')", con)) {
                    command.Parameters.AddWithValue("@id", hash);
                    command.Parameters.AddWithValue("@filetype", filetype);
                    command.Parameters.AddWithValue("@stddate", Utils.YEAR_STD);
                    SQLiteDataReader reader = command.ExecuteReader();
                    f = new Image(hash.ToString(), filetype);
                }
                Debug.WriteLine("Added: " + hash);
            } catch {
                Debug.WriteLine("Error: addEntry()");
            }
            entryCount = countEntrys();
            return f;
        }

        public bool ImageExists(string hash) {
            bool ret = false;
            try {
                using (SQLiteCommand command = new SQLiteCommand("SELECT count(id) FROM Foto WHERE id LIKE @param;", con)) {
                    command.Parameters.AddWithValue("@param", hash);
                    long scalar = command.ExecuteScalar() == null ? 0 : (Int64)command.ExecuteScalar();
                    ret = (scalar > 0) ? true : false;
                }
            } catch {
                Debug.WriteLine("Error: Image exists");
            }
            return ret;
        }

        /*
         * Inserts a new tag in Tag DB
         */
        private void insertTag(string tag) {
            try {
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Tag(id ,tag) SELECT @id, @tag WHERE NOT EXISTS(SELECT * FROM Tag WHERE tag LIKE @tag)", con)) {
                    command.Parameters.AddWithValue("@id", genGUID());
                    command.Parameters.AddWithValue("@tag", tag);
                    command.ExecuteNonQuery();
                    Debug.WriteLine("Tag added: " + tag);
                }
            } catch {
                Debug.WriteLine("Table Foto not created.");
            }
        }

        /*
         * Updates a value in DB
         */
        public void updateEntry(string[] id, string type, string value) {

            string comstring = "UPDATE Foto SET " + type + "= @value WHERE id LIKE ";
            for (int i = 0; i < id.Count(); i++) {
                comstring += ("@id" + i + " OR id LIKE ");
            }
            comstring = comstring.Substring(0, comstring.Count() - 12) + ";";

            try {
                using (SQLiteCommand command = new SQLiteCommand(comstring, con)) {
                    command.Parameters.AddWithValue("@value", value);
                    Debug.WriteLine("value" + ": " + value);
                    int c = 0;
                    foreach (string s in id) {
                        command.Parameters.AddWithValue("@id" + (c++), s);
                    }
                    command.ExecuteNonQuery();
                }
            } catch {
                MessageBox.Show("ERROR:" + comstring);
            }
        }


        /*
         * returns entry matching the id
         */
        public Image getImage(string id) {
            Image ret = null;
            try {
                using (SQLiteCommand command = new SQLiteCommand("SELECT f.id, f.filetype, f.loclat, f.loclng, f.date, f.description FROM Foto f WHERE f.id = @value", con)) {
                    command.Parameters.AddWithValue("@value", id);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Image img = new Image(reader[0] as string, reader[1] as string);
                        double[] location = new double[] { (double)(reader.GetDecimal(2)), (double)reader.GetDecimal(3) };
                        string datetemp = reader.GetInt64(4).ToString();
                        int[] date = new int[] { Convert.ToInt32(datetemp.Substring(0, 4)), Convert.ToInt32(datetemp.Substring(4, 2)), Convert.ToInt32(datetemp.Substring(5, 2)) };
                        string description = reader[5] as string;
                        img.setTags(datetemp, location, description, "");
                        ret = img;
                    }
                }
            } catch {
            }
            return ret;
        }

        /*
         * Updates location
         */
        public void updateEntry(string[] id, double[] loc) {

            string comstring = "UPDATE Foto SET loclat= @value WHERE id LIKE ";
            for (int i = 0; i < id.Count(); i++) {
                comstring += ("@id" + i + " OR id LIKE ");
            }
            comstring = comstring.Substring(0, comstring.Count() - 12) + ";";
            try {
                using (SQLiteCommand command = new SQLiteCommand(comstring, con)) {
                    command.Parameters.AddWithValue("@value", loc[0]);
                    int c = 0;
                    foreach (string s in id) {
                        command.Parameters.AddWithValue("@id" + (c++), s);
                    }
                    command.ExecuteNonQuery();
                }
            } catch {
                MessageBox.Show("LAT:" + comstring);
            }


            comstring = "UPDATE Foto SET loclng= @value WHERE id LIKE ";
            for (int i = 0; i < id.Count(); i++) {
                comstring += ("@id" + i + " OR id LIKE ");
            }
            comstring = comstring.Substring(0, comstring.Count() - 12) + ";";

            try {
                using (SQLiteCommand command = new SQLiteCommand(comstring, con)) {
                    command.Parameters.AddWithValue("@value", loc[1]);
                    int c = 0;
                    foreach (string s in id) {
                        command.Parameters.AddWithValue("@id" + (c++), s);
                    }
                    command.ExecuteNonQuery();
                }
            } catch {
                MessageBox.Show("LNG:" + comstring);
            }
        }


        /*
         * Deletes an entry from table Foto
         */
        public void deleteEntry(string id) {
            removeTags(new string[] { id });
            SQLiteConnection.ClearAllPools();
            try {
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Foto WHERE id LIKE @id", con)) {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    Debug.WriteLine("Deleted: " + id);
                }
            } catch {
                MessageBox.Show("Error deleting Foto " + id);
            }
            entryCount = countEntrys();
        }

        /*
         * Removes every tag related to an image
         */
        public void removeTags(string[] id) {
            SQLiteConnection.ClearAllPools();
            try {

                string comstring = "DELETE FROM FotoTag WHERE FotoID = ";
                for (int i = 0; i < id.Count(); i++) {
                    comstring += ("@id" + i + " OR FotoID = ");
                }
                comstring = comstring.Substring(0, comstring.Count() - 13) + ";";

                using (SQLiteCommand command = new SQLiteCommand(comstring, con)) {
                    int c = 0;
                    foreach (string s in id) {
                        command.Parameters.AddWithValue("@id" + (c++), s);
                    }
                    command.ExecuteNonQuery();
                }
            } catch {
                MessageBox.Show("Error deleting " + id);
            }
        }

        /*
         * Removes tags from Table Tag that are not connected to any Entry in table Foto
         */
        public void removeUnusedTags() {
            try {

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Tag WHERE NOT EXISTS(SELECT * FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID WHERE ft.TagID LIKE Tag.id)", con)) {
                    command.ExecuteNonQuery();
                }
            } catch {
            }
        }

        /*
         * Loads images matching the SearchQuery
         */
        public List<Image> loadEntries(SearchQuery sq) {
            string comm = "SELECT DISTINCT f.id, f.filetype, f.loclat, f.loclng, f.date, f.description FROM Foto f";
            if (sq == null || sq.isEmpty()) {
                comm += ";";
            } else {
                comm += " LEFT JOIN FotoTag ft ON f.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE";

                string query = sq.getQuery();
                if (query.StartsWith("/")) {
                    comm = comm.Replace("WHERE", "");
                    query = query.Substring(1);
                }
                comm += query;
                comm += ";";
            }
            Debug.WriteLine("Anfrage: " + comm);
            List<Image> loadinglist = new List<Image>();
            try {
                using (SQLiteConnection con = new SQLiteConnection(connection)) {
                    con.Open();
                    using (SQLiteCommand command = new SQLiteCommand(comm, con)) {
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            Image img = new Image(reader[0] as string, reader[1] as string);
                            double[] location = new double[] { (double)(reader.GetDecimal(2)), (double)reader.GetDecimal(3) };
                            string datetemp = reader.GetInt64(4).ToString();
                            int uno = Convert.ToInt32(datetemp.Substring(0, 4));
                            int dou = Convert.ToInt32(datetemp.Substring(4, 2));
                            int tri = Convert.ToInt32(datetemp.Substring(6, 2));
                            int[] date = new int[] { Convert.ToInt32(datetemp.Substring(0,4)), Convert.ToInt32(datetemp.Substring(4, 2)),
                                Convert.ToInt32(datetemp.Substring(6, 2)) };
                            string description = reader[5] as string;
                            img.setTags(datetemp, location, description, "");
                            loadinglist.Add(img);
                        }
                    }
                }
            } catch {
                //   Debug.WriteLine("Error processing: " + comm);
            }
            return loadinglist;
        }

        /*
         * returns all tags connected with the id (of the image)
         */
        public string getConnectedTags(string id) {
            string ret = "";
            string comm = "SELECT t.tag FROM Foto f LEFT JOIN FotoTag ft ON f.id LIKE ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE f.id LIKE @id";
            try {
                using (SQLiteConnection con = new SQLiteConnection(connection)) {
                    con.Open();
                    using (SQLiteCommand command = new SQLiteCommand(comm, con)) {
                        command.Parameters.AddWithValue("@id", id);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            ret += reader[0] as string + ",";
                        }
                    }
                }
            } catch {
                Debug.WriteLine("Reading tags error");
            }
            ret = ret.Equals("") ? ret : ret.Substring(0, ret.Count() - 1);
            return ret;
        }

        /*
        * returns the amount of entries
        */
        private int countEntrys() {
            long count = 0;
            try {
                using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM Foto", con)) {
                    count = (Int64)command.ExecuteScalar();
                }
            } catch {
                Debug.WriteLine("Error counting Entrys");
            }
            return (int)count;
        }


        /*
         * Returns saved search strings
         */
        public string[] getFavs() {
            List<string> list = new List<string>();
            //using (SQLiteConnection con = new SQLiteConnection(connection)) {
            try {
                using (SQLiteCommand command = new SQLiteCommand("SELECT search FROM Favs;", con)) {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        list.Add(reader[0] as string);
                    }
                }
            } catch {
            }
            //}
            return list.ToArray();
        }

        public TagEditElement[] getTags() {
            List<TagEditElement> list = new List<TagEditElement>();
            //try {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT tag, COUNT(ft.TagID) as 'Cntr' FROM Tag t LEFT JOIN FotoTag ft on t.id = ft.TagID GROUP BY tag ORDER BY Cntr DESC;", con)) {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        list.Add(new TagEditElement(reader[0].ToString(), reader.GetInt32(1)));
                    }
                }
            }
            //} catch {
            // }
            return list.ToArray();
        }

        public void updateTag(string newtag, string oldtag) {
            //try {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand("UPDATE Tag SET tag = @newtag WHERE tag LIKE @oldtag;", con)) {
                    command.Parameters.AddWithValue("@newtag", newtag);
                    command.Parameters.AddWithValue("@oldtag", oldtag);
                    command.ExecuteNonQuery();
                }
            }
            //} catch {
            //}
        }

        /*
         * Adds search string
         */
        public bool addFav(string f) {
            bool ret = false;
            //using (SQLiteConnection con = new SQLiteConnection(connection)) {
            try {
                using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Favs (search) VALUES (@f)", con)) {
                    command.Parameters.AddWithValue("@f", f);
                    command.ExecuteNonQuery();
                    ret = true;
                }
            } catch {

            }
            // }
            return ret;
        }

        /*
         * Removes search string
         */
        public void removeFav(string t) {
            //using (SQLiteConnection con = new SQLiteConnection(connection)) {
            try {
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Favs WHERE search = @t", con)) {
                    command.Parameters.AddWithValue("@t", t);
                    command.ExecuteNonQuery();
                }
            } catch {
            }
            //}
        }

        /*
        * generates a new GUID
        */
        private Guid genGUID() {
            return Guid.NewGuid();
        }
        public int getEntryCount() {
            return entryCount;
        }

        internal void deleteTag(string tag) {
            //try {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM FotoTag WHERE EXISTS (SELECT * FROM Tag t WHERE FotoTag.TagID = t.id AND t.tag LIKE @tag)", con)) {
                    command.Parameters.AddWithValue("@tag", tag);
                    command.ExecuteNonQuery();
                }

                using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Tag WHERE tag LIKE @tag", con)) {
                    command.Parameters.AddWithValue("@tag", tag);
                    command.ExecuteNonQuery();
                }
            }
            //} catch {
            //}
        }
    }
}
