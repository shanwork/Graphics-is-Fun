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
    public partial class TargetActualGraphContainer : System.Web.UI.UserControl
    {
        public string GraphBackground { get; set; }
        public string AxesColor { get; set; }
        public string TargetLevelColor { get; set; }
        public string BelowTargetColor { get; set; }
        public string ExceedTargetColor { get; set; }
        public string FallShortTargetColor { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["GraphBackground"] = GraphBackground;
            Session["AxesColor"] = AxesColor;
            Session["TargetLevelColor"] = TargetLevelColor;
            Session["BelowTargetColor"] = BelowTargetColor;
            Session["ExceedTargetColor"] = ExceedTargetColor;
            Session["FallShortTargetColor"] = FallShortTargetColor;
        }
    }
}