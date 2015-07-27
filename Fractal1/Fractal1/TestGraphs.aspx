<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGraphs.aspx.cs" Inherits="Fractal1.TestGraphs" %>
<%@ Register Src="~/TargetActualGraphContainer.ascx" TagPrefix="Graph" TagName="TargetActual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="graphContainer" style="margin:20px;border solid 2 px silver; "> 
    <Graph:TargetActual ID="SalesGraph" GraphBackground="250,210,230" TicksAndAxisColor="0,230,100" runat="server"  />
        </div>
</asp:Content>
