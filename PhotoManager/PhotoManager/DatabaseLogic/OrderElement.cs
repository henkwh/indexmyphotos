using GMap.NET.WindowsForms;

namespace PhotoManager {
    class OrderElement {

        public OrderElement(string text, string query) {
            this.Text = text;
            this.Query = query;
        }

        public OrderElement(string text, GMap.NET.MapProviders.GMapProvider mapprovider) {
            this.Text = text;
            this.Provider = mapprovider;
        }

        override
        public string ToString() {
            return Text;
        }

        public string Text { get; set; }

        public string Query { get; set; }

        public GMap.NET.MapProviders.GMapProvider Provider { get; set; }

    }
}