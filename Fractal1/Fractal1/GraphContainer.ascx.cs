using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fractal1
{
    internal struct GraphAttributes
    {
        int backgroundRed;
        int backgroundGreen;
        int backgroundBlue;
    }
    public partial class GraphContainer : System.Web.UI.UserControl
    {
        public string GraphBackground { get; set; }
        public string TicksAndAxis { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["GraphBackground"] = GraphBackground;
            Session["TicksAndAxis"] = TicksAndAxis;
        }
    }
}