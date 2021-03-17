<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="Database.insert" enableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
        <script type = "text/javascript">
            function footerConfirm() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                var tbxValue = document.getElementById('<%=((TextBox)GridView1.FooterRow.FindControl("productIDBox")).ClientID%>').value;
                if (tbxValue != "") {
                    if (confirm("還有欄位為新增是否返回")) {
                        confirm_value.value = "YES";
                    } else {
                        confirm_value.value = "NO";
                    }
                    document.forms[0].appendChild(confirm_value);
                }
            }
        </script>
        <script type = "text/javascript">
            function Confirm() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Do you want to save data?")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
            }
        </script>
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
</head>

<body>
    <form id="form1" runat="server">
        <div>
        <table class="auto-style1">
            <tr>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/addtion.aspx">追加訂單</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/edit.aspx">訂單修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/insertReceipt.aspx">收貨新增</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/editReceipt.aspx">收貨修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Page/Shipment.aspx">出貨修改</asp:HyperLink>
            </td>
            <td class="auto-style20">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page/inquireOrder.aspx">訂單查詢</asp:HyperLink>
            </td>
            </tr>
        </table>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="客戶名稱:"></asp:Label>
        <asp:TextBox ID="guestIDBox" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/pic/search.png"  AlternateText="No Image available" OnClick="findguest" runat="server" Height="16px" Width="16px" /> 
        <asp:Label ID="Label2" runat="server" Text="訂單日期:"></asp:Label>
        <asp:TextBox ID="DateBox" runat="server" Text="MM/dd/yyyy"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="ImageButton2_Click" runat="server" Height="16px" Width="16px" /> 
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="getguest" TypeName="Database.AccessLayer.guestAccessLayer"></asp:ObjectDataSource>
        <br />
        <br />
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" Visible="False"></asp:Calendar>
        <br />
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" DataSourceID="ObjectDataSource2" Visible="False" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" DataKeyNames="guestID">
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
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowFooter="True" AllowPaging="True" ShowHeaderWhenEmpty="True" DataKeyNames="productID,productType,price,DeliveryDate,colorNum,color,size,amount,brand,shipment,unshipment,remark" OnDataBound="GridView1_DataBound" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="商品編號" SortExpression="productID">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("productID") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="productIDBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tproductID" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" Width="100px" runat="server" Text='<%# Bind("productID") %>'  ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="商品類別" SortExpression="productType">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("productType") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="productTypeBox" class="user" Width="100px" runat="server" OnLoad="DropDownList3_Load" AutoPostBack="True">
                        </asp:DropDownList>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="tproductType" class="user"  Width="100px" runat="server" OnLoad="DropDownList3_Load"  OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" SelectedValue='<%# Bind("productType") %>' AutoPostBack="True" AppendDataBoundItems="True">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="上代" SortExpression="price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("price") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="priceBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tprice" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("price") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="納品書日" SortExpression="DeliveryDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="DeliveryDateBox" runat="server" Width="100px" Text =""></asp:TextBox>
                        <asp:ImageButton ID="Footerimgcalbut" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="Footerimgcalbut_Click" runat="server" Height="16px" Width="16px" />
                        <asp:Calendar ID="Calendar2" runat="server" OnSelectionChanged="Calendar2_SelectionChanged" Visible="False"></asp:Calendar>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tDeliveryDate" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="itemimgcalbut" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="itemimgcalbut_Click" runat="server" Height="16px" Width="16px" />
                        <asp:Calendar ID="Calendar3" runat="server" OnSelectionChanged="Calendar3_SelectionChanged" Visible="False"></asp:Calendar>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="色番" SortExpression="colorNum">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("colorNum") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="colorNumBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tcolorNum" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("colorNum") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ｶﾗｰ" SortExpression="color">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("color") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="colorBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tcolor" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("color") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ｻｲｽﾞ" SortExpression="size">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("size") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="sizeBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tsize" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("size") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="訂貨数量" SortExpression="amount">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("amount") %>' Width="100px" ></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="amountBox" runat="server" Width="100px" Text ="" OnTextChanged="amountBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tamount" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("amount") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="品牌" SortExpression="brand">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("brand") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="brandBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tbrand" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("brand") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="出貨數量" SortExpression="shipment">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("shipment") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="shipmentBox" runat="server" Width="100px" Text ="0" OnTextChanged="amountBox_TextChanged" AutoPostBack="True"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tshipment" AutoPostBack="True" OnTextChanged="tshipment_TextChanged" runat="server" Text='<%# Bind("shipment") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="未出數量" SortExpression="unshipment">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox13" runat="server" Text='<%# Bind("unshipment") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="unshipmentBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tunshipment" AutoPostBack="True" OnTextChanged="tunshipment_TextChanged" runat="server" Text='<%# Bind("unshipment") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="缺貨" SortExpression="unshipment">
                    <EditItemTemplate>
                        <asp:TextBox ID="s2" runat="server" Text='<%# Bind("outofstock") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="outofstockBOX" runat="server" Width="100px" Text ="N"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="outofstock" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("outofstock") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="結單" SortExpression="unshipment">
                    <EditItemTemplate>
                        <asp:TextBox ID="s1" runat="server" Text='<%# Bind("statement") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="statementBox" runat="server" Width="100px" Text ="N"></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="statement" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("statement") %>' Width="100px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="備註" SortExpression="remark">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox14" runat="server" Text='<%# Bind("remark") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="remarkBox" runat="server" Width="100px" Text =""></asp:TextBox>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="tremark" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("remark") %>' Width="100px" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="刪除" ></asp:LinkButton>
                    </ItemTemplate>
                    <ControlStyle Width="50px" />
                    <FooterTemplate>
                        <asp:Button ID="insertbutton" runat="server" Text="新增" OnClick="insertbutton_Click" />
                    </FooterTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" OnClientClick="footerConfirm()" Text="保存" />
        <br />
        <br />
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="getInsertModeDetail" TypeName="Database.insertModeDetailAccessLayer" DeleteMethod="deleteInsertModeDetail">
            <DeleteParameters>
                <asp:Parameter Name="productID" Type="String" />
                <asp:Parameter Name="productType" Type="String" />
                <asp:Parameter Name="price" Type="String" />
                <asp:Parameter Name="DeliveryDate" Type="String" />
                <asp:Parameter Name="colorNum" Type="String" />
                <asp:Parameter Name="color" Type="String" />
                <asp:Parameter Name="size" Type="String" />
                <asp:Parameter Name="amount" Type="String" />
                <asp:Parameter Name="brand" Type="String" />
                <asp:Parameter Name="shipment" Type="String" />
                <asp:Parameter Name="unshipment" Type="String" />
                <asp:Parameter Name="remark" Type="String" />
            </DeleteParameters>
        </asp:ObjectDataSource>
    </form>
</body>
</html>
