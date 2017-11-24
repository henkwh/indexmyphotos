namespace PhotoManager {
    class TrackBarSetting {

        public TrackBarSetting(int min, int max, int value, int ticks) {
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
