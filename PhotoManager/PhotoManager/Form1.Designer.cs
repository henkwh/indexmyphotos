namespace PhotoManager {
    partial class Form1 {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.panel_overview = new PhotoManager.CustomControls.FlowLayoutOverview();
            this.tabPage_viewer = new System.Windows.Forms.TabPage();
            this.pictureBox_viewer = new PhotoManager.CustomControls.PictureBoxViewer();
            this.tabPage_tags = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_dateday = new System.Windows.Forms.TextBox();
            this.tb_datemonth = new System.Windows.Forms.TextBox();
            this.tb_dateyear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_tags = new System.Windows.Forms.TextBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.btn_applytag = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tb_location = new System.Windows.Forms.TextBox();
            this.btn_showonMap = new System.Windows.Forms.Button();
            this.btn_tagtodefault = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_JoinTags = new System.Windows.Forms.CheckBox();
            this.btn_clearlist = new System.Windows.Forms.Button();
            this.panel_tagedit = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage_Map = new System.Windows.Forms.TabPage();
            this.tabPage_Settings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_deleteUnusedFiles = new System.Windows.Forms.Button();
            this.comboBox_bgColor = new System.Windows.Forms.ComboBox();
            this.lb_bgColor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_selectionColor = new System.Windows.Forms.ComboBox();
            this.btn_printAllEntries = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_autoScale = new System.Windows.Forms.CheckBox();
            this.btn_dropall = new System.Windows.Forms.Button();
            this.tabPage_favs = new System.Windows.Forms.TabPage();
            this.panel_favs = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tsprogressbar = new System.Windows.Forms.ProgressBar();
            this.tslabel_picturesof = new System.Windows.Forms.Label();
            this.combobox_sorting = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new PhotoManager.TrackBarControl();
            this.lb_Size = new System.Windows.Forms.Label();
            this.panel_tabHolder = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btn_fav = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabPage_viewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_viewer)).BeginInit();
            this.tabPage_tags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabPage_Settings.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tabPage_favs.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel_tabHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_search
            // 
            this.tb_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_search.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.Location = new System.Drawing.Point(0, 0);
            this.tb_search.Margin = new System.Windows.Forms.Padding(0);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(738, 30);
            this.tb_search.TabIndex = 0;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
            this.tb_search.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_viewer);
            this.tabControl1.Controls.Add(this.tabPage_tags);
            this.tabControl1.Controls.Add(this.tabPage_Map);
            this.tabControl1.Controls.Add(this.tabPage_Settings);
            this.tabControl1.Controls.Add(this.tabPage_favs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 326);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // tabPage_main
            // 
            this.tabPage_main.Controls.Add(this.panel_overview);
            this.tabPage_main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_main.Name = "tabPage_main";
            this.tabPage_main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_main.Size = new System.Drawing.Size(788, 300);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // panel_overview
            // 
            this.panel_overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_overview.Location = new System.Drawing.Point(3, 3);
            this.panel_overview.Margin = new System.Windows.Forms.Padding(0);
            this.panel_overview.Name = "panel_overview";
            this.panel_overview.Size = new System.Drawing.Size(782, 294);
            this.panel_overview.TabIndex = 0;
            this.panel_overview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel_overview_Scroll_1);
            // 
            // tabPage_viewer
            // 
            this.tabPage_viewer.Controls.Add(this.pictureBox_viewer);
            this.tabPage_viewer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_viewer.Name = "tabPage_viewer";
            this.tabPage_viewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_viewer.Size = new System.Drawing.Size(788, 300);
            this.tabPage_viewer.TabIndex = 5;
            this.tabPage_viewer.Text = "View";
            // 
            // pictureBox_viewer
            // 
            this.pictureBox_viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_viewer.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_viewer.Name = "pictureBox_viewer";
            this.pictureBox_viewer.ShownImage = null;
            this.pictureBox_viewer.Size = new System.Drawing.Size(782, 294);
            this.pictureBox_viewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_viewer.TabIndex = 0;
            this.pictureBox_viewer.TabStop = false;
            // 
            // tabPage_tags
            // 
            this.tabPage_tags.Controls.Add(this.splitContainer2);
            this.tabPage_tags.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tags.Name = "tabPage_tags";
            this.tabPage_tags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tags.Size = new System.Drawing.Size(788, 300);
            this.tabPage_tags.TabIndex = 1;
            this.tabPage_tags.Text = "Tag Editor";
            this.tabPage_tags.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_clearlist);
            this.splitContainer2.Panel2.Controls.Add(this.panel_tagedit);
            this.splitContainer2.Size = new System.Drawing.Size(782, 294);
            this.splitContainer2.SplitterDistance = 327;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.45455F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.54545F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tb_tags, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tb_description, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_applytag, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_tagtodefault, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 294);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tb_dateday, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_datemonth, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tb_dateyear, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(86, 73);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(238, 34);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tb_dateday
            // 
            this.tb_dateday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_dateday.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_dateday.Location = new System.Drawing.Point(3, 3);
            this.tb_dateday.MaxLength = 2;
            this.tb_dateday.Name = "tb_dateday";
            this.tb_dateday.Size = new System.Drawing.Size(53, 23);
            this.tb_dateday.TabIndex = 0;
            this.tb_dateday.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_datemonth
            // 
            this.tb_datemonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_datemonth.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_datemonth.Location = new System.Drawing.Point(62, 3);
            this.tb_datemonth.MaxLength = 2;
            this.tb_datemonth.Name = "tb_datemonth";
            this.tb_datemonth.Size = new System.Drawing.Size(53, 23);
            this.tb_datemonth.TabIndex = 0;
            this.tb_datemonth.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_dateyear
            // 
            this.tb_dateyear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_dateyear.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_dateyear.Location = new System.Drawing.Point(121, 3);
            this.tb_dateyear.MaxLength = 4;
            this.tb_dateyear.Name = "tb_dateyear";
            this.tb_dateyear.Size = new System.Drawing.Size(114, 23);
            this.tb_dateyear.TabIndex = 0;
            this.tb_dateyear.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 70);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 74);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_tags
            // 
            this.tb_tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_tags.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tags.Location = new System.Drawing.Point(86, 113);
            this.tb_tags.Multiline = true;
            this.tb_tags.Name = "tb_tags";
            this.tb_tags.Size = new System.Drawing.Size(238, 68);
            this.tb_tags.TabIndex = 0;
            this.tb_tags.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_description
            // 
            this.tb_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_description.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_description.Location = new System.Drawing.Point(86, 187);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(238, 68);
            this.tb_description.TabIndex = 2;
            this.tb_description.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btn_applytag
            // 
            this.btn_applytag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_applytag.Location = new System.Drawing.Point(86, 261);
            this.btn_applytag.Name = "btn_applytag";
            this.btn_applytag.Size = new System.Drawing.Size(238, 30);
            this.btn_applytag.TabIndex = 3;
            this.btn_applytag.Text = "OK";
            this.btn_applytag.UseVisualStyleBackColor = true;
            this.btn_applytag.Click += new System.EventHandler(this.btn_applytag_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(86, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tb_location);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btn_showonMap);
            this.splitContainer3.Size = new System.Drawing.Size(238, 64);
            this.splitContainer3.SplitterDistance = 31;
            this.splitContainer3.TabIndex = 0;
            // 
            // tb_location
            // 
            this.tb_location.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_location.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_location.Location = new System.Drawing.Point(0, 8);
            this.tb_location.Name = "tb_location";
            this.tb_location.Size = new System.Drawing.Size(238, 23);
            this.tb_location.TabIndex = 0;
            this.tb_location.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btn_showonMap
            // 
            this.btn_showonMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_showonMap.Location = new System.Drawing.Point(0, 0);
            this.btn_showonMap.Name = "btn_showonMap";
            this.btn_showonMap.Size = new System.Drawing.Size(238, 23);
            this.btn_showonMap.TabIndex = 0;
            this.btn_showonMap.Text = "Select from Map";
            this.btn_showonMap.UseVisualStyleBackColor = true;
            this.btn_showonMap.Click += new System.EventHandler(this.btn_showonMap_Click);
            // 
            // btn_tagtodefault
            // 
            this.btn_tagtodefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tagtodefault.Location = new System.Drawing.Point(3, 261);
            this.btn_tagtodefault.Name = "btn_tagtodefault";
            this.btn_tagtodefault.Size = new System.Drawing.Size(77, 30);
            this.btn_tagtodefault.TabIndex = 5;
            this.btn_tagtodefault.Text = "Default Tag";
            this.btn_tagtodefault.UseVisualStyleBackColor = true;
            this.btn_tagtodefault.Click += new System.EventHandler(this.btn_tagtodefault_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(3, 113);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.checkBox_JoinTags);
            this.splitContainer1.Size = new System.Drawing.Size(77, 68);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 39);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tags";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // checkBox_JoinTags
            // 
            this.checkBox_JoinTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox_JoinTags.Location = new System.Drawing.Point(16, 0);
            this.checkBox_JoinTags.Name = "checkBox_JoinTags";
            this.checkBox_JoinTags.Size = new System.Drawing.Size(61, 25);
            this.checkBox_JoinTags.TabIndex = 0;
            this.checkBox_JoinTags.Text = "Join";
            this.checkBox_JoinTags.UseVisualStyleBackColor = true;
            this.checkBox_JoinTags.CheckedChanged += new System.EventHandler(this.checkBox_JoinTags_CheckedChanged);
            // 
            // btn_clearlist
            // 
            this.btn_clearlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clearlist.Location = new System.Drawing.Point(371, 257);
            this.btn_clearlist.Name = "btn_clearlist";
            this.btn_clearlist.Size = new System.Drawing.Size(77, 34);
            this.btn_clearlist.TabIndex = 4;
            this.btn_clearlist.Text = "Clear List";
            this.btn_clearlist.UseVisualStyleBackColor = true;
            this.btn_clearlist.Click += new System.EventHandler(this.btn_clearlist_Click);
            // 
            // panel_tagedit
            // 
            this.panel_tagedit.AutoScroll = true;
            this.panel_tagedit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tagedit.Location = new System.Drawing.Point(0, 0);
            this.panel_tagedit.Name = "panel_tagedit";
            this.panel_tagedit.Size = new System.Drawing.Size(451, 294);
            this.panel_tagedit.TabIndex = 0;
            // 
            // tabPage_Map
            // 
            this.tabPage_Map.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Map.Name = "tabPage_Map";
            this.tabPage_Map.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Map.Size = new System.Drawing.Size(788, 300);
            this.tabPage_Map.TabIndex = 3;
            this.tabPage_Map.Text = "Map";
            this.tabPage_Map.UseVisualStyleBackColor = true;
            // 
            // tabPage_Settings
            // 
            this.tabPage_Settings.Controls.Add(this.tableLayoutPanel5);
            this.tabPage_Settings.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Settings.Name = "tabPage_Settings";
            this.tabPage_Settings.Size = new System.Drawing.Size(788, 300);
            this.tabPage_Settings.TabIndex = 6;
            this.tabPage_Settings.Text = "Settings";
            this.tabPage_Settings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.btn_deleteUnusedFiles, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.comboBox_bgColor, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.lb_bgColor, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.comboBox_selectionColor, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.btn_printAllEntries, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.checkBox_autoScale, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.btn_dropall, 0, 4);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(154, 22);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 5;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.19588F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.80412F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(416, 248);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_deleteUnusedFiles
            // 
            this.btn_deleteUnusedFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_deleteUnusedFiles.Location = new System.Drawing.Point(3, 3);
            this.btn_deleteUnusedFiles.Name = "btn_deleteUnusedFiles";
            this.btn_deleteUnusedFiles.Size = new System.Drawing.Size(202, 35);
            this.btn_deleteUnusedFiles.TabIndex = 0;
            this.btn_deleteUnusedFiles.Text = "Delete unused Files";
            this.btn_deleteUnusedFiles.UseVisualStyleBackColor = true;
            this.btn_deleteUnusedFiles.Click += new System.EventHandler(this.btn_deleteUnusedFiles_Click);
            // 
            // comboBox_bgColor
            // 
            this.comboBox_bgColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_bgColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_bgColor.FormattingEnabled = true;
            this.comboBox_bgColor.Location = new System.Drawing.Point(211, 92);
            this.comboBox_bgColor.Name = "comboBox_bgColor";
            this.comboBox_bgColor.Size = new System.Drawing.Size(202, 21);
            this.comboBox_bgColor.TabIndex = 1;
            this.comboBox_bgColor.SelectedIndexChanged += new System.EventHandler(this.comboBox_bgColor_SelectedIndexChanged);
            // 
            // lb_bgColor
            // 
            this.lb_bgColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_bgColor.Location = new System.Drawing.Point(3, 89);
            this.lb_bgColor.Name = "lb_bgColor";
            this.lb_bgColor.Size = new System.Drawing.Size(202, 32);
            this.lb_bgColor.TabIndex = 2;
            this.lb_bgColor.Text = "Background color";
            this.lb_bgColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Selection color";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_selectionColor
            // 
            this.comboBox_selectionColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_selectionColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_selectionColor.FormattingEnabled = true;
            this.comboBox_selectionColor.Location = new System.Drawing.Point(211, 124);
            this.comboBox_selectionColor.Name = "comboBox_selectionColor";
            this.comboBox_selectionColor.Size = new System.Drawing.Size(202, 21);
            this.comboBox_selectionColor.TabIndex = 4;
            this.comboBox_selectionColor.SelectedIndexChanged += new System.EventHandler(this.comboBox_selectionColor_SelectedIndexChanged);
            // 
            // btn_printAllEntries
            // 
            this.btn_printAllEntries.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_printAllEntries.Location = new System.Drawing.Point(211, 3);
            this.btn_printAllEntries.Name = "btn_printAllEntries";
            this.btn_printAllEntries.Size = new System.Drawing.Size(202, 35);
            this.btn_printAllEntries.TabIndex = 5;
            this.btn_printAllEntries.Text = "Print all Entries";
            this.btn_printAllEntries.UseVisualStyleBackColor = true;
            this.btn_printAllEntries.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 68);
            this.label6.TabIndex = 6;
            this.label6.Text = "Autoscale gaps between images";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_autoScale
            // 
            this.checkBox_autoScale.Checked = true;
            this.checkBox_autoScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoScale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_autoScale.Location = new System.Drawing.Point(211, 150);
            this.checkBox_autoScale.Name = "checkBox_autoScale";
            this.checkBox_autoScale.Size = new System.Drawing.Size(202, 62);
            this.checkBox_autoScale.TabIndex = 7;
            this.checkBox_autoScale.Text = "Enbable Autoscale";
            this.checkBox_autoScale.UseVisualStyleBackColor = true;
            this.checkBox_autoScale.CheckedChanged += new System.EventHandler(this.checkBox_autoScale_CheckedChanged);
            // 
            // btn_dropall
            // 
            this.btn_dropall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_dropall.Location = new System.Drawing.Point(3, 218);
            this.btn_dropall.Name = "btn_dropall";
            this.btn_dropall.Size = new System.Drawing.Size(202, 27);
            this.btn_dropall.TabIndex = 8;
            this.btn_dropall.Text = "Drop all Tables";
            this.btn_dropall.UseVisualStyleBackColor = true;
            this.btn_dropall.Click += new System.EventHandler(this.btn_dropall_Click);
            // 
            // tabPage_favs
            // 
            this.tabPage_favs.Controls.Add(this.panel_favs);
            this.tabPage_favs.Location = new System.Drawing.Point(4, 22);
            this.tabPage_favs.Name = "tabPage_favs";
            this.tabPage_favs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_favs.Size = new System.Drawing.Size(788, 300);
            this.tabPage_favs.TabIndex = 7;
            this.tabPage_favs.Text = "★";
            this.tabPage_favs.UseVisualStyleBackColor = true;
            // 
            // panel_favs
            // 
            this.panel_favs.AutoScroll = true;
            this.panel_favs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_favs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel_favs.Location = new System.Drawing.Point(3, 3);
            this.panel_favs.Name = "panel_favs";
            this.panel_favs.Size = new System.Drawing.Size(782, 294);
            this.panel_favs.TabIndex = 0;
            this.panel_favs.WrapContents = false;
            this.panel_favs.Resize += new System.EventHandler(this.panel_favs_Resize);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel_tabHolder, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 405);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.98167F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.01833F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 194F));
            this.tableLayoutPanel4.Controls.Add(this.tsprogressbar, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tslabel_picturesof, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.combobox_sorting, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.trackBar1, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.lb_Size, 4, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 382);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(802, 23);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // tsprogressbar
            // 
            this.tsprogressbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsprogressbar.Location = new System.Drawing.Point(78, 3);
            this.tsprogressbar.Name = "tsprogressbar";
            this.tsprogressbar.Size = new System.Drawing.Size(144, 17);
            this.tsprogressbar.TabIndex = 1;
            // 
            // tslabel_picturesof
            // 
            this.tslabel_picturesof.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tslabel_picturesof.Location = new System.Drawing.Point(3, 3);
            this.tslabel_picturesof.Margin = new System.Windows.Forms.Padding(3);
            this.tslabel_picturesof.Name = "tslabel_picturesof";
            this.tslabel_picturesof.Size = new System.Drawing.Size(69, 17);
            this.tslabel_picturesof.TabIndex = 0;
            this.tslabel_picturesof.Text = "0/0";
            this.tslabel_picturesof.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combobox_sorting
            // 
            this.combobox_sorting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combobox_sorting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobox_sorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.combobox_sorting.FormattingEnabled = true;
            this.combobox_sorting.IntegralHeight = false;
            this.combobox_sorting.ItemHeight = 13;
            this.combobox_sorting.Location = new System.Drawing.Point(225, 0);
            this.combobox_sorting.Margin = new System.Windows.Forms.Padding(0);
            this.combobox_sorting.Name = "combobox_sorting";
            this.combobox_sorting.Size = new System.Drawing.Size(198, 21);
            this.combobox_sorting.TabIndex = 5;
            this.combobox_sorting.TextChanged += new System.EventHandler(this.combobox_sorting_TextChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(610, 3);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(189, 17);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lb_Size
            // 
            this.lb_Size.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Size.Location = new System.Drawing.Point(575, 0);
            this.lb_Size.Name = "lb_Size";
            this.lb_Size.Size = new System.Drawing.Size(29, 23);
            this.lb_Size.TabIndex = 4;
            this.lb_Size.Text = "Size";
            this.lb_Size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_tabHolder
            // 
            this.panel_tabHolder.Controls.Add(this.tabControl1);
            this.panel_tabHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tabHolder.Location = new System.Drawing.Point(3, 53);
            this.panel_tabHolder.Name = "panel_tabHolder";
            this.panel_tabHolder.Size = new System.Drawing.Size(796, 326);
            this.panel_tabHolder.TabIndex = 3;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.Location = new System.Drawing.Point(10, 10);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.tb_search);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.btn_fav);
            this.splitContainer4.Size = new System.Drawing.Size(782, 30);
            this.splitContainer4.SplitterDistance = 738;
            this.splitContainer4.TabIndex = 5;
            // 
            // btn_fav
            // 
            this.btn_fav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_fav.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_fav.Font = new System.Drawing.Font("Wide Latin", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_fav.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_fav.Location = new System.Drawing.Point(0, 0);
            this.btn_fav.Name = "btn_fav";
            this.btn_fav.Size = new System.Drawing.Size(40, 30);
            this.btn_fav.TabIndex = 0;
            this.btn_fav.Text = "☆";
            this.btn_fav.UseVisualStyleBackColor = true;
            this.btn_fav.Click += new System.EventHandler(this.btn_fav_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 405);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "indexmyphotos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_viewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_viewer)).EndInit();
            this.tabPage_tags.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabPage_Settings.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tabPage_favs.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel_tabHolder.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.TabPage tabPage_tags;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tb_location;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_tags;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.FlowLayoutPanel panel_tagedit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tb_dateday;
        private System.Windows.Forms.TextBox tb_datemonth;
        private System.Windows.Forms.TextBox tb_dateyear;
        private System.Windows.Forms.Button btn_clearlist;
        private System.Windows.Forms.TabPage tabPage_Map;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btn_showonMap;
        private System.Windows.Forms.TabPage tabPage_viewer;
        private System.Windows.Forms.Button btn_applytag;
        private System.Windows.Forms.Button btn_tagtodefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tslabel_picturesof;
        private System.Windows.Forms.ProgressBar tsprogressbar;
        private System.Windows.Forms.Panel panel_tabHolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lb_Size;
        private System.Windows.Forms.ComboBox combobox_sorting;
        private TrackBarControl trackBar1;
        private CustomControls.PictureBoxViewer pictureBox_viewer;
        private CustomControls.FlowLayoutOverview panel_overview;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox checkBox_JoinTags;
        private System.Windows.Forms.TabPage tabPage_Settings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_deleteUnusedFiles;
        private System.Windows.Forms.ComboBox comboBox_bgColor;
        private System.Windows.Forms.Label lb_bgColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_selectionColor;
        private System.Windows.Forms.Button btn_printAllEntries;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBox_autoScale;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.TabPage tabPage_favs;
        private System.Windows.Forms.FlowLayoutPanel panel_favs;
        private System.Windows.Forms.Button btn_fav;
        private System.Windows.Forms.Button btn_dropall;
    }
}

