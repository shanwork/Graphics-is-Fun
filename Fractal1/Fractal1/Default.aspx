<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Fractal1._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="CanvassHolder" runat="server">
    
        
        <div id="divFractals" runat="server" style="margin-top:5px;  width:auto;margin:5px; height:auto;">
        
                <img src="~/fractals/FractalHome1.aspx" id="FractalHone1" runat="server" />
                 &nbsp;&nbsp;
                <img src="~/fractals/FractalHome2.aspx" id="FractalHone2" runat="server" />
                 &nbsp;&nbsp;
                <img src="~/fractals/FractalHome3.aspx" id="FractalHone3" runat="server" />
           
            </div>
         
    
    
</asp:Content>
 