using PhotoManager.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager.DatabaseLogic {
    class DragandDropWorker : BackgroundWorker {

        private DBHandler db;
        private string[] files;
        private MessageBoxInfo mbi;
        private string currentworkingdirectory, dir_full, dir_preview;
        private List<string> justDragDropped;
        private int imagescale;

        public DragandDropWorker(string[] files, string workingdirectory, string full, string preview, int imagescale, DBHandler db, MessageBoxInfo mbi) : base() {
            this.db = db;
            this.imagescale = imagescale;
            this.currentworkingdirectory = workingdirectory;
            this.dir_full = full;
            this.dir_preview = preview;
            this.files = files;
            justDragDropped = new List<string>();
            this.DoWork += DragandDropWorker_DoWork;
            this.mbi = mbi;
            mbi.Show();
            mbi.BringToFront();
        }

        public List<string> getjustDragDropped() {
            return justDragDropped;
        }

        private void DragandDropWorker_DoWork(object sender, DoWorkEventArgs e) {
            db.open();
            int counter = 0;
            int maxcntr = 0;
            bool addDate = Properties.Settings.Default.AUTOINSERTDATE;
            foreach (string file in files) {
                Console.WriteLine(file);
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                    string[] fileEntries = Directory.GetFiles(file);
                    foreach (string fileName in fileEntries) {
                        string n = loadFile(fileName, mbi, addDate);
                        if (!n.Equals("")) { justDragDropped.Add(n); counter++; }
                        maxcntr++;
                    }
                } else {
                    string n = loadFile(file, mbi, addDate);
                    if (!n.Equals("")) { justDragDropped.Add(n); counter++; }
                    maxcntr++;
                }
            }
            db.close();
            mbi.addText(counter + " of " + maxcntr + " Files added.");
            mbi.addText(counter + " Files selected.");
        }

        public MessageBoxInfo getMessgageBox() {
            return mbi;
        }

        private string loadFile(string path, MessageBoxInfo mbi, bool addDate) {
            string filetype = Path.GetExtension(path).ToLower();
            if (filetype.Equals(".png") || filetype.Equals(".jpg") || filetype.Equals(".jpeg")) {
                string hash = Utils.getHash(path);
                if (db.ImageExists(hash)) {
                    mbi.addText("File " + path + " already exists. Skipping...");
                    return "";
                }
                string date = null;
                if (addDate) {
                    date = Utils.getDateFromFile(path);
                    if (date.Count() != 8 || date[0] == '0') {
                        addDate = false;
                    }
                }
                Image img;
                if (addDate) {
                    img = db.addImage(hash, filetype, date);
                } else {
                    img = db.addImage(hash, filetype);
                }

                bool check = true;
                try { File.Copy(path, currentworkingdirectory + dir_full + img.getName() + filetype, true); } catch { check = false; }
                check = (ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, img.getName() + img.getFileType()) == null || check == false) ? false : true;
                if (check == false) {
                    db.deleteEntry(hash);
                    mbi.addText("Broken file: " + img.getName() + " was now removed from DB");
                } else {
                    mbi.addText("Added " + img.getName());
                }
                return img.getName();
            } else {
                mbi.addText("File " + path + " is not a supported Image File. Skipping...");
            }
            return "";
        }
    }
}