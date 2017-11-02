using System;
using System.Windows.Forms;

namespace PhotoManager {
    internal class MenuItemImage : MenuItem {

        private Image i;

        public MenuItemImage(string text) : base(text) {
        }

        public Image getParentPictureBox() {
            return i;
        }

        public void setParentPictureBox(Image i) {
            this.i = i;
        }
    }
}