<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNetGraphics._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

  
    <div class="row"><img id="temp" src="Canvass1.aspx" runat="server" />
        <table style="width:98%;">

            <tr>
               <td>
                     <div class="col-md-4" style="border:inset 3px; width:auto;height:auto; margin-top:5px;">
                         
            <asp:UpdatePanel ID="fractal1" runat="server">
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="fractalAnim1" EventName="Tick" />
              </Triggers>
            <ContentTemplate>
                <asp:Timer ID="fractalAnim1" runat="server" OnTick="fractalAnim1_Tick" Interval="1500" ></asp:Timer>
                <img id="fractalCanvassHolder" src="~/Canvass1.aspx" runat="server"  />
                    <asp:Label ID="lbl1" runat="server">A</asp:Label>
              
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>
               </td>
                <td>
                    <div class="col-md-4" style="border:inset 3px; width:auto;height:auto; margin-top:5px;">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        
                </td>
            </tr>
           <tr>
               <td>
                     <div class="col-md-4" style="border:inset 3px; width:auto;height:auto; margin-top:5px;">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
               </td>
                <td>
                    <div class="col-md-4" style="border:inset 3px; width:auto;height:auto; margin-top:5px;">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        
                </td>
            </tr>
        </table>
      
        
    </div>

</asp:Content>
