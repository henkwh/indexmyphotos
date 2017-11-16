﻿using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {
    class GMarkerElement : GMarkerGoogle {

        private int ToolTipCounter;

        public GMarkerElement(PointLatLng p, Bitmap b) : base(p, b) {
            BitmapWidth = b.Width;
            BitmapHeight = b.Height;
            ToolTipCounter = 1;
            ToolTipText = ToolTipCounter.ToString();
            ToolTip = new GMapRoundedToolTip(this);
            ToolTip.Fill = new SolidBrush(Color.BurlyWood);
            ToolTipMode = MarkerTooltipMode.OnMouseOver;
            LocationAsString = Utils.getWorkingLocation(new double[] { p.Lat, p.Lng });
        }

        public Bitmap Bitmap_DefSize { get; set; }

        public PointLatLng Pos { get; set; }
        
        public void IncrementToolTipCounter() {
            ToolTipCounter++;
            ToolTipText = ToolTipCounter.ToString();
        }

        public int getToolTipCounter() {
            return ToolTipCounter;
        }

        public string LocationAsString { get; set; }

        public int BitmapHeight { get; }

        public int BitmapWidth { get; }



    }
}