using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ConvNeuralNetwork
{
    public static class Reader
    {
        public static List<Entry> Load(string path)
        {
            List<int> label;
            List<byte[]> images;

            (label, images) = LoadImagesAndLabels(path);

            if (label.Count == 0 || images.Count == 0)
            {
                return new List<Entry>();
            }

            return label.Select((t, i) => new Entry { Label = t, Image = images[i] }).ToList();
        }

        private static (List<int>, List<byte[]>) LoadImagesAndLabels(string path)
        {
            List<int> label = new List<int>();
            List<byte[]> images = new List<byte[]>();
            string[] dirs = Directory.GetDirectories(path, "*");

            for (int i = 0; i < dirs.Length; i++)
            {
                int number = i;
                string[] files = Directory.GetFiles(dirs[i], "*");

                foreach (string file in files)
                {
                    Bitmap bitmap = new Bitmap(file);
                    Bitmap resizedBitmap = ResizeBitmap(bitmap, 28, 28);
                    label.Add(number);
                    images.Add(ToGrayscaleByte(resizedBitmap));
                }
            }

            return (label, images);
        }

        public static byte[] ToGrayscaleByte(Bitmap resizedBitmap)
        {
            byte[] byteArray = new byte[resizedBitmap.Width * resizedBitmap.Height];

            unsafe
            {
                for (int y = 0; y < resizedBitmap.Height; y++)
                {
                    for (int x = 0; x < resizedBitmap.Width; x++)
                    {
                        Color clr = resizedBitmap.GetPixel(x, y);
                        byte byPixel = (byte)((30 * clr.R + 59 * clr.G + 11 * clr.B) / 100);

                        byteArray[x * y] = byPixel;
                    }
                }
            }
            return byteArray;
        }
        public static Bitmap ResizeBitmap(Bitmap src, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                g.DrawImage(src, 0, 0, width, height);
            }
            return result;
        }
    }
}