using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager {
    public partial class TagAlert : Form {
        public enum uotnotification { CANCEL, JOIN, OVERWRITE, KEEP_OLD, NONE };

        private bool withjoin;

        private uotnotification forAll;

        public uotnotification ReturnValue {
            get; set;
        }

        public TagAlert() {
            InitializeComponent();
            forAll = uotnotification.NONE;
        }

        public void showInfo(Bitmap bmp, string infotext, bool show_btn_join) {
            if (forAll != uotnotification.NONE) {
                ReturnValue = forAll;
                this.DialogResult = DialogResult.OK;
            }
            btn_tagAlert_join.Enabled = true;
            btn_tagAlert_joinall.Enabled = true;
            withjoin = show_btn_join;
            StartPosition = FormStartPosition.CenterParent;
            label1.Text = infotext;
            pb_previewtagedit.SizeMode = PictureBoxSizeMode.Zoom;
            pb_previewtagedit.Image = bmp;
            this.ShowDialog();
        }

        public uotnotification alreadyChosen(bool btn_joinAll) {
            return forAll;
        }

        private void splitContainer2_Panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {

        }

        private void pb_previewtagedit_Click(object sender, EventArgs e) {

        }

        private void btn_tagAlert_join_Click(object sender, EventArgs e) {
            ReturnValue = uotnotification.JOIN;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btn_tagAlert_joinall_Click(object sender, EventArgs e) {
            forAll = uotnotification.OVERWRITE;
            btn_tagAlert_join.PerformClick();
        }

        private void btn_tagAlert_overwrite_Click(object sender, EventArgs e) {
            ReturnValue = uotnotification.OVERWRITE;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btn_Cancel_Click(object sender, EventArgs e) {
            ReturnValue = uotnotification.KEEP_OLD;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btn_tagAlert_overwriteall_Click(object sender, EventArgs e) {
            forAll = uotnotification.OVERWRITE;
            btn_tagAlert_overwrite.PerformClick();
        }
    }
}
