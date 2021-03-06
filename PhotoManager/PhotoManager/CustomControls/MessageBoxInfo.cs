﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    public partial class MessageBoxInfo : Form {

        /*
         * This forms pops up to give a textual feedback.
         * The only interaction is clicking OK that will dispose the form
         */

        public MessageBoxInfo(int parentxpos, int parentypos, int parentwidth, int parentheight) {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;


            int xpos = Math.Max(0, parentxpos + (parentwidth - Width) / 2);
            int ypos = Math.Max(0, parentypos + (parentheight - Height) / 2);
            Location = new Point(xpos, ypos);
        }


        public void addText(string t) {
            if (tb_text.InvokeRequired) {
                tb_text.BeginInvoke((MethodInvoker)delegate {
                    tb_text.Text += (t + "\r\n");
                    tb_text.SelectionStart = tb_text.Text.Length;
                    tb_text.ScrollToCaret();
                    tb_text.Refresh();
                    this.Refresh();
                });
            } else {
                tb_text.Text += t + ("\r\n");
                tb_text.SelectionStart = tb_text.Text.Length;
                tb_text.ScrollToCaret();
                tb_text.Refresh();
                this.Refresh();
            }
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
