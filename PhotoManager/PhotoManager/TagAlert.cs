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
        public enum uotnotification { ABORT, DISPOSE, DISPOSEALL, JOIN, JOINALL, OVERWRITE, OVERWRITEALL };

        public bool dispose = false;

        public uotnotification ReturnValue {
            get; set;
        }

        public TagAlert(Bitmap bmp, string info, bool dispose) {
            InitializeComponent();
            label1.Text = info;
            pb_previewtagedit.SizeMode = PictureBoxSizeMode.Zoom;
            pb_previewtagedit.Image = bmp;
            this.dispose = dispose;
            if (dispose == false) {
                btn_tagAlert_join.Text = "Join";
                btn_tagAlert_joinall.Text = "Join all";
            } else {
                btn_tagAlert_join.Text = "Discard";
                btn_tagAlert_joinall.Text = "Discard all";
            }

        }

        private void splitContainer2_Panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {

        }

        private void pb_previewtagedit_Click(object sender, EventArgs e) {

        }

        private void btn_tagAlert_join_Click(object sender, EventArgs e) {
            if (dispose == true) {
                ReturnValue = uotnotification.DISPOSE;
            } else {
                ReturnValue = uotnotification.JOIN;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btn_tagAlert_joinall_Click(object sender, EventArgs e) {
            if (dispose == true) {
                ReturnValue = uotnotification.DISPOSEALL;
            } else {
                ReturnValue = uotnotification.JOINALL;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_tagAlert_overwrite_Click(object sender, EventArgs e) {
            ReturnValue = uotnotification.OVERWRITE;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_tagAlert_overwriteall_Click(object sender, EventArgs e) {
            ReturnValue = uotnotification.OVERWRITEALL;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
