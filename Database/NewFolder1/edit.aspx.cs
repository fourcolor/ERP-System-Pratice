using Database.AccessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database
{
    public partial class insert1 : System.Web.UI.Page
    {
        static string[] cond = new string[2];
        static string[] HeaderTextstr ={
            "訂單編號",
            "流水號",
            "品番",
            "商品類別",
            "上代",
            "納期",
            "色番",
            "1表示順",

        };


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void guestName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                GridView1.DataSourceID = "ObjectDataSource2";
            }
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView1.SelectedRow;
                string s = gridViewRow.Cells[1].Text;
                orderDetailAccessLayer.cond = "where 訂單編號 = " + gridViewRow.Cells[1].Text + ";";
                ObjectDataSource2.DataBind();
                GridView2.DataBind();
                GridView2.ShowFooter = true;
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            orderDetailAccessLayer.cond = "where 1 = 1;";
            ObjectDataSource2.DataBind();
            GridView2.DataBind();
        }

        protected void findguest(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = false;
            if (GridView3.Visible == true)
            {
                GridView3.Visible = false;
            }
            else
            {
                GridView3.Visible = true;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            GridView3.Visible = false;
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DateBox.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }


        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView3.SelectedRow;
                string s = ((Label)gridViewRow.FindControl("guestID")).Text;
                guestID.Text = s;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            orderAccessLayer.cond = " where 1=1 ";
            if (guestID.Text != null && guestID.Text != "")
            {
                cond[0] = " and 客戶編號 = " + guestID.Text + " ";
            }
            else
            {
                cond[0] = "";
            }
            if (DateBox.Text != null && DateBox.Text != "")
            {
                try
                {
                    CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP"); //日期文化格式
                    DateTime d;
                    d = DateTime.ParseExact(DateBox.Text, "yyyy/MM/dd", CultureInfoDateCulture);
                    cond[1] = " and 訂單日期 = '" + DateBox.Text + "' ";
                }
                catch
                {
                    Response.Write("<script>alert('日期格式為yyyy/MM/dd');</script>");
                }
            }
            else
            {
                cond[1] = "";
            }
            foreach (var i in cond)
            {
                orderAccessLayer.cond += i;
            }
            GridView1.DataBind();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = GridView1.SelectedRow;
            string orderID = gridViewRow.Cells[1].Text;
            string ser = (GridView2.Rows.Count + 1).ToString();
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            string productID = ((TextBox)GridView2.FooterRow.FindControl("productIDFooter")).Text;
            string productType = ((TextBox)GridView2.FooterRow.FindControl("productTypeFooter")).Text;
            string jprice = ((TextBox)GridView2.FooterRow.FindControl("jpriceFooter")).Text;
            string DeliveryDate = ((TextBox)GridView2.FooterRow.FindControl("DeliveryDateFooter")).Text;
            string colornum = ((TextBox)GridView2.FooterRow.FindControl("colornumFooter")).Text;
            string color = ((TextBox)GridView2.FooterRow.FindControl("colorFooter")).Text;
            string size = ((TextBox)GridView2.FooterRow.FindControl("sizeFooter")).Text;
            string amount = ((TextBox)GridView2.FooterRow.FindControl("amountFooter")).Text;
            string brand = ((TextBox)GridView2.FooterRow.FindControl("brandFooter")).Text;
            string shipment = ((TextBox)GridView2.FooterRow.FindControl("shipmentFooter")).Text;
            string unshipment = ((TextBox)GridView2.FooterRow.FindControl("unshipmentFooter")).Text;
            string filemaker = ((TextBox)GridView2.FooterRow.FindControl("filemakerFooter")).Text;
            string fileDate = ((TextBox)GridView2.FooterRow.FindControl("fileDateFooter")).Text;
            string statment = ((TextBox)GridView2.FooterRow.FindControl("statmentFooter")).Text;
            string outofstock = ((TextBox)GridView2.FooterRow.FindControl("outofstockFooter")).Text;
            string remark = ((TextBox)GridView2.FooterRow.FindControl("remarkFooter")).Text;
            string cmd = "INSERT INTO `data`.`orderdetail` (`訂單編號`, `流水號`, `品番`, `商品類別`, `上代`, `納期`, `色番`, `ｶﾗｰ`, `ｻｲｽﾞ`, `訂貨数量`, `品牌`, `出貨數量`, `未出數量`, `建檔人`, `建檔日`, `結單`, `缺貨`, `備註`) " +
                "VALUES (" +
                "'" + orderID + "'," +
                " '" + ser + "', " +
                "'" + productID + "', " +
                "'" + productType + "', " +
                "'" + jprice + "', " +
                "'" + DeliveryDate + "', " +
                "'" + colornum + "', " +
                "'" + color + "', " +
                "'" + size + "', " +
                "'" + amount + "', " +
                "'" + brand + "', " +
                "'" + shipment + "', " +
                "'" + unshipment + "', " +
                "'" + filemaker + "', " +
                "'" + fileDate + "', " +
                "'" + statment + "', " +
                "'" + outofstock + "', " +
                "'" + remark + "'" +
                ");";
            sqlConn.Command(cmd);
            GridView2.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string s = ((TextBox)GridView3.Controls[0].Controls[0].FindControl("TextBox17")).Text;
            if (s != "" && s != null)
            {
                sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                string cmd = "INSERT INTO `data`.`guest` (`guestName`) VALUES ('" + s + "');";
                sqlConn.Command(cmd);
                GridView3.DataBind();

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string s = ((TextBox)GridView3.FooterRow.FindControl("TextBox18")).Text;
            if (s != "" && s != null)
            {
                guestAccessLayer.cond = " where guestName Like '%" + s + "%'";
            }
            else
            {
                guestAccessLayer.cond = " where 1=1";
            }
            GridView3.DataBind();
            guestAccessLayer.cond = " where 1=1";
        }

        protected void ObjectDataSource2_Updating(object sender, ObjectDataSourceMethodEventArgs e)
        {
            if (!Foolproof.IntFoolproof(e.InputParameters["amount"].ToString()))
            {
                Response.Write("<script>alert('訂貨数量為整數');</script>");
                e.Cancel = true;
            }
            else if (!Foolproof.DateFoolproof(e.InputParameters["fileDate"].ToString()))
            {
                Response.Write("<script>alert('建檔日期格式為yyyy/MM/dd');</script>");
                e.Cancel = true;
            }
            else if(!Foolproof.DateFoolproof(e.InputParameters["DeliveryDate"].ToString()))
            {
                Response.Write("<script>alert('納品書日格式為yyyy/MM/dd');</script>");
                e.Cancel = true;
            }
            else if(!Foolproof.IntFoolproof(e.InputParameters["unshipment"].ToString()))
            {
                Response.Write("<script>alert('未出數量為整數');</script>");
                e.Cancel = true;
            }
            else if(!Foolproof.DoubleFoolproof(e.InputParameters["price"].ToString()))
            {
                Response.Write("<script>alert('上代格式錯誤');</script>");
                e.Cancel = true;
            }
        }
    }
}