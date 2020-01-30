using System.Drawing;

namespace ConvNeuralNetwork
{
    public static class Reader
    {
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
        public static Bitmap ResizeBitmap(Bitmap bitmap, int width, int height)
        {
            Bitmap result = new Bitmap(bitmap, new Size(width, height));
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                g.DrawImage(bitmap, 0, 0, width, height);
            }
            return result;
        }
    }
}