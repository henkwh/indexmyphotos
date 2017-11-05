using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager {

    public class Image : PictureBox {

        private Bitmap preview;
        private string name, filetype, date, description, tags;
        private double[] location;
        private Size bounds;
        private bool borderShown;
        private const PictureBoxSizeMode mode = PictureBoxSizeMode.Zoom;

        public Image(string name, string filetype) {
            this.name = name;
            this.filetype = filetype;
            this.Image = null;
            this.location = null;
            this.description = null;
            this.date = Utils.YEAR_STD;
            this.borderShown = false;
            SizeMode = mode;
        }

        public void setTags(string date, double[] loc, string desc, string tags) {
            this.date = date;
            location = loc;
            description = desc;
            this.tags = tags;
        }

        public void setDate(string d) {
            date = d;
        }

        public void setLocation(double[] l) {
            location = l;
        }

        public void setDescription(string d) {
            description = d;
        }

        public void setTags(string t) {
            tags = t;
        }

        public void setPreview(Bitmap bmp) {
            if (bmp == null) {
                preview.Dispose();
            }
            if (preview == null) {
                preview = bmp;
            }
        }

        public void setImage(Bitmap b) {
            if (borderShown) {
                Image = ImageGenerator.drawFrame(b);
            } else {
                Image = b;
            }
        }

        public void setSize(int s) {
            bounds = new Size(s, s);
            Size = bounds;
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

        public string getLocationString() {
            return Utils.getWorkingLocation(location);
        }

        public double[] getLocation() {
            return location == null ? new double[] { 0, 0 } : location;
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
            if (!borderShown) {
                Image = ImageGenerator.drawFrame((Bitmap)preview);
                borderShown = true;
            }
        }

        public void hideBorder() {
            if (borderShown) {
                Image = preview;
                borderShown = false;
                System.Diagnostics.Debug.WriteLine("OMG");
            }
        }


    }



}
