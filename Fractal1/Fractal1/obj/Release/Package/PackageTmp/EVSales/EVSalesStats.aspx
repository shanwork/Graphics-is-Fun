<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EVSalesStats.aspx.cs" Inherits="Fractal1.EVSalesStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CanvassHolder" runat="server">
  <%--  <script>
        $(document).ready(function () {
            alert('hi2');
        });
        $("#grpByRegion").ready(function () {
            alert('hi');
            window.open('GroupByRegionGraph.aspx');
        });
</script>--%>
     <h4 style="text-align:center">Sample Sales Data For EV Units Sold in the Bay Area </h4>
    <table width="100%">

        <tr>
            <td id='grpByRegion'  style="text-align:center;border-style: outset;  border-width: 2px; padding: 3px; border-radius:2px; margin:5px; width: 235px;">
                <h4>Sales Grouped By Region</h4>
                 <asp:GridView ID="gvGrpByRegion" ClientIDMode="Static" runat="server" AutoGenerateColumns="false" Width="256px" >
                     <Columns>
                         <asp:BoundField HeaderText="Region" DataField="Item1" HeaderStyle-BackColor="#6699ff" ItemStyle-BackColor="#99ccff" />
                        <asp:BoundField HeaderText="Sales" DataField="Item2" HeaderStyle-BackColor="#6699ff" ItemStyle-BackColor="#99ccff" />

                     </Columns>
                </asp:GridView>
            </td>
              <td style="text-align:center;padding:3px; border: outset 2px; border-radius:2px;margin:5px;">
                  <h4>Sales Grouped By Product</h4>
                 <asp:GridView ID="gvGrpByModel" runat="server"  AutoGenerateColumns="false" Width="297px">
                      <Columns>
                         <asp:BoundField HeaderText="Model" DataField="Item1" HeaderStyle-BackColor="#9988ff" ItemStyle-BackColor="#ccAAff" />
                        <asp:BoundField HeaderText="Sales" DataField="Item2" HeaderStyle-BackColor="#9988ff" ItemStyle-BackColor="#ccAAff" />

                     </Columns>
                </asp:GridView>
            </td>
              <td style="text-align:center;padding:3px; border: outset 2px; border-radius:2px;margin:15px;">
                   <h4>Sales Grouped By Region, then by Product</h4>
                 
                 <asp:GridView ID="gvGrpByRegionModel" runat="server"  PageSize="4" AllowPaging="true"  AutoGenerateColumns="false" OnPageIndexChanging="gvGrpByRegionModel_PageIndexChanging" Width="313px"  >
                     <Columns>
                      
                       <asp:BoundField HeaderText="Region" DataField="Item1" HeaderStyle-BackColor="#00BBCB" ItemStyle-BackColor="#99ffcc" />
                       <asp:BoundField HeaderText="Model" DataField="Item2" HeaderStyle-BackColor="#00BBCB" ItemStyle-BackColor="#99ffCC" />
                        <asp:BoundField HeaderText="Sales" DataField="Item3" HeaderStyle-BackColor="#00BBCB" ItemStyle-BackColor="#99ffcc" />
</Columns>

                </asp:GridView>
            </td>
            
        </tr>
        <tr>
            <td colspan="3" style="margin:10px;text-align:center;">  
                <h4>Individual Sale Transactions</h4>
                 
                <asp:GridView ID="gvSaleDetails" HeaderStyle-Backcolor="#999999" RowStyle-BackColor="#cccccc" AlternatingRowStyle-BackColor="White" runat="server" AutoGenerateColumns="false" PagerSettings-Mode="NumericFirstLast"  PageSize="15" AllowPaging="true" OnPageIndexChanging="gvSaleDetails_PageIndexChanging" Width="1170px">
                    <Columns>

                        <asp:BoundField HeaderText="Region" DataField="Region" />
                        <asp:BoundField HeaderText="City" DataField="ZipCode" />
                        <asp:BoundField HeaderText="Model" DataField="Model" />
                       <asp:BoundField HeaderText="MSRP" DataField="MSRP" />
                        <asp:BoundField HeaderText="Sold Price" DataField="SoldPrice" />
                       <asp:BoundField HeaderText="Sold On" DataField="DateOfSale" />
                       
                    </Columns>

                </asp:GridView>
            </td>
        </tr>
    </table>
   
</asp:Content>
