<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FractalCanvass.aspx.cs" Inherits="Fractal1.FractalCanvass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
    <div>
        <div style="float:left">
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
    </form>
</body>
</html>
