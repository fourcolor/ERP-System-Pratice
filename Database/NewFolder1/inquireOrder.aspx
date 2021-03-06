﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inquireOrder.aspx.cs" Inherits="Database.inquireOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            width: 192px;
            height: 262px;
        }
        .auto-style1 {
            width: 173%;
            height: 204px;
        }
        .auto-style3 {
            width: 162px;
        }
        .auto-style5 {
            height: 20px;
            width: 98px;
        }
        .auto-style6 {
            width: 162px;
            height: 20px;
        }
        .auto-style7 {
            width: 98px;
        }
        .auto-style8 {
            width: 144px;
            height: 201px;
            margin-top: 0px;
        }
        .auto-style9 {
            height: 26px;
        }
        .auto-style10 {
            width: 98px;
            height: 26px;
        }
        .auto-style11 {
            width: 162px;
            height: 26px;
        }
        .auto-style12 {
            height: 25px;
        }
        .auto-style13 {
            width: 98px;
            height: 25px;
        }
        .auto-style14 {
            width: 162px;
            height: 25px;
        }
        .auto-style15 {
            height: 24px;
        }
        .auto-style16 {
            width: 98px;
            height: 24px;
        }
        .auto-style17 {
            width: 162px;
            height: 24px;
        }
        .auto-style18 {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style8">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>以訂單查詢</asp:ListItem>
            <asp:ListItem>以收貨單查詢</asp:ListItem>
        </asp:RadioButtonList>
        <table class="auto-style1">
            <tr>
                <td class="auto-style15">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
                <td class="auto-style16">訂單日期</td>
                <td class="auto-style17">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton4" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" runat="server" Height="16px" Width="16px" OnClick="ImageButton4_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style18">
                    <asp:CheckBox ID="CheckBox2" runat="server" />
                </td>
                <td class="auto-style5">店家</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> 
                </td>
                <td class="auto-style18">
                    <asp:ImageButton ID="guestButton" ImageUrl="~/pic/search.png"  AlternateText="No Image available" runat="server" Height="16px" Width="16px" OnClick="guestButton_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox3" runat="server" />
                </td>
                <td class="auto-style7">品牌</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox4" runat="server" />
                </td>
                <td class="auto-style7">季節</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox5" runat="server" />
                </td>
                <td class="auto-style7">商品類別</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="CheckBox6" runat="server" />
                </td>
                <td class="auto-style7">店家出貨日期</td>
                <td class="auto-style3">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton5" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" runat="server" Height="16px" Width="16px" OnClick="ImageButton5_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:CheckBox ID="CheckBox7" runat="server" />
                </td>
                <td class="auto-style10">收貨單日</td>
                <td class="auto-style11">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:ImageButton ID="ImageButton6" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" runat="server" Height="16px" Width="16px" OnClick="ImageButton6_Click" />
                </td>
            </tr>
            <tr>
                <td class="auto-style12">
                    <asp:CheckBox ID="CheckBox8" runat="server" />
                </td>
                <td class="auto-style13">結單</td>
                <td class="auto-style14">
                    <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
        <asp:GridView ID="GridView3" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource3" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" Visible="False">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="getguest" TypeName="Database.AccessLayer.guestAccessLayer"></asp:ObjectDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" Text="搜尋" OnClick="Button1_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server" DataSourceID="ObjectDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AllowPaging="True" Width="1228px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>

        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getInquireData" TypeName="Database.accessInquireLayse"></asp:ObjectDataSource>
        <br />
        <asp:GridView ID="GridView2" runat="server" DataSourceID="ObjectDataSource2" AllowPaging="True" Width="1104px">
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getinquire" TypeName="Database.ReceiptDetailAccessLayer">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" DefaultValue="&quot;&quot;" Name="orderID" PropertyName="SelectedRow.Cells[1].Text" Type="String" />
                <asp:ControlParameter ControlID="GridView1" DefaultValue="&quot;&quot;" Name="SERIALNUMBER" PropertyName="SelectedRow.Cells[2].Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
