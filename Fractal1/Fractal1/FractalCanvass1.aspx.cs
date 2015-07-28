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
    public partial class FractalCanvass1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBitmap(true);
        

        }
        public void RenderBitmap(bool isRandom)
        {
            int red = 0, green = 0, blue = 0;
            bool redYes = int.TryParse(Session["red"].ToString(), out red);
            bool greenYes = int.TryParse(Session["green"].ToString(), out green);
            bool blueYes = int.TryParse(Session["blue"].ToString(), out blue);

            Bitmap oCanvas = new Bitmap(500, 450);
            Response.ContentType = "image/jpeg";
          //  oCanvas = FractalElements.DrawRandom(790, 590, 10, 380, 10, 380, red, green, blue);
            int fractalIndex = 0;
            if (Session["FractalIndex"] != null)
            {
                bool isValidIndex = int.TryParse(Session["FractalIndex"].ToString(), out fractalIndex);

            }
            fractalIndex += 10;
            if (fractalIndex > 250)
                fractalIndex = 0;
            oCanvas = FractalElements.DrawRandomXIncYInc(490, 440, 10, 380, 10, 380, red, green, blue, fractalIndex);
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();

            // Cleanup
            //    g.Dispose();
            oCanvas.Dispose();
        }
    
        public void RenderBitmap()
        {
            Bitmap oCanvas = new Bitmap(500, 450);
            Response.ContentType = "image/jpeg";
            oCanvas = FractalElements.DrawRandomReversed(390, 390, 10, 380, 10, 380,125,125,255);
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();

            // Cleanup
            //    g.Dispose();
            oCanvas.Dispose();
        }
    }
}