using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager {
    class DBHandler {

        private string currentworkingdirectory;
        private string connection;

        private int entryCount;


        public DBHandler(string workingdirectory) {
            currentworkingdirectory = workingdirectory;
            connection = "Data Source=testdb.db3";
            //SQLiteConnection.CreateFile("testdb.db3");
            SQLiteConnection.ClearAllPools();
            createTable();
            removeUnusedTags();
            entryCount = countEntrys();

            testQuery("INSERT INTO Foto (id, filetype, date) VALUES('manual', 'typ', '01012017')");
            testQuery("INSERT INTO Foto (id, filetype, date) VALUES('manual2', 'typ2', '2017')");

        }


        private void testQuery(string q) {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                using (SQLiteCommand command = new SQLiteCommand(q, con)) {
                    command.ExecuteNonQuery();
                }
                con.Close(); con.Dispose();
            }
        }

        /*
   * Creates required tables Foto, Tag, FotoTag
   */
        private void createTable() {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("CREATE TABLE Foto(id VARCHAR(59) PRIMARY KEY, filetype VARCHAR(255),loclat DECIMAL(9,6),loclng DECIMAL(9,6),date datetime,description VARCHAR(255));", con)) {
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
                con.Close(); con.Dispose();

            }
        }

        /*
      * Adds a connection between image and tag
      */
        public void connectTag(string id, string tag) {
            if (!tagexists(tag)) {
                insertTag(tag);
            }
            string comm = "INSERT INTO FotoTag(FotoID, TagID) SELECT f.id, t.id FROM Foto f, Tag t WHERE f.id LIKE @id AND t.tag LIKE @tag";
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();

                try {
                    using (SQLiteCommand command = new SQLiteCommand(comm, con)) {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@tag", tag);
                        command.ExecuteNonQuery();
                    }
                } catch {
                }
                con.Close(); con.Dispose();
            }
        }


        /*
         * Inserts a new entry
         */
        public Image addImage(string hash, string filetype) {
            Image f = null;
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();

                try {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Foto (id, filetype, loclat, loclng) VALUES(@id, @filetype, 0, 0)", con)) {

                        command.Parameters.AddWithValue("@id", hash);
                        command.Parameters.AddWithValue("@filetype", filetype);
                        SQLiteDataReader reader = command.ExecuteReader();
                        f = new Image(hash.ToString(), filetype);
                    }
                    Debug.WriteLine("Added: " + hash);
                } catch {
                    Debug.WriteLine("Error: addEntry()");
                }
                con.Close(); con.Dispose();
            }
            updateEntry(hash.ToString(), "date", Utils.YEAR_STD);
            updateEntry(hash.ToString(), new double[] { 0.0, 0.0 });
            updateEntry(hash.ToString(), "description", "");
            entryCount = countEntrys();
            return f;
        }

        public bool ImageExists(string hash) {
            bool ret = false;
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("SELECT count(id) FROM Foto WHERE id LIKE @param;", con)) {
                        command.Parameters.AddWithValue("@param", hash);
                        long scalar = (Int64)command.ExecuteScalar() == null ? 0 : (Int64)command.ExecuteScalar();
                        ret = (scalar > 0) ? true : false;
                    }
                } catch {
                    Debug.WriteLine("Error: IMeg exists");
                }
                con.Close(); con.Dispose();
            }
            return ret;
        }

        /*
         * returns true if string tag already exists
         */
        public bool tagexists(string tag) {
            long count = 0;
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("SELECT count(id) FROM Tag WHERE tag LIKE @param;", con)) {
                        command.Parameters.AddWithValue("@param", tag);
                        count = (Int64)command.ExecuteScalar();
                    }
                } catch {
                    Debug.WriteLine("Error: tagexists()");
                }
                con.Close(); con.Dispose();
            }
            return count == 0 ? false : true;
        }

        /*
         * Inserts a new tag in Tag DB
         */
        public void insertTag(string tag) {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();

                try {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Tag (id, tag) VALUES (@id, @tag)", con)) {
                        command.Parameters.AddWithValue("@id", genGUID());
                        command.Parameters.AddWithValue("@tag", tag);
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Tag added: " + tag);
                    }
                } catch {
                    Debug.WriteLine("Table Foto not created.");
                }
                con.Close(); con.Dispose();
            }
        }

        /*
         * Updates a value in DB
         */
        public void updateEntry(string id, string type, string value) {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();

                try {
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Foto SET " + type + "= @value WHERE id LIKE @id", con)) {
                        command.Parameters.AddWithValue("@value", value);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("Error updating " + id + "\r\n" + "UPDATE Foto SET " + type + "= " + value + " WHERE id LIKE " + id);
                }
                con.Close(); con.Dispose();
            }
        }

        public Image getImage(string id) {
            Image ret = null;
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                //try {
                //MessageBox.Show(id);
                using (SQLiteCommand command = new SQLiteCommand("SELECT f.id, f.filetype, f.loclat, f.loclng, f.date, f.description FROM Foto f WHERE f.id = @value", con)) {
                    command.Parameters.AddWithValue("@value", id);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        Image img = new Image(reader[0] as string, reader[1] as string);
                        double[] location = new double[] { (double)(reader.GetDecimal(2)), (double)reader.GetDecimal(3) };
                        string[] date = reader.GetDateTime(4).ToString().Split('.');
                        string dateinput = (date.Count() >= 3) ? date[2].Substring(0, 4) + date[1] + date[0] : Utils.YEAR_STD;
                        string description = reader[5] as string;
                        img.setTags(dateinput, location, description, "");
                        ret = img;
                    }
                }
                //} catch {
                //}
                con.Close(); con.Dispose();
            }
            return ret;
        }

        public void updateEntry(string id, double[] loc) {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();

                try {
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Foto SET loclat= @value WHERE id LIKE @id", con)) {
                        command.Parameters.AddWithValue("@value", loc[0]);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("Error updating lat " + id);
                }
                try {
                    using (SQLiteCommand command = new SQLiteCommand("UPDATE Foto SET loclng= @value WHERE id LIKE @id", con)) {
                        command.Parameters.AddWithValue("@value", loc[1]);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("Error updating lng " + id);
                }
                con.Close(); con.Dispose();
            }
        }

        /*
         * Deletes an entry from Foto DB
         */
        public void deleteEntry(string id) {
            removeTags(id);
            SQLiteConnection.ClearAllPools();
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Foto WHERE id LIKE @id", con)) {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Deleted: " + id);
                    }
                } catch {
                    MessageBox.Show("Error deleting Foto " + id);
                }
                con.Close(); con.Dispose();
            }
            entryCount = countEntrys();
        }

        /*
         * Removes every tag related to an image
         */
        public void removeTags(string id) {
            SQLiteConnection.ClearAllPools();
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("DELETE FROM FotoTag WHERE FotoID = @id", con)) {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("Error deleting " + id);
                }
                con.Close(); con.Dispose();
            }
        }

        public void removeUnusedTags() {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                SQLiteConnection.ClearAllPools();
                con.Open();
                try {

                    using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Tag WHERE NOT EXISTS(SELECT * FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID WHERE ft.TagID LIKE Tag.id)", con)) {
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("FAIL");
                }

                con.Close(); con.Dispose(); con.Dispose();
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
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand(comm, con)) {
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            //MessageBox.Show("Found");
                            Image img = new Image(reader[0] as string, reader[1] as string);
                            double[] location = new double[] { (double)(reader.GetDecimal(2)), (double)reader.GetDecimal(3) };
                            string[] date = reader[4].ToString().Split('.');
                            string dateinput = (date.Count() >= 3) ? date[2].Substring(0, 4) + date[1] + date[0] : Utils.YEAR_STD;
                            string description = reader[5] as string;
                            img.setTags(dateinput, location, description, "");
                            loadinglist.Add(img);
                            // MessageBox.Show("END");
                        }
                    }
                } catch {
                    Debug.WriteLine("Error processing: " + comm);
                    //MessageBox.Show("Error processing: " + comm);
                }
                con.Close(); con.Dispose();
            }
            return loadinglist;
        }

        /*
         * returns all tags connected with the id (of the image)
         */
        public string getConnectedTags(string id) {
            string ret = "";
            string comm = "SELECT t.tag FROM Foto f LEFT JOIN FotoTag ft ON f.id LIKE ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE f.id LIKE @id";
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand(comm, con)) {
                        command.Parameters.AddWithValue("@id", id);
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            ret += reader[0] as string + ",";
                        }
                    }
                } catch {
                    Debug.WriteLine("Reading tags error");
                }
                con.Close(); con.Dispose();
            }
            ret = ret.Equals("") ? ret : ret.Substring(0, ret.Count() - 1);
            return ret;
        }

        /*
        * returns the amount of entries
        */
        public int countEntrys() {
            long count = 0;
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("SELECT COUNT(*) FROM Foto", con)) {
                        count = (Int64)command.ExecuteScalar();
                    }
                } catch {
                    Debug.WriteLine("Error counting Entrys");
                }
                con.Close(); con.Dispose();
            }
            return (int)count;
        }


        public string[] getFavs() {
            List<string> list = new List<string>();

            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("SELECT search FROM Favs;", con)) {
                        SQLiteDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            list.Add(reader[0] as string);
                        }
                    }
                } catch {
                }
                con.Close(); con.Dispose();
            }
            return list.ToArray();
        }

        public bool addFav(string f) {
            bool ret = false;
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();

                try {
                    using (SQLiteCommand command = new SQLiteCommand("INSERT INTO Favs (search) VALUES (@f)", con)) {
                        command.Parameters.AddWithValue("@f", f);
                        command.ExecuteNonQuery();
                        ret = true;
                    }
                } catch {

                }
                con.Close(); con.Dispose();
            }
            return ret;
        }

        public void removeFav(string t) {
            SQLiteConnection.ClearAllPools();
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("DELETE FROM Favs WHERE search = @t", con)) {
                        command.Parameters.AddWithValue("@t", t);
                        command.ExecuteNonQuery();
                    }
                } catch {
                }
                con.Close(); con.Dispose();
            }
        }

        public void dropTables() {
            using (SQLiteConnection con = new SQLiteConnection(connection)) {
                con.Open();
                try {
                    using (SQLiteCommand command = new SQLiteCommand("Drop Table Foto", con)) {
                        command.ExecuteNonQuery();
                    }
                } catch {
                    Debug.WriteLine("Error counting Entrys");
                }
                try {
                    using (SQLiteCommand command = new SQLiteCommand("Drop Table FotoTag", con)) {
                        command.ExecuteNonQuery();
                    }
                } catch {
                    Debug.WriteLine("Error counting Entrys");
                }
                try {
                    using (SQLiteCommand command = new SQLiteCommand("Drop Table Tag", con)) {
                        command.ExecuteNonQuery();
                    }
                } catch {
                    Debug.WriteLine("Error counting Entrys");
                }
                try {
                    using (SQLiteCommand command = new SQLiteCommand("Drop Table Favs", con)) {
                        command.ExecuteNonQuery();
                    }
                } catch {
                    Debug.WriteLine("Error counting Entrys");
                }
                con.Close(); con.Dispose();
            }
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
    }
}
