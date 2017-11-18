using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager.CustomControls {
    class ColorSetting {

        public ColorSetting(string t, Color C) {
            Colortext = t;
            Color = C;
        }

        public override string ToString() {
            return Colortext;
        }

        public string Colortext { get; }

        public Color Color { get; }

    }
}
