using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Fractal1.Core;

namespace Fractal1
{
    public partial class FractalsParent : System.Web.UI.Page
    {
        
        public void RenderBitmap(bool isRandom, int width, int height,Tuple<int, int, int> rgb=null, int marginX=0, int marginY=0)
        {
            int red = 0, green = 0, blue = 0;
            if (rgb != null)
            {
                red = rgb.Item1;
                green = rgb.Item2;
                blue = rgb.Item3;
            }
            if (isRandom == true)
            {
                bool redYes = int.TryParse(Session["red"].ToString(), out red);
                bool greenYes = int.TryParse(Session["green"].ToString(), out green);
                bool blueYes = int.TryParse(Session["blue"].ToString(), out blue);
            }
            Bitmap oCanvas = new Bitmap(width, height);
            Response.ContentType = "image/jpeg";
            int fractalIndex = 0;
            if (Session["FractalIndex"] != null)
            {
                bool isValidIndex = int.TryParse(Session["FractalIndex"].ToString(), out fractalIndex);

            }
            fractalIndex += 10;
            if (fractalIndex > 250)
                fractalIndex = 0;
            oCanvas = FractalElements.DrawRandomXIncYDec(width-2,height-2, 10, height-4, 10, height-4, red, green, blue, fractalIndex);
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();
            oCanvas.Dispose();
            Session["FractalIndex"] = fractalIndex;
        }
    }
}