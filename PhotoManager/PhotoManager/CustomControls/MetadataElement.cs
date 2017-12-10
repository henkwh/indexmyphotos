using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager.CustomControls {
    class MetadataElement {

        public MetadataElement(string desc, int date) {
            Description = desc;
            Date = date;
        }

        public string Description { get; }

        public int Date { get; }
    }
}
