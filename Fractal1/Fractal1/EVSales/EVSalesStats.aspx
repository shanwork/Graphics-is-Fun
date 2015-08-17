<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EVSalesStats.aspx.cs" Inherits="Fractal1.EVSalesStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CanvassHolder" runat="server">
    <style>
        .groupByRegionHeader
        {
            background-color:#6699ff;
        }
         .groupByRegionItem
        {
            background-color:#99ccff;
        }
          .groupByProductHeader
        {
            background-color:#9988ff;
        }
         .groupByProductItem
        {
            background-color:#ccAAff;
        }
            .groupByRegionProductHeader
        {
            background-color:#00BBCB;
        }
         .groupByRegionProductItem
        {
            background-color:#99ffcc;
        }
    </style>
    <script>
        $('#gvGrpByRegion tr').ready(function () {
            var xTick = $(this).find('.groupByRegionItem').length / 2;
            var maxY = 0;
            var yTick = 0;
            $('#gvGrpByRegion tr').each(function () {
               

                    $(this).find('.groupByRegionItem').each(function () {
                        //alert($(this).text().indexOf('$'));
                        if ($(this).text().indexOf('$')>=0)
                        {
                            y = parseInt(parseFloat($(this).text().replace("$", "").replace(/,/g, "")));
                            if (y > maxY)
                                maxY = y;
                        }

                    })
               })
            yTick = (180.00 / maxY);
            var startX = 22;
            $('#gvGrpByRegion tr').each(function () {


                $(this).find('.groupByRegionItem').each(function () {
                    //alert($(this).text().indexOf('$'));
                    if ($(this).text().indexOf('$') >= 0) {
                        yVal = parseInt(parseFloat($(this).text().replace("$", "").replace(/,/g, "")) * yTick);
                        var c =document.getElementById('cvGrpByRegion');
                        if (c != null) {
                            var ctx = c.getContext("2d");
                            ctx.fillStyle = "#777A99";
                            ctx.lineWidth = 20;
                            ctx.strokeStyle = "#448844";
                            ctx.moveTo(startX, 200);
                            ctx.lineTo(startX,  (190- yVal));
                            ctx.stroke();
                            
                            startX += 40;
                        }
                    }

                })
            })

        })
        $('#gvGrpByProduct tr').ready(function () {
            var xTick = $(this).find('.groupByProductItem').length / 2;
            var maxY = 0;
            var yTick = 0;
            $('#gvGrpByProduct tr').each(function () {


                $(this).find('.groupByProductItem').each(function () {
                    //alert($(this).text().indexOf('$'));
                    if ($(this).text().indexOf('$') >= 0) {
                        y = parseInt(parseFloat($(this).text().replace("$", "").replace(/,/g, "")));
                        if (y > maxY)
                            maxY = y;
                    }

                })
            })
            yTick = (180.00 / maxY);
            var startX = 22;
            $('#gvGrpByProduct tr').each(function () {


                $(this).find('.groupByProductItem').each(function () {
                    //alert($(this).text().indexOf('$'));
                    if ($(this).text().indexOf('$') >= 0) {
                        yVal = parseInt(parseFloat($(this).text().replace("$", "").replace(/,/g, "")) * yTick);
                        var c = document.getElementById('cvGrpByProduct');
                        if (c != null) {
                            var ctx = c.getContext("2d");
                            ctx.fillStyle = "#777A99";
                            ctx.lineWidth = 20;
                            ctx.strokeStyle = "#444488";
                            ctx.moveTo(startX, 200);
                            ctx.lineTo(startX, (190 - yVal));
                            ctx.stroke();

                            startX += 40;
                        }
                    }

                })
            })

        })
        $('#gvGrpByRegionProduct tr').ready(function () {
            var xTick = $(this).find('.groupByRegionProductItem').length / 2;
            var maxY = 0;
            var yTick = 0;
            $('#gvGrpByRegionProduct tr').each(function () {


                $(this).find('.groupByRegionProductItem').each(function () {
                    //alert($(this).text().indexOf('$'));
                    if ($(this).text().indexOf('$') >= 0) {
                        y = parseInt(parseFloat($(this).text().replace("$", "").replace(/,/g, "")));
                        if (y > maxY)
                            maxY = y;
                    }

                })
            })
            yTick = (180.00 / maxY);
            var startX = 12;
            $('#gvGrpByRegionProduct tr').each(function () {


                $(this).find('.groupByRegionProductItem').each(function () {
                    //alert($(this).text().indexOf('$'));
                    if ($(this).text().indexOf('$') >= 0) {
                        yVal = parseInt(parseFloat($(this).text().replace("$", "").replace(/,/g, "")) * yTick);
                        var c = document.getElementById('cvGrpByRegionProduct');
                        if (c != null) {
                            var ctx = c.getContext("2d");
                            ctx.fillStyle = "#777A99";
                            ctx.lineWidth = 10;
                            ctx.strokeStyle = "#884444";
                            ctx.moveTo(startX, 200);
                            ctx.lineTo(startX, (190 - yVal));
                            ctx.stroke();

                            startX += 30;
                        }
                    }

                })
            })

        })
    </script>

    <!--script>
        function setScroll(val, posId) {
            posId.value = val.scrollTop;
        }


        //only required for w/o ajax page ScrollWOAjax.
        function scrollTo(what, posId) {
            if (what != "0")
                document.getElementById(what).scrollTop = document.getElementById(posId).value;


        }
    </!--script>
 <script>
        $(document).ready(function () {
            alert('hi2');
        });
        
