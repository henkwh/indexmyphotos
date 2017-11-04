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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.panel_overview = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage_viewer = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage_Log = new System.Windows.Forms.TabPage();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.tabPage_tags = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tb_dateday = new System.Windows.Forms.TextBox();
            this.tb_datemonth = new System.Windows.Forms.TextBox();
            this.tb_dateyear = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_tags = new System.Windows.Forms.TextBox();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.btn_applytag = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tb_location = new System.Windows.Forms.TextBox();
            this.btn_showonMap = new System.Windows.Forms.Button();
            this.btn_tagtodefault = new System.Windows.Forms.Button();
            this.btn_clearlist = new System.Windows.Forms.Button();
            this.panel_tagedit = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage_Map = new System.Windows.Forms.TabPage();
            this.tabPage_history = new System.Windows.Forms.TabPage();
            this.tb_history = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tslabel_picturesof = new System.Windows.Forms.Label();
            this.tsprogressbar = new System.Windows.Forms.ProgressBar();
            this.panel_tabHolder = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lb_Size = new System.Windows.Forms.Label();
            this.lb_Info = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage_main.SuspendLayout();
            this.tabPage_viewer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage_Log.SuspendLayout();
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
            this.tabPage_history.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_tabHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_search
            // 
            this.tb_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_search.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.Location = new System.Drawing.Point(10, 10);
            this.tb_search.Margin = new System.Windows.Forms.Padding(10);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(782, 30);
            this.tb_search.TabIndex = 0;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
            this.tb_search.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_viewer);
            this.tabControl1.Controls.Add(this.tabPage_Log);
            this.tabControl1.Controls.Add(this.tabPage_tags);
            this.tabControl1.Controls.Add(this.tabPage_Map);
            this.tabControl1.Controls.Add(this.tabPage_history);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(796, 328);
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
            this.tabPage_main.Size = new System.Drawing.Size(788, 302);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // panel_overview
            // 
            this.panel_overview.AutoScroll = true;
            this.panel_overview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_overview.Location = new System.Drawing.Point(3, 3);
            this.panel_overview.Name = "panel_overview";
            this.panel_overview.Size = new System.Drawing.Size(782, 296);
            this.panel_overview.TabIndex = 0;
            this.panel_overview.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_overview_Paint);
            this.panel_overview.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // tabPage_viewer
            // 
            this.tabPage_viewer.Controls.Add(this.pictureBox1);
            this.tabPage_viewer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_viewer.Name = "tabPage_viewer";
            this.tabPage_viewer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_viewer.Size = new System.Drawing.Size(788, 302);
            this.tabPage_viewer.TabIndex = 5;
            this.tabPage_viewer.Text = "View";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(782, 296);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.Controls.Add(this.tb_log);
            this.tabPage_Log.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Size = new System.Drawing.Size(788, 218);
            this.tabPage_Log.TabIndex = 2;
            this.tabPage_Log.Text = "Overview";
            this.tabPage_Log.UseVisualStyleBackColor = true;
            // 
            // tb_log
            // 
            this.tb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_log.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_log.Location = new System.Drawing.Point(0, 0);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tb_log.Size = new System.Drawing.Size(788, 218);
            this.tb_log.TabIndex = 0;
            this.tb_log.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage_tags
            // 
            this.tabPage_tags.Controls.Add(this.splitContainer2);
            this.tabPage_tags.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tags.Name = "tabPage_tags";
            this.tabPage_tags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tags.Size = new System.Drawing.Size(788, 302);
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
            this.splitContainer2.Size = new System.Drawing.Size(782, 296);
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
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tb_tags, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.tb_description, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_applytag, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_tagtodefault, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(327, 296);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 75);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tags";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 75);
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
            this.tb_tags.Size = new System.Drawing.Size(238, 69);
            this.tb_tags.TabIndex = 0;
            this.tb_tags.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_description
            // 
            this.tb_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_description.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_description.Location = new System.Drawing.Point(86, 188);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(238, 69);
            this.tb_description.TabIndex = 2;
            this.tb_description.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btn_applytag
            // 
            this.btn_applytag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_applytag.Location = new System.Drawing.Point(86, 263);
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
            this.btn_tagtodefault.Location = new System.Drawing.Point(3, 263);
            this.btn_tagtodefault.Name = "btn_tagtodefault";
            this.btn_tagtodefault.Size = new System.Drawing.Size(77, 30);
            this.btn_tagtodefault.TabIndex = 5;
            this.btn_tagtodefault.Text = "Default Tag";
            this.btn_tagtodefault.UseVisualStyleBackColor = true;
            this.btn_tagtodefault.Click += new System.EventHandler(this.btn_tagtodefault_Click);
            // 
            // btn_clearlist
            // 
            this.btn_clearlist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clearlist.Location = new System.Drawing.Point(371, 259);
            this.btn_clearlist.Name = "btn_clearlist";
            this.btn_clearlist.Size = new System.Drawing.Size(77, 34);
            this.btn_clearlist.TabIndex = 4;
            this.btn_clearlist.Text = "Clear List";
            this.btn_clearlist.UseVisualStyleBackColor = true;
            this.btn_clearlist.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel_tagedit
            // 
            this.panel_tagedit.AutoScroll = true;
            this.panel_tagedit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tagedit.Location = new System.Drawing.Point(0, 0);
            this.panel_tagedit.Name = "panel_tagedit";
            this.panel_tagedit.Size = new System.Drawing.Size(451, 296);
            this.panel_tagedit.TabIndex = 0;
            // 
            // tabPage_Map
            // 
            this.tabPage_Map.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Map.Name = "tabPage_Map";
            this.tabPage_Map.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Map.Size = new System.Drawing.Size(788, 245);
            this.tabPage_Map.TabIndex = 3;
            this.tabPage_Map.Text = "Map";
            this.tabPage_Map.UseVisualStyleBackColor = true;
            // 
            // tabPage_history
            // 
            this.tabPage_history.Controls.Add(this.tb_history);
            this.tabPage_history.Location = new System.Drawing.Point(4, 22);
            this.tabPage_history.Name = "tabPage_history";
            this.tabPage_history.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_history.Size = new System.Drawing.Size(788, 245);
            this.tabPage_history.TabIndex = 4;
            this.tabPage_history.Text = "History";
            this.tabPage_history.UseVisualStyleBackColor = true;
            // 
            // tb_history
            // 
            this.tb_history.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_history.Location = new System.Drawing.Point(3, 3);
            this.tb_history.Multiline = true;
            this.tb_history.Name = "tb_history";
            this.tb_history.ReadOnly = true;
            this.tb_history.Size = new System.Drawing.Size(782, 239);
            this.tb_history.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tb_search, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_tabHolder, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(802, 405);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tslabel_picturesof
            // 
            this.tslabel_picturesof.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tslabel_picturesof.Location = new System.Drawing.Point(3, 3);
            this.tslabel_picturesof.Margin = new System.Windows.Forms.Padding(3);
            this.tslabel_picturesof.Name = "tslabel_picturesof";
            this.tslabel_picturesof.Size = new System.Drawing.Size(69, 15);
            this.tslabel_picturesof.TabIndex = 0;
            this.tslabel_picturesof.Text = "100/100";
            this.tslabel_picturesof.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsprogressbar
            // 
            this.tsprogressbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsprogressbar.Location = new System.Drawing.Point(78, 3);
            this.tsprogressbar.Name = "tsprogressbar";
            this.tsprogressbar.Size = new System.Drawing.Size(144, 15);
            this.tsprogressbar.TabIndex = 1;
            // 
            // panel_tabHolder
            // 
            this.panel_tabHolder.Controls.Add(this.tabControl1);
            this.panel_tabHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_tabHolder.Location = new System.Drawing.Point(3, 53);
            this.panel_tabHolder.Name = "panel_tabHolder";
            this.panel_tabHolder.Size = new System.Drawing.Size(796, 328);
            this.panel_tabHolder.TabIndex = 3;
            this.panel_tabHolder.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // trackBar1
            // 
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar1.Location = new System.Drawing.Point(635, 3);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(144, 15);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(782, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 21);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.tsprogressbar, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tslabel_picturesof, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.trackBar1, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.pictureBox2, 5, 0);
            this.tableLayoutPanel4.Controls.Add(this.lb_Size, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.lb_Info, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 384);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(802, 21);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // lb_Size
            // 
            this.lb_Size.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Size.Location = new System.Drawing.Point(600, 0);
            this.lb_Size.Name = "lb_Size";
            this.lb_Size.Size = new System.Drawing.Size(29, 21);
            this.lb_Size.TabIndex = 4;
            this.lb_Size.Text = "Size";
            this.lb_Size.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lb_Info
            // 
            this.lb_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Info.Location = new System.Drawing.Point(235, 0);
            this.lb_Info.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.lb_Info.Name = "lb_Info";
            this.lb_Info.Size = new System.Drawing.Size(352, 21);
            this.lb_Info.TabIndex = 5;
            this.lb_Info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 405);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_viewer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage_Log.ResumeLayout(false);
            this.tabPage_Log.PerformLayout();
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
            this.tabPage_history.ResumeLayout(false);
            this.tabPage_history.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_tabHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_main;
        private System.Windows.Forms.FlowLayoutPanel panel_overview;
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
        private System.Windows.Forms.TabPage tabPage_Log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tb_dateday;
        private System.Windows.Forms.TextBox tb_datemonth;
        private System.Windows.Forms.TextBox tb_dateyear;
        private System.Windows.Forms.Button btn_clearlist;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.TabPage tabPage_Map;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btn_showonMap;
        private System.Windows.Forms.TabPage tabPage_history;
        private System.Windows.Forms.TextBox tb_history;
        private System.Windows.Forms.TabPage tabPage_viewer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_applytag;
        private System.Windows.Forms.Button btn_tagtodefault;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label tslabel_picturesof;
        private System.Windows.Forms.ProgressBar tsprogressbar;
        private System.Windows.Forms.Panel panel_tabHolder;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lb_Size;
        private System.Windows.Forms.Label lb_Info;
    }
}

