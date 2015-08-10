using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Fractal1
{
    public partial class _Default : Page
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

            System.Threading.Thread.Sleep(500);


            
            getNextColor();
            StringBuilder table = new StringBuilder("<table border=1 cellpadding=0 cellspacing=0>");
            int currentRed = 50, currentGreen = 50, currentBlue = 50;
            bool isRedSession = int.TryParse(Session["currentRed"].ToString(), out currentRed);
            bool isGreenSession = int.TryParse(Session["currentGreen"].ToString(), out currentGreen);
            bool isBlueSession = int.TryParse(Session["currentBlue"].ToString(), out currentBlue);
            table.Append("<tr><td>");
            table.Append("Red:").Append(currentRed).Append("</td><td>").Append("Green:").Append(currentGreen).Append("</td><td>").Append("Blue:").Append(currentBlue).Append("</td></tr></table>");
            Session["red"] = Session["currentRed"];
            Session["green"] = Session["currentGreen"];
            Session["blue"] = Session["currentBlue"];
            
           
        }
        void getNextColor()
        {
            int currentRed = 50, currentGreen = 50, currentBlue = 50;
            if (Session["currentRed"] != null)
            {
                bool isRedSession = int.TryParse(Session["currentRed"].ToString(), out currentRed);
            }
            if (Session["currentGreen"] != null)
            {
                bool isGreenSession = int.TryParse(Session["currentGreen"].ToString(), out currentGreen);
            }
            if (Session["currentBlue"] != null)
            {
                bool isBlueSession = int.TryParse(Session["currentBlue"].ToString(), out currentBlue);
            }
            currentBlue += 25;
            if (currentBlue > 255)
            {
                currentBlue = 50;
                currentGreen += 25;
                if (currentGreen > 255)
                {
                    currentGreen = 50;
                    currentRed += 25;
                    if (currentRed > 255)
                        currentRed = 50;
                }
            }
            Session["currentBlue"] = currentBlue;
            Session["currentGreen"] = currentGreen;
            Session["currentRed"] = currentRed;

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
                if (changeInitials % 3 == 0)
                {

                }
            }

        }
    }
}