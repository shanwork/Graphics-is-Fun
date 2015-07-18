<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fractal1._Default" %>
<%@ Register Src="~/FractalContainer.ascx" TagPrefix="fract" TagName="ctl" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div style="float:left;border:inset 2px silver; margin-top:50px; width:auto; height:auto;">
            Welcome to a rather crude  attempt to write an animation on a fractal in asp.net!!!
            For some reason, I wasnt able to translate mandelbrot into graphics here, so I plotted a random 
            set of points<p></p>
           
            Inspired by the article <a href="http://www.codemag.com/Article/03050801" target="_top">Using GDI+ in Asp.Net </a> by Markus Egger
            Source for this app is under <a href="https://github.com/shanwork/Graphics-is-Fun" target="_blank">here</a>
            Please feel free to email me at champgads@gmail.com
        </div>
        <div style="float:right;margin-top:5px; margin-right:100px;:inset 5px silver; width:auto; height:auto;">
         <asp:UpdatePanel ID="test" runat="server">
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
              </Triggers>
            <ContentTemplate>
                <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="1500" ></asp:Timer>
                <img id="img1" src="Canvass1.aspx" runat="server"  />
                <asp:Label ID="lbl1" runat="server" Visible="false">A</asp:Label>
                
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
         
    </div>
    
</asp:Content>
 