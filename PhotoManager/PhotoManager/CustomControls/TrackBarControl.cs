using System.Windows.Forms;

namespace PhotoManager {
    class TrackBarControl : TrackBar {

        private TrackBarSetting main, map;
        public enum tabPage { MAIN, MAP };

        public TrackBarControl() {
            main = new TrackBarSetting(50, 150, Properties.Settings.Default.SCALE_MAIN, 5);
            map = new TrackBarSetting(40, 90, Properties.Settings.Default.SCALE_MAP, 15);
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
            Value = (int)((tbs.Value - tbs.Min) * (1.0 * tbs.Ticks / (1.0 * tbs.Max - tbs.Min)));
        }

        public int scrollEvent(tabPage tp) {   // 50 150 100 5
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
