﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using System.Reflection;

namespace PhotoManager {
    public partial class GMapInstance : GMapControl {

        private Cursor pincursor;
        private bool editmode;
        private GMapOverlay overlay;
        private Form1 form;
        private int pinscale;

        private long lastClick;

        private double deltadistance = 0;

        public GMapInstance(Form1 f, string cwd) {
            form = f;
            overlay = new GMapOverlay("markers");
            addBrowser();
            pincursor = new Cursor(Assembly.GetExecutingAssembly().GetManifestResourceStream("PhotoManager.Resources.pin2.cur"));
           
            editmode = false;
            pinscale = Properties.Settings.Default.SCALE_MAP;
        }

        public void addBrowser() {
            MouseDown += new MouseEventHandler(myMap_Click);
            MouseUp += new MouseEventHandler(myMap_Up);
            PreviewKeyDown += GMapInstance_PreviewKeyDown;
            OnMapZoomChanged += GMapInstance_OnMapZoomChanged;
            Dock = System.Windows.Forms.DockStyle.Fill;
            DragButton = MouseButtons.Left;
            IgnoreMarkerOnMouseWheel = true;
            ShowCenter = false;
            MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            //MapProvider = GMap.NET.MapProviders.OpenCycleMapProvider.Instance;
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

        private void GMapInstance_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            PointLatLng mypos = Position;
            if (e.KeyCode == Keys.Up) {
                mypos.Lat += 1;
            } else if (e.KeyCode == Keys.Down) {
                mypos.Lat -= 1;
            } else if (e.KeyCode == Keys.Right) {
                mypos.Lng += 1;
            } else if (e.KeyCode == Keys.Left) {
                mypos.Lng -= 1;
            }
            Position = mypos;
            Update();
        }

        private void myMap_Up(object sender, MouseEventArgs e) {
            if (Environment.TickCount - lastClick < 200) {
                double lat = FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = FromLocalToLatLng(e.X, e.Y).Lng;
                setEditMode(false);
                form.setOnMapDone(Utils.getWorkingLocation(new double[] { lat, lng }));
            }
        }

        public void removeMarkers() {
            Overlays.Remove(overlay);
            overlay.Markers.Clear();
            Overlays.Add(overlay);
        }

        public void setEditMode(bool editMode) {
            if (editMode) {
                Cursor = pincursor;
                editmode = true;
            } else {
                Cursor = Cursors.Default;
                editmode = false;
            }
            foreach (GMarkerElement gm in overlay.Markers) {
                gm.IsVisible = !editmode;
            }
        }

        private void myMap_Click(object sender, MouseEventArgs e) {
            if (!editmode) {
                string location = "";
                foreach (GMarkerElement marker in overlay.Markers) {
                    if (marker.IsMouseOver) {
                        location = marker.LocationAsString;
                        form.ClickedMap(location);
                        break;
                    }
                }
            } else {
                lastClick = Environment.TickCount;

            }
            System.Diagnostics.Debug.WriteLine(Zoom + "");
        }

        private void GMapInstance_OnMapZoomChanged() {
            
        }

        /*
         * Adds GMapMarker to the location
         */
        public void addMarker(double[] position, Bitmap preview) {
            //Increment TolTipTCounter and -Text
            PointLatLng point = new PointLatLng(position[0], position[1]);
            GMarkerElement marker = new GMarkerElement(point, ImageGenerator.resizeImage(preview, pinscale));
            marker.Bitmap_DefSize = preview;
            foreach (GMarkerElement ie in overlay.Markers) {
                if (deltadistance == 0) {
                    if (ie.Position.Lat == point.Lat && ie.Position.Lng == point.Lng) {
                        ie.IncrementToolTipCounter();
                        return;
                    }
                } else {
                    System.Diagnostics.Debug.WriteLine(deltadistance * Zoom / 10);
                    if (Math.Sqrt(Math.Pow(ie.Position.Lat - point.Lat, 2) + Math.Pow(ie.Position.Lng - point.Lng, 2)) < deltadistance * 6.2 / Zoom) {

                        ie.IncrementToolTipCounter();
                        return;
                    }
                }
            }
            overlay.Markers.Add(marker);
            Overlays.Remove(overlay);
            Overlays.Add(overlay);
        }

        public int getPinScale() {
            return pinscale;
        }

        /*
         * TODO: Only local scale
         */
        public void setPinScale(int p) {
            pinscale = p;
            int i = overlay.Markers.Count() - 1;
            while (i >= 0) {
                GMarkerElement marker = (GMarkerElement)overlay.Markers.ElementAt(i);
                overlay.Markers.Remove(marker);
                Bitmap Bitmap_DefSize = marker.Bitmap_DefSize;
                marker = new GMarkerElement(marker.Position, ImageGenerator.resizeImage(Bitmap_DefSize, pinscale));
                marker.Bitmap_DefSize = Bitmap_DefSize;
                overlay.Markers.Add(marker);
                i--;
            }
            this.Refresh();
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // GMapInstance
            // 
            this.Name = "GMapInstance";
            this.Load += new System.EventHandler(this.GMapInstance_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GMapInstance_MouseClick);
            this.ResumeLayout(false);

        }

        public int getPinCount() {
            int sum = 0;
            foreach (GMarkerElement marker in overlay.Markers) {
                sum += marker.getToolTipCounter();
            }
            return sum;
        }

        private void GMapInstance_MouseClick(object sender, MouseEventArgs e) {
            if (editmode) {
                double lat = FromLocalToLatLng(e.X, e.Y).Lat;
                double lng = FromLocalToLatLng(e.X, e.Y).Lng;
                form.setOnMapDone(Utils.getWorkingLocation(new double[] { lat, lng }));
                setEditMode(false);
            }
        }

        private void GMapInstance_Load(object sender, EventArgs e) {

        }
    }
}