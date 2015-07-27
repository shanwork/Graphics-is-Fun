<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGraphs.aspx.cs" Inherits="Fractal1.TestGraphs" %>
<%@ Register Src="~/GraphContainer.ascx" TagPrefix="Graph" TagName="Prefix" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="graphContainer" style="margin:20px;border solid 2 px silver; "> 
    <Graph:Prefix ID="SalesGraph" GraphBackground="220,230,230" TicksAndAxis="0,30,100" runat="server"  />
        </div>
</asp:Content>
