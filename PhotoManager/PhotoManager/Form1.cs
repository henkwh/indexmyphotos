using PhotoManager.CustomControls;
using PhotoManager.DatabaseLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PhotoManager {
    public partial class Form1 : Form {

        private enum EDITOPERATION { ADD, REMOVE, SWITCH };

        private bool newWorkerRequested = false, ThreadRunning = false;
        private string currentworkingdirectory = "";
        public static string dir_preview = @"\preview\";
        public static string dir_full = @"\full\";

        private BackgroundWorker worker;
        private GMapInstance map;

        private List<Image> multiedit = new List<Image>();
        private List<string> justDragDropped;
        private List<Image> shown = new List<Image>();

        private DBHandler db;

        private int imagescale;

        private OrderElement selectedorder;

        private ToolTip toolTip;

        private int lastWorker;

        public Form1() {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
            currentworkingdirectory = System.IO.Directory.GetCurrentDirectory();
            Utils.createDirectories(currentworkingdirectory, dir_full, dir_preview);

            //Ititialize BAckgroundworker
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_finished);

            //Initialize DBHandler
            db = new DBHandler(currentworkingdirectory);
            db.open();
            string[] favs = db.getFavs();
            db.close();
            addFavElement(favs);

            //Initialize GMap
            map = new GMapInstance(this, currentworkingdirectory);
            tabPage_Map.Controls.Add(map);
            trackBar_scale.updateTabPage(TrackBarControl.tabPage.MAIN, 0);
            imagescale = trackBar_scale.scrollEvent(TrackBarControl.tabPage.MAIN);

            //Initialize quickinfo tooltip
            toolTip = new ToolTip();
            toolTip.AutomaticDelay = 1000;
            toolTip.UseFading = true;
            toolTip.UseAnimation = true;

            //Load settings from Properties.Settings.Default
            checkBox_Quickinfo.Checked = Properties.Settings.Default.QUICKINFO;
            RadioButton btn = Properties.Settings.Default.BORDERSTYLE_FRAME ? radioButton_Frame : radioButton_Edge;
            btn.Checked = true;
            trackBar_scale_gap.Value = Math.Min(Math.Max((Properties.Settings.Default.GAPSCALE - 10) / 2, 0), trackBar_scale_gap.Maximum);
            Properties.Settings.Default.Upgrade();
            checkBox_autoScale.Checked = Properties.Settings.Default.AUTOSCALE;
            Utils.addSelectionObects(combobox_sorting, comboBox_bgColor, comboBox_selectionColor);

            //Add event handlers
            panel_overview.Paint += Panel_overview_Paint;
            panel_overview.Scroll += Panel_overview_Scroll;
            panel_overview.MouseClick += Panel_overview_MouseClick;
            panel_overview.ContextMenu = addMenuItems();

            //Load
            newWorker();
        }

        private void Panel_overview_Scroll(object sender, ScrollEventArgs e) {
            panel_overview.Refresh();
        }

        private void Panel_overview_Paint(object sender, PaintEventArgs e) {
            FlowLayoutPanel panel = (FlowLayoutPanel)sender;
            Graphics g = panel.CreateGraphics();
            g.TranslateTransform(0, panel.AutoScrollPosition.Y);
            int panelwidth = panel.VerticalScroll.Visible ? panel.Width - SystemInformation.VerticalScrollBarWidth : panel.Width;
            int[] tmp = ImageGenerator.calculateGap(Properties.Settings.Default.GAPSCALE, imagescale, panelwidth);
            int gap = tmp[0];
            int rtrn = tmp[1];
            int x = gap;
            Debug.WriteLine(Properties.Settings.Default.GAPSCALE);
            int y = Properties.Settings.Default.GAPSCALE;
            int max = panel.Width - gap - imagescale;
            int c = 0;
            foreach (Image i in shown) {
                Size s;
                try {
                    s = ImageGenerator.genSize(imagescale, i.Image.Width, i.Image.Height);
                } catch {
                    break;
                }
                g.DrawImage(i.Image, x + (imagescale - s.Width) / 2, y + (imagescale - s.Height) / 2, s.Width, s.Height);
                i.XPos = x;
                i.YPos = y;
                x += gap + imagescale;
                c++;
                if (c == rtrn - 2) {
                    y += Properties.Settings.Default.GAPSCALE + imagescale;
                    x = gap;
                    c = 0;
                }
            }
            panel.AutoScrollMinSize = new Size(panel.AutoScrollMinSize.Width, Properties.Settings.Default.GAPSCALE + imagescale + y);
        }



        /*
         * Handles Drag-and-Drop of Files
         */
        void Form1_DragDrop(object sender, DragEventArgs e) {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            DragandDropWorker dnd = new DragandDropWorker(files, currentworkingdirectory, dir_full, dir_preview, imagescale, db, new MessageBoxInfo(Location.X, Location.Y, Width, Height));
            dnd.RunWorkerCompleted += Dnd_RunWorkerCompleted;
            dnd.RunWorkerAsync();
        }

        private void Dnd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            justDragDropped = ((DragandDropWorker)sender).getjustDragDropped();
            MessageBoxInfo mbi = ((DragandDropWorker)sender).getMessgageBox();
            mbi.BringToFront();
            newWorker();
        }

        void Form1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        /*
         * Creates a new worker instance
         */
        public void newWorker() {
            if (Environment.TickCount - lastWorker <= 500) {
                return;
            }
            lastWorker = Environment.TickCount;
            if (ThreadRunning == true) {
                newWorkerRequested = true;
                worker.CancelAsync();
                return;
            }
            ThreadRunning = true;
            worker.RunWorkerAsync();
        }
        /*
         * called if worker is finished
         */
        private void worker_finished(object sender, RunWorkerCompletedEventArgs e) {
            tsprogressbar.Value = shown.Count();
            justDragDropped = null;
            panel_overview.Refresh();
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
                    tsprogressbar.Maximum = shown.Count();
                    tsprogressbar.Value = 0;
                    updateLabel(0);
                });
            }
            panel_overview.MouseMove += Panel_overview_MouseMove1;
            int ticks = Environment.TickCount + 700;            //Delay after refresh()
            bool frame = Properties.Settings.Default.BORDERSTYLE_FRAME;
            foreach (Image img in shown) {
                Bitmap bmp = ImageGenerator.genPreview(currentworkingdirectory, dir_full, dir_preview, img.getName() + img.getFileType(), imagescale);
                img.setPreview(bmp);
                img.setImage(bmp, frame);
                if (justDragDropped != null && justDragDropped.Contains(img.getName())) { selectImage(img); }
                img.setSize(imagescale);

                if (img.getLocation()[0] != 0 && img.getLocation()[1] != 0) {
                    map.addMarker(img.getLocation(), img.getPreview());
                }
                if (Environment.TickCount - ticks > 1000) {
                    panel_overview.BeginInvoke((MethodInvoker)delegate {
                        tsprogressbar.Value = shown.IndexOf(img);
                        panel_overview.Refresh();
                        ticks = Environment.TickCount;
                    });
                }
                if (e.Cancel || worker.CancellationPending) {
                    break;
                }
            }
        }

        private void Panel_overview_MouseMove1(object sender, MouseEventArgs e) {
            if (Properties.Settings.Default.QUICKINFO) {
                Image i = getClickedImage(Cursor.Position);
                if (i != null && !i.getName().Equals((string)toolTip.Tag)) {
                    toolTip.SetToolTip(panel_overview, Utils.getToolTipTextForImage(i));
                    toolTip.Tag = i.getName();
                    //toolTip.Active = false;
                    toolTip.Active = true;
                } else if (i == null) {
                    toolTip.Active = false;
                }
            }
        }

        /*
         * Returns clicked image on main panel from cursor position
         */
        private Image getClickedImage(Point cursorposition) {
            Point p = panel_overview.PointToClient(cursorposition);
            p.Y -= panel_overview.AutoScrollPosition.Y;
            foreach (Image i in shown) {
                if (p.X >= i.XPos && p.X <= i.XPos + imagescale) {
                    if (p.Y > i.YPos && p.Y < i.YPos + imagescale) {
                        return i;
                    }
                }
            }
            return null;
        }


        /*
         * Mouse event handler in main panel
         */
        private void Panel_overview_MouseClick(object sender, MouseEventArgs a) {
            Image i = getClickedImage(Cursor.Position);
            if (i != null) {
                if (a.Button == MouseButtons.Right) {

                } else if (a.Button == MouseButtons.Left) {
                    if (ModifierKeys == Keys.Control) {
                        updateMultiedit(i, EDITOPERATION.SWITCH);
                        panel_overview.Refresh();
                    } else {
                        pictureBox_viewer.ShownImage = i;
                        tabControl1.SelectedTab = tabPage_viewer;
                        pictureBox_viewer.Image = new Bitmap(currentworkingdirectory + dir_full + i.getName() + i.getFileType());
                    }
                }
            }
        }


        /*
         * Adds a ContextMenu to the preview image
         */
        private ContextMenu addMenuItems() {
            ContextMenu cm = new ContextMenu();
            cm.Popup += Cm_Popup;
            string[] name = new string[] { "Delete", "Edit Tags", "Select all", "Show in explorer" };
            for (int i = 0; i < name.Count(); i++) {
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
                    case 3:
                        menuItem.Click += Open_Explorer_Click;
                        break;
                }
                cm.MenuItems.Add(menuItem);
            }
            return cm;
        }

        private void Open_Explorer_Click(object sender, EventArgs e) {
            Image i = getClickedImage(Cursor.Position);
            if (i != null && File.Exists(currentworkingdirectory + dir_full + i.getName() + i.getFileType())) {
                Process.Start("explorer.exe", "/select, \"" + currentworkingdirectory + dir_full + i.getName() + i.getFileType() + "\"");
            }
        }

        private void Cm_Popup(object sender, EventArgs e) {
            Image i = getClickedImage(Cursor.Position);
            if (i != null) {
                updateMultiedit(i, EDITOPERATION.ADD);
                panel_overview.Refresh();
            }
        }

        private void SelectAll_Click(object sender, EventArgs e) {
            foreach (Image i in shown) {
                updateMultiedit(i, EDITOPERATION.ADD);
            }
            panel_overview.Refresh();
        }

        private void selectImage(Image i) {
            updateMultiedit(i, EDITOPERATION.ADD);
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
            List<PictureBox> totaglist = new List<PictureBox>();
            foreach (Image i in multiedit) {
                PictureBox tageditbox = new PictureBox();
                tageditbox.Image = i.getPreview();
                tageditbox.Tag = i;
                tageditbox.SizeMode = PictureBoxSizeMode.AutoSize;
                ToolTip tt = new ToolTip();
                tt.SetToolTip(tageditbox, Utils.getToolTipTextForImage(i));
                tt.Tag = i.getName();
                ContextMenu cm = new ContextMenu();
                MenuItemImage[] milist = new MenuItemImage[] { new MenuItemImage("Remove"), new MenuItemImage("Fill") };
                foreach (MenuItemImage mii in milist) {
                    mii.setParentPictureBox(i);
                    cm.MenuItems.Add(mii);
                }
                milist[0].Click += TagRemove_Click;
                milist[1].Click += (sndr, evnt) => {
                    fillTags(((MenuItemImage)sndr).getParentPictureBox());
                };
                tageditbox.ContextMenu = cm;
                totaglist.Add(tageditbox);
            }
            panel_tagedit.Controls.AddRange(totaglist.ToArray());
            fillTags(null);
            if (multiedit.Count == 1) {
                fillTags(multiedit[0]);
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
            updateMultiedit(i, EDITOPERATION.REMOVE);
            panel_tagedit.Update();
            panel_overview.Refresh();
            if (multiedit.Count == 1) {
                tabControl1_SelectedIndexChanged(multiedit[0], null);
            }else if (multiedit.Count() == 0) {
                fillTags(null);
            }
        }


        /*
        * Removes all references to an image coomnpletely - in database, preview/full directory and the object
        */
        private void Delete_Click(Object sender, EventArgs e) {
            while (multiedit.Count != 0) {
                Debug.WriteLine("Deleting: " + multiedit[0].getName());
                db.open();
                db.deleteEntry(multiedit[0].getName());
                db.close();
                map.removeMarkers();
                if (multiedit[0] == pictureBox_viewer.ShownImage) {
                    pictureBox_viewer.ShownImage.Dispose();
                    pictureBox_viewer.Image.Dispose();
                }
                string name = multiedit[0].getName();
                string type = multiedit[0].getFileType();
                multiedit[0].setPreview(null);
                if (multiedit[0].Image != null) {
                    multiedit[0].Image.Dispose();
                }
                multiedit[0].Dispose();
                multiedit.RemoveAt(0);
                try {
                    File.Delete(currentworkingdirectory + dir_full + name + type);
                    File.Delete(currentworkingdirectory + dir_preview + name + type);
                } catch {
                }
            }
            multiedit.Clear();
            newWorker();
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Escape:
                    resetMultiedit();
                    panel_overview.Refresh();
                    break;
                case Keys.Left:
                    if (tabControl1.SelectedTab == tabPage_viewer && pictureBox_viewer.ShownImage != null) {
                        int index = shown.IndexOf(pictureBox_viewer.ShownImage);
                        if (index > 0) {
                            pictureBox_viewer.Image = new Bitmap(currentworkingdirectory + dir_full + shown[index - 1].getName() + shown[index - 1].getFileType());
                            pictureBox_viewer.ShownImage = shown[index - 1];
                            updateLabel((shown.IndexOf(pictureBox_viewer.ShownImage) + 1));
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
            }
            panel_tagedit.Controls.Clear();
            panel_tagedit.Refresh();
            multiedit.Clear();
            updateLabel(0);
            panel_overview.Refresh();
        }

        private void btn_applytag_Click(object sender, EventArgs e) {

            if (multiedit.Count() == 0) {
                MessageBox.Show("No items selected!");
                return;
            }

            tsprogressbar.Maximum = multiedit.Count();
            tsprogressbar.Value = 0;

            string desc = tb_description.Text;
            string tags = tb_tags.Text.Equals(" ") ? " " : tb_tags.Text.Replace(" ", "").Replace("\r\n", "");
            bool tagjoin = checkBox_JoinTags.Checked;
            string location = tb_location.Text;
            string dtin = Utils.parseDate(tb_dateyear.Text, true) + Utils.parseDate(tb_datemonth.Text, false) + Utils.parseDate(tb_dateday.Text, false);
            if (dtin.Count() != 8) {
                MessageBox.Show("Invalid Date");
                return;
            }
            db.open();
            List<string> ids = new List<string>();
            foreach (Image i in multiedit) {
                ids.Add(i.getName());
            }
            string[] idarr = ids.ToArray();
            if (!tags.Equals("") && !checkBox_JoinTags.Checked) {
                db.removeTags(idarr);
                Debug.WriteLine("Removed tags");
            }
            tsprogressbar.Value = tsprogressbar.Maximum / 4;
            if (!tags.Equals(" ") && !tags.Equals("")) {
                string[] tagssplit = tags.Split(',');
                foreach (Image i in multiedit) {
                    db.connectTag(i.getName(), tagssplit, i == multiedit[0]);
                }
            }

            tsprogressbar.Value = Math.Min(tsprogressbar.Maximum - 1, tsprogressbar.Maximum / 2);
            if (desc.Equals(" ")) {
                db.updateEntry(idarr, "description", "");
                Debug.WriteLine("reset desc");
            } else if (!desc.Equals("")) {
                Debug.WriteLine("set desc");
                db.updateEntry(idarr, "description", desc);
            }
            if (location.Equals(" ")) {
                Debug.WriteLine("reset loc");
                db.updateEntry(idarr, new double[] { 0, 0 });
            } else if (!location.Equals("")) {
                Debug.WriteLine("set loc");
                db.updateEntry(idarr, Utils.parseLocation(location));
            }
            tsprogressbar.Value = Math.Min(tsprogressbar.Maximum - 1, (tsprogressbar.Maximum * 3) / 4);
            if ((tb_dateyear.Text + tb_datemonth.Text + tb_dateday.Text).Equals(" ")) {
                db.updateEntry(idarr, "date", Utils.YEAR_STD);
                Debug.WriteLine("reset date");
            } else if (!(tb_dateyear.Text + tb_datemonth.Text + tb_dateday.Text).Equals("")) {
                db.updateEntry(idarr, "date", dtin);
                Debug.WriteLine("set date");
            }
            db.close();
            tsprogressbar.Value = tsprogressbar.Maximum;
        }
        private void btn_clearlist_Click(object sender, EventArgs e) {
            resetMultiedit();
            fillTags(null);
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
                box.ForeColor = Color.Black;
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabPage_tags) {
              if(multiedit.Count() == 0) {
                    fillTags(null);
                }
            } else if (tabControl1.SelectedTab == tabPage_main) {
                trackBar_scale.updateTabPage(TrackBarControl.tabPage.MAIN, imagescale);
                tslabel_picturesof.Text = shown.Count() + "/" + db.getEntryCount();
            } else if (tabControl1.SelectedTab == tabPage_Map) {
                tslabel_picturesof.Text = map.getPinCount() + "/" + shown.Count() + "/" + db.getEntryCount();
                map.setEditMode(false);
                trackBar_scale.updateTabPage(TrackBarControl.tabPage.MAP, map.getPinScale());
            } else if (tabControl1.SelectedTab == tabPage_viewer) {
                if (pictureBox_viewer.ShownImage != null) {
                    tslabel_picturesof.Text = (shown.IndexOf(pictureBox_viewer.ShownImage) + 1) + "/" + shown.Count() + "/" + db.getEntryCount();
                }
            } else if (tabControl1.SelectedTab == tabPage_Taglist) {
                flowLayoutPanel_tags.Controls.Clear();
                TagEditElement[] tee = db.getTags();
                foreach (TagEditElement t in tee) {
                    t.getEditButton().Click += (sndr, evnt) => {
                        db.updateTag(t.getNewTag(), t.OldTag);
                        t.OldTag = t.getNewTag();
                    };
                    t.GetDeleteButton().Click += (sndr, evnt) => {
                        if (t.getNewTag().Equals(t.OldTag)) {
                            db.deleteTag(t.OldTag);
                            flowLayoutPanel_tags.Controls.Remove(t);
                            flowLayoutPanel_tags.Refresh();
                        } else {
                            MessageBox.Show("Tag was changed - Save first");
                        }
                    };
                }
                flowLayoutPanel_tags.Controls.AddRange(tee);
                flowLayoutPanel_tags.Refresh();
            }
        }

        private void fillTags(Image i) {
            foreach (TextBox b in new TextBox[] { tb_location, tb_tags, tb_description, tb_dateyear, tb_datemonth, tb_dateday }) {
                if (i == null) {
                    b.BackColor = Color.LightGray;
                    b.Text = "";
                } else {
                    b.ForeColor = Color.Black;
                }
            }

            if (i != null) {
                if (i.getLocation()[0] != 0 && i.getLocation()[1] != 0) {
                    tb_location.Text = i.getLocationString();
                }
                tb_tags.Text = db.getConnectedTags(i.getName());
                tb_description.Text = i.getDescription();
                if (!i.getDate().Equals(Utils.YEAR_STD)) {
                    tb_dateyear.Text = i.getDate().Substring(0, 4);
                    tb_datemonth.Text = i.getDate().Substring(4, 2).Equals("00") ? "" : i.getDate().Substring(4, 2);
                    tb_dateday.Text = i.getDate().Substring(6, 2).Equals("00") ? "" : i.getDate().Substring(6, 2);
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
            if (multiedit.Count() == 0) {
                MessageBox.Show("No items selected!");
                return;
            }
            tsprogressbar.Maximum = multiedit.Count();
            tsprogressbar.Value = 0;
            DialogResult dialogResult = MessageBox.Show("Reset Tags to default?", "Critical Operation", MessageBoxButtons.YesNo);
            if (dialogResult != DialogResult.Yes) {
                return;
            }
            db.open();
            List<string> ids = new List<string>();
            foreach (Image i in multiedit) {
                ids.Add(i.getName());
                i.setTags(Utils.YEAR_STD, null, "", "");
                tsprogressbar.Value++;
                tabControl1_SelectedIndexChanged(multiedit[0], null);
            }
            db.removeTags(ids.ToArray());
            db.updateEntry(ids.ToArray(), Utils.parseLocation("0,0"));
            db.updateEntry(ids.ToArray(), "description", "");
            db.updateEntry(ids.ToArray(), "date", Utils.YEAR_STD);
            db.close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e) {
            if (tabControl1.SelectedTab == tabPage_main) {
                imagescale = trackBar_scale.scrollEvent(TrackBarControl.tabPage.MAIN);
                Properties.Settings.Default.AUTOSCALE = checkBox_autoScale.Checked;
                panel_overview.Refresh();
            } else if (tabControl1.SelectedTab == tabPage_Map) {
                map.setPinScale(trackBar_scale.scrollEvent(TrackBarControl.tabPage.MAP));
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

        private void btn_deleteUnusedFiles_Click(object sender, EventArgs e) {
            MessageBoxInfo mbinfo = new MessageBoxInfo(Location.X, Location.Y, Width, Height);
            mbinfo.Show();
            Utils.deleteImagesNotInDB(currentworkingdirectory, dir_full, dir_preview, db.loadEntries(null), mbinfo);
            mbinfo = null;
        }

        private void comboBox_bgColor_SelectedIndexChanged(object sender, EventArgs e) {
            panel_overview.BackColor = ((ColorSetting)comboBox_bgColor.Items[comboBox_bgColor.SelectedIndex]).Color;
            Properties.Settings.Default.BGCOLOR = panel_overview.BackColor;

        }

        private void comboBox_selectionColor_SelectedIndexChanged(object sender, EventArgs e) {
            ImageGenerator.selectionColor = ((ColorSetting)comboBox_selectionColor.Items[comboBox_selectionColor.SelectedIndex]).Color;
            Properties.Settings.Default.SELCOLOR = ImageGenerator.selectionColor;

        }

        private void button_printAll_Click(object sender, EventArgs e) {
            MessageBoxInfo mbi = new MessageBoxInfo(Location.X, Location.Y, Width, Height);
            mbi.Show();
            List<Image> ListAll = db.loadEntries(null);
            int c = 0;
            foreach (Image i in ListAll) {
                mbi.addText((++c) + ".    " + i.getName() + " | Type: " + i.getFileType() + "\r\n\t Date       : " + i.getDate() + "\r\n\t Location   : " + i.getLocationString() + "\r\n\t Tags       : " + db.getConnectedTags(i.getName()) + "\r\n\t Description: " + i.getDescription() + "\r\n");
            }
        }

        private void checkBox_autoScale_CheckedChanged(object sender, EventArgs e) {
            ImageGenerator.autoscale = checkBox_autoScale.Checked;
            Properties.Settings.Default.AUTOSCALE = checkBox_autoScale.Checked;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            Properties.Settings.Default.Save();
            db.close();
        }

        private void checkBox_JoinTags_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.JOIN = checkBox_JoinTags.Checked;
        }

        /*
         * Add new search string to database
         */
        private void btn_fav_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(tb_search.Text)) {
                btn_fav.Text = "★";
                db.open();
                bool b = db.addFav(tb_search.Text);
                db.close();
                if (b) {
                    FavouriteElement fe = new FavouriteElement(tb_search.Text);
                    fe.resize(panel_favs.Width - SystemInformation.VerticalScrollBarWidth);
                    fe.delButton().Click += favDel_Click;
                    fe.copyButton().Click += favCpy_Click;
                    panel_favs.Controls.Add(fe);
                    panel_favs.Refresh();
                }
            }
        }

        private void favCpy_Click(object sender, EventArgs e) {
            FavouriteElement fe = (FavouriteElement)(((Button)sender).Parent).Parent;
            tb_search.Text = fe.getText();
            tabControl1.SelectedTab = tabPage_main;
            KeyEventArgs kea = new KeyEventArgs(Keys.Return);
            tb_search_KeyDown(null, kea);
        }

        private void favDel_Click(object sender, EventArgs e) {
            FavouriteElement fe = (FavouriteElement)(((Button)sender).Parent).Parent;
            panel_favs.Controls.Remove(fe);
            db.open();
            db.removeFav(fe.getText());
            db.close();
        }

        private void panel_favs_Resize(object sender, EventArgs e) {
            foreach (FavouriteElement fe in panel_favs.Controls) {
                fe.resize(panel_favs.Width - SystemInformation.VerticalScrollBarWidth);
            }
        }

        private void tb_search_TextChanged(object sender, EventArgs e) {
            btn_fav.Text = "☆";
        }

        /*
         * Handles change requests in multieditlist
         */
        private void updateMultiedit(Image i, EDITOPERATION op) {
            switch (op) {
                case EDITOPERATION.ADD:
                    if (!multiedit.Contains(i)) {
                        multiedit.Add(i);
                        i.showBorder(Properties.Settings.Default.BORDERSTYLE_FRAME);
                    }
                    break;
                case EDITOPERATION.REMOVE:
                    if (multiedit.Contains(i)) {
                        multiedit.Remove(i);
                        i.hideBorder();
                    }
                    break;
                case EDITOPERATION.SWITCH:
                    updateMultiedit(i, multiedit.Contains(i) ? EDITOPERATION.REMOVE : EDITOPERATION.ADD);
                    return;
            }
            updateLabel(multiedit.Count());
        }

        private void updateLabel(int first) {
            try {
                db.open();
                string t = (first == 0) ? "" : first + "/";
                t += shown.Count() + "/" + db.getEntryCount();
                db.close();
                tslabel_picturesof.Text = t;
            } catch { }
        }

        private void radioButton_SelectionMarker_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.BORDERSTYLE_FRAME = radioButton_Frame.Checked ? true : false;
        }

        private void trackBar_scale_Scroll(object sender, EventArgs e) {
            Properties.Settings.Default.GAPSCALE = 10 + 2 * trackBar_scale_gap.Value;
        }

        /* Disable Keys in tabcontrol to avoid switching to another tab while scroling through fotos*/
        private void tabControl1_KeyDown(object sender, KeyEventArgs e) {
            if (tabControl1.SelectedTab != tabPage_tags && (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)) {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            Properties.Settings.Default.QUICKINFO = checkBox_Quickinfo.Checked;

        }

        private void addFavElement(string[] favs) {
            foreach (string s in favs) {
                FavouriteElement fe = new FavouriteElement(s);
                fe.resize(panel_favs.Width - SystemInformation.VerticalScrollBarWidth);
                fe.delButton().Click += favDel_Click;
                fe.copyButton().Click += favCpy_Click;
                panel_favs.Controls.Add(fe);
            }
        }

        public void ClickedMap(string location) {
            tb_search.Text = "Location:" + location;
            tabControl1.SelectedTab = tabPage_main;
            newWorker();
        }
    }
}
