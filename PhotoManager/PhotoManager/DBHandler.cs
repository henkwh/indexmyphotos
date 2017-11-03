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

        private DateTime deftime = new DateTime(Sorting.YEAR_STD, 01, 01);


        public DBHandler(string workingdirectory) {
            currentworkingdirectory = workingdirectory;
            //MessageBox.Show(currentworkingdirectory);

            //connection = @"Data Source=(LocalDB)\v13.0;AttachDbFilename="+currentworkingdirectory+@"\Database.mdf;Integrated Security=True";

            connection = @"Data Source=(LocalDB)\v13.0;AttachDbFilename=C:\Users\Henk\Source\Repos\indexmyphotos\PhotoManager\PhotoManager\Database.mdf;Integrated Security=True";
            //connection = "Data Source=(LocalDB)\\v13.0;AttachDbFilename=D:\\Dokumente\\Source\\Repos\\PHviee\\phviewer\\phviewer\\Database.mdf;Integrated Security=True";
            createTable();
        }

        private void createTable() {
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("CREATE TABLE imgdb(id UNIQUEIDENTIFIER PRIMARY KEY,hash TEXT, filetype TEXT,location TEXT,tags TEXT,date datetime, description TEXT);", con)) {
                        command.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("Table created.");
                    }
                } catch {
                    Debug.WriteLine("Table not created.");
                }
            }

        }


        public Image addImage(string path, string hash, string filetype) {
            Image img = null;
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();


                try {
                    using (SqlCommand command = new SqlCommand("INSERT INTO imgdb VALUES(@id, @hash, @type, @location, @tags, @shootdate, @description)", con)) {

                        Guid g = genGUID();
                        command.Parameters.Add(new SqlParameter("id", g));
                        command.Parameters.Add(new SqlParameter("hash", hash));
                        command.Parameters.Add(new SqlParameter("type", filetype));
                        command.Parameters.Add(new SqlParameter("location", ""));
                        command.Parameters.Add(new SqlParameter("tags", ""));
                        command.Parameters.Add(new SqlParameter("shootdate", deftime));
                        command.Parameters.Add(new SqlParameter("description", ""));
                        command.ExecuteNonQuery();


                        System.IO.File.Copy(path, currentworkingdirectory + Form1.dir_full + g + filetype, false);
                        img = new Image(g.ToString(), filetype);
                        Debug.WriteLine("Table filled!");
                    }
                } catch {
                    Debug.WriteLine("Table not filled.");
                }
                con.Close();
            }
            return img;
        }

        public bool updateEntry(string filename, string filetype, string location, string tags, DateTime date, string description) {
            bool ret = false;
            List<Image> imagelist = new List<Image>();
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("UPDATE imgdb SET location=@location, tags=@tags, date=@shootdate, description=@description WHERE id LIKE @id", con)) {
                        command.Parameters.Add(new SqlParameter("location", String.IsNullOrEmpty(location) ? "" : location));
                        command.Parameters.Add(new SqlParameter("tags", String.IsNullOrEmpty(tags) ? "" : tags));
                        command.Parameters.Add(new SqlParameter("shootdate", date));
                        command.Parameters.Add(new SqlParameter("description", String.IsNullOrEmpty(description) ? "" : description));
                        command.Parameters.Add(new SqlParameter("id", filename));
                        command.ExecuteNonQuery();
                        Debug.WriteLine("Updated: " + filename + " | " + location + " | " + date + " | " + tags + " | " + description);
                    }
                    ret = true;
                } catch (SqlException sqlEx) {
                    Debug.WriteLine("Error updating: " + sqlEx.Message);
                }
                con.Close();
            }
            return ret;
        }

        public bool deleteEntry(string id) {
            bool success = false;
            try {
                using (SqlConnection con = new SqlConnection(connection)) {
                    con.Open();
                    using (SqlCommand command = new SqlCommand("DELETE FROM imgdb WHERE id=@id", con)) {
                        command.Parameters.Add(new SqlParameter("id", id));
                        command.ExecuteNonQuery();
                        success = true;
                    }
                    con.Close();
                }
            } catch {
            }
            return success;
        }



        public List<Image> loadAll() {

            List<Image> imagelist = new List<Image>();
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM imgdb", con)) {
                        ;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            Image img = new Image(reader.GetGuid(0).ToString(), reader.GetString(2));
                            string location = reader.GetString(3);
                            string tags = reader.GetString(4);
                            DateTime date = reader.GetDateTime(5);
                            string description = reader.GetString(6);
                            img.setTags(date, location, description, tags);
                            imagelist.Add(img);
                        }
                    }
                } catch {
                    Debug.WriteLine("Error loading");
                }
                con.Close();
            }
            return imagelist;
        }

        public List<Image> matchSearchQuery(string like) {
            List<Image> imagelist = new List<Image>();
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("SELECT * FROM imgdb WHERE tags LIKE '" + like + "'", con)) {
                        ;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) {
                            Image img = new Image(reader.GetGuid(0).ToString(), reader.GetString(2));
                            string location = reader.GetString(3);
                            string tags = reader.GetString(4);
                            DateTime date = reader.GetDateTime(5);
                            string description = reader.GetString(6);
                            img.setTags(date, location, description, tags);
                            imagelist.Add(img);
                        }
                    }
                } catch {
                    Debug.WriteLine("Error loading");
                }
                con.Close();
            }
            return imagelist;
        }


        public bool fileExists(string hash) {
            Int32 counter = 0;
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("SELECT COUNT (*) FROM imgdb WHERE hash LIKE @hash", con)) {
                        command.Parameters.Add(new SqlParameter("hash", hash));
                        counter = (Int32)command.ExecuteScalar();
                    }
                } catch (SqlException sqlEx) {
                    Debug.WriteLine("Error comparing hash: " + sqlEx.Message);
                }
                con.Close();
            }
            return counter > 0 ? true : false;
        }


        public List<Image> load() {




            return null;
        }


        private Guid genGUID() {
            Guid g = Guid.NewGuid();
            return Guid.NewGuid();
        }

        public bool deleteTable() {
            bool okay = false;
            using (SqlConnection con = new SqlConnection(connection)) {
                con.Open();
                try {
                    using (SqlCommand command = new SqlCommand("DROP TABLE imgdb", con)) {
                        command.ExecuteNonQuery();
                        okay = true;
                        MessageBox.Show("Gelöscht!");
                    }
                } catch {
                    Debug.WriteLine("Fehler beim Löschen.");
                }
            }
            return okay;
        }


    }
}
