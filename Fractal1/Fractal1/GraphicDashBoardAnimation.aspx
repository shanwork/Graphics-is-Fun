<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GraphicDashBoardAnimation.aspx.cs" Inherits="Fractal1.GraphicDashBoard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CanvassHolder" runat="server">
   
    <div>
         <asp:UpdatePanel ID="test" runat="server">
              <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="tmr" EventName="Tick" />
              </Triggers>
            <ContentTemplate>
                <asp:Timer ID="tmr" runat="server" OnTick="tmr_Tick" Interval="1500" ></asp:Timer>
       <table style="width:auto;">
           <tr>
               <td colspan="2"> 
            </td>
           </tr>
           <tr>
               <td> 
                   <div style="float:right;margin-top:5px; margin-right:100px;:inset 5px silver; width:auto; height:auto;">
        
                <img id="img1" src="~/fractals/FractalCanvass1.aspx" runat="server"  />
                 
          
            </div>
       </td>
               <td>   
                   <div style="float:right;margin-top:5px; margin-right:100px;:inset 5px silver; width:auto; height:auto;">
         
                <img id="img2" src="~/fractals/FractalCanvass3.aspx" runat="server"  />                
            
    </div></td>
           </tr>
      <!--tr>
               <td> 
                   <div style="float:right;margin-top:5px; margin-right:100px;:inset 5px gray; width:auto; height:auto;">
        <img id="img3" src="TrigoGraph.aspx" runat="server" visible="false"  />
                
                 
                
          
            </div>
       </td>
               <td>   
                   <div style="float:right;margin-top:5px; margin-right:100px;:inset 5px gray; width:auto; height:auto;">
         
                
            
    </div></td>
           </!--tr--->

       </table>
           </ContentTemplate>
            </asp:UpdatePanel>
    </div>
   
     
</asp:Content>
