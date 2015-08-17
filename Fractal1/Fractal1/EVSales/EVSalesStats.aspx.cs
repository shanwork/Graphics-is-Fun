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
            if (!this.IsPostBack)
                bindAll();
//            this.ClientScript.RegisterStartupScript(this.GetType(), "scrollDiv", 
//                    @"function scrollTo('divdatagrid1','" + scrollPos.ClientID + @"') {
//                        document.getElementById('divdatagrid1').scrollTop = document.getElementById('" + scrollPos.ClientID + @").value;", true);
    
            /*
               function scrollTo(what, posId) {
            if (what != "0")
                document.getElementById(what).scrollTop = document.getElementById(posId).value;


        }
             */
        }
        void bindAll()
        {
            gvSaleDetailsBind();
            aggregatesBind();
        }
        void aggregatesBind()
        {
            gvGrpByRegion.DataSource = Singleton.Instance.EVSales.groupByRegion();
            gvGrpByRegion.DataBind();

            gvGrpByProduct.DataSource = Singleton.Instance.EVSales.groupByModel();
            gvGrpByProduct.DataBind();

            gvGrpByRegionProduct.DataSource = Singleton.Instance.EVSales.groupByRegionAndModel();
            gvGrpByRegionProduct.DataBind();

        }
        void gvSaleDetailsBind()
        {
            gvSaleDetails.DataSource = Singleton.Instance.EVSales.getAllSalesData();
            gvSaleDetails.DataBind();
        }
        protected void gvSaleDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSaleDetails.PageIndex = e.NewPageIndex;
            gvSaleDetails.DataSource = Singleton.Instance.EVSales.getAllSalesData();
            gvSaleDetails.DataBind();
        }

        protected void gvGrpByRegionProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGrpByRegionProduct.PageIndex = e.NewPageIndex;
            gvGrpByRegionProduct.DataSource = Singleton.Instance.EVSales.groupByRegionAndModel();
            gvGrpByRegionProduct.DataBind();
        }

        protected void gvSaleDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSaleDetails.EditIndex = e.NewEditIndex;
            gvSaleDetailsBind();
           
        }

        protected void gvSaleDetails_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            int id = 0;
            bool isId = int.TryParse(gvSaleDetails.Rows[gvSaleDetails.EditIndex].Cells[0].ToString(), out id);
            DataModelLibrary1.EVSale updateIten = Singleton.Instance.EVSales.getAllSalesData().Where(saleDetails => saleDetails.EvSaleId == id).First();
        //    updateIten.CostPrice = 
           //// DataModelLibrary1.EVSales = 
           // Singleton.Instance.EVSales.Where(saleDetails => saleDetails.EvSaleId == id).First();
           //// SaleDetail saleDetail = AppAndSessionLife.SalesRecords.Where(saleDetails => saleDetails.SaleDetailId == id).First();
        }

        protected void gvSaleDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSaleDetails.EditIndex = -1 ;
            gvSaleDetailsBind();
        }

        protected void gvSaleDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            gvSaleDetails.EditIndex = e.RowIndex;
            int id = 0;
            bool isId = int.TryParse(gvSaleDetails.Rows[gvSaleDetails.EditIndex].Cells[0].Text, out id);
            if (isId== true)
            {
                DataModelLibrary1.EVSale updateIten = Singleton.Instance.EVSales.getAllSalesData().Where(saleDetails => saleDetails.EvSaleId == id).First();
                updateIten.CostPrice = double.Parse(((TextBox)gvSaleDetails.Rows[gvSaleDetails.EditIndex].Cells[5].Controls[0]).Text);
            }
            gvSaleDetails.EditIndex = -1;
            bindAll();
        }
    }
}