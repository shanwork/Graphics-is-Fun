using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fractal1.Core;
using DataModelLibrary1;
namespace Fractal1
{
    public partial class EVSalesStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            gvGrpByRegion.DataSource = Singleton.EVSales.groupByRegion();
            gvGrpByRegion.DataBind();

            gvGrpByModel.DataSource = Singleton.EVSales.groupByModel();
            gvGrpByModel.DataBind();

            gvGrpByRegionModel.DataSource = Singleton.EVSales.groupByRegionAndModel();
            gvGrpByRegionModel.DataBind();

            gvSaleDetails.DataSource = Singleton.EVSales.getAllSalesData();
            gvSaleDetails.DataBind();
        }

        protected void gvSaleDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSaleDetails.PageIndex = e.NewPageIndex;
            gvSaleDetails.DataSource = Singleton.EVSales.getAllSalesData();
            gvSaleDetails.DataBind();
        }

        protected void gvGrpByRegionModel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGrpByRegionModel.PageIndex = e.NewPageIndex;
            gvGrpByRegionModel.DataSource = Singleton.EVSales.groupByRegionAndModel();
            gvGrpByRegionModel.DataBind();
        }
    }
}