</script-->
     <h4 style="text-align:center">Sample Sales Data For EV Units Sold in the Bay Area </h4>
    <table width="100%">

        <tr>
            <td id='grpByRegion' width="30%"  style="width:30%; text-align:center;border-style: outset;  border-width: 2px; padding: 3px; border-radius:2px; margin:5px; width: 235px;">
                <h4>Sales Grouped By Region</h4>
                <canvas id="cvGrpByRegion" width="200" height="200" style="border:1px solid #000000; background-color:silver;"></canvas><br />
                 <asp:GridView  ID="gvGrpByRegion" ClientIDMode="Static" HeaderStyle-CssClass="groupByRegionHeader"  runat="server" AutoGenerateColumns="false" Width="256px" >
                     <Columns>
                         <asp:BoundField HeaderText="Region" DataField="Item1"   ItemStyle-CssClass="groupByRegionItem"/>
                        <asp:BoundField HeaderText="Sales" DataField="Item2" ItemStyle-CssClass="groupByRegionItem" />

                     </Columns>
                </asp:GridView>
            </td>
              <td style="width:30%;text-align:center;padding:3px; border: outset 2px; border-radius:2px;margin:5px;">
                  <h4>Sales Grouped By Product</h4>
                 <canvas id="cvGrpByProduct" width="200" height="200" style="border:1px solid #000000; background-color:silver;"></canvas><br />
                <asp:GridView ID="gvGrpByProduct"  ClientIDMode="Static"  runat="server"  AutoGenerateColumns="false" HeaderStyle-CssClass="groupByProductHeader"  Width="297px">
                      <Columns>
                         <asp:BoundField HeaderText="Model" DataField="Item1" ItemStyle-CssClass="groupByProductItem"/>
                        <asp:BoundField HeaderText="Sales" DataField="Item2"  ItemStyle-CssClass="groupByProductItem"/>

                     </Columns>
                </asp:GridView>
            </td>
              <td style="align-content:center;padding:3px; border: outset 2px; border-radius:2px;margin:15px;">
                   <h4>Sales Grouped By Region, then by Product</h4>
                  <canvas id="cvGrpByRegionProduct" width="500" height="200" style="border:1px solid #000000; background-color:silver;"></canvas><br />
                <div id="divGroupRegionProduct" style="align-content:center; height:105px; width:85%;overflow:scroll;"  onscroll='javascript:setScroll(this, <% =scrollPos.ClientID %> );'>
                 <asp:GridView ID="gvGrpByRegionProduct" HeaderStyle-CssClass="groupByRegionProductHeader"   ClientIDMode="Static"  width="100%" runat="server"  PageSize="20" AllowPaging="true"  AutoGenerateColumns="false" OnPageIndexChanging="gvGrpByRegionProduct_PageIndexChanging"   >
                     <Columns>
                      
                       <asp:BoundField HeaderText="Region" DataField="Item1" ItemStyle-CssClass="groupByRegionProductItem" />
                       <asp:BoundField HeaderText="Model" DataField="Item2"   ItemStyle-CssClass="groupByRegionProductItem" />
                        <asp:BoundField HeaderText="Sales" DataField="Item3"  ItemStyle-CssClass="groupByRegionProductItem"/>
</Columns>

                </asp:GridView>
                     </div>
            </td>
            
        </tr>
        <tr>
            <td colspan="3" style="margin:10px;text-align:center;">  
                 <input id="scrollPos" runat="server" type="hidden" value="0" />

                <h4>Individual Sale Transactions</h4>
                      <div id="divdatagrid1" style="width: 100%; overflow:scroll; height: 252px;" >
                <asp:GridView ID="gvSaleDetails" 
                    HeaderStyle-Backcolor="#999999" 
                    RowStyle-BackColor="#cccccc" 
                    AlternatingRowStyle-BackColor="White" runat="server" AutoGenerateColumns="false" PagerSettings-Mode="NumericFirstLast"  PageSize="15" AllowPaging="true" OnPageIndexChanging="gvSaleDetails_PageIndexChanging" Width="1170px" OnRowCancelingEdit="gvSaleDetails_RowCancelingEdit" OnRowEditing="gvSaleDetails_RowEditing" OnRowUpdated="gvSaleDetails_RowUpdated" OnRowUpdating="gvSaleDetails_RowUpdating">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="EvSaleId" ReadOnly="true" />
                        <asp:BoundField HeaderText="Region" DataField="Region" ReadOnly="true"  />
                        <asp:BoundField HeaderText="City" DataField='ZipCode' ReadOnly="true"  />
                        <asp:BoundField HeaderText="Model" DataField="Model"  ReadOnly="true"  />
                       <asp:BoundField HeaderText="MSRP" DataField="MSRP"  ReadOnly="true" />
                        <asp:BoundField HeaderText="Sold Price" DataField="SoldPrice"   />
                       <asp:BoundField HeaderText="Sold On" DataField="DateOfSale"  ReadOnly="true"  />
                       
                    </Columns>

                </asp:GridView>
                          </div>
            </td>
        </tr>
    </table>
   
</asp:Content>
