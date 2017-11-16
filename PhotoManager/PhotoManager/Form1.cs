using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace PhotoManager {
    public partial class Form1 : Form {

        private bool newWorkerRequested = false, ThreadRunning = false;
        private string currentworkingdirectory = "";
        public static string dir_preview = @"\preview\";
        public static string dir_full = @"\full\";

        private BackgroundWorker worker;
        private GMapInstance map;

        private List<Image> multiedit = new List<Image>();
        private List<Image> shown = new List<Image>();

        private DBHandler db;

        private int imagescale;

        private OrderElement selectedorder;

        public Form1() {
            currentworkingdirectory = System.IO.Directory.GetCurrentDirectory();
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_finished);
            db = new DBHandler(currentworkingdirectory);
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            map = new GMapInstance(this, currentworkingdirectory, Utils.SCALE_MAP_DEF);
            tabPage_Map.Controls.Add(map);
            trackBar1.updateTabPage(TrackBarControl.tabPage.MAIN, 0);
            imagescale = trackBar1.scrollEvent(TrackBarControl.tabPage.MAIN);
            combobox_sorting.Items.Add(new OrderElement("Date ascending", " ORDER BY f.date ASC"));
            combobox_sorting.Items.Add(new OrderElement("Date descending", " ORDER BY f.date DESC"));
            combobox_sorting.Items.Add(new OrderElement("Location N to S", " ORDER BY f.loclat DESC"));
            combobox_sorting.Items.Add(new OrderElement("Location S to N", " ORDER BY f.loclat ASC"));
            combobox_sorting.Items.Add(new OrderElement("Location W to E", " ORDER BY f.loclng ASC"));
            combobox_sorting.Items.Add(new OrderElement("Location E to W", " ORDER BY f.loclng DESC"));
            combobox_sorting.Items.Add(new OrderElement("Filetype", " ORDER BY f.filetype ASC"));
            combobox_sorting.SelectedIndex = 1;
            if (!System.IO.Directory.Exists(currentworkingdirectory + dir_full)) {
                System.IO.Directory.CreateDirectory(currentworkingdirectory + dir_full);
            }
            if (!System.IO.Directory.Exists(currentworkingdirectory + dir_preview)) {
                System.IO.Directory.CreateDirectory(currentworkingdirectory + dir_preview);
            }
            Utils.deleteImagesNotInDB(currentworkingdirectory, dir_full, dir_preview, db.loadEntries(null));
            newWorker();
        }

        /*
         * Handles Drag-and-Drop of Files
         */
        void Form1_DragDrop(object sender, DragEventArgs e) {
            int counter = 0;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            tsprogressbar.Maximum = files.Count();
            tsprogressbar.Value = 0;
            foreach (string file in files) {
                Console.WriteLine(file);
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                    string[] fileEntries = Directory.GetFiles(file);
                    tsprogressbar.Maximum = fileEntries.Count();
                    tsprogressbar.Value = 0;
                    foreach (string fileName in fileEntries) {
                        counter = loadFile(fileName) ? counter + 1 : counter;
                        tsprogressbar.Value++;
                    }
                } else {
                    counter = loadFile(file) ? counter + 1 : counter;
                    try {
                        tsprogressbar.Value++;
                    } catch { }
                }

            }
            MessageBox.Show(counter + " of " + (files.Length) + " Files added.");
            newWorker();
        }
        /*
          * Checks if Dag-Dropped file is valid
         *@path Path to File or Directory
         */
        private bool loadFile(string path) {
            string filetype = System.IO.Path.GetExtension(path).ToLower();
            if (filetype.Equals(".png") || filetype.Equals(".jpg") || filetype.Equals(".jpeg")) {
                string hash = Utils.getHash(path);
                if (db.ImageExists(hash)) {
                    MessageBox.Show("File " + path + " already exists. Skipping...");
                    return false;
                }
                Image img = db.addImage(path, hash, filetype);
                System.IO.File.Copy(path, currentworkingdirectory + dir_full + img.getName() + filetype, false);
                ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, img.getName() + img.getFileType());
                return true;
            } else {
                MessageBox.Show("File " + path + " is not a supported Image File. Skipping...");
            }
            return false;
        }

        void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        /*
         * Creates a new worker instance
         */
        private void newWorker() {
            if (ThreadRunning == true) {
                newWorkerRequested = true;
                worker.CancelAsync();
                return;
            }
            panel_overview.SuspendLayout();
            panel_overview.Controls.Clear();
            ThreadRunning = true;
            worker.RunWorkerAsync();
        }
        /*
         * called if worker is finished
         */
        private void worker_finished(object sender, RunWorkerCompletedEventArgs e) {
            panel_overview.ResumeLayout();
            ThreadRunning = false;
            if (newWorkerRequested == true) {
                newWorkerRequested = false;
                newWorker();
            }
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e) {
            //Get images matching the input string
            SearchQuery sq = new SearchQuery(tb_search.Text, selectedorder.Query);
            shown = db.loadEntries(sq);
            if (InvokeRequired) {
                panel_overview.BeginInvoke((MethodInvoker)delegate {
                    map.removeMarkers();
                    tsprogressbar.Maximum = shown.Count;
                    tsprogressbar.Value = 0;
                    tslabel_picturesof.Text = shown.Count + "/" + db.getEntryCount();
                });
            }
            ToolTip toolTip = new ToolTip();
            int i = 0;
            int c = i;
            while (i < shown.Count) {
                for (int j = 0; j < Utils.WORKER_FILL_INTERVAL; j++) {
                    if (i + j >= shown.Count()) {
                        break;
                    }
                    Image img = shown[i + j];
                    setHandler(img);
                    addMenuItems(img);
                    Bitmap bmp = ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, img.getName() + img.getFileType());
                    img.setPreview(bmp);
                    img.setImage(bmp);
                    toolTip.SetToolTip(shown[i + j], Utils.getToolTipTextForImage(shown[i + j]));
                    shown[i + j].setSize(imagescale);
                    if (img.getLocation()[0] != 0 && img.getLocation()[1] != 0) {          //No Location set -> No marker
                        map.addMarker(img.getLocation(), img.getPreview());
                    }
                }
                int range = (i + Utils.WORKER_FILL_INTERVAL > shown.Count()) ? shown.Count() - i : Utils.WORKER_FILL_INTERVAL;
                Image[] addThis = shown.GetRange(i, range).ToArray();
                bool wait = true;
                BeginInvoke((MethodInvoker)delegate {
                    panel_overview.Controls.AddRange(addThis);
                    try {
                        tsprogressbar.Value += range;
                    } catch { }
                    panel_overview.Update();
                    panel_overview.ResumeLayout();
                    map.Update();
                    wait = false;
                });
                while (wait) {
                    Thread.Sleep(Utils.WORKER_SLEEP_TIME);
                }
                i += Utils.WORKER_FILL_INTERVAL;
                if (e.Cancel || worker.CancellationPending) {   //Abort Worker
                    break;
                }
            }
        }

        /*
         * Adds MouseEventHandler to  the preview Image in main panel
         */
        private void setHandler(Image i) {
            i.MouseClick += new MouseEventHandler((o, a) => {
                if (a.Button == MouseButtons.Right) {
                } else if (a.Button == MouseButtons.Left) {
                    if (ModifierKeys == Keys.Control) {
                        if (multiedit.Contains(i)) {
                            multiedit.Remove(i);
                            i.hideBorder();
                        } else {
                            multiedit.Add(i);
                            i.showBorder();
                        }
                    } else {
                        pictureBox_viewer.ShownImage = i;
                        tabControl1.SelectedTab = tabPage_viewer;
                        pictureBox_viewer.Image = new Bitmap(currentworkingdirectory + dir_full + i.getName() + i.getFileType());
                    }
                }
            }
           );
        }


        /*
         * Adds a ContextMenu to the preview image
         */
        private void addMenuItems(Image image) {
            ContextMenu cm = new ContextMenu();
            string[] name = new string[] { "Delete", "Edit Tags", "Select all" };
            cm.Popup += Popup_Preview;
            for (int i = 0; i < 3; i++) {
                MenuItemImage menuItem = new MenuItemImage(name[i]);
                switch (i) {
                    case 0:
                        menuItem.Click += Delete_Click;
                        break;
                    case 1:
                        menuItem.Click += TagEdit_Click;
                        break;
                    case 2:
                        menuItem.Click += SelectAll_Click;
                        break;
                }
                menuItem.setParentPictureBox(image);
                menuItem.Tag = image;
                cm.MenuItems.Add(menuItem);
            }
            image.ContextMenu = cm;
        }

        private void SelectAll_Click(object sender, EventArgs e) {
            foreach (Image i in shown) {
                multiedit.Add(i);
                i.showBorder();
            }
        }

        /*
        * Adds border to selected preview images in main panel
        */
        private void Popup_Preview(object sender, EventArgs e) {
            ContextMenu sndr = (ContextMenu)sender;
            Image i = ((MenuItemImage)sndr.MenuItems[0]).getParentPictureBox();
            if (!multiedit.Contains(i)) {
                multiedit.Add(i);
            }
            i.showBorder();
        }


        /*
        * Adds a ContextMenu to the preview image in tag view
        */
        private void TagEdit_Click(object sender, EventArgs e) {
            tabControl1.SelectedTab = tabPage_tags;
            addImagestoTabPage();
        }

        private void addImagestoTabPage() {
            panel_tagedit.Controls.Clear();
            foreach (Image i in multiedit) {
                PictureBox tageditbox = new PictureBox();
                tageditbox.Image = i.getPreview();
                tageditbox.SizeMode = PictureBoxSizeMode.AutoSize;
                ContextMenu cm = new ContextMenu();
                MenuItemImage menuItem = new MenuItemImage("Remove");
                menuItem.setParentPictureBox(i);
                menuItem.Click += TagRemove_Click;
                cm.MenuItems.Add(menuItem);
                tageditbox.ContextMenu = cm;
                panel_tagedit.Controls.Add(tageditbox);
            }
        }


        /*
        * Removes border from preview image in main panel
        */
        private void TagRemove_Click(object sender, EventArgs e) {
            Image i = ((MenuItemImage)sender).getParentPictureBox();
            foreach (PictureBox img in panel_tagedit.Controls.OfType<PictureBox>()) {
                if (i.getPreview() == img.Image) {
                    panel_tagedit.Controls.Remove(img);
                }
            }
            multiedit.Remove(i);
            i.hideBorder();
            panel_tagedit.Update();
            if (multiedit.Count == 1) {
                tabControl1_SelectedIndexChanged(multiedit[0], null);
            }
        }


        /*
        * Removes all references to an image coomnpletely - in database, preview/full directory and the object
        */
        private void Delete_Click(Object sender, EventArgs e) {
            while (multiedit.Count != 0) {
                Debug.WriteLine("Deleting: " + multiedit[0].getName());
                db.deleteEntry(multiedit[0].getName());
                map.removeMarkers();
                if (multiedit[0] == pictureBox_viewer.ShownImage) {
                    pictureBox_viewer.ShownImage.Dispose();
                    pictureBox_viewer.Image.Dispose();
                }
                string name = multiedit[0].getName();
                string type = multiedit[0].getFileType();
                multiedit[0].setPreview(null);      //Dispose to avoid deleting while file in use
                if (multiedit[0].Image != null) {
                    multiedit[0].Image.Dispose();
                }
                multiedit[0].Dispose();
                multiedit.RemoveAt(0);
                Thread.Sleep(100);
                try {
                    File.Delete(currentworkingdirectory + dir_full + name + type);
                    File.Delete(currentworkingdirectory + dir_preview + name + type);
                } catch {
                    MessageBox.Show("Error deleting File");
                }
            }
            multiedit.Clear();
            newWorker();
        }

        /*
        * Deletes a single image instance by click of ContetMenu
        */
        private void Delete_Entry(Image i) {
            db.deleteEntry(i.getName());
            multiedit.Remove(i);
            string name = i.getName();
            string type = i.getFileType();
            i.Image.Dispose();
            i.Image = null;
            i.Dispose();
            i = null;
            File.Delete(currentworkingdirectory + dir_full + i.getName() + i.getFileType());
            File.Delete(currentworkingdirectory + dir_preview + i.getName() + i.getFileType());
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    resetMultiedit();
                    break;
                case Keys.Left:
                    if (tabControl1.SelectedTab == tabPage_viewer && pictureBox_viewer.ShownImage != null) {
                        int index = shown.IndexOf(pictureBox_viewer.ShownImage);
                        if (index > 0) {
                            pictureBox_viewer.Image = new Bitmap(currentworkingdirectory + dir_full + shown[index - 1].getName() + shown[index - 1].getFileType());
                            pictureBox_viewer.ShownImage = shown[index - 1];
                            tslabel_picturesof.Text = (shown.IndexOf(pictureBox_viewer.ShownImage) + 1) + "/" + shown.Count() + "/" + db.getEntryCount();
                        }
                    }
                    break;
                case Keys.Right:
                    if (tabControl1.SelectedTab == tabPage_viewer && pictureBox_viewer.ShownImage != null) {
                        int index = shown.IndexOf(pictureBox_viewer.ShownImage);
                        if (index < shown.Count - 1) {
                            pictureBox_viewer.Image = new Bitmap(currentworkingdirectory
                                + dir_full + shown[index + 1].getName() + shown[index + 1].getFileType());
                            pictureBox_viewer.ShownImage = shown[index + 1];
                            tslabel_picturesof.Text = (shown.IndexOf(pictureBox_viewer.ShownImage) + 1) + "/" + shown.Count() + "/" + db.getEntryCount();
                        }
                    }
                    break;
            }


        }

        private void resetMultiedit() {
            foreach (Image i in multiedit) {
                i.hideBorder();
                panel_tagedit.Controls.Clear();
            }
            multiedit.Clear();
            panel_overview.Update();
            panel_tagedit.Update();
        }

        private void btn_applytag_Click(object sender, EventArgs e) {
            tsprogressbar.Maximum = multiedit.Count();
            tsprogressbar.Value = 0;

            string desc = tb_description.Text;
            string tags = tb_tags.Text.Equals(" ") ? " " : tb_tags.Text.Replace(" ", "").Replace("\r\n", "");
            string location = tb_location.Text;
            string dtin = tb_dateyear.Text + tb_datemonth.Text + tb_dateday.Text;

            TagAlert ta = new TagAlert();

            foreach (Image i in multiedit) {
                UpdateParameter[] list = Utils.checkInputTags(i, location, tags, db.getConnectedTags(i.getName()), desc, dtin, ta);
                string[] dbstring = { "location", "tags", "description", "date" };
                bool set = false;
                for (int j = 0; j < list.Count(); j++) {
                    UpdateParameter p = list[j];
                    if (p.isreturnValueSet()) {
                        set = true;
                        if (j == 0) {
                            db.updateEntry(i.getName(), Utils.parseLocation(p.getReturnValue()));
                        } else if (j == 1) {
                            string[] tagssplit = p.getReturnValue().Split(',');
                            db.removeTags(i.getName());
                            if (tagssplit.Count() == 1 && tagssplit[0].Replace(" ", "").Equals("")) {
                            } else {
                                foreach (string s in tagssplit) {
                                    db.connectTag(i.getName(), s);
                                }
                            }
                        } else {
                            db.updateEntry(i.getName(), dbstring[j], p.getReturnValue());
                        }
                    }
                }
                if (set) {
                    Image i2 = db.getImage(i.getName());
                    i.setTags(i2.getDate(), i2.getLocation(), i2.getDescription(), i2.getTags());
                }
                tsprogressbar.Value++;
            }
            db.removeUnusedTags();
        }
        private void btn_clearlist_Click(object sender, EventArgs e) {
            resetMultiedit();
        }

        private void tb_search_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                newWorker();
                multiedit.Clear();
            }
        }

        private void tb_TextChanged(object sender, EventArgs e) {
            TextBox box = (TextBox)sender;
            if (box.Text.Equals("")) {
                box.BackColor = Color.LightGray;
            } else {
                box.BackColor = Color.White;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabPage_tags) {
                addImagestoTabPage();
                foreach (TextBox tb in new TextBox[] { tb_dateday, tb_datemonth, tb_dateyear, tb_dateday, tb_tags, tb_description, tb_location }) {
                    tb.BackColor = Color.LightGray;
                    tb.Text = "";
                }
                if (multiedit.Count == 1) {
                    if (multiedit[0].getLocation()[0] != 0 && multiedit[0].getLocation()[1] != 0) {
                        tb_location.Text = multiedit[0].getLocationString();
                    }
                    tb_tags.Text = db.getConnectedTags(multiedit[0].getName());
                    tb_description.Text = multiedit[0].getDescription();
                    if (!multiedit[0].getDate().Equals(Utils.YEAR_STD)) {
                        tb_dateyear.Text = multiedit[0].getDate().Substring(0, 4);
                        if (multiedit[0].getDate().Count() == Utils.YEAR_STD.Count()) {
                            tb_datemonth.Text = multiedit[0].getDate().Substring(4, 2);
                            tb_dateday.Text = multiedit[0].getDate().Substring(6, 2);
                        }
                    }
                }
            } else if (tabControl1.SelectedTab == tabPage_Log) {
                if (tb_log.Text.Equals("")) {
                    tb_log.Text = "";// "           Name                      Type |        Date         | Hash | Loc | Tags | Beschreibung\r\n\r\n";
                    List<Image> ListAll = db.loadEntries(new SearchQuery("", ""));
                    foreach (Image i in ListAll) {
                        tb_log.Text += i.getName() + " | Type: " + i.getFileType() + "\r\n\t Hash       : " + Utils.getHash(currentworkingdirectory + dir_full + i.getName() + i.getFileType()) + "\r\n\t Date       : " + i.getDate() + "\r\n\t Location   : " + i.getLocationString() + "\r\n\t Tags       : " + db.getConnectedTags(i.getName()) + "\r\n\t Description: " + i.getDescription() + "\r\n";
                    }
                }
            } else if (tabControl1.SelectedTab == tabPage_main) {
                trackBar1.updateTabPage(TrackBarControl.tabPage.MAIN, imagescale);
                tslabel_picturesof.Text = shown.Count() + "/" + db.getEntryCount();
            } else if (tabControl1.SelectedTab == tabPage_Map) {
                tslabel_picturesof.Text = map.getPinCount() + "/" + shown.Count() + "/" + db.getEntryCount();
                map.setEditMode(false);
                trackBar1.updateTabPage(TrackBarControl.tabPage.MAP, map.getPinScale());
            } else if (tabControl1.SelectedTab == tabPage_viewer) {
                if (pictureBox_viewer.ShownImage != null) {
                    tslabel_picturesof.Text = (shown.IndexOf(pictureBox_viewer.ShownImage) + 1) + "/" + shown.Count() + "/" + db.getEntryCount();
                }
            }
        }

        private void btn_showonMap_Click(object sender, EventArgs e) {
            if (multiedit.Count == 0) {
                MessageBox.Show("No items selected!");
                return;
            }
            tabControl1.SelectedTab = tabPage_Map;
            map.setEditMode(true);
        }

        public void setOnMapDone(string loc) {
            tabControl1.SelectedTab = tabPage_tags;
            tb_location.Text = loc;
        }

        private void btn_tagtodefault_Click(object sender, EventArgs e) {
            tsprogressbar.Maximum = multiedit.Count();
            tsprogressbar.Value = 0;
            DialogResult dialogResult = MessageBox.Show("Reset Tags to default?", "Critical Operation", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) {
                return;
            }
            foreach (Image i in multiedit) {
                db.updateEntry(i.getName(), new double[] { 0, 0 });
                db.updateEntry(i.getName(), "description", "");
                db.updateEntry(i.getName(), "date", Utils.YEAR_STD);
                db.removeTags(i.getName());
                i.setTags(Utils.YEAR_STD, null, "", "");
                tsprogressbar.Value++;
                tabControl1_SelectedIndexChanged(multiedit[0], null);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabPage_main) {
                imagescale = trackBar1.scrollEvent(TrackBarControl.tabPage.MAIN);
                panel_overview.SuspendLayout();
                int c = 0;
                foreach (Image i in shown) {
                    i.setSize(imagescale);
                    if (c == 5) {
                        panel_overview.ResumeLayout();
                        c = 0;
                        panel_overview.SuspendLayout();
                    }
                    c++;
                }
                panel_overview.ResumeLayout();
            } else if (tabControl1.SelectedTab == tabPage_Map) {
                map.setPinScale(trackBar1.scrollEvent(TrackBarControl.tabPage.MAP));
            }
        }

        private void combobox_sorting_TextChanged(object sender, EventArgs e) {

            foreach (OrderElement oe in combobox_sorting.Items) {
                if (oe.Text.Equals(combobox_sorting.Text)) {
                    selectedorder = oe;
                    break;
                }
            }
        }

        public void ClickedMap(string location) {
            tb_search.Text = "Location:" + location;
            tabControl1.SelectedTab = tabPage_main;
            newWorker();
        }
    }
}
