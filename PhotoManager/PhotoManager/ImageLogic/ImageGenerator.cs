using PhotoManager.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoManager {
    static class ImageGenerator {

        /*
         * Adds functionality to edit, generate previews and resize images
         */

        public const int FRAME_SIZE = 10;

        private const int PREVIEWSIZE = 200;

        public static bool autoscale = true;

        public static Color selectionColor = Color.White;

        /*
         * Creates preview image and places it in preview folder
         */
        public static Bitmap genPreview(string cwd, string full, string preview, string filepath) {
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
                System.Diagnostics.Debug.WriteLine("SIZE");
                Size ret = new Size(PREVIEWSIZE, PREVIEWSIZE);
                if (tempBmp.Height > tempBmp.Width) {
                    ret.Height = PREVIEWSIZE;
                    ret.Width = PREVIEWSIZE * tempBmp.Width / tempBmp.Height;
                } else {
                    ret.Width = PREVIEWSIZE;
                    ret.Height = PREVIEWSIZE * tempBmp.Height / tempBmp.Width;
                }
                Bitmap bmp = new Bitmap(tempBmp, ret);
                Bitmap bmp2 = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format16bppRgb565);//Format16bppRgb555
                int orient = getOrientation(tempBmp);
                bmp2 = doFlip(bmp2, orient);
                tempBmp.Dispose();
                bmp2.Save(cwd + preview + filepath);
                return bmp2;
            } else {
                return new Bitmap(cwd + preview + filepath);
            }
        }


        public static Bitmap doFlip(Bitmap bmp, int id) {
            switch (id) {
                case 1: return bmp;
                case 2: bmp.RotateFlip(RotateFlipType.RotateNoneFlipX); break;
                case 3: bmp.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
                case 4: bmp.RotateFlip(RotateFlipType.Rotate180FlipX); break;
                case 5: bmp.RotateFlip(RotateFlipType.Rotate90FlipX); break;
                case 6: bmp.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
                case 7: bmp.RotateFlip(RotateFlipType.Rotate270FlipX); break;
                case 8: bmp.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
            }
            return bmp;
        }
        public static Bitmap resizeImage(Bitmap imgToResize, int size) {
            return new Bitmap(imgToResize, genSize(size, imgToResize.Width, imgToResize.Height));
        }

        private static int getOrientation(Bitmap bmp) {
            if (bmp.PropertyIdList.Contains(0x0112)) {
                return bmp.GetPropertyItem(0x0112).Value[0];
            }
            return 1;
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
            if (autoscale) {
                double factor = (panelwidth - gap * 1.5f) * 1.0f / (imagescale + gap * 1.5f);
                int round = (int)Math.Round(factor);
                double retgap = (panelwidth - (round) * imagescale) * 1.0f / (round + 1);
                return new int[] { (int)Math.Round(retgap), round - 1 };
            } else {
                double factor = (panelwidth - gap) * 1.0f / (imagescale + gap);
                int round = (int)Math.Floor(factor);
                return new int[] { gap, (round - 1) };
            }
        }

        public static MetadataElement getMetaData(string path, bool getComment, bool getDate) {
            long parsedate = Math.Min(File.GetCreationTime(path).Ticks, Math.Min(File.GetLastWriteTime(path).Ticks, File.GetLastAccessTime(path).Ticks));
            DateTime dt = new DateTime(parsedate);
            string[] year = new string[] { Utils.parseDate(dt.Year, true), Utils.parseDate(dt.Month, false), Utils.parseDate(dt.Day, false) };

            Bitmap tempBmp = new Bitmap(path);
            string date1 = "", date2 = "", comment = "";
            if (getDate) {
                if (tempBmp.PropertyIdList.Contains(0x0132)) {
                    date1 = (System.Text.Encoding.UTF8.GetString(tempBmp.GetPropertyItem(0x0132).Value));
                }
                if (tempBmp.PropertyIdList.Contains(0x9003)) {
                    date2 = (System.Text.Encoding.UTF8.GetString(tempBmp.GetPropertyItem(0x9003).Value));
                }
            }
            if (getComment) {
                if (tempBmp.PropertyIdList.Contains(0x9286)) {
                    comment = (System.Text.Encoding.UTF8.GetString(tempBmp.GetPropertyItem(0x9286).Value)).Replace("\0", "");
                    if (comment.Equals("Created with GIMP")) { comment = ""; }
                }
            }
            if (getDate) {
                foreach (string s in new string[] { date1, date2 }) {
                    if (s != null && s.Count() >= 10) {
                        string[] compare = new string[] { Utils.parseDate(s.Substring(0, 4), true), Utils.parseDate(s.Substring(5, 2), false), Utils.parseDate(s.Substring(8, 2), false) };
                        if (Int32.Parse(compare[0] + compare[1] + compare[2]) < Int32.Parse(year[0] + year[1] + year[2])) {
                            year = compare;
                        }
                    }
                }
            }
            int date = getDate ? Int32.Parse(year[0] + year[1] + year[2]) : Int32.Parse(Utils.YEAR_STD);
            return new MetadataElement(getComment && comment != null ? comment : "", date);
        }
    }
}
