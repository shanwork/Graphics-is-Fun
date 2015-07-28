using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using Fractal1.Core;
using Fractal1.BusinessLayer;

namespace Fractal1
{
    public partial class TargetActualGraphCanvass : System.Web.UI.Page
    {
        int backgroundRed, backgroundGreen, backgroundBlue;
        int axesRedValue, axesGreenValue, axesBlueValue;
        int targetLevelRed, targetLevelGreen, targetLevelBlue ;
        int belowTargetRed,  belowTargetGreen, belowTargetBlue ;
        int exceedTargetRed, exceedTargetGreen, exceedTargetBlue ;
        int fallShortTargetRed, fallShortTargetGreen, fallShortTargetBlue ;
        int barThickness;
        protected void Page_Load(object sender, EventArgs e)
        {
            SetValues();
            RenderGraph();
        }
        void SetValues()
        {
            backgroundRed= backgroundGreen= backgroundBlue = 220;
            if (Session["GraphBackground"] != null)
            {
                string[] backgroundRDBValues = Session["GraphBackground"].ToString().Split(',');
                if (backgroundRDBValues.Length == 3)
                {
                    bool bRed = int.TryParse(backgroundRDBValues[0], out backgroundRed);
                    bool bGreen = int.TryParse(backgroundRDBValues[1], out backgroundGreen);
                    bool bBlue = int.TryParse(backgroundRDBValues[2], out backgroundBlue);
                }
            }

            axesRedValue =  axesGreenValue =  axesBlueValue = 0;
            if (Session["AxesColor"] != null)
            {
                string[] ticksAndAxisRDBValues = Session["AxesColor"].ToString().Split(',');
                if (ticksAndAxisRDBValues.Length == 3)
                {
                    bool tRed = int.TryParse(ticksAndAxisRDBValues[0], out axesRedValue);
                    bool tGreen = int.TryParse(ticksAndAxisRDBValues[1], out axesGreenValue);
                    bool tBlue = int.TryParse(ticksAndAxisRDBValues[2], out axesBlueValue);
                }
            }
            targetLevelRed = 0; targetLevelGreen = 180; targetLevelBlue = 10;
            if (Session["TargetLevelColor"] != null)
            {
                string[] targetLevelRGBValues = Session["TargetLevelColor"].ToString().Split(',');
                if (targetLevelRGBValues.Length == 3)
                {
                    bool tgRed = int.TryParse(targetLevelRGBValues[0], out targetLevelRed);
                    bool tgGreen = int.TryParse(targetLevelRGBValues[1], out targetLevelGreen);
                    bool tgBlue = int.TryParse(targetLevelRGBValues[2], out targetLevelBlue);
                }
            }
            belowTargetRed = 0; belowTargetGreen = 10; belowTargetBlue = 180;
            if (Session["BelowTargetColor"] != null)
            {
                string[] belowTargetRGBValues = Session["BelowTargetColor"].ToString().Split(',');
                if (belowTargetRGBValues.Length == 3)
                {
                    bool btRed = int.TryParse(belowTargetRGBValues[0], out belowTargetRed);
                    bool btGreen = int.TryParse(belowTargetRGBValues[1], out belowTargetGreen);
                    bool btBlue = int.TryParse(belowTargetRGBValues[2], out belowTargetBlue);
                }
            }
            exceedTargetRed = 0; exceedTargetGreen = 250; exceedTargetBlue = 100;
            if (Session["ExceedTargetColor"] != null)
            {
                string[] exceedTargetRGBValues = Session["ExceedTargetColor"].ToString().Split(',');
                if (exceedTargetRGBValues.Length == 3)
                {
                    bool etRed = int.TryParse(exceedTargetRGBValues[0], out exceedTargetRed);
                    bool etGreen = int.TryParse(exceedTargetRGBValues[1], out exceedTargetGreen);
                    bool etBlue = int.TryParse(exceedTargetRGBValues[2], out exceedTargetBlue);
                }
            }
            fallShortTargetRed = 250; fallShortTargetGreen = 150; fallShortTargetBlue = 50;
            if (Session["FallShortTargetColor"] != null)
            {
                string[] fallShortTargetRGBValues = Session["FallShortTargetColor"].ToString().Split(',');
                if (fallShortTargetRGBValues.Length == 3)
                {
                    bool fstRed = int.TryParse(fallShortTargetRGBValues[0], out fallShortTargetRed);
                    bool fstGreen = int.TryParse(fallShortTargetRGBValues[1], out fallShortTargetGreen);
                    bool fstBlue = int.TryParse(fallShortTargetRGBValues[2], out fallShortTargetBlue);
                }
            }
            barThickness = 10;
            if (Session["BarThickness"] != null)
            {
                bool bThickness = int.TryParse(Session["BarThickness"].ToString(), out barThickness);
            }
        }
        protected void RenderGraph()
        {
            // getting the data..
            
            
            DataTable dtRegionSalesByUnits = SalesData.getRegionSalesUnitsData();

            
            var regionSalesEnumreable = dtRegionSalesByUnits.AsEnumerable();
            var maxTarget = (
                    from row in regionSalesEnumreable
                    select row.Field<string>(2)).Max();
            var maxSales = (from row in regionSalesEnumreable
                            select row.Field<string>(3)).Max();
            // legitimizing and finding boundary values to set the graph ticks
            int maxSalesInt = 0, maxTargetInt = 0;// (string)maxTarget > (int)maxSales ? (int)maxTarget : (int)maxSales + 1000;
            bool maxSalesBool = int.TryParse(maxSales.ToString(), out maxSalesInt);
            bool maxTargetBool = int.TryParse(maxTarget.ToString(), out maxTargetInt);
            float quantityToPixel = 0;
            // legitimate data.. so we proceed to draw the graph...
            if (maxSalesBool && maxTargetBool)
            {
                int numXTicks = dtRegionSalesByUnits.Rows.Count + 2;
                int numYTicks = 10;
                int unitY = 1000;
                int bitmapWidth = 590, bitmapHeight = 490;

                // factor as to one pixel represents how much quantity
                quantityToPixel = (((maxSalesInt > maxTargetInt ? maxSalesInt : maxTargetInt) + 1000) / unitY)
                    / (bitmapHeight - 19);
                // number of Y ticks
                numYTicks = ((maxSalesInt > maxTargetInt ? maxSalesInt : maxTargetInt) + 1000) / unitY;

                Bitmap oCanvas = new Bitmap(bitmapWidth, bitmapHeight);
                int xTickIntervals = (bitmapWidth - 2) / numXTicks;
                int yTickIntervals = (bitmapHeight - 2) / numYTicks;
                int[] yAxis = { bitmapHeight - 18, bitmapHeight - 15 };

                int[] xAxis = { 15, 18 };

                Response.ContentType = "image/jpeg";
                List<Tuple<int, int, int, int, int>> CanvassPoints = new List<Tuple<int, int, int, int, int>>();
                int targetedAmount = 0, actualAmount = 0;
                for (int x = 1; x < (bitmapWidth - 1); x++)
                {
                    for (int y = 1; y < (bitmapHeight - 1); y++)
                    {
                        // draw the default base background ...
                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));
                            
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
                                        if (dtRegionSalesByUnits.Rows.Count > xMultiple && y < yAxis[1])
                                        {
                                            targetedAmount = Convert.ToInt32(dtRegionSalesByUnits.Rows[xMultiple]["TargetSalesUnits"]) / 1000;
                                            actualAmount = Convert.ToInt32(dtRegionSalesByUnits.Rows[xMultiple]["SoldUnits"]) / 1000;
                                            // falls short
                                            if (targetedAmount <= actualAmount)
                                            {
                                                if ((y + 1) > yAxis[1] - (targetedAmount * 10) && y < yAxis[1])
                                                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, belowTargetRed, belowTargetGreen, belowTargetBlue));
                                                if (targetedAmount < actualAmount)
                                                {
                                                    if (y >= yAxis[1] - actualAmount * 10 && y < yAxis[1] - targetedAmount * 10)
                                                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, exceedTargetRed, exceedTargetGreen, exceedTargetBlue));


                                                }
                                                if (y < yAxis[1] - actualAmount * 10)
                                                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));


                                                //if (targetedAmount == actualAmount && y <  yAxis[1] - targetedAmount)
                                                //    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));


                                            }
                                            else
                                            {
                                                if ((y + 1) > yAxis[1] - (targetedAmount) * 10 && y < yAxis[1] - actualAmount * 10)
                                                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, fallShortTargetRed, fallShortTargetGreen, fallShortTargetBlue));
                                                if (y >= yAxis[1] - actualAmount * 10 && y < yAxis[1])
                                                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, belowTargetRed, belowTargetGreen, belowTargetBlue));
                                                if (y < yAxis[1] - targetedAmount * 10)
                                                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));

                                            }
                                            if (y == yAxis[1] - targetedAmount * 10 ||
                                                (y + 1) == yAxis[1] - targetedAmount * 10)
                                                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, targetLevelRed, targetLevelGreen, targetLevelBlue));


                                        }
                                    }
                                   
                                    
                                }
                                //else 
                                //    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));


                            }
                        } 
                         }
                }
                oCanvas = GraphicsEngine.DrawImage(bitmapWidth, bitmapHeight, CanvassPoints);
                oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
                oCanvas.Dispose();
            }
        }
        #region previousIterations
        protected void RenderGraphHardCodedBarThickness()
        {
            // getting the data..


            DataTable dtRegionSalesByUnits = SalesData.getRegionSalesUnitsData();


            var regionSalesEnumreable = dtRegionSalesByUnits.AsEnumerable();
            var maxTarget = (
                    from row in regionSalesEnumreable
                    select row.Field<string>(2)).Max();
            var maxSales = (from row in regionSalesEnumreable
                            select row.Field<string>(3)).Max();
            // legitimizing and finding boundary values to set the graph ticks
            int maxSalesInt = 0, maxTargetInt = 0;// (string)maxTarget > (int)maxSales ? (int)maxTarget : (int)maxSales + 1000;
            bool maxSalesBool = int.TryParse(maxSales.ToString(), out maxSalesInt);
            bool maxTargetBool = int.TryParse(maxTarget.ToString(), out maxTargetInt);
            float quantityToPixel = 0;
            // legitimate data.. so we proceed to draw the graph...
            if (maxSalesBool && maxTargetBool)
            {
                int numXTicks = dtRegionSalesByUnits.Rows.Count + 2;
                int numYTicks = 10;
                int unitY = 1000;
                int bitmapWidth = 590, bitmapHeight = 490;

                // factor as to one pixel represents how much quantity
                quantityToPixel = (((maxSalesInt > maxTargetInt ? maxSalesInt : maxTargetInt) + 1000) / unitY)
                    / (bitmapHeight - 19);
                // number of Y ticks
                numYTicks = ((maxSalesInt > maxTargetInt ? maxSalesInt : maxTargetInt) + 1000) / unitY;

                Bitmap oCanvas = new Bitmap(bitmapWidth, bitmapHeight);
                int xTickIntervals = (bitmapWidth - 2) / numXTicks;
                int yTickIntervals = (bitmapHeight - 2) / numYTicks;
                int[] yAxis = { bitmapHeight - 18, bitmapHeight - 15 };

                int[] xAxis = { 15, 18 };

                Response.ContentType = "image/jpeg";
                List<Tuple<int, int, int, int, int>> CanvassPoints = new List<Tuple<int, int, int, int, int>>();
                int targetedAmount = 0, actualAmount = 0;
                for (int x = 1; x < (bitmapWidth - 1); x++)
                {
                    for (int y = 1; y < (bitmapHeight - 1); y++)
                    {
                        if ((y >= yAxis[0] && y < yAxis[1]) ||
                            (x >= xAxis[0] && x < xAxis[1]) ||
                            ((x % xTickIntervals == 0 || (x + 1) % xTickIntervals == 0) && (y > yAxis[1] && y < bitmapHeight - 6))
                          || ((y % yTickIntervals == 0 || (y + 1) % yTickIntervals == 0) && (x > 5 && x < xAxis[1]) && y < yAxis[0]))
                        {
                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, axesRedValue, axesGreenValue, axesBlueValue));
                        }
                        else if ((x > xAxis[1]) && (x % xTickIntervals == 0 ||
                                  (x + 1) % xTickIntervals == 0 ||
                                  (x - 1) % xTickIntervals == 0 ||
                                  (x + 2) % xTickIntervals == 0 ||
                                  (x - 2) % xTickIntervals == 0 ||
                                  (x + 3) % xTickIntervals == 0 ||
                                  (x - 3) % xTickIntervals == 0))
                        {

                            int xMultiple = x % xTickIntervals == 0 ? x / xTickIntervals :
                                    (x + 1) % xTickIntervals == 0 ? (x + 1) / xTickIntervals :
                                    (x - 1) % xTickIntervals == 0 ? (x - 1) / xTickIntervals :
                                    (x - 2) % xTickIntervals == 0 ? (x - 2) / xTickIntervals :
                                    (x + 2) % xTickIntervals == 0 ? (x + 2) / xTickIntervals :
                                    (x - 3) % xTickIntervals == 0 ? (x - 3) / xTickIntervals :
                                    (x + 3) / xTickIntervals;
                            xMultiple--;
                            if (dtRegionSalesByUnits.Rows.Count > xMultiple && y < yAxis[1])
                            {
                                targetedAmount = Convert.ToInt32(dtRegionSalesByUnits.Rows[xMultiple]["TargetSalesUnits"]) / 1000;
                                actualAmount = Convert.ToInt32(dtRegionSalesByUnits.Rows[xMultiple]["SoldUnits"]) / 1000;
                                // falls short
                                if (targetedAmount <= actualAmount)
                                {
                                    if ((y + 1) > yAxis[1] - (targetedAmount * 10) && y < yAxis[1])
                                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, belowTargetRed, belowTargetGreen, belowTargetBlue));
                                    if (targetedAmount < actualAmount)
                                    {
                                        if (y >= yAxis[1] - actualAmount * 10 && y < yAxis[1] - targetedAmount * 10)
                                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, exceedTargetRed, exceedTargetGreen, exceedTargetBlue));


                                    }
                                    if (y < yAxis[1] - actualAmount * 10)
                                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));


                                    //if (targetedAmount == actualAmount && y <  yAxis[1] - targetedAmount)
                                    //    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));


                                }
                                else
                                {
                                    if ((y + 1) > yAxis[1] - (targetedAmount) * 10 && y < yAxis[1] - actualAmount * 10)
                                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, fallShortTargetRed, fallShortTargetGreen, fallShortTargetBlue));
                                    if (y >= yAxis[1] - actualAmount * 10 && y < yAxis[1])
                                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, belowTargetRed, belowTargetGreen, belowTargetBlue));
                                    if (y < yAxis[1] - targetedAmount * 10)
                                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));

                                }
                                if (y == yAxis[1] - targetedAmount * 10 ||
                                    (y + 1) == yAxis[1] - targetedAmount * 10)
                                    CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, targetLevelRed, targetLevelGreen, targetLevelBlue));


                            }
                            else
                                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));
                        }
                        else
                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, backgroundRed, backgroundGreen, backgroundBlue));
                    }
                }
                oCanvas = GraphicsEngine.DrawImage(bitmapWidth, bitmapHeight, CanvassPoints);
                oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
                oCanvas.Dispose();
            }
        }
        //protected void RenderRegionSalesByUnitsGraphHardCodeValues()
        //{
        //    DataTable dtRegionSalesByUnits = SalesData.getRegionSalesUnitsData();
        //    int numXTicks = dtRegionSalesByUnits.Rows.Count + 2;
        //    int numYTicks = 10;
        //    int unitY = 1000;
        //    int bitmapWidth = 590, bitmapHeight = 490;
        //    var regionSalesEnumreable = dtRegionSalesByUnits.AsEnumerable();
        //    var maxTarget = (
        //            from row in regionSalesEnumreable
        //            select row.Field<string>(2)).Max();
        //    var maxSales = (from row in regionSalesEnumreable
        //                    select row.Field<string>(3)).Max();

        //    int maxSalesInt = 0, maxTargetInt = 0;// (string)maxTarget > (int)maxSales ? (int)maxTarget : (int)maxSales + 1000;
        //    bool maxSalesBool = int.TryParse(maxSales.ToString(), out maxSalesInt);
        //    bool maxTargetBool = int.TryParse(maxTarget.ToString(), out maxTargetInt);

        //    if (maxSalesBool && maxTargetBool)
        //        numYTicks = (maxSalesInt > maxTargetInt ? maxSalesInt : maxTargetInt) + 1000 / unitY;
        //    Bitmap oCanvas = new Bitmap(bitmapWidth, bitmapHeight);
        //    int xTickIntervals = (bitmapWidth - 2) / numXTicks;
        //    int yTickIntervals = (bitmapHeight - 2) / numYTicks;
        //    int[] yAxis = { bitmapHeight - 18, bitmapHeight - 15 };

        //    int[] xAxis = { 15, 18 };

        //    Response.ContentType = "image/jpeg";
        //    List<Tuple<int, int, int, int, int>> CanvassPoints = new List<Tuple<int, int, int, int, int>>();
        //    for (int x = 1; x < (bitmapWidth - 1); x++)
        //    {
        //        for (int y = 1; y < (bitmapHeight - 1); y++)
        //        {
        //            if ((y >= yAxis[0] && y < yAxis[1]) ||
        //                (x >= xAxis[0] && x < xAxis[1]) ||
        //                ((x % xTickIntervals == 0 || (x + 1) % xTickIntervals == 0) && (y > yAxis[1] && y < bitmapHeight - 6))
        //              || ((y % yTickIntervals == 0 || (y + 1) % yTickIntervals == 0) && (x > 5 && x < xAxis[1]) && y < yAxis[0]))
        //            {
        //                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, TicksAndAxisBackgroundBackgroundRed,TicksAndAxisBackgroundBackgroundGreen,tickAndAxisBlue));
        //            }
        //            else if (x % xTickIntervals == 0 ||
        //                      (x + 1) % xTickIntervals == 0 ||
        //                      (x - 1) % xTickIntervals == 0 ||
        //                      (x + 2) % xTickIntervals == 0 ||
        //                      (x - 2) % xTickIntervals == 0 ||
        //                      (x + 3) % xTickIntervals == 0 ||
        //                      (x - 3) % xTickIntervals == 0)
        //            {
        //                int xMultiple = x % xTickIntervals == 0 ? x / xTickIntervals :
        //                        (x + 1) % xTickIntervals == 0 ? (x + 1) / xTickIntervals :
        //                        (x - 1) % xTickIntervals == 0 ? (x - 1) / xTickIntervals :
        //                        (x - 2) % xTickIntervals == 0 ? (x - 2) / xTickIntervals :
        //                        (x + 2) % xTickIntervals == 0 ? (x + 2) / xTickIntervals :
        //                        (x - 3) % xTickIntervals == 0 ? (x - 3) / xTickIntervals :
        //                        (x + 3) / xTickIntervals;
        //                switch (xMultiple)
        //                {
        //                    case 1:
        //                        if (y > 200 && y <= 220)
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 250, 150));
        //                        else if (y > 220 && y <= 223)
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 0, 150, 0));
        //                        else if (y > 223 && y <= yAxis[1])
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 150, 250));
        //                        else
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));
        //                        break;
        //                    case 2:
        //                        if (y > 190 && y <= 250)
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 250, 150));
        //                        else if (y > 250 && y <= 253)
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 0, 150, 0));
        //                        else if (y > 253 && y <= yAxis[1])
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 150, 250));
        //                        else
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));
        //                        break;
        //                    case 3:
        //                        if (y > 290 && y < 293)
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 0, 150, 0));
        //                        else if (y > 293 && y <= 310)
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 250, 150, 150));
        //                        else if (y > 310 && y <= yAxis[1])
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 150, 250));
        //                        else
        //                            CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));
        //                        break;
        //                    default:
        //                        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));
        //                        break;
        //                }
        //            }
        //            else
        //                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));
        //        }
        //    }
        //    #region commented
        //    /*
        //    for (int x = 10; x < (bitmapWidth - 10); x++)
        //    {
        //        for (int y = 10; y < (bitmapHeight - 10); y++)
        //        {
        //            if ((y >= yAxis[0] && y < yAxis[2])
        //            || )
        //            ////  if ((y > 430 && y < 433)
        //            // //     ||( x>12 && x < 15)
        //            //  //    || ((x%xTickIntervals == 0||(x+1)%xTickIntervals==0) && (y >433 && y < 438))
        //            //  //    || ((y%yTickIntervals == 0||(y+1)%yTickIntervals==0) && (x > 2 && x < 12))
        //            //      )
        //            {
        //                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, TicksAndAxisBackgroundBackgroundRed,axesGreenValue,tickAndAxisBlue));
        //            }
        //            //else if ( x%xTickIntervals == 0||
        //            //          (x+1)%xTickIntervals==0||
        //            //          (x-1)%xTickIntervals==0)

        //            //{
        //            //    switch (x%xTickIntervals)
        //            //    {
        //            //        //case 0:
        //            //        //    if (y > 200 && y < 220)
        //            //        //        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 250, 150));
        //            //        //        else if (y > 220 && y < 223)
        //            //        //        CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 0, 150, 0));
        //            //        //    else if (y > 223 && y < 430)
        //            //        //       CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 150, 250));
        //            //        //     break;
        //            //        //case 1:
        //            //        //     if (y > 190 && y < 250)
        //            //        //         CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 250, 150));
        //            //        //     else if (y > 250 && y < 253)
        //            //        //         CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 0, 150, 0));
        //            //        //     else if (y > 253 && y < 430)
        //            //        //         CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 150, 250));
        //            //        //     break;
        //            //        //case 2:
        //            //        //     if (y > 290 && y < 293)
        //            //        //         CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 0, 150, 0));
        //            //        //     else if (y > 293 && y < 310)
        //            //        //         CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 250, 150, 150));
        //            //        //     else if (y > 310 && y < 430)
        //            //        //         CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y, 150, 150, 250));
        //            //        //     break;
        //            //        default:
        //            //             CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));
        //            //             break;
        //            //    }
        //            //}
        //            else
        //                CanvassPoints.Add(new Tuple<int, int, int, int, int>(x, y,backgroundRed,backgroundGreen,backgroundBlue));


        //        }
            
        //    } * */
        //    #endregion
        //    oCanvas = GraphicsEngine.DrawImage(bitmapWidth, bitmapHeight, CanvassPoints);
        //    oCanvas.Save(Response.OutputStream, ImageFormat.Jpeg);
        //    oCanvas.Dispose();
        //}
        #endregion
    }
}