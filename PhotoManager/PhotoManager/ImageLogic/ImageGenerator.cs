﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {



    static class ImageGenerator {
        private static int MAXSIZE = 150;
        public static int SIZE = MAXSIZE;
        public static int[] MINMAXSIZE = { 100, 300 };

        public const int FRAME_SIZE = 10;


        /*
         * Creates preview image and places it in preview folder
         */
        public static Bitmap genPreview(string cwd, string full, string preview, string filepath) {
            if (!File.Exists(cwd + preview + filepath)) {
                string complete = cwd + full + filepath;
                if (!File.Exists(complete)) {
                    return null;
                }
                Bitmap tempBmp = new Bitmap(complete);
                Size ret = new Size(MAXSIZE, MAXSIZE);
                if (tempBmp.Height > tempBmp.Width) {
                    ret.Height = MAXSIZE;
                    ret.Width = MAXSIZE * tempBmp.Width / tempBmp.Height;
                } else {
                    ret.Width = MAXSIZE;
                    ret.Height = MAXSIZE * tempBmp.Height / tempBmp.Width;
                }
                Bitmap bmp = new Bitmap(tempBmp, ret);
                Bitmap bmp2 = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format16bppArgb1555);
                tempBmp.Dispose(); //get our memory back
                bmp2.Save(cwd + preview + filepath);
                return bmp;
            } else {
                return new Bitmap(cwd + preview + filepath);
            }
        }

        public static Bitmap resizeImage(Bitmap imgToResize, int size) {
            return new Bitmap(imgToResize, genSize(size, imgToResize.Width, imgToResize.Height));
        }


        public static Bitmap drawFrame(Bitmap bm) {
            Bitmap b = new Bitmap(bm);
            Rectangle rectf = new Rectangle(FRAME_SIZE / 2, FRAME_SIZE / 2, b.Width - FRAME_SIZE, b.Height - FRAME_SIZE);
            Graphics g = Graphics.FromImage(b);
            Pen p = new Pen(Color.Red, FRAME_SIZE);
            PointF[] point = new PointF[3];
            point[0] = new PointF(2 * bm.Width / 3, 0);
            point[1] = new PointF(bm.Width, 0);
            point[2] = new PointF(bm.Width, bm.Width - 2 * bm.Width / 3);
            SolidBrush brush = new SolidBrush(Color.Yellow);
            g.FillPolygon(brush, point);
            g.Flush();
            return b;
        }

        public static Bitmap drawFrame2(Bitmap bm) {
            Bitmap b = new Bitmap(bm);
            Rectangle rectf = new Rectangle(FRAME_SIZE / 2, FRAME_SIZE / 2, b.Width - FRAME_SIZE, b.Height - FRAME_SIZE);
            Graphics g = Graphics.FromImage(b);
            Pen p = new Pen(Color.Red, FRAME_SIZE);
            //g.DrawRectangle(p, rectf);
            //g.DrawLine(p, -10,30,bm.Width+40, bm.Height+20);
            g.Flush();
            return b;
        }


        public static Size genSize(int s, int width, int height) {
            if (height > width) {
                return new Size(s * width / height, s);
            } else {
                return new Size(s, s * height / width);
            }
        }

    }
}