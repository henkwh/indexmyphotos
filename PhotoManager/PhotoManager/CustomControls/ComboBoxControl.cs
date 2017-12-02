using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoManager.CustomControls {
    class ComboBoxControl : ComboBox{

        private List<OrderElement> main;
        private List<OrderElement> map;

        private shownpanel actualpanel;
        public enum shownpanel { MAIN, MAP};

        public ComboBoxControl() {

            //TextChanged += combobox_sorting_TextChanged;
            MessageBox.Show("OK");
            main = new List<OrderElement>();
            map = new List<OrderElement>();
            main.Add(new OrderElement("Date ascending", " ORDER BY f.date ASC"));
            main.Add(new OrderElement("Date descending", " ORDER BY f.date DESC"));
            main.Add(new OrderElement("Location N to S", " ORDER BY f.loclat DESC"));
            main.Add(new OrderElement("Location S to N", " ORDER BY f.loclat ASC"));
            main.Add(new OrderElement("Location W to E", " ORDER BY f.loclng ASC"));
            main.Add(new OrderElement("Location E to W", " ORDER BY f.loclng DESC"));
            main.Add(new OrderElement("Filetype", " ORDER BY f.filetype ASC"));

            map.Add(new OrderElement("Google Map Provider", GMap.NET.MapProviders.GoogleMapProvider.Instance));
            map.Add(new OrderElement("Open Cycle Map", GMap.NET.MapProviders.OpenCycleMapProvider.Instance));

            actualpanel = shownpanel.MAIN;
            load(actualpanel);
        }

        public void load(shownpanel sp) {
            if (sp == shownpanel.MAIN && actualpanel != sp) {
                Items.Clear();
                Items.AddRange(main.ToArray());
            } else if (sp == shownpanel.MAP && actualpanel != sp) {
                Items.Clear();
                Items.AddRange(map.ToArray());
            }
            Refresh();
            actualpanel = sp;
        }

      public string getOrder() {
            foreach (OrderElement oe in Items) {
                if (oe.Text.Equals(Text)) {
                    return oe.Text;
                }
            }
            return "";
        }

       /* private void combobox_sorting_TextChanged(object sender, EventArgs e) {
            foreach (OrderElement oe in combobox_sorting.Items) {
                if (oe.Text.Equals(combobox_sorting.Text)) {
                    selectedorder = oe;
                    break;
                }
            }
        }*/


    }
}
