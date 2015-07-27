<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fractal1._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        
        <div style="float:right;margin-top:5px; margin-right:100px;:inset 5px silver; width:auto; height:auto;">
         <asp:UpdatePanel ID="test" runat="server">
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
              </Triggers>
            <ContentTemplate>
                <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="1500" ></asp:Timer>
                <img id="img1" src="Canvass3.aspx" runat="server"  />
                <asp:Label ID="lbl1" runat="server" Visible="false">A</asp:Label>
                
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
         
    </div>
    
</asp:Content>
 