using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Fractal1.Core;
using Fractal1.BusinessLayer;
using Fractal1.graphs;
using DataModelLibrary1;

namespace Fractal1.EVSales
{
    public partial class EVGraphByRegion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBitmap(false, 400, 390);
        }
        public void RenderBitmap(bool isRandom, int bitmapWidth, int bitmapHeight, Tuple<int, int, int> rgb = null, int marginX = 0, int marginY = 0)
        {
            var IEnumSalesByRegion = Singleton.EVSales.groupByRegion().AsEnumerable();
            var maxSaleAmount = 
                (from row in IEnumSalesByRegion 
                     select Convert.ToDouble(row.Item2.Replace("$","").Replace(",",""))).Max();
            int numXTicks = IEnumSalesByRegion.Count() + 2;
            int numYTicks = 10;
            int unitY = 100000000;

            // factor as to one pixel represents how much quantity
            int xTickIntervals = (bitmapWidth - 2) / numXTicks;
            int yTickIntervals = (bitmapHeight - 2) / numYTicks;
            int[] yAxis = { bitmapHeight - 18, bitmapHeight - 15 };

            // number of Y ticks want a nin zero amount
            int factoringYTicks = 1000;
            do
            {
                numYTicks = (int)((maxSaleAmount + factoringYTicks) / (double)unitY);
                unitY *= 1000;
            } while (numYTicks <= 0);
            yTickIntervals = (bitmapHeight - 2) / numYTicks;
                
            int red = 0, green = 0, blue = 0;
            if (rgb != null)
            {
                red = rgb.Item1;
                green = rgb.Item2;
                blue = rgb.Item3;
            }
            
            int[] xAxis = { 15, 18 };

            if (isRandom == true)
            {
                bool redYes = int.TryParse(Session["red"].ToString(), out red);
                bool greenYes = int.TryParse(Session["green"].ToString(), out green);
                bool blueYes = int.TryParse(Session["blue"].ToString(), out blue);
            }
            Bitmap oCanvas = new Bitmap(bitmapWidth, bitmapHeight);
            Response.ContentType = "image/jpeg";
            List<Tuple<int, int, int, int, int>> CanvassPoints = new List<Tuple<int, int, int, int, int>>();
            // set the pixels
            int backgroundRedValue = 220, backgroundBlueValue = 220, backgroundGreenValue = 220;
            int axesRedValue = 0, axesGreenValue = 30, axesBlueValue = 100;
            int regionSalesRedValue = 0, regionSalesGreenValue = 30, regionSalesBlueValue = 100;
            int barThickness = 30;
            int regionSalesAmount;
                /*
                 GraphBackground="220,220,220" 
            AxesColor="0,30,100" 
            TargetLevelColor="9,46,32"
            BelowTargetColor="0,120,171"
            ExceedTargetColor="0,158,130"
            FallShortTargetColor="255,120,50"
            BarThickness="30"
                 */
            for (int x = 1; x < (bitmapWidth - 1); x++)
            {
                for (int y = 1; y < (bitmapHeight - 1); y++)
                {
                    // draw the default base background ...
                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRedValue, backgroundGreenValue, backgroundBlueValue));

                    // processing the ticks and axes
                    if ((y >= yAxis[0] && y < yAxis[1]) ||
                        (x >= xAxis[0] && x < xAxis[1]) ||
                        ((x % xTickIntervals == 0 || (x + 1) % xTickIntervals == 0) && (y > yAxis[1] && y < bitmapHeight - 6))
                      || ((y % yTickIntervals == 0 || (y + 1) % yTickIntervals == 0) && (x > 5 && x < xAxis[1]) && y < yAxis[0]))
                    {
                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, axesRedValue, axesGreenValue, axesBlueValue));
                    }
                    // actual data values - bar drawing
                    else
                    {
                        for (int bt = 0; bt < barThickness / 2; bt++)
                        {
                            if (x > xAxis[1])
                            {
                                if ((x - bt) % xTickIntervals == 0 || (x + bt) % xTickIntervals == 0)
                                {
                                    int xMultiple = (x - bt) % xTickIntervals == 0 ? (x - bt) / xTickIntervals :
                                             (x + bt) / xTickIntervals;
                                    xMultiple--;
                                    if (Singleton.EVSales.groupByRegion().Count > xMultiple && y < yAxis[1])
                                    {
                                        regionSalesAmount = Convert.ToInt32(Singleton.EVSales.groupByRegion()[xMultiple].Item2.Replace("$", "").Replace(",", "")) / numYTicks;
                                        if ((y + 1) > yAxis[1] - (regionSalesAmount * 10) && y < yAxis[1])
                                                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, regionSalesRedValue, regionSalesGreenValue, regionSalesBlueValue));
                                         

                                        }
                                        //else
                                        //{
                                        //    if ((y + 1) > yAxis[1] - (targetedAmount) * 10 && y < yAxis[1] - actualAmount * 10)
                                        //        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, fallShortTargetRed, fallShortTargetGreen, fallShortTargetBlue));
                                        //    if (y >= yAxis[1] - actualAmount * 10 && y < yAxis[1])
                                        //        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, belowTargetRed, belowTargetGreen, belowTargetBlue));
                                        //    if (y < yAxis[1] - targetedAmount * 10)
                                        //        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRedValue, backgroundGreenValue, backgroundBlueValue));

                                        //}
                                        //if (y == yAxis[1] - targetedAmount * 10 ||
                                        //    (y + 1) == yAxis[1] - targetedAmount * 10)
                                        //    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, targetLevelRed, targetLevelGreen, targetLevelBlue));


                                    }
                             //   }


                            }
                            //else 
                            //    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));


                        }
                    }
                } // end Y loop
            } // end X loop
            oCanvas =  GraphicsEngine.DrawImage(bitmapWidth, bitmapHeight, CanvassPoints);
            oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            oCanvas.Dispose();    
            int fractalIndex = 0;
            if (Session["FractalIndex"] != null)
            {
                bool isValidIndex = int.TryParse(Session["FractalIndex"].ToString(), out fractalIndex);

            }
            //fractalIndex += 10;
            //if (fractalIndex > 250)
            //    fractalIndex = 0;
            //oCanvas = FractalElements.DrawRandomXIncYDec(width - 2, height - 2, 10, height - 4, 10, height - 4, red, green, blue, fractalIndex);
            //oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
            //Response.End();
            //oCanvas.Dispose();
            //Session["FractalIndex"] = fractalIndex;
        }
    
    }
}