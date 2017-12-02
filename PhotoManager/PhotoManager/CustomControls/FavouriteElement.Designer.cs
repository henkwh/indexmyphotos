namespace PhotoManager.CustomControls {
    partial class FavouriteElement {
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.tb_searchstring = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Controls.Add(this.btn_delete, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_copy, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tb_searchstring, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_delete.Location = new System.Drawing.Point(725, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(28, 28);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "❌";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_copy
            // 
            this.btn_copy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_copy.Location = new System.Drawing.Point(693, 3);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(26, 28);
            this.btn_copy.TabIndex = 2;
            this.btn_copy.Text = "C";
            this.btn_copy.UseVisualStyleBackColor = true;
            // 
            // tb_searchstring
            // 
            this.tb_searchstring.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_searchstring.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_searchstring.Location = new System.Drawing.Point(3, 3);
            this.tb_searchstring.Name = "tb_searchstring";
            this.tb_searchstring.ReadOnly = true;
            this.tb_searchstring.Size = new System.Drawing.Size(684, 26);
            this.tb_searchstring.TabIndex = 3;
            // 
            // FavouriteElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FavouriteElement";
            this.Size = new System.Drawing.Size(756, 34);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.TextBox tb_searchstring;
    }
}
