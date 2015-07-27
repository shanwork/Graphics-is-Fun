<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OldDefaultPage.aspx.cs" Inherits="Fractal1.OldDefaultPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        $(document).ready(function () {
            var containingUL = $('#waveCont');
            if (containingUL != null) {
                $("#waveCont").html("<li style='background-color:#0F0F0F'>Test 1 </li>" +
                    "<li style='background-color:#FF0F0F'>Test 2 </li>" +
                    "<li style='background-color:#FFFF0F'>Test 3 </li>" 
                    );
            }
             
                $('#waveCont').animate({ html:"<li style='background-color:#FF0F0F'>Test 1 </li>" +
                "<li style='background-color:#FF0FFF'>Test 2 </li>" +
                "<li style='background-color:#FFFF0F'>Test 3 </li>"})
            
        }
    )

</script>
    <div class="jumbotron">
   <ul id="waveCont" class="wave">
  <li>1</li>
   </ul>
    </div>
    <div class="row">
          <asp:UpdatePanel ID="test" runat="server">
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
              </Triggers>
            <ContentTemplate>
                <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="500" ></asp:Timer>
                <img id="img1" src="Canvass1.aspx" runat="server"  />
                <asp:Label ID="lbl1" runat="server">A</asp:Label>
               
            </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</asp:Content>
