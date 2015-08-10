using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using Fractal1.Core;

namespace Fractal1
{
    public partial class FractalHome1 : FractalsParent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            RenderBitmap(false, 380, 410, new Tuple<int, int, int>(150, 70, 140));
        
        }
       
    
    }
}