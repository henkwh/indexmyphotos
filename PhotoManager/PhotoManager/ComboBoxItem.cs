using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PhotoManager {

    public class ComboBoxItem : ComboBox {

        public ComboBoxItem() { 
            this.Items.Add("Date ascending");
            this.Items.Add("Date descending");
            this.Items.Add("Location N->S");
            this.Items.Add("Location S->N");
            this.Items.Add("Location W->E");
            this.Items.Add("Location E->W");
            this.Items.Add("Count Tags");

            this.SelectedItem = Items[0];
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Add properties, events etc. you want to expose...
    }
}
