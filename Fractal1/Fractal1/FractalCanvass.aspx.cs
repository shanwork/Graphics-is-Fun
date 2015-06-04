using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Fractal1
{
    public partial class FractalCanvass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            System.Threading.Thread.Sleep(500);
            List<string> RGBVals ;
            var RGBCurrent =/* lbl1.Text =*/ string.Format("Red: {0}, Green{1}, Blue{2}", Session["red"], Session["blue"], Session["green"]);
            if (Session["RGBVals"] == null)
                RGBVals = new List<string>();
            else
                RGBVals = (List<string>)Session["RGBVals"];
            var stringFound = RGBVals.Where(p=>p.Contains(RGBCurrent));
            if (stringFound.Count<string>() == 0)
                RGBVals.Add(RGBCurrent);
            Session["RGBVals"] = RGBVals;
            StringBuilder table = new StringBuilder("<table border=1 cellpadding=0 cellspacing=0>");
            foreach(string RGB   in RGBVals)
            {
                table.Append("<tr><td>");
                if (RGB.Equals(RGBCurrent))
                {
                    table.Append("<b>").Append(RGB).Append("</b>");
                }
                else
                {

                    table.Append(RGB);
                }
                table.Append("</td</tr>");
                
            }
            table.Append("</table>");
            lbl1.Text = table.ToString();
           // for (RGBVals.Select<)
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
        void assignInitialSessionVariables()
        {
            int changeInitials = 0;
            if (Session["changeInitials"] == null)
            {
                Session["changeInitials"] = 0;
            }
            else
            {
                bool cIValid = int.TryParse(Session["changeInitials"].ToString(), out changeInitials);
                if (changeInitials%3 ==0)
                {

                }
            }
            
        }
    
    }
}