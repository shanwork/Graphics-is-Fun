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
    public partial class FractalContainer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBitmap();
       
        }
        public void RenderBitmap()
        {
            int red = 0, green = 0, blue = 0;
            if (Session["red"] == null)
            {
                Session["red"] = 125;
            }
            else
            {
                red = int.Parse(Session["red"].ToString());
                switch(red)
                {
                    case 0: Session["red"] = 100; break;
                    case 100: Session["red"] = 150; break;
                    case 150: Session["red"] = 200; break;
                    case 200: Session["red"] = 255; break;
                    default: Session["red"] = 0; break;
                }
            }
            if (Session["green"] == null)
            {
                Session["green"] = 150;
            }
            else
            {
                green = int.Parse(Session["green"].ToString());
                switch (green)
                {
                    case 0: Session["green"] = 100; break;
                    case 100: Session["green"] = 150; break;
                    case 150: Session["green"] = 200; break;
                    case 200: Session["green"] = 255; break;
                    default: Session["green"] = 0; break;
                }
            }
            if (Session["blue"] == null)
            {
                Session["blue"] = 200;
            }
            else
            {
                blue = int.Parse(Session["blue"].ToString());
                switch (blue)
                {
                    case 0: Session["blue"] = 100; break;
                    case 100: Session["blue"] = 150; break;
                    case 150: Session["blue"] = 200; break;
                    case 200: Session["blue"] = 255; break;
                    default: Session["blue"] = 0; break;
                }
            }
            Bitmap oCanvas = new Bitmap(500, 450);
            Response.ContentType = "image/jpeg";
            oCanvas = FractalImages.DrawRandom(390, 390, 10, 380, 10, 380, red, green, blue);
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();

            // Cleanup
            //    g.Dispose();
            oCanvas.Dispose();
        }
    }
}