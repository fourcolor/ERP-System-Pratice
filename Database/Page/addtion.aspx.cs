using Database.AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database.Page
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int status = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertbutton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                inserModeDetail detail = new inserModeDetail();
                detail.amount = ((TextBox)GridView1.FooterRow.FindControl("amountBox")).Text;
                detail.brand = ((TextBox)GridView1.FooterRow.FindControl("brandBox")).Text;
                detail.color = ((TextBox)GridView1.FooterRow.FindControl("colorBox")).Text;
                detail.colorNum = ((TextBox)GridView1.FooterRow.FindControl("colorNumBox")).Text;
                detail.price = ((TextBox)GridView1.FooterRow.FindControl("priceBox")).Text;
                detail.productID = ((TextBox)GridView1.FooterRow.FindControl("productIDBox")).Text;
                detail.productType = ((TextBox)GridView1.FooterRow.FindControl("productTypeBox")).Text;
                detail.remark = ((TextBox)GridView1.FooterRow.FindControl("remarkBox")).Text;
                detail.shipment = ((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text;
                detail.size = ((TextBox)GridView1.FooterRow.FindControl("sizeBox")).Text;
                detail.unshipment = ((TextBox)GridView1.FooterRow.FindControl("unshipmentBox")).Text;
                detail.DeliveryDate = ((TextBox)GridView1.FooterRow.FindControl("DeliveryDateBox")).Text;
                detail.statement = ((TextBox)GridView1.FooterRow.FindControl("statementBox")).Text;
                detail.replyDate = ((TextBox)GridView1.FooterRow.FindControl("replyDateBox")).Text;
                detail.outofstock = ((TextBox)GridView1.FooterRow.FindControl("outofstockBOX")).Text;
                insertModeDetailAccessLayer.adddetails.Add(detail);
                GridView1.DataBind();
                GridView1.Rows[0].Visible = false;
            }
        }

        protected void TextBox15_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int index = (textBox.NamingContainer as GridViewRow).RowIndex;
            insertModeDetailAccessLayer.adddetails[index].amount = ((TextBox)GridView1.Rows[index].FindControl("tamount")).Text;
            insertModeDetailAccessLayer.adddetails[index].brand = ((TextBox)GridView1.Rows[index].FindControl("tbrand")).Text;
            insertModeDetailAccessLayer.adddetails[index].color = ((TextBox)GridView1.Rows[index].FindControl("tcolor")).Text;
            insertModeDetailAccessLayer.adddetails[index].colorNum = ((TextBox)GridView1.Rows[index].FindControl("tcolorNum")).Text;
            insertModeDetailAccessLayer.adddetails[index].price = ((TextBox)GridView1.Rows[index].FindControl("tprice")).Text;
            insertModeDetailAccessLayer.adddetails[index].productID = ((TextBox)GridView1.Rows[index].FindControl("tproductID")).Text;
            insertModeDetailAccessLayer.adddetails[index].productType = ((TextBox)GridView1.Rows[index].FindControl("tproductType")).Text;
            insertModeDetailAccessLayer.adddetails[index].remark = ((TextBox)GridView1.Rows[index].FindControl("tremark")).Text;
            insertModeDetailAccessLayer.adddetails[index].shipment = ((TextBox)GridView1.Rows[index].FindControl("tshipment")).Text;
            insertModeDetailAccessLayer.adddetails[index].size = ((TextBox)GridView1.Rows[index].FindControl("tsize")).Text;
            insertModeDetailAccessLayer.adddetails[index].unshipment = ((TextBox)GridView1.Rows[index].FindControl("tunshipment")).Text;
            insertModeDetailAccessLayer.adddetails[index].outofstock = ((TextBox)GridView1.Rows[index].FindControl("outofstock")).Text;
            insertModeDetailAccessLayer.adddetails[index].statement = ((TextBox)GridView1.Rows[index].FindControl("statement")).Text;
            insertModeDetailAccessLayer.adddetails[index].DeliveryDate = ((TextBox)GridView1.Rows[index].FindControl("tDeliveryDate")).Text;
            insertModeDetailAccessLayer.adddetails[index].replyDate = ((TextBox)GridView1.Rows[index].FindControl("treplyDate")).Text;
            GridView1.DataBind();
            GridView1.Rows[0].Visible = false;
        }

        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            int index = (calendar.NamingContainer as GridViewRow).RowIndex;
            ((TextBox)GridView1.Rows[index].FindControl("tDeliveryDate")).Text = calendar.SelectedDate.ToString("yyyy/MM/dd");
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            ((TextBox)GridView1.FooterRow.FindControl("DeliveryDateBox")).Text = ((Calendar)sender).SelectedDate.ToString("yyyy/MM/dd");
        }

        protected void Footerimgcalbut_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.Visible = false;
            Calendar1.Visible = false;
            if (GridView1.FooterRow.FindControl("Calendar2").Visible == false)
            {
                GridView1.FooterRow.FindControl("Calendar2").Visible = true;
            }
            else
            {
                GridView1.FooterRow.FindControl("Calendar2").Visible = false;
            }
        }

        protected void itemimgcalbut_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            int index = (imageButton.NamingContainer as GridViewRow).RowIndex;
            if (GridView1.Rows[index].FindControl("Calendar3").Visible == true)
            {
                GridView1.Rows[index].FindControl("Calendar3").Visible = false;
            }
            else
            {
                GridView1.Rows[index].FindControl("Calendar3").Visible = true;
            }
        }

        protected void amountBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)GridView1.FooterRow.FindControl("unshipmentBox")).Text = (Convert.ToInt32(((TextBox)GridView1.FooterRow.FindControl("amountBox")).Text) - Convert.ToInt32(((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text)).ToString();
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridView1.Rows[0].Visible = false;
        }

        protected void findguest(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = false;
            if (GridView2.Visible)
            {
                GridView2.Visible = false;
            }
            else
            {
                GridView2.Visible = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.Visible = false;
            if (Calendar1.Visible == true && status == 1)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
                status = 1;
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.Visible = false;
            if (Calendar1.Visible == true && status == 2)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
                status = 2;
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView2.SelectedRow;
                string s = ((Label)gridViewRow.FindControl("guestID")).Text;
                guestIDBox.Text = s;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            switch (status)
            {
                case 1:
                    DateBox.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
                    break;
                case 2:
                    fileDateBox.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
                    break;
            }
        }

        protected void Calendar5_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            int index = (calendar.NamingContainer as GridViewRow).RowIndex;
            ((TextBox)GridView1.Rows[index].FindControl("treplyDate")).Text = calendar.SelectedDate.ToString("yyyy/MM/dd");

        }

        protected void Calendar4_SelectionChanged(object sender, EventArgs e)
        {
            Calendar calendar = (Calendar)sender;
            int index = (calendar.NamingContainer as GridViewRow).RowIndex;
            ((TextBox)GridView1.FooterRow.FindControl("replyDateBox")).Text = calendar.SelectedDate.ToString("yyyy/MM/dd");

        }

        protected void Footerimgcalbut2_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.Visible = false;
            Calendar1.Visible = false;
            if (GridView1.FooterRow.FindControl("Calendar4").Visible == false)
            {
                GridView1.FooterRow.FindControl("Calendar4").Visible = true;
            }
            else
            {
                GridView1.FooterRow.FindControl("Calendar4").Visible = false;
            }
        }

        protected void itemimgcalbut2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imageButton = (ImageButton)sender;
            int index = (imageButton.NamingContainer as GridViewRow).RowIndex;
            if (GridView1.Rows[index].FindControl("Calendar5").Visible == true)
            {
                GridView1.Rows[index].FindControl("Calendar5").Visible = false;
            }
            else
            {
                GridView1.Rows[index].FindControl("Calendar5").Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "YES")
            {
                return;
            }
            else
            {
                List<inserModeDetail> orderDetails = new List<inserModeDetail>();
                foreach (var i in insertModeDetailAccessLayer.adddetails)
                {
                    orderDetails.Add(i);
                }
                orderDetails.RemoveAt(0);
                bool flag = true;
                if (!Foolproof.GuestFoolproof(guestIDBox.Text))
                {
                    Response.Write("<script>alert('客人編號錯誤')</script>");
                    flag = false;
                }
                else if (!Foolproof.DateFoolproof(DateBox.Text))
                {
                    Response.Write("<script>alert('訂單日期格式為yyyy/MM/dd')</script>");
                    flag = false;
                }
                else if (!Foolproof.DateFoolproof(fileDateBox.Text))
                {
                    Response.Write("<script>alert('建檔日期錯誤')</script>");
                    flag = false;
                }
                else
                {
                    foreach (var i in orderDetails)
                    {
                        if (!Foolproof.DateFoolproof(i.DeliveryDate))
                        {
                            Response.Write("<script>alert('日期格式為yyyy/MM/dd');</script>");
                            flag = false;
                            break;
                        }
                        if (!Foolproof.DateFoolproof(i.replyDate))
                        {
                            Response.Write("<script>alert('日期格式為yyyy/MM/dd');</script>");
                            flag = false;
                            break;
                        }
                        if (!Foolproof.DoubleFoolproof(i.price))
                        {
                            Response.Write("<script>alert('上代欄位格式錯誤');</script>");
                            flag = false;
                            break;
                        }
                        if (!Foolproof.IntFoolproof(i.amount))
                        {
                            Response.Write("<script>alert('訂貨数量欄位格式錯誤');</script>");
                            flag = false;
                            break;
                        }
                        if (!Foolproof.IntFoolproof(i.shipment))
                        {
                            Response.Write("<script>alert('出貨數量欄位格式錯誤');</script>");
                            flag = false;
                            break;
                        }
                        if (!Foolproof.IntFoolproof(i.unshipment))
                        {
                            Response.Write("<script>alert('未出數量欄位格式錯誤');</script>");
                            flag = false;
                            break;
                        }
                        if (i.statement != "N" && i.statement != "Y")
                        {
                            Response.Write("<script>alert('結單欄位格式錯誤');</script>");
                            flag = false;
                            break;
                        }
                        if (i.outofstock != "N" && i.outofstock != "Y")
                        {
                            Response.Write("<script>alert('缺貨欄位格式錯誤');</script>");
                            flag = false;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    insertModeDetailAccessLayer.adddetails.RemoveAt(0);
                    sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                    int num = 1;
                    string com = "INSERT INTO `data`.`order` (`客戶編號`, `訂單日期`,`追加`) VALUES (" + guestIDBox.Text + ", '" + DateBox.Text + "','Y');";
                    sqlConn.Command(com);
                    com = "SELECT max(訂單編號) FROM data.order;";
                    string orderID = sqlConn.SelectCommand(com).Tables[0].Rows[0][0].ToString();
                    foreach (var i in insertModeDetailAccessLayer.adddetails)
                    {
                        com = "INSERT INTO `data`.`orderdetail` (`訂單編號`,`流水號`, `品番`, `商品類別`, `上代`, `納期`,`回客日期`, `色番`, `ｶﾗｰ`, `ｻｲｽﾞ`, `訂貨数量`, `品牌`, `出貨數量`, `未出數量`, `建檔人`, `建檔日`,`結單`,`缺貨`, `備註`) " +
                            "VALUES ("
                             + orderID + ", "
                             + num + ", "
                             + i.productID + ", " +
                            "'" + i.productType + "', "
                             + i.price + ", " +
                            "'" + i.DeliveryDate + "', "+
                            "'" + i.replyDate + "', "
                             + i.colorNum + ", " +
                            "'" + i.color + "', " +
                            "'" + i.size + "', "
                             + i.amount + ", " +
                            "'" + i.brand + "', "
                             + 0 + ", "
                             + i.amount + ", " +
                            "'" + fileMakerBox.Text + "', " +
                            "'" + fileDateBox.Text + "', " +
                            "'" + i.statement + "', " +
                            "'" + i.outofstock + "', " +
                            "'" + i.remark + "' " +
                            ");";
                        sqlConn.Command(com);
                        num++;
                    }
                    insertModeDetailAccessLayer.adddetails.Clear();
                    GridView1.DataBind();
                    GridView1.Rows[0].Visible = false;
                }
            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = (((DropDownList)sender).NamingContainer as GridViewRow).RowIndex;
            insertModeDetailAccessLayer.adddetails[index].productType = ((DropDownList)sender).SelectedValue;
            GridView1.DataBind();
        }

        protected void DropDownList3_Load(object sender, EventArgs e)
        {
            DropDownList dropDownList = sender as DropDownList;
            productTypeAccessLayer producttype = new productTypeAccessLayer();
            List<string> vs = producttype.getProductType();
            dropDownList.Items.Add("");
            foreach (var i in vs)
            {
                dropDownList.Items.Add(i);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            productTypeAccessLayer producttype = new productTypeAccessLayer();
            List<string> vs = producttype.getProductType();
            // Instead of string array it could be your data retrieved from database.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("tproductType");
                foreach (string colName in vs)
                    ddl.Items.Add(new ListItem(colName));
            }
        }
    }
}