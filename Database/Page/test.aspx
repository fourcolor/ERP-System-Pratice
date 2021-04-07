<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Database.Page.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title></title>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-1.8.0.js"></script>
    <script src="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>
    <link rel="Stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.6-rc.0/js/select2.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script  type="text/javascript">
        $(function () {
            $('#TextBox1').autocomplete({
            source: function (request, response) {
                    var param = { n: $('#TextBox1').val() };
                $.ajax({
                    url: "test.aspx/find",
                    data: JSON.stringify(param),
                    type: "POST",
                    contenType: "application/json;char=utf-8",
                    success: function (data) {
                        console.log(data.d.n)
                    },
                });
            },
            minLength: 1
        });
    });
    </script>
    <script>
        $(function () {
            var param = { n: $('#TextBox1').val() };
            console.log(param);
            $('<%= ((DropDownList)GridView1.Controls[0].Controls[0].FindControl("DropDownList2")).ClientID%>').select2({
                maximumSelectionLength: 1,
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
            $('<%= GridView1.Rows[0].FindControl("DropDownList2").ClientID%>').val(null).trigger('change');
        })
    </script>
     <style type="text/css">
         .user {
             width: 342px;
             height: 27px;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">

        <p>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged">1</asp:TextBox>
        </p>
        <asp:DropDownList ID="DropDownList1" class="user" runat="server" multiple AppendDataBoundItems="True" OnDataBound="DropDownList1_DataBound" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="1">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </EmptyDataTemplate>
        </asp:GridView>
     </form>

</body>
</html>
