﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

namespace Fractal1
{
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
        public  static Complex Pow(Complex z, int powerTo)
        {
            //for now power to two
            double realPart = z.Real * z.Real - z.Imaginary * z.Imaginary;
            double imPart = 2 * z.Imaginary * z.Real  ;
            return new Complex(realPart, imPart);

        }
        // <-- End --- using this instead
        public static Complex AddSquaredValueTo(Complex c, Complex z )
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
    public static class FractalImages
    {
        public static List<Color> GenerateColorPalette(int r=0,int g=0, int b=255)
        {
            List<Color> retVal = new List<Color>();
            for (int i = 0; i <= 255; i++)
            {
                
                retVal.Add(Color.FromArgb(255, r,g, b));
                if (r < 254) r++;
                if (g < 254) g++;
                if (b < 254) b++;

            }
            return retVal;
        }
        public static Bitmap DrawRandom(int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            List<Color> Palette = GenerateColorPalette(r,g,b);
            FastBitmap img = new FastBitmap(width, height); // Bitmap to contain the set

            double rScale = (Math.Abs(rMin) + Math.Abs(rMax)) / width; // Amount to move each pixel in the real numbers
            double iScale = (Math.Abs(iMin) + Math.Abs(iMax)) / height; // Amount to move each pixel in the imaginary numbers

            Random xRand = new Random();
            Random yRand = new Random();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    
                    for (int i = 0; i < Palette.Count; i++) // 255 iterations with the method we already wrote
                    {
                        try
                        {
                            if ((Palette.Count - i + x) % (Palette.Count + i - y) < 2)
                            {
                                img.SetPixel(x, y, Palette[i]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % (Palette.Count + i - y) < 3 && i > 0)
                            {
                                img.SetPixel(x, y, Palette[i-1]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % (Palette.Count + i - y) < 4 && i > 1)
                            {
                                img.SetPixel(x, y, Palette[i - 2]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                            if ((Palette.Count - i + x) % (Palette.Count + i - y) < 5 && i > 2)
                            {
                                img.SetPixel(x, y, Palette[i - 3]); // Set the pixel if the magnitude is greater than two
                                break;
                            }
                           
                        }
                        catch (DivideByZeroException ex)
                        {
                            continue;
                        }
                     
                    }
                }
            }

            return img.Bitmap;
        }
        public static Bitmap DrawMandelbrot(int width, int height, double rMin, double rMax, double iMin, double iMax, int r=0, int g=0, int b=0)
        {
            List<Color> Palette = GenerateColorPalette(r,g,b);
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