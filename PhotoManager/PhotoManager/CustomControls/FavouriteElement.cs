using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    public partial class FavouriteElement : UserControl {

        public FavouriteElement(string text) {
            InitializeComponent();
            lb_fav.Text = text;
        }

        public void resize(int width) {
            Width = width;
        }

        public Button delButton() {
            return btn_delete;
        }

        public string getText() {
            return lb_fav.Text;
        }

        public Button copyButton() {
            return btn_copy;
        }
    }
}
