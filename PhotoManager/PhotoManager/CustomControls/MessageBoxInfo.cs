using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btn_OK_Click(object sender, EventArgs e) {
            this.Hide();
        }
    }
}
