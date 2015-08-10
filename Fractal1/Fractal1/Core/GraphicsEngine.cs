using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace Fractal1.Core
{
    public class Complex
    {
        public Complex(double real, double imaginary)
        {
            this.Imaginary = imaginary;
            this.Real = real;
            Magnitude = Math.Sqrt(real * real + imaginary * imaginary);
        }
        // Code is not being invoked correctly - need to figure out --->START
        public static Complex operator +(Complex z, Complex c)
        {
            return new Complex(c.Real + z.Real, c.Imaginary + z.Imaginary);
        }
        public static Complex Pow(Complex z, int powerTo)
        {
            //for now power to two
            double realPart = z.Real * z.Real - z.Imaginary * z.Imaginary;
            double imPart = 2 * z.Imaginary * z.Real;
            return new Complex(realPart, imPart);

        }
        // <-- End --- using this instead
        public static Complex AddSquaredValueTo(Complex c, Complex z)
        {
            double realPartSquare = z.Real * z.Real - z.Imaginary * z.Imaginary;
            double imPartSquare = 2 * z.Imaginary * z.Real;
            double realPart = c.Real + realPartSquare;
            double imPart = c.Imaginary + imPartSquare;
            return new Complex(realPart, imPart);
        }
        public double Magnitude { get; set; }
        public double Real { get; set; }
        public double Imaginary { get; set; }

    }
    public class FastBitmap
    {
        public FastBitmap(int width, int height)
        {
            this.Bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        }

        public unsafe void SetPixel(int x, int y, Color color)
        {
            BitmapData data = this.Bitmap.LockBits(new Rectangle(0, 0, this.Bitmap.Width, this.Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr scan0 = data.Scan0;

            byte* imagePointer = (byte*)scan0.ToPointer(); // Pointer to first pixel of image
            int offset = (y * data.Stride) + (3 * x); // 3x because we have 24bits/px = 3bytes/px
            byte* px = (imagePointer + offset); // pointer to the pixel we want
            px[0] = color.B; // Red component
            px[1] = color.G; // Green component
            px[2] = color.R; // Blue component

            this.Bitmap.UnlockBits(data); // Set the data again
        }

        public Bitmap Bitmap
        {
            get;
            set;
        }
    }
    
    public  static class GraphicsEngine
    {
        public static Bitmap DrawImage(int width, int height, List<Tuple<int, int, int, int, int>> CanvassPoints)//int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            FastBitmap img = new FastBitmap(width, height);
            foreach (Tuple<int, int, int, int, int> CanvassPoint in CanvassPoints)
            {
                try
                {
                    img.SetPixel(CanvassPoint.Item1, CanvassPoint.Item2, Color.FromArgb(CanvassPoint.Item3, CanvassPoint.Item4, CanvassPoint.Item5));
                }
                catch (Exception ex)
                {
                    string ex1 = ex.Message;
                }
          //      System.Threading.Thread.Sleep(500);
            }
            return img.Bitmap;
        }
    }
    public static class FractalElements
    {
        public static List<Color> GenerateColorPalette(int r = 0, int g = 0, int b = 255)
        {
            List<Color> retVal = new List<Color>();
            for (int i = 0; i <= 255; i++)
            {

                retVal.Add(Color.FromArgb(255, r, g, b));
                if (r < 254) r++;
                if (g < 254) g++;
                if (b < 254) b++;

            }
            return retVal;
        }
        public static Bitmap DrawRandomReversed(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {

                    for (int i = Palette.Count - 1; i >= 0; i--) // 255 iterations with the method we already wrote
                    {
                        int dividend = (Palette.Count + i - y);

                        if (dividend != 0)
                        {
                            if ((Palette.Count - i + x) % dividend < 2)
                            {
                                img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % dividend < 3 && i > 0)
                            {
                                img.SetPixel(x, y, Palette[i - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % dividend < 4 && i > 1)
                            {
                                img.SetPixel(x, y, Palette[i - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % dividend < 5 && i > 2)
                            {
                                img.SetPixel(x, y, Palette[i - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }

                        }
                        else
                        {
                            if (i == 0)
                            {
                                img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (i > 0)
                            {
                                img.SetPixel(x, y, Palette[i - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (i > 1)
                            {
                                img.SetPixel(x, y, Palette[i - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (i > 2)
                            {
                                img.SetPixel(x, y, Palette[i - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                        }

                    }
                }
            }

            return img.Bitmap;
        }
        public static Bitmap DrawRandomXDecYInc(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0, int ifractalIndex = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            int index = 0;
            for (int x = width - 1; x >= index; x--)
            {
                for (int y = height - 1; y >= 0; y--)
                {

                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        int palletteIndex = i + ifractalIndex;
                        if (palletteIndex > 255)
                            palletteIndex = 0;
                        int dividend = (Palette.Count + i - y);
                        int xDisp = x;
                        if (xDisp > width) xDisp = index;
                        int yDisp = y;
                        if (yDisp > height) yDisp = index;
                        if (dividend != 0)
                        {
                            if ((Palette.Count - palletteIndex + x) % dividend < 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 3 && palletteIndex > 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 4 && palletteIndex > 1)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 5 && palletteIndex > 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }

                        }
                        else
                        {
                            if (palletteIndex == 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 1)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                        }

                    }
                }
            }

            return img.Bitmap;
        }
        public static Bitmap DrawRandomXIncYDec(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0, int ifractalIndex = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            int index = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = height - 1; y >= 0; y--)
                {

                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        int palletteIndex = i + ifractalIndex;
                        if (palletteIndex > 255)
                            palletteIndex = 0;
                        int dividend = (Palette.Count + i - y);
                        int xDisp = x;
                        if (xDisp > width) xDisp = index;
                        int yDisp = y;
                        if (yDisp > height) yDisp = index;
                        if (dividend != 0)
                        {
                            if ((Palette.Count - palletteIndex + x) % dividend < 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 3 && palletteIndex > 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 4 && palletteIndex > 1)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 5 && palletteIndex > 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }

                        }
                        else
                        {
                            if (palletteIndex == 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 1)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                        }

                    }
                }
            }

            return img.Bitmap;
        }
        public static void DrawSinGraphGD(Graphics gd, int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0, int ifractalIndex = 0)
        {
            double yF = 0, yF_Prev = 0;
            List<Tuple<int, int>> graphPoints = new List<Tuple<int,int>>();
            List<Point> points = new List<Point>();
            for (int xM2 = width / 2; xM2 >= 0; xM2--)
            {
                int x = xM2 - (width / 2);
                yF = ((12 * Math.Sin(3 * x) / (1 + Math.Abs(x))) + (double)height / 2.0);
               double deviation = (double)(height / 2.0 - yF) * 150.0;
                yF = (double)(height / 2.0) + deviation;
                if (yF >= 0 && yF < height)
                {
                    points.Add(new Point(Convert.ToInt32(yF),xM2 ));
                    
                }
                


            }
            Pen graphPen = new Pen(new SolidBrush(Color.Black)) ;
            gd.DrawCurve(graphPen,points.ToArray()); //(new Pen(new SolidBrush(Color.Black),2.0), points.ToArray());
        }

        public static Bitmap DrawSinGraph( int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0, int ifractalIndex = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set
            Color DrawGraph = Color.FromArgb(255,0, 70, 10);
            Color DrawGray = Color.FromArgb(255, 240, 240, 240);

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
             
            for (int xM2 = width / 2; xM2 >= 0; xM2--)
            {
                int x = xM2 - (width / 2);
                double yF = ((12 * Math.Sin(3 * x) / (1 + Math.Abs(x))) + (double)height / 2.0);
                double deviation = (double)(height / 2.0 - yF) * 150.0;
                yF = (double)(height / 2.0) + deviation;
                if (yF >= 0 && yF < height)

                    img.SetPixel(xM2, (int)yF, DrawGraph); // Set the pixel if the magnitude is greater than two
                img.SetPixel(xM2, (int)yF + 1, DrawGraph);
                img.SetPixel(xM2, (int)yF - 1, DrawGraph);


            }
            for (int xM = width / 2; xM < width; xM++)
            {
                int x = xM - (width / 2);
                double yF = ((12 * Math.Sin(3 * x) / (1 + Math.Abs(x))) + (double)height / 2.0);
                double deviation = (double)(height / 2.0 - yF) * 150.0;
                yF = (double)(height / 2.0) + deviation;
                if (yF >= 0 && yF < height)
                    img.SetPixel(xM, (int)yF, DrawGraph); // Set the pixel if the magnitude is greater than two
                img.SetPixel(xM, (int)yF + 1, DrawGraph);
                img.SetPixel(xM, (int)yF - 1, DrawGraph);


            }

            return img.Bitmap;
        }

        public static Bitmap DrawRandomXIncYInc(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0, int ifractalIndex = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            int index = 0;
            for (int x = index; x < width; x++)
            {
                for (int y = index; y < height; y++)
                {

                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        int palletteIndex = i + ifractalIndex;
                        if (palletteIndex > 255)
                            palletteIndex = 0;
                        int dividend = (Palette.Count + i - y);
                        int xDisp = x;
                        if (xDisp > width) xDisp = index;
                        int yDisp = y;
                        if (yDisp > height) yDisp = index;
                        if (dividend != 0)
                        {
                            if ((Palette.Count - palletteIndex + x) % dividend < 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 3 && palletteIndex > 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 4 && palletteIndex > 1)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - palletteIndex + x) % dividend < 5 && palletteIndex > 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }

                        }
                        else
                        {
                            if (palletteIndex == 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 0)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 1)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if (palletteIndex > 2)
                            {
                                img.SetPixel(xDisp, yDisp, Palette[palletteIndex - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                        }

                    }
                }
            }

            return img.Bitmap;
        }
        public static Bitmap DrawRandom2(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            for (int x = width - 1; x >= 0; x--)
            {
                for (int y = 0; y < height; y++)
                {

                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        int dividend = (Palette.Count - y);

                        if (dividend != 0)
                        {
                            if ((Palette.Count - i) % dividend < 2)
                            {
                                img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i) % dividend < 3 && i > 0)
                            {
                                img.SetPixel(x, y, Palette[i - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i) % dividend < 4 && i > 1)
                            {
                                img.SetPixel(x, y, Palette[i - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i) % dividend < 5 && i > 2)
                            {
                                img.SetPixel(x, y, Palette[i - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }

                        }
                        else
                        {
                            if ((Palette.Count - i + x) % dividend < 2)
                            {
                                img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % dividend < 3 && i > 0)
                            {
                                img.SetPixel(x, y, Palette[i - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % dividend < 4 && i > 1)
                            {
                                img.SetPixel(x, y, Palette[i - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % dividend < 5 && i > 2)
                            {
                                img.SetPixel(x, y, Palette[i - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                        }

                    }
                }
            }

            return img.Bitmap;
        }
        public static Bitmap DrawRandom2Broken(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            List<Color> Palette = GenerateColorPalette(g, b, r);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            for (int x = height - 1; x >= 0; x--)
            {
                for (int y = 0; y < height; y++)
                {

                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        int dividend = (Palette.Count - i + y);
                        if (dividend == 0) dividend = i + 2;
                        if (dividend != 0)
                        {
                            if ((Palette.Count + i - x) % dividend < 2)
                            {
                                img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            else if ((Palette.Count + i - x) % dividend < 3 && i > 0)
                            {
                                img.SetPixel(x, y, Palette[i - 1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            else if ((Palette.Count + i - x) % dividend < 4 && i > 1)
                            {
                                img.SetPixel(x, y, Palette[i - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            else if ((Palette.Count + i - x) % dividend < 5 && i > 2)
                            {
                                img.SetPixel(x, y, Palette[i - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            //else  
                            //{
                            //    int defaultPalleteIndex = (i + 1 < Palette.Count ? i + 1 : i);
                            //    img.SetPixel(x, y, Palette[defaultPalleteIndex]); // Set the pixel if the magnitude is greater than two
                            //    break;
                            //}
                        }


                    }
                }
            }

            return img.Bitmap;
        }
        public static Bitmap DrawMandelbrot(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            List<Color> Palette = GenerateColorPalette(r, g, b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Complex c = new Complex(x * rScale + rMin, y * iScale + iMin); // Scaled complex number
                    Complex z = c; z = Complex.AddSquaredValueTo(c, z); //c + Complex.Pow(z, 2); // Z = Zlast^2 + C

                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        if (z.Magnitude >= 17.0)
                        {
                            img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                            break; // We're done with this loop
                        }
                        else
                        {
                            z = Complex.AddSquaredValueTo(c, z); //c + Complex.Pow(z, 2); // Z = Zlast^2 + C
                        }
                    }
                }
            }

            return img.Bitmap;
        }
    }
}