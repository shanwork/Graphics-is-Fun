<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGraphs.aspx.cs" Inherits="Fractal1.TestGraphs" %>
<%@ Register Src="~/TargetActualGraphContainer.ascx" TagPrefix="Graph" TagName="TargetActual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="graphContainer" style="float:left;border: solid 2 px silver; margin-top:50px;"> 
    <Graph:TargetActual ID="SalesGraph" 
            GraphBackground="210,230,250" 
            AxesColor="0,30,100" 
            TargetLevelColor="255,180,10"
            BelowTargetColor="0,10,180"
            ExceedTargetColor="0,250,100"
            FallShortTargetColor="250,150,50"
            runat="server"  />
        </div>
    <div id="graphData" style="float:right;border: solid 2 px silver;margin-top:150px; "> 
        <h3>Unit Sales Over Last Week Region Wise</h3>
    <asp:GridView ID="gvSalesByUnits" runat="server">

    </asp:GridView>
        </div>
</asp:Content>
