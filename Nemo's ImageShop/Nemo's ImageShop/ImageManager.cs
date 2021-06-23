using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.CodeDom.Compiler;

namespace Nemo_s_ImageShop
{
    class ImageManager
    {
        public string filePath { get; set; }
        public string fileName { get; set; }
        public Image originalImage { get; set; }
        public Bitmap bmpFile { get; set; }
        public Image convertedImage { get; set; }
        public string originalForm { get; set; }
        public string convertedForm { get; set; }


        public void ResizeImage()
        {

        }

        public void InitializeImage(Image imageFile, string filePath, string fileName)
        {
            this.originalImage = imageFile;
            this.bmpFile = imageFile as Bitmap;
            this.filePath = filePath;
            this.fileName = fileName;

            if (imageFile.RawFormat.Equals(ImageFormat.Jpeg))
            {
                if (filePath.EndsWith(".jpg"))
                    originalForm = ".jpg";
                else
                    originalForm = ".jpeg";
            }
            else if (imageFile.RawFormat.Equals(ImageFormat.Png))
            {
                originalForm = ".png";
            }
            else
            {
                originalForm = ".bmp";
            }
        }

        private byte Clamp(double value)
        {
            if (value > 255)
                return (byte)255;
            else if (value < 0)
                return (byte)0;
            else
                return (byte)value;
        }

        public void ResizeImage(float ratio)
        {
            int width = (int)(bmpFile.Width * ratio);
            int height = (int)(bmpFile.Height * ratio);

            Size size = new Size(width, height);

            bmpFile = new Bitmap(bmpFile, size);
        }

        private void StandardTransform(byte[] LUT)
        {
            Color PixelColor;
            Color newColor;

            byte R, G, B;
            double percent;

            ProgressBar ProgressWindow = new ProgressBar();
            ProgressWindow.Show();

            for (int y = 0; y < bmpFile.Height; y++)
            {
                percent = (double)y / (bmpFile.Height - 1) * 100;
                ProgressWindow.ShowProgress(percent);

                for (int x = 0; x < bmpFile.Width; x++)
                {
                    PixelColor = bmpFile.GetPixel(x, y);
                    R = LUT[PixelColor.R];
                    G = LUT[PixelColor.G];
                    B = LUT[PixelColor.B];

                    newColor = Color.FromArgb(R, G, B);
                    bmpFile.SetPixel(x, y, newColor);
                }
            }
        }

        public void NegativeTransform()
        {
            byte[] LUT = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                LUT[i] = (byte)(255 - i);
            }

            StandardTransform(LUT);
        }

        public void GrayScaleTransform()
        {
            Color PixelColor;
            Color newColor;

            byte avg;
            double percent;

            ProgressBar ProgressWindow = new ProgressBar();
            ProgressWindow.Show();

            for (int y = 0; y < bmpFile.Height; y++)
            {
                percent = (double)y / (bmpFile.Height - 1) * 100;
                ProgressWindow.ShowProgress(percent);

                for (int x = 0; x < bmpFile.Width; x++)
                {
                    PixelColor = bmpFile.GetPixel(x, y);
                    avg = (byte)(PixelColor.R + PixelColor.G + PixelColor.B / 3);

                    newColor = Color.FromArgb(avg, avg, avg);
                    bmpFile.SetPixel(x, y, newColor);
                }
            }
        }

        public void ThresholdTransform()
        {
            byte[] LUT = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                if (i < 128)
                    LUT[i] = 0;
                else
                    LUT[i] = 255;
            }

            StandardTransform(LUT);
        }

        public void PosturizeTransform(byte level)
        {
            double tmp;
            int divide = 256 / level;
            byte[] LUT = new byte[256];


            for (int i = 0; i < 256; i++)
            {
                tmp = (double)((i / divide) * divide);
                LUT[i] = Clamp(tmp);
            }

            StandardTransform(LUT);
        }

        public void GammaTransform(double value)
        {
            double tmp;
            byte[] LUT = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                tmp = 255.0 * Math.Pow((double)i / 255.0, value);
                LUT[i] = Clamp(tmp);
            }

            StandardTransform(LUT);
        }

        public void StretchTransform()
        {
            double tmp;
            byte[] LUT = new byte[256];

            for (int i = 0; i < 256; i++)
            {
                tmp = ((double)i * 2 - 128);
                LUT[i] = Clamp(tmp);
            }

            StandardTransform(LUT);
        }

        public void ConvertImage(string format)
        {
            switch (format)
            {
                case "original format":
                    convertedForm = originalForm;
                    break;
                case "*.jpeg":
                    convertedForm = ".jpeg";
                    break;
                case "*.png":
                    convertedForm = ".png";
                    break;
                case "*.bmp":
                    convertedForm = ".bmp";
                    break;
                default:
                    break;
            }
        }
    }
}
