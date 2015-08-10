using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fractal1.Core;

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
        public string HdnIdentifier { get; set; }
        
        public string GraphDimensions { get; set; }
        public string GraphBackground { get; set; }
        public string AxesColor { get; set; }
        public string TargetLevelColor { get; set; }
        public string BelowTargetColor { get; set; }
        public string ExceedTargetColor { get; set; }
        public string FallShortTargetColor { get; set; }
        public string BarThickness { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Singleton.RGBElement graphDimensions = new Singleton.RGBElement();
            Dictionary<string, string> contextualRGBs = new Dictionary<string,string>();
            contextualRGBs.Add("GraphDimensions",GraphDimensions);
            if (Singleton.Colors == null)
                Singleton.Colors = new Dictionary<string, Dictionary<string, string>>();
        //    Fractal1.Core.Singleton.Colors.Add(HdnIdentifier, contextualRGBs);
            Session["GraphDimensions"] = GraphDimensions;
            Session["GraphBackground"] = GraphBackground;
            Session["AxesColor"] = AxesColor;
            Session["TargetLevelColor"] = TargetLevelColor;
            Session["BelowTargetColor"] = BelowTargetColor;
            Session["ExceedTargetColor"] = ExceedTargetColor;
            Session["FallShortTargetColor"] = FallShortTargetColor;
            Session["BarThickness"] = BarThickness;
        }
    }
}