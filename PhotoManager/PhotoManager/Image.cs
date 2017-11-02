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
        private DateTime date;
        private string filetype, location, description, tags;

        public Image(string name, string filetype) {
            date = new DateTime(Sorting.YEAR_STD, 01, 01);
            this.name = name;
            this.Image = null;
            location = null;
            description = null;
            this.filetype = filetype;
        }

        public void setTags(DateTime dt, string loc, string desc, string tags) {
            date = dt;
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

        public DateTime getDate() {
            return date;
        }

        public bool tagsempty() {
            return tags == null || tags.Equals("");
        }

        public void showBorder() {
            if (BackColor == Color.OrangeRed) {
                return;
            }
            SizeMode = PictureBoxSizeMode.CenterImage;
            Size = Image.Size;
            Image = ImageGenerator.resizeImage((Bitmap)Image, Math.Max((int)(Image.Size.Width * 0.9), (int)(Image.Size.Height * 0.9)));
            BackColor = Color.OrangeRed;
        }

        public void showBordernot() {
            if (BackColor == Color.Transparent) {
                return;
            }
            Image = ImageGenerator.resizeImage((Bitmap)Image, Math.Max(this.Size.Width, this.Size.Height));
            BackColor = Color.Transparent;
            SizeMode = PictureBoxSizeMode.AutoSize;
        }


    }



}
