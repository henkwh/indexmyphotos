using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    public partial class FavouriteElement : UserControl {

        public FavouriteElement(string text) {
            InitializeComponent();
            tb_searchstring.Text = text;
        }

        public void resize(int width) {
            Width = width;
        }

        public Button delButton() {
            return btn_delete;
        }

        public string getText() {
            return tb_searchstring.Text;
        }

        public Button copyButton() {
            return btn_copy;
        }
    }
}
