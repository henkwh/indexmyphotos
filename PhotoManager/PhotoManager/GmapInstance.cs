using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Diagnostics;

namespace PhotoManager {
    public partial class GMapInstance : GMapControl {

        private Cursor pincursor;
        private bool editmode;
        private GMapOverlay overlay;
        private Form1 form;


        public GMapInstance(Form1 f, string cwd) {
            form = f;
            overlay = new GMapOverlay("markers");
            addBrowser();
            pincursor = new Cursor(cwd + "\\pin.cur");
            editmode = false;
        }


        public void addBrowser() {
            MouseClick += new MouseEventHandler(myMap_Click);
            KeyDown += new KeyEventHandler(myMap_ButtonClick);
            Dock = System.Windows.Forms.DockStyle.Fill;
            DragButton = MouseButtons.Left;
            IgnoreMarkerOnMouseWheel = true;
            ShowCenter = false;
            MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            CanDragMap = true;
            MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            NegativeMode = false;
            Zoom = 5;
            IgnoreMarkerOnMouseWheel = true;
            MinZoom = 2;
            MaxZoom = 22;
            Position = new PointLatLng(48.8617774, 2.349272);
        }

        private void myMap_ButtonClick(object sender, KeyEventArgs e) {
            PointLatLng mypos = Position;
            if (e.KeyCode == Keys.W) {
                mypos.Lat += 1;
            } else if (e.KeyCode == Keys.S) {
                mypos.Lat -= 1;
            } else if (e.KeyCode == Keys.D) {
                mypos.Lng += 1;
            } else if (e.KeyCode == Keys.A) {
                mypos.Lng -= 1;

            }
            Position = mypos;
            Update();
        }

        private void myMap_Hover(object sender, EventArgs e) {
            //Debug.WriteLine(Cursor.Position.X + " " + Cursor.Position.Y);
        }

        public void removeMarkers() {
            //Overlays.Remove(overlay);
            //overlay.Markers.Clear();
            //Overlays.Add(overlay);
        }

        public void setEditMode(bool editMode) {
            if (editMode) {
                Cursor = pincursor;
                editmode = true;
            } else {
                Cursor = Cursors.Default;
                editmode = false;
            }
        }

        private void myMap_Click(object sender, MouseEventArgs e) {
            if (!editmode) {
                foreach (GMapMarker marker in overlay.Markers) {
                    if (marker.IsMouseOver) {
                        string location = marker.Tag.ToString();
                        form.ClickedMap(location);
                        break;
                    }
                }
            } else {
                double lat = FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = FromLocalToLatLng(e.X, e.Y).Lng;
                setEditMode(false);
                form.setOnMapDone(lat.ToString().Replace(",", ".") + ", " + lng.ToString().Replace(",", "."));
            }
        }
        //google: 50.736363, 6.168436

        /*
         * Adds GMapMarker to the location
         */
        public void addMarker(string position, Bitmap preview) {
            string positionextruded = Sorting.parseLocation(position);
            if (position == null || position.Equals("")) {
                return;
            }

            string[] pos = positionextruded.Split(';');
            if (pos.Length != 2) {
                return;
            }

            foreach (GMapMarker ie in overlay.Markers) {    //Add counter to images tagged with the same place
                if (ie.Position.Lat == double.Parse(pos[0]) && ie.Position.Lng == double.Parse(pos[1])) {   //Existiert bereits
                    ie.ToolTipText = "" + (int.Parse(ie.ToolTipText) + 1);
                    return;
                }
            }
            PointLatLng point = new PointLatLng(double.Parse(pos[0]), double.Parse(pos[1]));
            GMapMarker marker = new GMarkerGoogle(point, ImageGenerator.resizeImage(preview, ImageGenerator.PIN_SIZE));
            marker.ToolTip = new GMapRoundedToolTip(marker);
            marker.ToolTip.Fill = new SolidBrush(Color.BurlyWood);
            marker.ToolTipText = "1";
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.Tag = position;
            overlay.Markers.Add(marker);
            Overlays.Remove(overlay);
            //overlay.Markers.Add(new GMarkerGoogle(new PointLatLng(55.0051436, 15.3826013), GMarkerGoogleType.blue));
            Overlays.Add(overlay);
            Update();
        }
    }
}