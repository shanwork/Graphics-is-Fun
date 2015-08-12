<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TestGraphs.aspx.cs" Inherits="Fractal1.TestGraphs" %>
<%@ Register Src="~/graphs/TargetActualGraphContainer.ascx" TagPrefix="Graph" TagName="TargetActual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CanvassHolder" runat="server">
    <div id="graphGridContainer" style="float:left;border: solid 2px gray; background-color:rgb(235,240,240);"> 
    <h3>UNIT SALES: TARGETED, ACTUAL, EXCEEDED AND FALL SHORT BARS *</h3>
    <div id="graphContainer" style="float:left;border: solid 2px silver; margin-right:15px; background-color:rgb(220,240,240);"> 
    <Graph:TargetActual ID="SalesGraph" HdnIdentifier="TestUnit"
            GraphDimensions="600,500"
            GraphBackground="220,220,220" 
            AxesColor="0,30,100" 
            TargetLevelColor="9,46,32"
            BelowTargetColor="0,120,171"
            ExceedTargetColor="0,158,130"
            FallShortTargetColor="255,120,50"
            BarThickness="30"
            runat="server"  />
        </div>
    <div id="graphData" style="float:right;border: solid 2 px silver;margin-top:5px; "> 
        <h4>DATA IN FIGURES</h4>
    <asp:GridView ID="gvSalesByUnits" runat="server" HeaderStyle-BackColor="#eeffcc" BackColor="White">

    </asp:GridView>
        <p></p>
        <h4>LEGEND</h4>
        <table cellpadding:1>
            <tr>
                <td style="background-color:rgb(9,46,32); width:35px;padding:1px;border:solid 1px white;">&nbsp;</td>
                <td  >:Target Level</td>
            </tr>
            <tr>
                <td style="background-color:rgb(0,120,171); width:35px;padding:1px;border:solid 1px white;">&nbsp;</td>
                <td  >:Values below target Level</td>
            </tr>
            <tr>
                <td style="background-color:rgb(0,158,130); width:35px;padding:1px;border:solid 1px white;">&nbsp;</td>
                <td  >:Values exceeding target Level</td>
            </tr>
            <tr>
                <td style="background-color:rgb(255,120,50); width:35px;padding:1px;border:solid 1px white;">&nbsp;</td>
                <td  >:Ammount falling short of target Level</td>
            </tr>

        </table>    
        </div><p><i>* Iteratively evolving, the graph is embedded in a user control. All colors and the bar thickness are configurable; with time more elements will be made configurable.</i></p>
    
        </div>
</asp:Content>
