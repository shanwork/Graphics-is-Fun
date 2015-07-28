using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Fractal1.BusinessLayer
{
    public static class SalesData
    {

        public static DataTable getRegionSalesUnitsData()
        {
            DataTable dtSalesData = SalesData.seedSampleSalesUnitsData();
            return dtSalesData;
        }
       
         static DataTable seedSampleSalesUnitsData()
        {
            DataTable dtseedSampleSalesData = new DataTable();
            
            DataColumn dcRegionID = new DataColumn("ID");
            dtseedSampleSalesData.Columns.Add(dcRegionID);
           
            DataColumn dcRegionName = new DataColumn("Region");
            dtseedSampleSalesData.Columns.Add(dcRegionName);

            DataColumn dcRegionTargetSalesUnits = new DataColumn("TargetSalesUnits");
            dtseedSampleSalesData.Columns.Add(dcRegionTargetSalesUnits);

            DataColumn dcRegionSoldUnits = new DataColumn("SoldUnits");
            dtseedSampleSalesData.Columns.Add(dcRegionSoldUnits);

            DataColumn dcRegionStartPeriod = new DataColumn("StartPeriod");
            dtseedSampleSalesData.Columns.Add(dcRegionStartPeriod);

            DataColumn dcRegionEndPeriod = new DataColumn("EndPeriod");
            dtseedSampleSalesData.Columns.Add(dcRegionEndPeriod);

            DataRow drRow1 = dtseedSampleSalesData.NewRow();
            drRow1["ID"] = 1;
            drRow1["Region"] = "North Bay";
            drRow1["TargetSalesUnits"] = 10000;
            drRow1["SoldUnits"] = 10123;
            drRow1["StartPeriod"] = DateTime.Now.AddDays(-8).ToShortDateString();
            drRow1["EndPeriod"] = DateTime.Now.AddDays(-1).ToShortDateString();
            dtseedSampleSalesData.Rows.Add(drRow1);

            DataRow drRow2 = dtseedSampleSalesData.NewRow();
            drRow2["ID"] = 2;
            drRow2["Region"] = "East Bay";
            drRow2["TargetSalesUnits"] = 19000;
            drRow2["SoldUnits"] = 15560;
            drRow2["StartPeriod"] = DateTime.Now.AddDays(-8).ToShortDateString();
            drRow2["EndPeriod"] = DateTime.Now.AddDays(-1).ToShortDateString();
            dtseedSampleSalesData.Rows.Add(drRow2);

            DataRow drRow3 = dtseedSampleSalesData.NewRow();
            drRow3["ID"] = 3;
            drRow3["Region"] = "West Bay";
            drRow3["TargetSalesUnits"] = 29000;
            drRow3["SoldUnits"] = 40123;
            drRow3["StartPeriod"] = DateTime.Now.AddDays(-8).ToShortDateString();
            drRow3["EndPeriod"] = DateTime.Now.AddDays(-1).ToShortDateString();
            dtseedSampleSalesData.Rows.Add(drRow3);

            DataRow drRow4 = dtseedSampleSalesData.NewRow();
            drRow4["ID"] = 4;
            drRow4["Region"] = "North Bay";
            drRow4["TargetSalesUnits"] = 15000;
            drRow4["SoldUnits"] = 15123;
            drRow4["StartPeriod"] = DateTime.Now.AddDays(-8).ToShortDateString();
            drRow4["EndPeriod"] = DateTime.Now.AddDays(-1).ToShortDateString();
            dtseedSampleSalesData.Rows.Add(drRow4);

            DataRow drRow5 = dtseedSampleSalesData.NewRow();
            drRow5["ID"] = 5;
            drRow5["Region"] = "Sacramento";
            drRow5["TargetSalesUnits"] = 35000;
            drRow5["SoldUnits"] = 43012;
            drRow5["StartPeriod"] = DateTime.Now.AddDays(-8).ToShortDateString();
            drRow5["EndPeriod"] = DateTime.Now.AddDays(-1).ToShortDateString();
            dtseedSampleSalesData.Rows.Add(drRow5);

            DataRow drRow6 = dtseedSampleSalesData.NewRow();
            drRow6["ID"] = 6;
            drRow6["Region"] = "Tahoe";
            drRow6["TargetSalesUnits"] = 11000;
            drRow6["SoldUnits"] = 8123;
            drRow6["StartPeriod"] = DateTime.Now.AddDays(-8).ToShortDateString();
            drRow6["EndPeriod"] = DateTime.Now.AddDays(-1).ToShortDateString();
            dtseedSampleSalesData.Rows.Add(drRow6);
            return dtseedSampleSalesData;
        
        }
    }
}