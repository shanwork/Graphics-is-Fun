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
using Fractal1.graphs;

namespace Fractal1
{
    public partial class TargetActualGraphCanvass : GraphsParent
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            hardCodingTargetActualGraphFromHardCodedData();
        }
        
    }
}