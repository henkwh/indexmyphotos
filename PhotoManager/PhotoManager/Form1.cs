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
        private List<Image> images;


        private DBHandler db;


        /*
         * TODO
         * worker crash after set location on map and then reload main panel
         *
         */

        public Form1() {
            currentworkingdirectory = System.IO.Directory.GetCurrentDirectory();
            InitializeComponent();
            db = new DBHandler(currentworkingdirectory);
            images = db.loadAll();
            foreach (Image img in images) {
                setHandler(img);
                addMenuItems(img);
            }
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            map = new GMapInstance(this, currentworkingdirectory);
            tabPage_Map.Controls.Add(map);

            if (!System.IO.Directory.Exists(currentworkingdirectory + dir_full)) {
                System.IO.Directory.CreateDirectory(currentworkingdirectory + dir_full);
            }
            if (!System.IO.Directory.Exists(currentworkingdirectory + dir_preview)) {
                System.IO.Directory.CreateDirectory(currentworkingdirectory + dir_preview);
            }
            newWorker();
        }

        private void panel_overview_Paint(object sender, PaintEventArgs e) {
            Debug.WriteLine("paint");

        }

        /*
         * Handles Drag-and-Drop of FIles
         */

        void Form1_DragDrop(object sender, DragEventArgs e) {
            int counter = 0;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files) {
                Console.WriteLine(file);
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) {
                    string[] fileEntries = Directory.GetFiles(file);
                    foreach (string fileName in fileEntries) {
                        counter = loadFile(fileName) ? counter + 1 : counter;
                    }
                } else {
                    counter = loadFile(file) ? counter + 1 : counter;

                }

            }
            MessageBox.Show(counter + " of " + (files.Length) + " Files added.");
            newWorker();
        }

        /*
          * Checks if Dag-Dropped file is valid
         *@path Path to FIle or Directory
         */
        private bool loadFile(string path) {
            string filetype = System.IO.Path.GetExtension(path).ToLower();
            if (filetype.Equals(".png") || filetype.Equals(".jpg") || filetype.Equals(".jpeg")) {
                string hash = Sorting.getHash(path);
                if (db.fileExists(hash)) {
                    //Sorting.addMessage("Datei " + path + " already exists. Skipping...", null);
                    MessageBox.Show("File " + path + " already exists. Skipping...");
                    return false;
                }
                Image img = db.addImage(path, hash, filetype);
                setHandler(img);
                addMenuItems(img);
                images.Add(img);
                return true;
            } else {
                MessageBox.Show("File " + path + " is not a supported Image FIle. Skipping...");
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
         * Worker adds previews to the main panel
         */
        private void newWorker() {
            if (ThreadRunning == true) {
                newWorkerRequested = true;
                Debug.WriteLine("Request");
                worker.CancelAsync();
                return;
            }
            for (int i = 0; i < tabPage_main.Controls.Count; i++) {
                tabPage_main.Controls.RemoveAt(i);
            }
            panel_overview = new FlowLayoutPanel();
            panel_overview.Dock = DockStyle.Fill;
            panel_overview.AutoScroll = true;
            panel_overview.Visible = true;
            panel_overview.WrapContents = true;
            tabPage_main.Controls.Add(panel_overview);
            ThreadRunning = true;
            worker = null;
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_finished);
            worker.RunWorkerAsync();
        }

        private void worker_finished(object sender, RunWorkerCompletedEventArgs e) {
            ThreadRunning = false;
            if (newWorkerRequested == true) {
                newWorkerRequested = false;
                newWorker();
            }
        }

        private void worker_DoWork2(object sender, DoWorkEventArgs e) {

            try {
                map.removeMarkers();
                //Get Images matching the request
                shown = Sorting.sort(tb_search.Text, images);
                //Invoke and Reset ProgressBar
                if (pb_loaded.InvokeRequired) {
                    pb_loaded.BeginInvoke((MethodInvoker)delegate {
                        pb_loaded.Maximum = shown.Count;
                        pb_loaded.Value = 0;
                    });
                }
                //Invoke and Reset Label
                if (label_picturesof.InvokeRequired) {
                    label_picturesof.BeginInvoke((MethodInvoker)delegate {
                        label_picturesof.Text = shown.Count + "/" + images.Count;
                    });
                }

                int counter = 0;    //Counts the Loops for a delay so the main thread may refresh the Interface
                foreach (Image i in shown) {
                    if (counter > 5) {
                        Thread.Sleep(50);
                        counter = 0;
                    }
                    if (i.getPreview() == null) {   //No Preview Icon so far
                        try {
                            Bitmap bmp = ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, i.getName() + i.getFileType());
                            i.setPreview(bmp);
                            i.Size = bmp.Size;
                            i.Image = bmp;
                        } catch {
                            Sorting.addMessage("Error creating Preview for file: " + i.getName(), i);
                        }
                    } else if (Math.Max(i.Size.Height, i.Size.Width) != ImageGenerator.SIZE) {
                        panel_overview.BeginInvoke((MethodInvoker)delegate {
                            i.Size = ImageGenerator.genSize(i);
                        });

                    }

                    if (!i.getLocation().Equals("")) {          //No Location set -> No marker
                        map.addMarker(i.getLocation(), i.getPreview());
                    }

                    if (panel_overview.InvokeRequired) {    //Invoke main panel to add Preview Icon
                        panel_overview.BeginInvoke((MethodInvoker)delegate {
                            panel_overview.Controls.Add(i);
                            panel_overview.Refresh();
                        });
                    } else {
                        panel_overview.Controls.Add(i);
                    }
                    if (pb_loaded.InvokeRequired) {
                        pb_loaded.BeginInvoke((MethodInvoker)delegate {
                            pb_loaded.Value++;
                        });
                    }
                    counter++;
                    if (e.Cancel || worker.CancellationPending) {   //Abort Worker
                        Debug.WriteLine("Exit");
                        break;
                    }
                }
            } catch {
                MessageBox.Show("Error: Restarting Worker");
            }

            if (panel_overview.InvokeRequired) {        //Invoke main panel to refresh the UI
                panel_overview.BeginInvoke((MethodInvoker)delegate {
                    panel_overview.Refresh();
                    panel_overview.Update();
                });
                Thread.Sleep(10);   //10 ms sleep before a new worker can be created
            }
        }


        private void worker_DoWork(object sender, DoWorkEventArgs e) {
            try {
                map.removeMarkers();
                //Get Images matching the request
                shown = Sorting.sort(tb_search.Text, images);
                //Invoke and Reset ProgressBar
                if (InvokeRequired) {
                    BeginInvoke((MethodInvoker)delegate {
                        pb_loaded.Maximum = shown.Count;
                        pb_loaded.Value = 0;
                        label_picturesof.Text = shown.Count + "/" + images.Count;
                    });
                }

                int counter = 0;    //Counts the Loops for a delay so the main thread may refresh the Interface
                foreach (Image i in shown) {
                    /*if (counter > 5) {
                        Thread.Sleep(50);
                        counter = 0;
                    }*/
                    if (i.getPreview() == null) {   //No Preview Icon so far
                        try {
                            Bitmap bmp = ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, i.getName() + i.getFileType());
                            i.setPreview(bmp);
                            i.Size = bmp.Size;
                            i.Image = bmp;
                        } catch {
                            Sorting.addMessage("Error creating Preview for file: " + i.getName(), i);
                        }
                    } else if (false && Math.Max(i.Size.Height, i.Size.Width) != ImageGenerator.SIZE) {
                        panel_overview.BeginInvoke((MethodInvoker)delegate {
                            i.Size = ImageGenerator.genSize(i);
                        });

                    }

                    if (!i.getLocation().Equals("")) {          //No Location set -> No marker
                        map.addMarker(i.getLocation(), i.getPreview());
                    }

                    if (InvokeRequired) {    //Invoke main panel to add Preview Icon
                        BeginInvoke((MethodInvoker)delegate {
                            panel_overview.Controls.Add(i);
                            pb_loaded.Value++;
                            panel_overview.Refresh();
                        });
                    } else {
                        panel_overview.Controls.Add(i);
                        pb_loaded.Value++;
                        panel_overview.Refresh();
                    }

                    counter++;
                    if (e.Cancel || worker.CancellationPending) {   //Abort Worker
                        break;
                    }
                }
            } catch {
                MessageBox.Show("Error: Restarting Worker");
            }
            /*
            if (panel_overview.InvokeRequired) {        //Invoke main panel to refresh the UI
                panel_overview.BeginInvoke((MethodInvoker)delegate {
                    panel_overview.Refresh();
                    panel_overview.Update();
                });
                Thread.Sleep(10);   //10 ms sleep before a new worker can be created
            }*/
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {

        }

        /*
         * Adds MouseEventHandler to  the preview Image in main panel
         */
        private void setHandler(Image i) {
            i.SizeMode = PictureBoxSizeMode.StretchImage;
            i.MouseClick += new MouseEventHandler((o, a) => {
                if (a.Button == MouseButtons.Right) {

                } else if (a.Button == MouseButtons.Left) {
                    if (ModifierKeys == Keys.Control) {
                        if (multiedit.Contains(i)) {
                            multiedit.Remove(i);
                            //i.BorderStyle = BorderStyle.None;
                            i.showBordernot();
                        } else {
                            multiedit.Add(i);
                            //i.BorderStyle = BorderStyle.Fixed3D;
                            i.showBorder();
                        }

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
            MenuItemImage menuItem = new MenuItemImage("Delete");
            MenuItemImage menuItem2 = new MenuItemImage("Edit tags");
            menuItem.Click += Delete_Click;
            menuItem2.Click += TagEdit_Click;
            menuItem.setParentPictureBox(image);
            menuItem2.setParentPictureBox(image);
            menuItem.Tag = image;
            menuItem2.Tag = image;
            cm.Popup += Popup_Preview;
            cm.MenuItems.Add(menuItem);
            cm.MenuItems.Add(menuItem2);
            image.ContextMenu = cm;
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
            //i.BorderStyle = BorderStyle.Fixed3D;
            i.showBorder();
            removeDoublesinmultiedit();
        }


        /*
        * Adds a ContextMenu to the preview image in tag view
        */
        private void TagEdit_Click(object sender, EventArgs e) {
            tabControl1.SelectedTab = tabPage_tags;
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
                if (multiedit.Count == 1) {
                    tb_location.Text = i.getLocation();
                    tb_tags.Text = i.getTags();
                    tb_description.Text = i.getDescription();
                    tb_dateday.Text = i.getDate().Day.ToString();
                    tb_datemonth.Text = i.getDate().Month.ToString();
                    tb_dateyear.Text = i.getDate().Year.ToString();
                } else {
                    tb_location.Text = "";
                    tb_tags.Text = "";
                    tb_description.Text = "";
                    tb_dateday.Text = "";
                    tb_datemonth.Text = "";
                    tb_dateyear.Text = "";
                }
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
            i.showBordernot();
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
                string name = multiedit[0].getName();
                string type = multiedit[0].getFileType();
                multiedit[0].setPreview(null);      //Dispose to avoid deleting while file in use
                if (multiedit[0].Image != null) {
                    multiedit[0].Image.Dispose();
                    multiedit[0].Image = null;
                }
                images.Remove(multiedit[0]);
                multiedit[0].Dispose();
                multiedit[0] = null;
                multiedit.RemoveAt(0);

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

        private void removeDoublesinmultiedit() {
            for (int u = 0; u < multiedit.Count; u++) {
                int cntr = 0;
                foreach (Image i in multiedit) {
                    if (i == multiedit[u]) {
                        cntr++;
                    }
                }
                if (cntr > 1) {
                    multiedit.RemoveAt(u);
                    u--;
                }
            }
            panel_tagedit.Controls.Clear();
        }


        /*
        * Deletes a single image instance by click of ContetMenu
        */
        private void Delete_Entry(Image i) {
            db.deleteEntry(i.getName());
            images.Remove(i);
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
                case Keys.Down:
                    if (ImageGenerator.SIZE >= ImageGenerator.MINMAXSIZE[0]) {
                        ImageGenerator.SIZE -= 50;
                        newWorker();
                    }
                    break;
                case Keys.PageDown:
                    if (ImageGenerator.SIZE >= ImageGenerator.MINMAXSIZE[0]) {
                        ImageGenerator.SIZE -= 100;
                        newWorker();
                    }
                    break;
                case Keys.PageUp:
                    if (ImageGenerator.SIZE <= ImageGenerator.MINMAXSIZE[1]) {
                        ImageGenerator.SIZE += 100;
                        newWorker();
                    }
                    break;
                case Keys.Up:
                    if (ImageGenerator.SIZE <= ImageGenerator.MINMAXSIZE[1]) {
                        ImageGenerator.SIZE += 50;
                        newWorker();
                    }
                    break;
                case Keys.Space:
                    newWorker();
                    break;
                case Keys.Escape:
                    resetMultiedit();
                    break;
            }


        }

        private void resetMultiedit() {
            foreach (Image i in multiedit) {
                //i.BorderStyle = BorderStyle.None;
                i.showBordernot();
                panel_tagedit.Controls.Clear();
            }
            multiedit.Clear();
            panel_overview.Update();
            panel_tagedit.Update();
        }

        private void btn_applytag_Click(object sender, EventArgs e) {
            bool exited = false;
            foreach (Image i in multiedit) {
                string desc = tb_description.Text;
                string tags = Sorting.TagsIn(tb_tags.Text);
                string location = Sorting.LocationIn(tb_location.Text);
                if (location.Equals(Sorting.YEAR_ERR.ToString())) {
                    MessageBox.Show("Error - Invalid Coordinates!");
                    return;
                }
                string[] dtin = { tb_dateyear.Text, tb_datemonth.Text, tb_dateday.Text };
                DateTime datetime = Sorting.DateTimeIn(dtin);
                if (datetime.Year == Sorting.YEAR_ERR) {
                    MessageBox.Show("Error - Invalid Date!");
                    return;
                }

                UpdateParemeters up = Sorting.checkInputTags(i, location, tags, desc, datetime);
                if (up == null) {
                    MessageBox.Show("Aborted!");
                    exited = true;
                    break;
                }
                if (db.updateEntry(i.getName(), i.getFileType(), up.getLocation(i.getLocation()), up.getTags(i.getTags()), up.getDate(i.getDate()), up.getDescription(i.getDescription()))) {
                    i.setTags(up.getDate(i.getDate()), up.getLocation(i.getLocation()), up.getDescription(i.getDescription()), up.getTags(i.getTags()));
                } else {
                    Sorting.addMessage("Error: " + i.getName(), i);
                }
            }
            Sorting.JoinForAll = false;
            Sorting.DisposeForAll = false;
            if (exited == false) {
                if (multiedit.Count > 0) {

                    MessageBox.Show("OK");
                } else {
                    MessageBox.Show("Error:\r\nList is empty!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            resetMultiedit();
        }

        private void tb_search_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return) {
                if (tb_search.Text.Equals("DROP TABLE")) {
                    DialogResult dialogResult = MessageBox.Show("Reset Database?", "Critical operation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) {
                        multiedit = images;
                        Delete_Click(null, null);
                        // Directory.Delete(currentworkingdirectory+dir_full, true);
                        //Directory.Delete(currentworkingdirectory+dir_preview, true);
                        db.deleteTable();
                    }
                    return;
                }
                newWorker();
                tb_history.Text += DateTime.Now.ToString("h:mm") + " | " + tb_search.Text + "\r\n";
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
                tb_dateday.BackColor = Color.LightGray;
                tb_datemonth.BackColor = Color.LightGray;
                tb_dateyear.BackColor = Color.LightGray;
                tb_location.BackColor = Color.LightGray;
                tb_tags.BackColor = Color.LightGray;
                tb_description.BackColor = Color.LightGray;
                tb_dateday.Text = tb_datemonth.Text = tb_dateyear.Text = tb_location.Text = tb_description.Text = tb_tags.Text = "";
                if (multiedit.Count == 1) {
                    tb_location.Text = multiedit[0].getLocation();
                    if (multiedit[0].getTags().Length > 1) {
                        tb_tags.Text = multiedit[0].getTags().Replace("#", ",").Substring(1, multiedit[0].getTags().Length - 1);
                    }
                    tb_description.Text = multiedit[0].getDescription();
                    if (multiedit[0].getDate().Year != Sorting.YEAR_STD) {
                        tb_dateyear.Text = multiedit[0].getDate().Year.ToString();
                        tb_datemonth.Text = multiedit[0].getDate().Month.ToString();
                        tb_dateday.Text = multiedit[0].getDate().Day.ToString();
                    }
                }

            } else if (tabControl1.SelectedTab == tabPage_Log) {
                tb_log.Text = "           Name                      Type |        Date         | Hash | Loc | Tags | Beschreibung\r\n\r\n";
                foreach (Image i in images) {
                    tb_log.Text += i.getName() + " " + i.getFileType() + " | " + i.getDate() + " | " + Sorting.getHash(currentworkingdirectory + dir_full + i.getName() + i.getFileType()) + " | " + i.getLocation() + " | " + i.getTags() + " | " + i.getDescription() + "\r\n";
                }

            } else if (tabControl1.SelectedTab == tabPage_main) {
                if (multiedit.Count != 0) {
                    DialogResult dialogResult = MessageBox.Show("Some Items are still checked - Uncheck selection?", "Selection", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) {
                        resetMultiedit();
                    }
                }
            } else if (tabControl1.SelectedTab == tabPage_Map) {
                map.setEditMode(false);
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e) {

        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

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
            tb_location.BackColor = Color.LightGreen;
        }

        private void btn_tagtodefault_Click(object sender, EventArgs e) {

            DialogResult dialogResult = MessageBox.Show("Reset Tags to default?", "Critical Operation", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) {
                return;
            }

            foreach (Image i in multiedit) {
                if (db.updateEntry(i.getName(), i.getFileType(), "", "", new DateTime(Sorting.YEAR_STD, 01, 01), "")) {
                    i.setTags(new DateTime(Sorting.YEAR_STD, 01, 01), "", "", "");
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
