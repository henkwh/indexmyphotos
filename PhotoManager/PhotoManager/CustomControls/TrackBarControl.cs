﻿using System.Windows.Forms;

namespace PhotoManager {
    public class TrackBarControl : TrackBar {

        /*
         * Main panel and map panel are using different scale values. To match the Trackbar on the bottom, each specific values are stored and selecting the other panel causes a switching of the Trackbars values.
         */
        private TrackBarSetting main, map;
        public enum tabPage { MAIN, MAP };

        public TrackBarControl() {
            main = new TrackBarSetting(50, 300, Properties.Settings.Default.SCALE_MAIN, 6);
            map = new TrackBarSetting(40, 100, Properties.Settings.Default.SCALE_MAP, 15);
        }

        public void updateTabPage(tabPage tp, int value) {
            TrackBarSetting tbs = null;
            if (tp == tabPage.MAIN) {
                tbs = main;
            } else if (tp == tabPage.MAP) {
                tbs = map;
            }
            Maximum = tbs.Ticks;
            Minimum = 0;
            Value = (int)((tbs.Value + 1 - tbs.Min) * (1.0 * tbs.Ticks / (1.0 * tbs.Max - tbs.Min)));
        }

        public int scrollEvent(tabPage tp) {
            TrackBarSetting tbs = null;
            if (tp == tabPage.MAIN) {
                tbs = main;
                tbs.Value = (int)(1.0 * tbs.Min + Value * (1.0 * (tbs.Max - tbs.Min) / tbs.Ticks));
                Properties.Settings.Default.SCALE_MAIN = tbs.Value;
            } else if (tp == tabPage.MAP) {
                tbs = map;
                tbs.Value = (int)(1.0 * tbs.Min + Value * (1.0 * (tbs.Max - tbs.Min) / tbs.Ticks));
                Properties.Settings.Default.SCALE_MAP = tbs.Value;
            }
            Properties.Settings.Default.Save();
            return tbs.Value;
        }

    }
}
