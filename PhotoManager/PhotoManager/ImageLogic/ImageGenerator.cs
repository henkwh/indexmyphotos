using System;
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

        /*
         * Adds functionality to edit, generate previews and resize images
         */

        public const int FRAME_SIZE = 10;

        public static bool autoscale = true;

        public static Color selectionColor = Color.White;

        /*
         * Creates preview image and places it in preview folder
         */
        public static Bitmap genPreview(string cwd, string full, string preview, string filepath, int scale) {
            if (!File.Exists(cwd + preview + filepath)) {
                string complete = cwd + full + filepath;
                if (!File.Exists(complete)) {
                    return null;
                }
                Bitmap tempBmp;
                try {
                    tempBmp = new Bitmap(complete);
                } catch {
                    return null;
                }
                Size ret = new Size(scale, scale);
                if (tempBmp.Height > tempBmp.Width) {
                    ret.Height = scale;
                    ret.Width = scale * tempBmp.Width / tempBmp.Height;
                } else {
                    ret.Width = scale;
                    ret.Height = scale * tempBmp.Height / tempBmp.Width;
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


        public static Bitmap drawFrame(Bitmap bm, bool frame) {
            Bitmap b = new Bitmap(bm);
            Graphics g = Graphics.FromImage(b);
            if (frame) {
                Rectangle rectf = new Rectangle(FRAME_SIZE / 2, FRAME_SIZE / 2, b.Width - FRAME_SIZE, b.Height - FRAME_SIZE);
                Pen p = new Pen(selectionColor, FRAME_SIZE);
                g.DrawRectangle(p, rectf);
            } else {
                PointF[] point = new PointF[3];
                point[0] = new PointF(2 * bm.Width / 3, 0);
                point[1] = new PointF(bm.Width, 0);
                point[2] = new PointF(bm.Width, bm.Width - 2 * bm.Width / 3);
                SolidBrush brush = new SolidBrush(selectionColor);
                g.FillPolygon(brush, point);
            }
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

        public static int[] calculateGap(int gap, int imagescale, int panelwidth) {
            int one = 0, c = 1;
            while (one <= panelwidth) {
                c++;
                one += (gap + imagescale);
            }
            if (c < 3) {
                return new int[] { 0, 3 };
            }
            if (autoscale) {
                one -= (gap + imagescale);
                return new int[] { gap + ((panelwidth - one) / c), c };
            } else {
                return new int[] { gap, c };
            }

        }
    }
}
