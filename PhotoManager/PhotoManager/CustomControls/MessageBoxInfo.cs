using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    public partial class MessageBoxInfo : Form {
        public MessageBoxInfo(int parentxpos, int parentypos, int parentwidth, int parentheight) {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;


            int xpos = Math.Max(0, parentxpos + (parentwidth - Width) / 2);
            int ypos = Math.Max(0, parentypos + (parentheight - Height) / 2);
            Location = new Point(xpos, ypos);
        }


        public void addText(string t) {
            tb_text.Text += t + "\r\n";
        }

        public TextBox getTextBox() {
            return tb_text;
        }

        private void btn_OK_Click(object sender, EventArgs e) {
            this.Hide();
            this.Dispose();
        }
    }
}
