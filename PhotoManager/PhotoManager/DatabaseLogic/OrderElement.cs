namespace PhotoManager {
    class OrderElement {

        public OrderElement(string text, string query) {
            this.Text = text;
            this.Query = query;
        }

        override
        public string ToString() {
            return Text;
        }

        public string Text { get; set; }

        public string Query { get; set; }


    }
}