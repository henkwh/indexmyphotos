using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager{

    class Image : PictureBox {

        private Bitmap preview;
        private string name;
        private string date;
        private string filetype, location, description, tags;
        private Size size;
        private PictureBoxSizeMode mode = PictureBoxSizeMode.Zoom;

        public Image(string name, string filetype) {
            //date = new DateTime(Sorting.YEAR_STD, 01, 01);
            date = Sorting.YEAR_STD;
            this.name = name;
            this.Image = null;
            location = null;
            description = null;
            this.filetype = filetype;
            SizeMode = mode;
        }

        public void setTags(string date, string loc, string desc, string tags) {
            this.date = date;
            location = loc;
            description = desc;
            this.tags = tags;
        }

        public void setPreview(Bitmap bmp) {
            if (bmp == null) {
                preview.Dispose();
            }
            //this.Image = bmp;
            if (preview == null) {
                preview = bmp;
            }
        }

        public void setSize(int s) {
            size = new Size(s, s);
            Size = size;
        }

        public string getName() {
            return name;
        }

        public string getFileType() {
            return filetype;
        }

        public Bitmap getPreview() {
            return preview;
        }

        public string getTags() {
            return string.IsNullOrEmpty(tags) ? "" : tags;
        }

        public string getLocation() {
            return string.IsNullOrEmpty(location) ? "" : location;
        }

        public string getDescription() {
            return description;
        }

        public string getDate() {
            return date;
        }

        public bool tagsempty() {
            return tags == null || tags.Equals("");
        }

        public void showBorder() {
            if (BackColor == Color.OrangeRed) {
                return;
            }
            BackColor = Color.OrangeRed;
        }

        public void hideBorder() {
            if (BackColor == Color.Transparent) {
                return;
            }
            BackColor = Color.Transparent;
        }


    }



}
