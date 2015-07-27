using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;


namespace Fractal1
{
    public class Aspx_FastBitmap
    {
        public Aspx_FastBitmap(int width, int height)
        {
            this.Aspx_Bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);
        }

        public unsafe void SetPixel(int x, int y, Color color)
        {
            BitmapData data = this.Aspx_Bitmap.LockBits(new Rectangle(0, 0, this.Aspx_Bitmap.Width, this.Aspx_Bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr scan0 = data.Scan0;

            byte* imagePointer = (byte*)scan0.ToPointer(); // Pointer to first pixel of image
            int offset = (y * data.Stride) + (3 * x); // 3x because we have 24bits/px = 3bytes/px
            byte* px = (imagePointer + offset); // pointer to the pixel we want
            px[0] = color.B; // Red component
            px[1] = color.G; // Green component
            px[2] = color.R; // Blue component

            this.Aspx_Bitmap.UnlockBits(data); // Set the data again
        }

        public Bitmap Aspx_Bitmap
        {
            get;
            set;
        }
    }
    
    public partial class aspx_graphics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected Bitmap DrawImage(int width, int height, List<Tuple<int, int, int, int, int>> CanvassPoints)//int width, int height, double rMin, double rMax, double iMin, double iMax, int r = 0, int g = 0, int b = 0)
        {
            FastBitmapTemp img = new FastBitmapTemp(width, height);
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
                System.Threading.Thread.Sleep(500);
            }
            return img.Bitmap;
        }
    }
}