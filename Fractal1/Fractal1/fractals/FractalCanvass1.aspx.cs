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
    public partial class FractalCanvass1 : FractalsParent
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RenderBitmap(true, 450, 440);
        

        }
      
    }
}