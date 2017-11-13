using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {
    class TrackBarSettings {


        public TrackBarSettings(int min, int max, int value, int ticks) {
            Max = max;
            Min = min;
            Value = value;
            Ticks = ticks;
        }

        public int Max { get; set; }

        public int Min { get; set; }

        public int Value { get; set; }

        public int Ticks { get; set; }

    }
}
