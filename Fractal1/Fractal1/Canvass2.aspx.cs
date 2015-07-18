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
    public partial class Canvass2 : System.Web.UI.Page
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

            Bitmap oCanvas = new Bitmap(800, 600);
            Response.ContentType = "image/jpeg";
            int fractalIndex = 0;
            if (Session["FractalIndex"] != null)
            {
                bool isValidIndex = int.TryParse(Session["FractalIndex"].ToString(), out fractalIndex);

            }
            fractalIndex+=10;
            if (fractalIndex > 250)
                fractalIndex = 0;
            oCanvas = FractalImages.DrawRandomIndexed(790, 590, 10, 380, 10, 380, red, green, blue, fractalIndex);
            
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();

            // Cleanup
            //    g.Dispose();
            oCanvas.Dispose();
            Session["FractalIndex"] = fractalIndex;
            // Cleanup
            //    g.Dispose();
            oCanvas.Dispose();
        }

        public void RenderBitmap()
        {
            int fractalIndex = 0;
            if (Session["FractalIndex"] != null)
            {
                bool isValidIndex = int.TryParse(Session["FractalIndex"].ToString(), out fractalIndex);

            }
            fractalIndex++;
            if (fractalIndex > 3)
                fractalIndex = 0;
            Bitmap oCanvas = new Bitmap(500, 450);
            Response.ContentType = "image/jpeg";
            switch (fractalIndex)
            {
                case 0:
                    oCanvas = FractalImages.DrawRandom(390, 390, 10, 380, 10, 380, 125, 125, 255);
                    break;
                case 1:
                    oCanvas = FractalImages.DrawRandom2(390, 390, 10, 380, 10, 380, 125, 125, 255);
                    break;
            }
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            Response.End();

            // Cleanup
            //    g.Dispose();
            oCanvas.Dispose();
            Session["FractalIndex"] = fractalIndex;
        }
    }

    //public partial class Canvass2 : System.Web.UI.Page
    //{
    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        RenderBitmap(true);
       
    //    }
    //    public void RenderBitmap()
    //    {
    //        Bitmap oCanvas = new Bitmap(500, 450);
    //        Response.ContentType = "image/jpeg";
    //        oCanvas = FractalImages.DrawRandom2(790, 590, 10, 380, 10, 380, 0, 255, 0);
    //        oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
    //        Response.End();

    //        // Cleanup
    //        //    g.Dispose();
    //        oCanvas.Dispose();
    //    }
    //    public void RenderBitmap(bool isRandom)
    //    {
    //        int red = 0, green = 0, blue = 0;
    //        bool redYes = int.TryParse(Session["red"].ToString(), out red);
    //        bool greenYes = int.TryParse(Session["green"].ToString(), out green);
    //        bool blueYes = int.TryParse(Session["blue"].ToString(), out blue);

    //        Bitmap oCanvas = new Bitmap(500, 450);
    //        Response.ContentType = "image/jpeg";
    //        oCanvas = FractalImages.DrawRandom2(790, 590, 10, 380, 10, 380, red, green, blue);
    //        oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
    //        Response.End();

    //        // Cleanup
    //        //    g.Dispose();
    //        oCanvas.Dispose();
           
    //    }
    
    //}
}