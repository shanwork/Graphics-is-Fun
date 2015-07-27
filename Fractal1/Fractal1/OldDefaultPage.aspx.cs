using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fractal1
{
    public partial class OldDefaultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //    <fract:ctl ID="testFract" runat="server" />


        }

        protected void tmr_Tick(object sender, EventArgs e)
        {
            int red = 0, green = 0, blue = 0;
            if (Session["red"] == null)
            {
                Session["red"] = 0;
            }



            if (Session["green"] == null)
            {
                Session["green"] = 150;
            }



            if (Session["blue"] == null)
            {
                Session["blue"] = 200;
            }



            // Response.Redirect("Default.aspx");
            if (img1.Src == "Canvass1.aspx")
                img1.Src = "Canvass2.aspx";
            else
                img1.Src = "Canvass1.aspx";
            lbl1.Text = string.Format("Red: {0}, Green{1}, Blue{2}", Session["red"], Session["blue"], Session["green"]);

            red = int.Parse(Session["red"].ToString());
            switch (red)
            {
                case 0: Session["red"] = 100; break;
                case 100: Session["red"] = 150; break;
                case 150: Session["red"] = 200; break;
                case 200: Session["red"] = 255; break;
                default: Session["red"] = 0; break;
            } green = int.Parse(Session["green"].ToString());
            switch (green)
            {
                case 0: Session["green"] = 100; break;
                case 100: Session["green"] = 150; break;
                case 150: Session["green"] = 200; break;
                case 200: Session["green"] = 255; break;
                default: Session["green"] = 0; break;
            }
            blue = int.Parse(Session["blue"].ToString());
            switch (blue)
            {
                case 0: Session["blue"] = 100; break;
                case 100: Session["blue"] = 150; break;
                case 150: Session["blue"] = 200; break;
                case 200: Session["blue"] = 255; break;
                default: Session["blue"] = 0; break;
            }
        }
  
    }
}