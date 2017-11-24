namespace PhotoManager {
    class UpdateParameter {

        private string ReturnValue;
        private bool returnValueSet;

        public UpdateParameter(string newEntry, string oldEntry) {
            OldEntry = oldEntry;
            NewEntry = newEntry;
            returnValueSet = false;
        }

        public string OldEntry { get; set; }

        public string NewEntry { get; set; }

        public bool isEqual() {
            return OldEntry.Equals(NewEntry);
        }
        
        public string getReturnValue() {
            return ReturnValue;
        }

        public void setReturnValue(string s) {
            returnValueSet = true;
            ReturnValue = s;
        }

        public bool isreturnValueSet() {
            return returnValueSet;
        }

        public bool isOldEntryEmpty() {
            return OldEntry.Equals("") || OldEntry.Equals(Utils.YEAR_STD) || OldEntry.Equals(Utils.getSQLLocation(0, 0));
        }

        public bool requestedChange() {
            return !NewEntry.Equals("");
        }

    }
}
