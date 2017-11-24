using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    class PictureBoxViewer : PictureBox{

        /*
         * PictureBoxBiewer is a PictureBox that sores the shown image
         */

        public Image ShownImage { get; set; }

    }
}
