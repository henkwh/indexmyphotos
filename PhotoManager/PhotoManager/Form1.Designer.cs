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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pb_loaded = new System.Windows.Forms.ProgressBar();
            this.label_picturesof = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_main = new System.Windows.Forms.TabPage();
            this.panel_overview = new System.Windows.Forms.FlowLayoutPanel();
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
            this.btn_clearlist = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tb_location = new System.Windows.Forms.TextBox();
            this.btn_showonMap = new System.Windows.Forms.Button();
            this.btn_tagtodefault = new System.Windows.Forms.Button();
            this.panel_tagedit = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage_Map = new System.Windows.Forms.TabPage();
            this.tabPage_history = new System.Windows.Forms.TabPage();
            this.tb_history = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_main.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(802, 42);
            this.splitContainer1.SplitterDistance = 691;
            this.splitContainer1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.tb_search);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(7);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(691, 42);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tb_search
            // 
            this.tb_search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_search.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_search.Location = new System.Drawing.Point(7, 7);
            this.tb_search.Margin = new System.Windows.Forms.Padding(0);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(680, 30);
            this.tb_search.TabIndex = 0;
            this.tb_search.TextChanged += new System.EventHandler(this.tb_search_TextChanged);
            this.tb_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_search_KeyDown);
            this.tb_search.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pb_loaded, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_picturesof, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(107, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pb_loaded
            // 
            this.pb_loaded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_loaded.Location = new System.Drawing.Point(3, 3);
            this.pb_loaded.Name = "pb_loaded";
            this.pb_loaded.Size = new System.Drawing.Size(101, 15);
            this.pb_loaded.TabIndex = 0;
            // 
            // label_picturesof
            // 
            this.label_picturesof.AutoSize = true;
            this.label_picturesof.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_picturesof.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_picturesof.Location = new System.Drawing.Point(3, 21);
            this.label_picturesof.Name = "label_picturesof";
            this.label_picturesof.Size = new System.Drawing.Size(101, 21);
            this.label_picturesof.TabIndex = 1;
            this.label_picturesof.Text = "0/0";
            this.label_picturesof.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_main);
            this.tabControl1.Controls.Add(this.tabPage_Log);
            this.tabControl1.Controls.Add(this.tabPage_tags);
            this.tabControl1.Controls.Add(this.tabPage_Map);
            this.tabControl1.Controls.Add(this.tabPage_history);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(802, 403);
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
            this.tabPage_main.Size = new System.Drawing.Size(794, 377);
            this.tabPage_main.TabIndex = 0;
            this.tabPage_main.Text = "Main";
            this.tabPage_main.UseVisualStyleBackColor = true;
            // 
            // panel_overview
            // 
            this.panel_overview.AutoScroll = true;
            this.panel_overview.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_overview.Location = new System.Drawing.Point(3, 3);
            this.panel_overview.Name = "panel_overview";
            this.panel_overview.Size = new System.Drawing.Size(788, 359);
            this.panel_overview.TabIndex = 0;
            this.panel_overview.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_overview_Paint);
            this.panel_overview.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            // 
            // tabPage_Log
            // 
            this.tabPage_Log.Controls.Add(this.tb_log);
            this.tabPage_Log.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Log.Name = "tabPage_Log";
            this.tabPage_Log.Size = new System.Drawing.Size(794, 377);
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
            this.tb_log.Size = new System.Drawing.Size(794, 377);
            this.tb_log.TabIndex = 0;
            this.tb_log.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // tabPage_tags
            // 
            this.tabPage_tags.Controls.Add(this.splitContainer2);
            this.tabPage_tags.Location = new System.Drawing.Point(4, 22);
            this.tabPage_tags.Name = "tabPage_tags";
            this.tabPage_tags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_tags.Size = new System.Drawing.Size(794, 377);
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
            this.splitContainer2.Panel2.Controls.Add(this.panel_tagedit);
            this.splitContainer2.Size = new System.Drawing.Size(788, 371);
            this.splitContainer2.SplitterDistance = 330;
            this.splitContainer2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.45455F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.54546F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tb_tags, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tb_description, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.btn_applytag, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btn_clearlist, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer3, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_tagtodefault, 0, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 371);
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
            this.tableLayoutPanel3.Location = new System.Drawing.Point(87, 109);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 73);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tb_dateday
            // 
            this.tb_dateday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_dateday.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_dateday.Location = new System.Drawing.Point(3, 3);
            this.tb_dateday.MaxLength = 2;
            this.tb_dateday.Name = "tb_dateday";
            this.tb_dateday.Size = new System.Drawing.Size(54, 23);
            this.tb_dateday.TabIndex = 0;
            this.tb_dateday.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_datemonth
            // 
            this.tb_datemonth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_datemonth.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_datemonth.Location = new System.Drawing.Point(63, 3);
            this.tb_datemonth.MaxLength = 2;
            this.tb_datemonth.Name = "tb_datemonth";
            this.tb_datemonth.Size = new System.Drawing.Size(54, 23);
            this.tb_datemonth.TabIndex = 0;
            this.tb_datemonth.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_dateyear
            // 
            this.tb_dateyear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_dateyear.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_dateyear.Location = new System.Drawing.Point(123, 3);
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
            this.label1.Size = new System.Drawing.Size(78, 106);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 79);
            this.label2.TabIndex = 1;
            this.label2.Text = "Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 64);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tags";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 54);
            this.label4.TabIndex = 1;
            this.label4.Text = "Description";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_tags
            // 
            this.tb_tags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_tags.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_tags.Location = new System.Drawing.Point(87, 188);
            this.tb_tags.Multiline = true;
            this.tb_tags.Name = "tb_tags";
            this.tb_tags.Size = new System.Drawing.Size(240, 58);
            this.tb_tags.TabIndex = 0;
            this.tb_tags.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // tb_description
            // 
            this.tb_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_description.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_description.Location = new System.Drawing.Point(87, 252);
            this.tb_description.Multiline = true;
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(240, 48);
            this.tb_description.TabIndex = 2;
            this.tb_description.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btn_applytag
            // 
            this.btn_applytag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_applytag.Location = new System.Drawing.Point(87, 306);
            this.btn_applytag.Name = "btn_applytag";
            this.btn_applytag.Size = new System.Drawing.Size(240, 27);
            this.btn_applytag.TabIndex = 3;
            this.btn_applytag.Text = "OK";
            this.btn_applytag.UseVisualStyleBackColor = true;
            this.btn_applytag.Click += new System.EventHandler(this.btn_applytag_Click);
            // 
            // btn_clearlist
            // 
            this.btn_clearlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_clearlist.Location = new System.Drawing.Point(3, 306);
            this.btn_clearlist.Name = "btn_clearlist";
            this.btn_clearlist.Size = new System.Drawing.Size(78, 27);
            this.btn_clearlist.TabIndex = 4;
            this.btn_clearlist.Text = "Clear List";
            this.btn_clearlist.UseVisualStyleBackColor = true;
            this.btn_clearlist.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(87, 3);
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
            this.splitContainer3.Size = new System.Drawing.Size(240, 100);
            this.splitContainer3.SplitterDistance = 41;
            this.splitContainer3.TabIndex = 0;
            // 
            // tb_location
            // 
            this.tb_location.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_location.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_location.Location = new System.Drawing.Point(0, 0);
            this.tb_location.Name = "tb_location";
            this.tb_location.Size = new System.Drawing.Size(240, 23);
            this.tb_location.TabIndex = 0;
            this.tb_location.TextChanged += new System.EventHandler(this.tb_TextChanged);
            // 
            // btn_showonMap
            // 
            this.btn_showonMap.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_showonMap.Location = new System.Drawing.Point(0, 0);
            this.btn_showonMap.Name = "btn_showonMap";
            this.btn_showonMap.Size = new System.Drawing.Size(240, 23);
            this.btn_showonMap.TabIndex = 0;
            this.btn_showonMap.Text = "Select from Map";
            this.btn_showonMap.UseVisualStyleBackColor = true;
            this.btn_showonMap.Click += new System.EventHandler(this.btn_showonMap_Click);
            // 
            // btn_tagtodefault
            // 
            this.btn_tagtodefault.Location = new System.Drawing.Point(3, 339);
            this.btn_tagtodefault.Name = "btn_tagtodefault";
            this.btn_tagtodefault.Size = new System.Drawing.Size(75, 23);
            this.btn_tagtodefault.TabIndex = 5;
            this.btn_tagtodefault.Text = "Default Tag";
            this.btn_tagtodefault.UseVisualStyleBackColor = true;
            this.btn_tagtodefault.Click += new System.EventHandler(this.btn_tagtodefault_Click);
            // 
            // panel_tagedit
            // 
            this.panel_tagedit.AutoScroll = true;
            this.panel_tagedit.Location = new System.Drawing.Point(0, 0);
            this.panel_tagedit.Name = "panel_tagedit";
            this.panel_tagedit.Size = new System.Drawing.Size(454, 359);
            this.panel_tagedit.TabIndex = 0;
            // 
            // tabPage_Map
            // 
            this.tabPage_Map.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Map.Name = "tabPage_Map";
            this.tabPage_Map.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Map.Size = new System.Drawing.Size(794, 377);
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
            this.tabPage_history.Size = new System.Drawing.Size(794, 377);
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
            this.tb_history.Size = new System.Drawing.Size(788, 371);
            this.tb_history.TabIndex = 0;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 445);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_main.ResumeLayout(false);
            this.tabPage_Log.ResumeLayout(false);
            this.tabPage_Log.PerformLayout();
            this.tabPage_tags.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar pb_loaded;
        private System.Windows.Forms.Label label_picturesof;
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
        private System.Windows.Forms.Button btn_applytag;
        private System.Windows.Forms.FlowLayoutPanel panel_tagedit;
        private System.Windows.Forms.TabPage tabPage_Log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox tb_dateday;
        private System.Windows.Forms.TextBox tb_datemonth;
        private System.Windows.Forms.TextBox tb_dateyear;
        private System.Windows.Forms.Button btn_clearlist;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabPage tabPage_Map;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btn_showonMap;
        private System.Windows.Forms.Button btn_tagtodefault;
        private System.Windows.Forms.TabPage tabPage_history;
        private System.Windows.Forms.TextBox tb_history;
    }
}

