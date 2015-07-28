using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Fractal1.BusinessLayer;

namespace Fractal1
{
    public partial class TestGraphs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtRegionSalesByUnits = SalesData.getRegionSalesUnitsData();
            gvSalesByUnits.DataSource = dtRegionSalesByUnits;
            gvSalesByUnits.DataBind();
        }
    }
}