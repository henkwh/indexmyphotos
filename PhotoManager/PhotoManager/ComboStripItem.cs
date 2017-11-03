using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PhotoManager {
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
                                         ToolStripItemDesignerAvailability.ContextMenuStrip |
                                         ToolStripItemDesignerAvailability.StatusStrip)]
    public class ComboStripItem : ToolStripControlHost {
        private ComboBox combo;

        public ComboStripItem()
            : base(new ComboBox()) {
            this.combo = this.Control as ComboBox;

            this.combo.Items.Add("Date ascending");
            this.combo.Items.Add("Date descending");
            this.combo.Items.Add("Location N->S");
            this.combo.Items.Add("Location S->N");
            this.combo.Items.Add("Location W->E");
            this.combo.Items.Add("Location E->W");
            this.combo.Items.Add("Count Tags");

            this.combo.SelectedItem = combo.Items[0];
            this.combo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Add properties, events etc. you want to expose...
    }
}
