using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {
    class UpdateParemeters {

        private string location, tag, description;
        public bool locationbool, tagbool, descriptionbool, dtbool;
        private DateTime dt;

        public UpdateParemeters() {

        }

        public void setTags(string tags) {
            tag = tags;
            tagbool = true;
        }

        public void setLocation(string location) {
            this.location = location;
            locationbool = true;
        }
        public void setDescription(string description) {
            this.description = description;
            descriptionbool = true;
        }
        public void setDateTime(DateTime dt) {
            this.dt = dt;
            dtbool = true;
        }

        public string getTags(string s) {
            if (tagbool) {
                return tag;
            } else {
                return s;
            }
        }
        public string getLocation(string s) {
            if (locationbool) {
                return location;
            } else {
                return s;
            }
        }
        public string getDescription(string s) {
            if (descriptionbool) {
                return description;
            } else {
                return s;
            }
        }
        public DateTime getDate(DateTime s) {
            if (dtbool) {
                return dt;
            } else {
                return s;
            }
        }




    }
}
