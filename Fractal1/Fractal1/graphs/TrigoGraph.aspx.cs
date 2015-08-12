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
    public partial class TrigoGraph : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBitmap(true);

        }
        public void RenderBitmap(bool isRandom)
        {
            int red = 0, green = 0, blue = 0;
            //bool redYes = int.TryParse(Session["red"].ToString(), out red);
            //bool greenYes = int.TryParse(Session["green"].ToString(), out green);
            //bool blueYes = int.TryParse(Session["blue"].ToString(), out blue);

            Bitmap oCanvas = new Bitmap(300, 290);
            Graphics gd =  Graphics.FromImage(oCanvas);
            gd.FillRectangle(new SolidBrush(Color.Silver), new Rectangle(new Point(2,2),new Size(295,285)));
          //  //Response.ContentType = "image/jpeg";
          //  int fractalIndex = 0;
          //  if (Session["FractalIndex"] != null)
          //  {
          //      bool isValidIndex = int.TryParse(Session["FractalIndex"].ToString(), out fractalIndex);

          //  }
          //  fractalIndex += 10;
          //  if (fractalIndex > 250)
          //      fractalIndex = 0;
          // FractalElements.DrawSinGraph( 270, 270, 5, 270, 10, 270, red, green, blue, fractalIndex);
          //// oCanvas = FractalElements.DrawSinGraph(gd, 430, 380, 10, 380, 10, 380, red, green, blue, fractalIndex);

          //  oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
          //  Response.End();

          //  // Cleanup
          //  //    g.Dispose();
          //  oCanvas.Dispose();
          //  Session["FractalIndex"] = fractalIndex;
            // Cleanup
            //    g.Dispose();
            //oCanvas.Dispose();
        }

    }
}