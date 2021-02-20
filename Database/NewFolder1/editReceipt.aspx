﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editReceipt.aspx.cs" Inherits="Database.editReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="客戶ID"></asp:Label>
            <asp:TextBox ID="guestID" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" ImageUrl="~/pic/search.png"  AlternateText="No Image available" OnClick="findguest" runat="server" Height="16px" Width="16px" /> 
            <asp:Label ID="Label2" runat="server" Text="收貨日期"></asp:Label>
            <asp:TextBox ID="recieptDate" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButton2" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="ImageButton2_Click" runat="server" Height="16px" Width="16px" /> 
            <asp:Button ID="Button1" runat="server" Text="搜尋" OnClick="Button1_Click" />
        </div>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource3" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" Visible="False" AutoGenerateColumns="False">
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
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="font-weight: 700" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="receiptID" HeaderText="收貨編號" SortExpression="receiptID" />
                <asp:BoundField DataField="guestID" HeaderText="客人編號" SortExpression="guestID" />
                <asp:BoundField DataField="receiptDate" HeaderText="收貨日期" SortExpression="receiptDate" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getactuallReceipts" TypeName="Database.ReceiptAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="guestID" Name="guestID" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="recieptDate" Name="Date" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" DataSourceID="ObjectDataSource2" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="receiptID,receiptSERIALNUMBER,orderID,SERIALNUMBER,jprice,amount" ForeColor="Black">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="receiptID" HeaderText="收貨編號" SortExpression="receiptID" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="receiptSERIALNUMBER" HeaderText="收貨流" InsertVisible="False" ReadOnly="True" SortExpression="receiptSERIALNUMBER" />
                <asp:BoundField DataField="orderID" InsertVisible="False" ReadOnly="True" HeaderText="訂單編號" SortExpression="orderID" />
                <asp:BoundField DataField="SERIALNUMBER" InsertVisible="False" ReadOnly="True" HeaderText="流水號" SortExpression="SERIALNUMBER" />
                <asp:BoundField DataField="productID" InsertVisible="False" ReadOnly="True" HeaderText="商品編號" SortExpression="productID" />
                <asp:BoundField DataField="productType" InsertVisible="False" ReadOnly="True" HeaderText="商品類別" SortExpression="productType" />
                <asp:BoundField DataField="jprice" InsertVisible="False" ReadOnly="True" HeaderText="上代" SortExpression="jprice" />
                <asp:BoundField DataField="DeliveryDate" InsertVisible="False" ReadOnly="True" HeaderText="納品書日" SortExpression="DeliveryDate" />
                <asp:BoundField DataField="colorNum" InsertVisible="False" ReadOnly="True" HeaderText="色番" SortExpression="colorNum" />
                <asp:BoundField DataField="color" InsertVisible="False" ReadOnly="True" HeaderText="ｶﾗｰ" SortExpression="color" />
                <asp:BoundField DataField="size" InsertVisible="False" ReadOnly="True" HeaderText="ｻｲｽﾞ" SortExpression="size" />
                <asp:BoundField DataField="amount" InsertVisible="False" ReadOnly="True" HeaderText="訂貨数量" SortExpression="amount" />
                <asp:BoundField DataField="exchangeRate" HeaderText="匯率" SortExpression="exchangeRate" />
                <asp:BoundField DataField="brand" InsertVisible="False" ReadOnly="True" HeaderText="品牌" SortExpression="brand" />
                <asp:BoundField DataField="shipment" HeaderText="出貨數量" SortExpression="shipment" />
                <asp:BoundField DataField="unshipment" InsertVisible="False" ReadOnly="True" HeaderText="未出數量" SortExpression="unshipment" />
                <asp:BoundField DataField="shipped" HeaderText="實收數量" SortExpression="shipped" />
                <asp:BoundField DataField="shippedDate" HeaderText="出貨日" SortExpression="shippedDate" />
                <asp:BoundField DataField="tprice" InsertVisible="False" ReadOnly="True" HeaderText="小計" SortExpression="tprice" />
                <asp:BoundField DataField="remark" HeaderText="備註" SortExpression="remark" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getReceiptDetail" TypeName="Database.ReceiptDetailAccessLayer" DeleteMethod="deleteRecieptDetail" UpdateMethod="updateRecieptDetail">
            <DeleteParameters>
                <asp:Parameter Name="receiptID" Type="String" />
                <asp:Parameter Name="receiptSERIALNUMBER" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="receiptID" Type="String" />
                <asp:Parameter Name="receiptSERIALNUMBER" Type="String" />
                <asp:Parameter Name="orderID" Type="Int32" />
                <asp:Parameter Name="SERIALNUMBER" Type="Int32" />
                <asp:Parameter Name="jprice" Type="Double" />
                <asp:Parameter Name="amount" Type="Int32" />
                <asp:Parameter Name="exchangeRate" Type="Double" />
                <asp:Parameter Name="shipment" Type="Int32" />
                <asp:Parameter Name="shipped" Type="Int32" />
                <asp:Parameter Name="shippedDate" Type="String" />
                <asp:Parameter Name="remark" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>