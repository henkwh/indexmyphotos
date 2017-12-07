using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    public class TableLayoutInfoElement : TableLayoutPanel {

        private Label date, description;

        public TableLayoutInfoElement() {
            Dock = DockStyle.Fill;
            Margin = new Padding(0);
            AutoSize = true;
            Name = "Viewertable";
            ColumnCount = 3;
            RowCount = 0;
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1F));
            ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;

            //Add separator
            Label separator= new Label();
            separator.AutoSize = false;
            separator.Height = 20;
            separator.BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(separator, 1, 0);

            description = newLabel(System.Drawing.ContentAlignment.TopCenter);
            date = newLabel(System.Drawing.ContentAlignment.TopRight);
            Controls.Add(description, 0, 0);
            Controls.Add(date, 2, 0);
        }

        public void setDescription(string d) {
            description.Text = d;
        }


        public void setDate(string d) {
            string t = "";
            string[] dtype = new string[] { d.Substring(0, 4), d.Substring(4, 2), d.Substring(6, 2) };
            foreach (string s in dtype) {
                if (!s.Equals("00") && !s.Equals("1000")) {
                    t = s + "." + t;
                }
            }
            date.Text = t.Substring(0, Math.Max(0, t.Count() - 1));
        }

        private static Label newLabel(System.Drawing.ContentAlignment alignment) {
            Label l = new Label();
            l.Margin = new Padding(0);
            l.Dock = DockStyle.Fill;
            l.AutoSize = false;
            l.TextAlign = alignment;
            l.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);//Dubai, Century Gothic
            return l;
        }

    }
}
