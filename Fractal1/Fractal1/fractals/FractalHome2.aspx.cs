using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fractal1
{
    public partial class FractalHome2 : FractalsParent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBitmap(false,400,410, new Tuple<int, int, int>(70, 140,150));
      
        }
    }
}