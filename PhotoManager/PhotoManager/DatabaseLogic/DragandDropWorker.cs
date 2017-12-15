using PhotoManager.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager.DatabaseLogic {
    class DragandDropWorker : BackgroundWorker {

        private DBHandler db;
        private string[] files;
        private MessageBoxInfo mbi;
        private string currentworkingdirectory, dir_full, dir_preview;
        private List<string> justDragDropped;
        private int imagescale;
        private ProgressBar pb;

        public DragandDropWorker(string[] files, string workingdirectory, string full, string preview, int imagescale, DBHandler db, MessageBoxInfo mbi, ProgressBar pb) : base() {
            this.db = db;
            this.imagescale = imagescale;
            this.currentworkingdirectory = workingdirectory;
            this.dir_full = full;
            this.dir_preview = preview;
            this.files = files;
            this.pb = pb;
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
            int maxcntr = countMax(files);
            pb.BeginInvoke((MethodInvoker)delegate {
                pb.Maximum = maxcntr;
                pb.Value = 0;
            });
            bool addDate = Properties.Settings.Default.AUTOINSERTDATE;
            bool addComment = Properties.Settings.Default.AUTOINSERTCOMMENT;
            foreach (string file in files) {
                //Console.WriteLine(file);
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                    string[] fileEntries = Directory.GetFiles(file);
                    foreach (string fileName in fileEntries) {
                        string n = loadFile(fileName, mbi, addDate, addComment);
                        if (!n.Equals("")) { justDragDropped.Add(n); counter++; }
                        pb.BeginInvoke((MethodInvoker)delegate {
                            if (pb.Value < pb.Maximum) { pb.Value++; }
                        });
                    }
                } else {
                    string n = loadFile(file, mbi, addDate, addComment);
                    if (!n.Equals("")) { justDragDropped.Add(n); counter++; }
                    pb.BeginInvoke((MethodInvoker)delegate {
                        if (pb.Value < pb.Maximum) { pb.Value++; }
                    });
                }
            }
            db.close();
            mbi.addText("");
            mbi.addText(counter + " of " + maxcntr + " Files added.");
            mbi.addText(justDragDropped.Count() + " Files selected.");
        }

        private int countMax(string[] files) {
            int c = 0;
            foreach (string file in files) {
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                    c += Directory.GetFiles(file).Count();
                } else {
                    c++;
                }
            }
            return c;
        }

        public MessageBoxInfo getMessgageBox() {
            return mbi;
        }

        private string loadFile(string path, MessageBoxInfo mbi, bool addDate, bool addComment) {
            string filetype = Path.GetExtension(path).ToLower();
            if (filetype.Equals(".png") || filetype.Equals(".jpg") || filetype.Equals(".jpeg")) {
                string hash = Utils.getHash(path);
                if (db.ImageExists(hash)) {
                    mbi.addText("WARN: File " + path + " already exists. Skipping...");
                    return "";
                }
                string date = Utils.YEAR_STD, comment = "";
                if (addComment || addDate) {
                    MetadataElement mde = ImageGenerator.getMetaData(path, addComment, addDate);
                    date = mde.Date.ToString();
                    comment = mde.Description;
                }

                if (comment.Contains(".") && comment.Count() == 10) {      //Description IS date
                    date = comment.Substring(6, 4) + comment.Substring(3, 2) + comment.Substring(0, 2);
                    comment = "";
                } else if (comment.Count() > 10) {  //Description CONTAINS date at the END
                    string sub = comment.Substring(comment.Count() - 10, 10);
                    string tempdate = sub.Substring(6, 4) + sub.Substring(3, 2) + sub.Substring(0, 2);
                    try {
                        int i = Int32.Parse(tempdate);
                        date = tempdate;
                    } catch {
                    }
                }
                Image img;
                img = db.addImage(hash, filetype, date, comment);
                bool check = true;
                try { File.Copy(path, currentworkingdirectory + dir_full + img.getName() + filetype, true); } catch { check = false; }
                check = (ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, img.getName() + img.getFileType()) == null || check == false) ? false : true;
                if (check == false) {
                    db.deleteEntry(new string[] { hash });
                    mbi.addText("FAIL: Broken file: " + img.getName() + " was now removed from DB");
                } else {
                    mbi.addText("OK:  Added " + img.getName() + ", date: " + date + ", description: " + comment);
                    if (addDate && !date.Equals(Utils.YEAR_STD)) {
                        mbi.addText("          set date to " + date);
                    }
                    if (addComment && !comment.Equals("")) {
                        mbi.addText("          set description to " + comment);
                    }
                }
                return img.getName();
            } else {
                mbi.addText("FAIL: File " + path + " is not a supported Image File. Skipping...");
            }
            return "";
        }
    }
}