using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace ConvolutionalNeuralNetwork
{
    public static class MnistReader
    {
        public static List<MnistEntry> Load(string path)
        {
            //var label = LoadLabels(labelFile, maxItem);
            //var images = LoadImages(imageFile, maxItem);
            List<int> label;
            List<byte[]> images;

            (label, images) = LoadImagesAndLabels(path);

            if (label.Count == 0 || images.Count == 0)
            {
                return new List<MnistEntry>();
            }

            return label.Select((t, i) => new MnistEntry { Label = t, Image = images[i] }).ToList();
        }

        private static (List<int> label, List<byte[]> images) LoadImagesAndLabels(string path)
        {
            List<int> label = new List<int>();
            List<byte[]> images = new List<byte[]>();
            string[] dirs = Directory.GetDirectories(path, "*");

            foreach (string dir in dirs)
            {
                int number = int.Parse(dir[dir.Length - 1].ToString());
                string[] files = Directory.GetFiles(dir, "*");

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

        private static List<byte[]> LoadImages(string filename, int maxItem = -1)
        {
            var result = new List<byte[]>();



            if (File.Exists(filename) && 1 == 2)
            {
                using (var instream = new GZipStream(File.Open(filename, FileMode.Open), CompressionMode.Decompress))
                {
                    using (var reader = new BinaryReader(instream))
                    {
                        var magicNumber = ReverseBytes(reader.ReadInt32());
                        var numberOfImage = ReverseBytes(reader.ReadInt32());
                        var rowCount = ReverseBytes(reader.ReadInt32());
                        var columnCount = ReverseBytes(reader.ReadInt32());
                        if (maxItem != -1)
                        {
                            numberOfImage = Math.Min(numberOfImage, maxItem);
                        }

                        for (var i = 0; i < numberOfImage; i++)
                        {
                            var image = reader.ReadBytes(rowCount * columnCount);

                            result.Add(image);
                        }
                    }
                }
            }

            return result;
        }

        private static List<int> LoadLabels(string filename, int maxItem = -1)
        {
            var result = new List<int>();

            if (File.Exists(filename))
            {
                using (var instream = new GZipStream(File.Open(filename, FileMode.Open), CompressionMode.Decompress))
                {
                    using (var reader = new BinaryReader(instream))
                    {
                        var magicNumber = ReverseBytes(reader.ReadInt32());
                        var numberOfItem = ReverseBytes(reader.ReadInt32());
                        if (maxItem != -1)
                        {
                            numberOfItem = Math.Min(numberOfItem, maxItem);
                        }

                        for (var i = 0; i < numberOfItem; i++)
                        {
                            result.Add(reader.ReadByte());
                        }
                    }
                }
            }

            return result;
        }
        public static byte[] ImageToByte(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        public static byte[] ToGrayscaleByte(Bitmap resizedBitmap)
        {
            byte[] byteArray = new byte[28 * 28];

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
        public static float[] ToGrayscaleFloat(Bitmap resizedBitmap)
        {
            float[] byteArray = new float[28 * 28];

            unsafe
            {
                for (int y = 0; y < resizedBitmap.Height; y++)
                {
                    for (int x = 0; x < resizedBitmap.Width; x++)
                    {
                        Color clr = resizedBitmap.GetPixel(x, y);
                        byte byPixel = (byte)((30 * clr.R + 59 * clr.G + 11 * clr.B) / 100);

                        byteArray[x * y] = byPixel / 255;
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
        private static int ReverseBytes(int v)
        {
            var intAsBytes = BitConverter.GetBytes(v);
            Array.Reverse(intAsBytes);
            return BitConverter.ToInt32(intAsBytes, 0);
        }
    }
}