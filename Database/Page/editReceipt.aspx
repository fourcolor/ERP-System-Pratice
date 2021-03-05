<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editReceipt.aspx.cs" Inherits="Database.editReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
    <script>
        $(function () {
            $user = $("[class$='user']");
            $user.select2({
                //maximumSelectionLength: 1,
                language: 'zh-TW',
                width: '100%',
                type: "POST",
                // 最多字元限制
                maximumInputLength: 10,
                // 最少字元才觸發尋找, 0 不指定
                minimumInputLength: 0,
                // 當找不到可以使用輸入的文字
                // tags: true,
                placeholder: '請輸入名稱...',
                // AJAX 相關操作

            });
            //$user.val(null).trigger('change');
        });
    </script>
         <style type="text/css">
         .user {
             width: 75px;
             height: 20px;
         }
     </style>
        <style type="text/css">
        #form1 {
            font-weight: 700;
        }
        .auto-style1 {
            background-color:lightgreen;
            width: 100%;
        }
        .auto-style20 {
            width: 80px;
        }
    </style>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
    <form id="form1" runat="server">
         <table class="auto-style1">
            <tr>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/insert.aspx">訂單新增</asp:HyperLink>
            </td>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/edit.aspx">訂單修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/addtion.aspx">追加訂單</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/insertReceipt.aspx">收貨新增</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Page/Shipment.aspx">出貨修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page/inquireOrder.aspx">訂單查詢</asp:HyperLink>
            </td>
            </tr>
        </table>
        <div>
            <asp:Label ID="Label1" runat="server" Text="客戶ID"></asp:Label>
            <asp:TextBox ID="guestIDt" runat="server" OnTextChanged="guestID_TextChanged" AutoPostBack="True"></asp:TextBox>
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
                <asp:ControlParameter ControlID="guestIDt" Name="guestID" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="recieptDate" Name="Date" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource2" DataKeyNames="receiptID,receiptSERIALNUMBER,orderID,SERIALNUMBER,jprice,amount" ShowFooter="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:TemplateField HeaderText="收貨編號" InsertVisible="False" SortExpression="receiptID">
                    <EditItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("receiptID") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FootrecieptID" runat="server" Width="75px" Text='<%# ((Label)GridView2.Rows[0].FindControl("Label1")).Text %>'></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("receiptID") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="收貨流" InsertVisible="False" SortExpression="receiptSERIALNUMBER">
                    <EditItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("receiptSERIALNUMBER") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                         <asp:Label ID="Footrecieptser" runat="server" Width="75px" Text='<%#GridView2.Rows.Count+1 %>'></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("receiptSERIALNUMBER") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="訂單編號" InsertVisible="False" SortExpression="orderID">
                    <EditItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("orderID") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="FooterorderID" class="user" runat="server" AppendDataBoundItems="True" OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="True" Width="75px">
                        </asp:DropDownList>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server"  Text='<%# Bind("orderID") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="流水號" InsertVisible="False" SortExpression="SERIALNUMBER">
                    <EditItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("SERIALNUMBER") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="Footerorderser" class="user" runat="server" AppendDataBoundItems="True" OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="Footerorderser_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("SERIALNUMBER") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品編號" InsertVisible="False" SortExpression="productID">
                    <EditItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("productID") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FootProductID"  Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("productID") %>'></asp:Label>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品類別" InsertVisible="False" SortExpression="productType">
                    <EditItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("productType") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FootProductType" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("productType") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上代" InsertVisible="False" SortExpression="jprice">
                    <EditItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Eval("jprice") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterJprice" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("jprice") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="納品書日" InsertVisible="False" SortExpression="DeliveryDate">
                    <EditItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("DeliveryDate") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FootDeliDate" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label22" runat="server" Text='<%# Bind("DeliveryDate") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="色番" InsertVisible="False" SortExpression="colorNum">
                    <EditItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Eval("colorNum") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterColorNum" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label20" runat="server" Text='<%# Bind("colorNum") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ｶﾗｰ" InsertVisible="False" SortExpression="color">
                    <EditItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("color") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterColor" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label21" runat="server" Text='<%# Bind("color") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ｻｲｽﾞ" InsertVisible="False" SortExpression="size">
                    <EditItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Eval("size") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterSize" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label19" runat="server" Text='<%# Bind("size") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="訂貨数量" InsertVisible="False" SortExpression="amount">
                    <EditItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterAmount" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label18" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="匯率" SortExpression="exchangeRate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("exchangeRate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="FooterExchangerate" Text="" Width="75px" runat="server" AutoPostBack="True" OnTextChanged="FooterExchangerate_TextChanged"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label17" runat="server" Text='<%# Bind("exchangeRate") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="品牌" InsertVisible="False" SortExpression="brand">
                    <EditItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Eval("brand") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterBrand" Width="75px" runat="server" Text="" ></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label16" runat="server" Text='<%# Bind("brand") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出貨數量" SortExpression="shipment">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("shipment") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="Footershipment" Text="" Width="75px" runat="server" AutoPostBack="True" OnTextChanged="FooterExchangerate_TextChanged"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label15" runat="server" Text='<%# Bind("shipment") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="未出數量" InsertVisible="False" SortExpression="unshipment">
                    <EditItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Eval("unshipment") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="Footerunshipment" Text="" Width="75px" runat="server" ></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label14" runat="server" Text='<%# Bind("unshipment") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="實收數量" SortExpression="shipped">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("shipped") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="Footershipped" Width="75px" Text="" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label13" runat="server" Text='<%# Bind("shipped") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出貨日" SortExpression="shippedDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("shippedDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="FooterShippedDate" Text="" Width="75px" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label12" runat="server" Text='<%# Bind("shippedDate") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="小計" InsertVisible="False" SortExpression="tprice">
                    <EditItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Eval("tprice") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="FooterTprice" Width="75px" runat="server" Text=""></asp:Label>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label11" runat="server" Text='<%# Bind("tprice") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="其他">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("other") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="FootOther" Text="" Width="75px" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label9" runat="server" Text='<%# Bind("other") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="缺貨" SortExpression="outofstock">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("outofstock") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="Footeroutofstock" Text="" Width="75px" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label10" runat="server" Text='<%# Bind("outofstock") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="備註" SortExpression="remark">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("remark") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="FooterRemark" Text="" Width="75px" runat="server"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label8" runat="server" Text='<%# Bind("remark") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Width="75px" />
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="Button2" runat="server" Text="其他" OnClick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="新增" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="編輯"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle Width="75px" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>

        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getReceiptDetail" TypeName="Database.ReceiptDetailAccessLayer" DeleteMethod="deleteRecieptDetail" UpdateMethod="updateRecieptDetail" OnUpdating="ObjectDataSource2_Updating2">
            <DeleteParameters>
                <asp:Parameter Name="receiptID" Type="String" />
                <asp:Parameter Name="receiptSERIALNUMBER" Type="String" />
                <asp:Parameter Name="orderID" Type="String" />
                <asp:Parameter Name="SERIALNUMBER" Type="String" />
                <asp:Parameter Name="jprice" Type="String" />
                <asp:Parameter Name="amount" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="receiptID" Type="String" />
                <asp:Parameter Name="receiptSERIALNUMBER" Type="String" />
                <asp:Parameter Name="orderID" Type="String" />
                <asp:Parameter Name="SERIALNUMBER" Type="String" />
                <asp:Parameter Name="jprice" Type="String" />
                <asp:Parameter Name="amount" Type="String" />
                <asp:Parameter Name="exchangeRate" Type="String" />
                <asp:Parameter Name="shipment" Type="String" />
                <asp:Parameter Name="shipped" Type="String" />
                <asp:Parameter Name="shippedDate" Type="String" />
                <asp:Parameter Name="other" Type="String" />
                <asp:Parameter Name="outofstock" Type="String" />
                <asp:Parameter Name="remark" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
