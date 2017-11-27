using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    public partial class TagEditElement : UserControl {
        public TagEditElement(string tag, int occ) {
            InitializeComponent();
            label_occurence.Text = "# "+occ;
            if(occ == 0) {
                label_occurence.BackColor = Color.LightCoral;
            }
            textBox_tag.Text = tag;
            OldTag = tag;
        }

        public Button getEditButton() {
            return button_Edit_text;
        }

        public Button GetDeleteButton() {
            return button_Delete;
        }

        public string OldTag { get; set; }

        public string getNewTag() {
            return textBox_tag.Text;
        }

        private void button_Edit_text_Click(object sender, EventArgs e) {

        }

        private void button_Delete_Click(object sender, EventArgs e) {

        }
    }
}
