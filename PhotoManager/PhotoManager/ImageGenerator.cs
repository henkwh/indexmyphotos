using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoManager {



    static class ImageGenerator {
        private static int MAXSIZE = 150;
        public static int PIN_SIZE = 75;
        public static int SIZE = MAXSIZE;
        public static int[] MINMAXSIZE = { 100, 300 };

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
            Size ret = new Size();
            if (imgToResize.Height > imgToResize.Width) {
                ret.Height = size;
                ret.Width = size * imgToResize.Width / imgToResize.Height;
            } else {
                ret.Width = size;
                ret.Height = size * imgToResize.Height / imgToResize.Width;
            }
            return new Bitmap(imgToResize, ret);
        }

        public static Size genSize(Image box) {
            Size ret = new Size();
            if (box.Height > box.Width) {
                ret.Height = SIZE;
                ret.Width = SIZE * box.getPreview().Width / box.getPreview().Height;
            } else {
                ret.Width = SIZE;
                ret.Height = SIZE * box.getPreview().Height / box.getPreview().Width;
            }
            return ret;
        }

    }
}
