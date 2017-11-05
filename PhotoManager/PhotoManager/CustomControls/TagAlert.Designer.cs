namespace PhotoManager {
    partial class TagAlert {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pb_previewtagedit = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_tagAlert_join = new System.Windows.Forms.Button();
            this.btn_tagAlert_joinall = new System.Windows.Forms.Button();
            this.btn_tagAlert_overwrite = new System.Windows.Forms.Button();
            this.btn_tagAlert_overwriteall = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_previewtagedit)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(692, 237);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pb_previewtagedit);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Panel1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.splitContainer2_Panel1_PreviewKeyDown);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(692, 178);
            this.splitContainer2.SplitterDistance = 199;
            this.splitContainer2.TabIndex = 0;
            // 
            // pb_previewtagedit
            // 
            this.pb_previewtagedit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_previewtagedit.Location = new System.Drawing.Point(0, 0);
            this.pb_previewtagedit.Name = "pb_previewtagedit";
            this.pb_previewtagedit.Size = new System.Drawing.Size(199, 178);
            this.pb_previewtagedit.TabIndex = 0;
            this.pb_previewtagedit.TabStop = false;
            this.pb_previewtagedit.Click += new System.EventHandler(this.pb_previewtagedit_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 178);
            this.label1.TabIndex = 0;
            this.label1.Text = "label_info";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_tagAlert_join, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_tagAlert_joinall, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_tagAlert_overwrite, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_tagAlert_overwriteall, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Cancel, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 55);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_tagAlert_join
            // 
            this.btn_tagAlert_join.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tagAlert_join.Location = new System.Drawing.Point(10, 10);
            this.btn_tagAlert_join.Margin = new System.Windows.Forms.Padding(10);
            this.btn_tagAlert_join.Name = "btn_tagAlert_join";
            this.btn_tagAlert_join.Size = new System.Drawing.Size(118, 35);
            this.btn_tagAlert_join.TabIndex = 0;
            this.btn_tagAlert_join.Text = "Join";
            this.btn_tagAlert_join.UseVisualStyleBackColor = true;
            this.btn_tagAlert_join.Click += new System.EventHandler(this.btn_tagAlert_join_Click);
            // 
            // btn_tagAlert_joinall
            // 
            this.btn_tagAlert_joinall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tagAlert_joinall.Location = new System.Drawing.Point(148, 10);
            this.btn_tagAlert_joinall.Margin = new System.Windows.Forms.Padding(10);
            this.btn_tagAlert_joinall.Name = "btn_tagAlert_joinall";
            this.btn_tagAlert_joinall.Size = new System.Drawing.Size(118, 35);
            this.btn_tagAlert_joinall.TabIndex = 0;
            this.btn_tagAlert_joinall.Text = "Join all";
            this.btn_tagAlert_joinall.UseVisualStyleBackColor = true;
            this.btn_tagAlert_joinall.Click += new System.EventHandler(this.btn_tagAlert_joinall_Click);
            // 
            // btn_tagAlert_overwrite
            // 
            this.btn_tagAlert_overwrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tagAlert_overwrite.Location = new System.Drawing.Point(286, 10);
            this.btn_tagAlert_overwrite.Margin = new System.Windows.Forms.Padding(10);
            this.btn_tagAlert_overwrite.Name = "btn_tagAlert_overwrite";
            this.btn_tagAlert_overwrite.Size = new System.Drawing.Size(118, 35);
            this.btn_tagAlert_overwrite.TabIndex = 0;
            this.btn_tagAlert_overwrite.Text = "Overwrite";
            this.btn_tagAlert_overwrite.UseVisualStyleBackColor = true;
            this.btn_tagAlert_overwrite.Click += new System.EventHandler(this.btn_tagAlert_overwrite_Click);
            // 
            // btn_tagAlert_overwriteall
            // 
            this.btn_tagAlert_overwriteall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_tagAlert_overwriteall.Location = new System.Drawing.Point(424, 10);
            this.btn_tagAlert_overwriteall.Margin = new System.Windows.Forms.Padding(10);
            this.btn_tagAlert_overwriteall.Name = "btn_tagAlert_overwriteall";
            this.btn_tagAlert_overwriteall.Size = new System.Drawing.Size(118, 35);
            this.btn_tagAlert_overwriteall.TabIndex = 1;
            this.btn_tagAlert_overwriteall.Text = "Overwrite all";
            this.btn_tagAlert_overwriteall.UseVisualStyleBackColor = true;
            this.btn_tagAlert_overwriteall.Click += new System.EventHandler(this.btn_tagAlert_overwriteall_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Cancel.Location = new System.Drawing.Point(562, 10);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(120, 35);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Keep Old";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // TagAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 237);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "TagAlert";
            this.Text = "Warnung";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_previewtagedit)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_tagAlert_join;
        private System.Windows.Forms.Button btn_tagAlert_joinall;
        private System.Windows.Forms.Button btn_tagAlert_overwrite;
        private System.Windows.Forms.Button btn_tagAlert_overwriteall;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pb_previewtagedit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
    }
}