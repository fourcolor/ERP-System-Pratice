<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeBehind="Shipment.aspx.cs" Inherits="Database.Shipment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 75px;
        }
        .auto-style19 {
            width:100%;
            height: 18px;
        }
        .auto-style20 {
            background-color:lightgreen;
            width: 80px;
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <table class="auto-style19">
        <tr>
            <td class="auto-style20">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page/insert.aspx">訂單新增</asp:HyperLink>
            </td>
            <td class="auto-style20">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/addtion.aspx">追加訂單</asp:HyperLink>
            </td>
            <td class="auto-style20">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Page/edit.aspx">訂單修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/insertReceipt.aspx">收貨新增</asp:HyperLink>
            </td>
            <td class="auto-style20">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/editReceipt.aspx">收貨修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/inquireOrder.aspx">訂單查詢</asp:HyperLink>
            </td>
        </tr>
        </table>
            <asp:Label ID="Label1" runat="server" Text="客戶ID"></asp:Label>
            <asp:TextBox ID="guestID" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" ImageUrl="~/pic/search.png"  AlternateText="No Image available" OnClick="findguest" runat="server" Height="16px" Width="16px" /> 
            <asp:Label ID="Label2" runat="server" Text="出貨日期"></asp:Label>
            <asp:TextBox ID="shippedDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="ImageButton2_Click" runat="server" Height="16px" Width="16px" /> 
        </div>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        <asp:GridView ID="GridView5" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource3" OnSelectedIndexChanged="GridView5_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:TemplateField HeaderText="客戶ID">
                    <ItemTemplate>
                        <asp:Label ID="guestID"  Width="75px" runat="server" Text='<%# Bind("guestID") %>'  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客戶名稱">
                    <ItemTemplate>
                        <asp:Label ID="guestName"  Width="75px" runat="server" Text='<%# Bind("guestName") %>'  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getguest" TypeName="Database.AccessLayer.guestAccessLayer"></asp:ObjectDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="搜尋" />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1">
            <Columns>
                <asp:BoundField DataField="brand" HeaderText="brand" SortExpression="brand" ItemStyle-Width="75px" >
<ItemStyle Width="75px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:GridView ID="GridView2" runat="server" DataSource='<%# Bind("content") %>' ShowHeader="False" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="productID" HeaderText="productID" SortExpression="productID" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="producttype" HeaderText="producttype" SortExpression="producttype" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="jprice" HeaderText="jprice" SortExpression="jprice" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colornum" HeaderText="colornum" SortExpression="colornum" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="color" HeaderText="color" SortExpression="color" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="size" HeaderText="size" SortExpression="size" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="tprice" SortExpression="tprice">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("tprice") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="tpriceLabel" runat="server" Text='<%# Bind("tprice") %>'></asp:Label>
                                        <asp:Label ID="tpriceLabelempty" runat="server" Text='NT$' Visible="False"></asp:Label>
                                        <asp:CheckBox ID="CheckBox1" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" Checked="True" />
                                    </ItemTemplate>
                                    <ItemStyle Width="75px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="remark" SortExpression="remark">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="remarkLabel" runat="server" Text='<%# Bind("remark") %>'></asp:Label>
                                        <asp:Label ID="remarkLabelempty" runat="server" Text='' Visible="False"></asp:Label>
                                        <asp:CheckBox ID="CheckBox2" runat="server" Checked="True" OnCheckedChanged="CheckBox2_CheckedChanged"/>
                                    </ItemTemplate>
                                    <ItemStyle Width="75px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table runat="server">
                            <tr>
                                <td class="auto-style1">貨號</td>
                                <td class="auto-style1">商品類別</td>
                                <td class="auto-style1">上代稅</td>
                                <td class="auto-style1">色號</td>
                                <td class="auto-style1">顏色</td>
                                <td class="auto-style1">尺寸</td>
                                <td class="auto-style1">數量</td>
                                <td class="auto-style1">金額</td>
                                <td class="auto-style1">備註</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getships" TypeName="Database.shipmentAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="guestID" DefaultValue="" Name="guestID" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="shippedDate" DefaultValue="" Name="shipmentDate" PropertyName="Text" Type="String" />
                <asp:Parameter DefaultValue="false" Name="o" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" Width="796px">
            <Columns>
                <asp:BoundField DataField="brand" HeaderText="brand" SortExpression="brand" ItemStyle-Width="75px" >
<ItemStyle Width="75px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:GridView ID="GridView4" runat="server" DataSource='<%# Bind("content") %>' ShowHeader="False" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="productID" HeaderText="productID" SortExpression="productID" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="producttype" HeaderText="producttype" SortExpression="producttype" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="jprice" HeaderText="jprice" SortExpression="jprice" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="colornum" HeaderText="colornum" SortExpression="colornum" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="color" HeaderText="color" SortExpression="color" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="size" HeaderText="size" SortExpression="size" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="amount" HeaderText="amount" SortExpression="amount" ItemStyle-Width="75px">
                                <ItemStyle Width="75px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="備註列印"></asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table runat="server">
                            <tr>
                                <td class="auto-style1">貨號</td>
                                <td class="auto-style1">商品類別</td>
                                <td class="auto-style1">上代稅</td>
                                <td class="auto-style1">色號</td>
                                <td class="auto-style1">顏色</td>
                                <td class="auto-style1">尺寸</td>
                                <td class="auto-style1">數量</td>
                                <td class="auto-style1">備註</td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getships" TypeName="Database.shipmentAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="guestID" DefaultValue="" Name="guestID" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="shippedDate" DefaultValue="" Name="shipmentDate" PropertyName="Text" Type="String" />
                <asp:Parameter DefaultValue="True" Name="o" Type="Boolean" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="匯出pdf" />
    </form>
</body>
</html>
