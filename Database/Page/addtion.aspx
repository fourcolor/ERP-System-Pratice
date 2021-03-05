<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addtion.aspx.cs" Inherits="Database.Page.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        <style type="text/css">
        #form1 {
            font-weight: 700;
        }
        .auto-style1 {
            width:100%;
            background-color:lightgreen;
            height: 18px;
        }
        .auto-style2 {
            width: 80px;
           
            height: 20px;
        }
        .auto-style3 {
            color:deepskyblue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div >
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page/insert.aspx">訂單插入</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/edit.aspx">訂單修改</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/insertReceipt.aspx">收貨新增</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/editReceipt.aspx">收貨修改</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Page/Shipment.aspx">出貨新增</asp:HyperLink>
                </td>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/inquireOrder.aspx">訂單搜尋</asp:HyperLink>
                </td>
            </tr>
        </table>
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
        <asp:Label ID="Label3" runat="server" Text="建檔人:    "></asp:Label>
        <asp:TextBox ID="fileMakerBox" runat="server" style="margin-left: 13px"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="建檔日期:"></asp:Label>
        <asp:TextBox ID="fileDateBox" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton3" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="ImageButton3_Click" runat="server" Height="16px" Width="16px" /> 
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
        </div>
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
                <asp:TemplateField HeaderText="回客日期" SortExpression="DeliveryDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox88" runat="server" Text='<%# Bind("DeliveryDate") %>' Width="100px"></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="replyDateBox" runat="server" Width="100px" Text =""></asp:TextBox>
                        <asp:ImageButton ID="Footerimgcalbut2" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="Footerimgcalbut2_Click" runat="server" Height="16px" Width="16px" />
                        <asp:Calendar ID="Calendar4" runat="server" OnSelectionChanged="Calendar4_SelectionChanged" Visible="False"></asp:Calendar>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="treplyDate" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("replyDate") %>' Width="100px"></asp:TextBox>
                        <asp:ImageButton ID="itemimgcalbut2" ImageUrl="~/pic/calendar.jpg"  AlternateText="No Image available" OnClick="itemimgcalbut2_Click" runat="server" Height="16px" Width="16px" />
                        <asp:Calendar ID="Calendar5" runat="server" OnSelectionChanged="Calendar5_SelectionChanged" Visible="False"></asp:Calendar>
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
                        <asp:TextBox ID="tshipment" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("shipment") %>' Width="100px"></asp:TextBox>
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
                        <asp:TextBox ID="tunshipment" AutoPostBack="True" OnTextChanged="TextBox15_TextChanged" runat="server" Text='<%# Bind("unshipment") %>' Width="100px"></asp:TextBox>
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
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="addgetInsertModeDetail" TypeName="Database.insertModeDetailAccessLayer"></asp:ObjectDataSource>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="保存" />
        </p>
    </form>
</body>
</html>
