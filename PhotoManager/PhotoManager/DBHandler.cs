using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            connection = @"Data Source=(LocalDB)\v13.0;AttachDbFilename=C:\Users\Henk\Source\Repos\indexmyphotos\PhotoManager\PhotoManager\Database.mdf;Integrated Security=True";
            createTable();
            removeUnusedTags();
            entryCount = countEntrys();
        }

        /*
   * Creates required tables Foto, Tag, FotoTag
   */
        private void createTable() {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("CREATE TABLE Foto(id UNIQUEIDENTIFIER PRIMARY KEY,hash VARCHAR(MAX), filetype VARCHAR(MAX),location VARCHAR(MAX),date datetime,description VARCHAR(MAX));", con)) {
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Table created.");
                    }
                } catch {
                    Debug.WriteLine("Table Foto not created.");
                }

                try {
                    using (SqlCommand command = new SqlCommand("CREATE TABLE FotoTag(FotoID UNIQUEIDENTIFIER,TagID UNIQUEIDENTIFIER, PRIMARY KEY(FotoID, TagID));", con)) {
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Table created.");
                    }
                } catch {
                    Debug.WriteLine("Table Tag not created.");
                }

                try {
                    using (SqlCommand command = new SqlCommand("CREATE TABLE Tag(id UNIQUEIDENTIFIER PRIMARY KEY,tag VARCHAR(MAX));", con)) {
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Table created.");
                    }
                } catch {
                    Debug.WriteLine("Table Fototag not created.");
                }

            }
        }

        /*
      * Adds a connection between image and tag
      */
        public void connectTag(string id, string tag) {
            if (!tagexists(tag)) {
                insertTag(tag);
            }
            string comm = "INSERT INTO FotoTag(FotoID, TagID) SELECT f.id, t.id FROM Foto f, Tag t WHERE f.id = @id AND t.tag LIKE @tag";
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand(comm, con)) {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@tag", tag);
                        command.ExecuteNonQuery();
                    }
                } catch {
                }
            }
        }


        /*
         * Inserts a new entry
         */
        public Image addImage(string path, string hash, string filetype) {
            Image f = null;
            Guid g = genGUID();
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Foto (id, hash, filetype) VALUES(@id, @hash, @filetype)", con)) {

                        command.Parameters.AddWithValue("@id", g);
                        command.Parameters.AddWithValue("@hash", hash);
                        command.Parameters.AddWithValue("@filetype", filetype);
                        SqlDataReader reader = command.ExecuteReader();
                        f = new Image(g.ToString(), filetype);
                    }
                    Debug.WriteLine("Added: " + hash);
                } catch {
                    Debug.WriteLine("Error: addEntry()");
                }
            }
            updateEntry(g.ToString(), "date", Sorting.YEAR_STD);
            updateEntry(g.ToString(), "location", "");
            updateEntry(g.ToString(), "description", "");
            entryCount = countEntrys();
            return f;
        }

        public bool ImageExists(string hash) {
            bool ret = false;
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("SELECT count(id) FROM Foto WHERE hash LIKE @param;", con)) {
                        command.Parameters.AddWithValue("@param", hash);
                        ret = ((Int32)command.ExecuteScalar() > 0) ? true : false;
                    }
                } catch {
                    Debug.WriteLine("Error: tagexists()");
                }
            }
            return ret;
        }

        /*
         * returns true if string tag already exists
         */
        public bool tagexists(string tag) {
            Int32 count = 0;
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("SELECT count(id) FROM Tag WHERE tag LIKE @param;", con)) {
                        command.Parameters.AddWithValue("@param", tag);
                        count = (Int32)command.ExecuteScalar();
                    }
                } catch {
                    Debug.WriteLine("Error: tagexists()");
                }
            }
            return count == 0 ? false : true;
        }

        /*
         * Inserts a new tag in Tag DB
         */
        public void insertTag(string tag) {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Tag (id, tag) VALUES (@id, @tag)", con)) {
                        command.Parameters.AddWithValue("@id", genGUID());
                        command.Parameters.AddWithValue("@tag", tag);
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Tag added: " + tag);
                    }
                } catch {
                    Debug.WriteLine("Table Foto not created.");
                }
            }
        }

        /*
         * Updates a value in DB
         */
        public void updateEntry(string id, string type, string value) {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("UPDATE Foto SET " + type + "= @value WHERE id LIKE @id", con)) {
                        command.Parameters.AddWithValue("@value", value);
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Updated!");
                    }
                } catch {
                    MessageBox.Show("Error updating " + id);
                }
            }
        }

        /*
         * Deletes an entry from Foto DB
         */
        public void deleteEntry(string id) {
            removeTags(id);
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Foto WHERE id = @id", con)) {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Deleted: " + id);
                    }
                } catch {
                    MessageBox.Show("Error deleting Foto " + id);
                }
            }
            entryCount = countEntrys();
        }

        /*
         * Removes every tag related to an image
         */
        public void removeTags(string id) {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("DELETE FROM FotoTag WHERE FotoID = @id", con)) {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                } catch {
                    MessageBox.Show("Error deleting " + id);
                    return;
                }
            }
        }
            private void removeUnusedTags() {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("DELETE FROM Tag WHERE NOT EXISTS(SELECT * FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID WHERE ft.TagID = Tag.id)", con)) {
                        command.ExecuteNonQuery();
                    }
                } catch {
                    return;
                }
            }
        }

        /*
         * Loads images matching the SearchQuery
         */
        public List<Image> loadEntries(SearchQuery sq) {
            string comm = "SELECT DISTINCT f.id, f.filetype, f.location, f.date, f.description FROM Foto f";

            if (sq == null || sq.isEmpty()) {
                comm += ";";
            } else {
                comm += " LEFT JOIN FotoTag ft ON f.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE";
                comm += sq.getQuery();
                comm += ";";
            }
            Debug.WriteLine("Anfrage: " + comm);
            List<Image> loadinglist = new List<Image>();
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand(comm, con)) {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            Image img = new Image(reader.GetGuid(0).ToString(), reader[1] as string);
                            string location = reader[2] as string;
                            string[] date = reader[3].ToString().Split('.');
                            string dateinput = (date.Count() >= 3) ? date[2].Substring(0, 4) + date[1] + date[0] : Sorting.YEAR_STD;
                            string description = reader[4] as string;
                            Debug.WriteLine(description + "");
                            img.setTags(dateinput, location, description, "");
                            loadinglist.Add(img);
                        }
                    }
                } catch {
                    Debug.WriteLine("Error processing: " + comm);
                    MessageBox.Show("Error processing: " + comm);
                }
            }
            return loadinglist;
        }

        /*
         * returns all tags connected with the id (of the image)
         */
        public string getConnectedTags(string id) {
            string ret = "";
            string comm = "SELECT t.tag FROM Foto f LEFT JOIN FotoTag ft ON f.id = ft.FotoID LEFT JOIN Tag t ON t.id = ft.TagID WHERE f.id LIKE @id";
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand(comm, con)) {
                        command.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            ret += reader[0] as string + ", ";
                        }
                    }
                } catch {
                    Debug.WriteLine("Reading tags error");
                }
            }
            ret = ret.Equals("") ? ret : ret.Substring(0, ret.Count() - 2);
            return ret;
        }

        /*
        * returns the amount of entries
        */
        public int countEntrys() {
            Int32 count = 0;
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Foto", con)) {
                        count = (Int32)command.ExecuteScalar();
                    }
                } catch {
                    Debug.WriteLine("Error counting Entrys");
                }
            }
            return count;
        }

        /*
        * generates a new GUID
        */
        private Guid genGUID() {
            Guid g = Guid.NewGuid();
            return Guid.NewGuid();
        }

        public int getEntryCount() {
            return entryCount;
        }
    }
}
