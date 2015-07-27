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
            
            DataColumn dcRegionID = new DataColumn("RegionID");
            dtseedSampleSalesData.Columns.Add(dcRegionID);
           
            DataColumn dcRegionName = new DataColumn("RegionName");
            dtseedSampleSalesData.Columns.Add(dcRegionName);

            DataColumn dcRegionTargetSalesUnits = new DataColumn("RegionTargetSalesUnits");
            dtseedSampleSalesData.Columns.Add(dcRegionTargetSalesUnits);

            DataColumn dcRegionSoldUnits = new DataColumn("RegionSoldUnits");
            dtseedSampleSalesData.Columns.Add(dcRegionSoldUnits);

            DataColumn dcRegionStartPeriod = new DataColumn("RegionStartPeriod");
            dtseedSampleSalesData.Columns.Add(dcRegionStartPeriod);

            DataColumn dcRegionEndPeriod = new DataColumn("RegionEndPeriod");
            dtseedSampleSalesData.Columns.Add(dcRegionEndPeriod);

            DataRow drRow1 = dtseedSampleSalesData.NewRow();
            drRow1["RegionID"] = 1;
            drRow1["RegionName"] = "North Bay";
            drRow1["RegionTargetSalesUnits"] = 10000;
            drRow1["RegionSoldUnits"] = 10123;
            drRow1["RegionStartPeriod"] = DateTime.Now.AddDays(-8) ;
            drRow1["RegionEndPeriod"] = DateTime.Now.AddDays(-1);
            dtseedSampleSalesData.Rows.Add(drRow1);

            DataRow drRow2 = dtseedSampleSalesData.NewRow();
            drRow2["RegionID"] = 2;
            drRow2["RegionName"] = "East Bay";
            drRow2["RegionTargetSalesUnits"] = 19000;
            drRow2["RegionSoldUnits"] = 15560;
            drRow2["RegionStartPeriod"] = DateTime.Now.AddDays(-8);
            drRow2["RegionEndPeriod"] = DateTime.Now.AddDays(-1);
            dtseedSampleSalesData.Rows.Add(drRow2);

            DataRow drRow3 = dtseedSampleSalesData.NewRow();
            drRow3["RegionID"] = 3;
            drRow3["RegionName"] = "West Bay";
            drRow3["RegionTargetSalesUnits"] = 29000;
            drRow3["RegionSoldUnits"] = 40123;
            drRow3["RegionStartPeriod"] = DateTime.Now.AddDays(-8);
            drRow3["RegionEndPeriod"] = DateTime.Now.AddDays(-1);
            dtseedSampleSalesData.Rows.Add(drRow3);

            DataRow drRow4 = dtseedSampleSalesData.NewRow();
            drRow4["RegionID"] = 4;
            drRow4["RegionName"] = "North Bay";
            drRow4["RegionTargetSalesUnits"] = 15000;
            drRow4["RegionSoldUnits"] = 15123;
            drRow4["RegionStartPeriod"] = DateTime.Now.AddDays(-8);
            drRow4["RegionEndPeriod"] = DateTime.Now.AddDays(-1);
            dtseedSampleSalesData.Rows.Add(drRow4);

            DataRow drRow5 = dtseedSampleSalesData.NewRow();
            drRow5["RegionID"] = 5;
            drRow5["RegionName"] = "Sacramento";
            drRow5["RegionTargetSalesUnits"] = 35000;
            drRow5["RegionSoldUnits"] = 43012;
            drRow5["RegionStartPeriod"] = DateTime.Now.AddDays(-8);
            drRow5["RegionEndPeriod"] = DateTime.Now.AddDays(-1);
            dtseedSampleSalesData.Rows.Add(drRow5);

            DataRow drRow6 = dtseedSampleSalesData.NewRow();
            drRow6["RegionID"] = 6;
            drRow6["RegionName"] = "Tahoe";
            drRow6["RegionTargetSalesUnits"] = 11000;
            drRow6["RegionSoldUnits"] = 8123;
            drRow6["RegionStartPeriod"] = DateTime.Now.AddDays(-8);
            drRow6["RegionEndPeriod"] = DateTime.Now.AddDays(-1);
            dtseedSampleSalesData.Rows.Add(drRow6);
            return dtseedSampleSalesData;
        
        }
    }
}