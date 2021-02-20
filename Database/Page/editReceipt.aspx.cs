using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace Database
{
    public partial class editReceipt : System.Web.UI.Page
    {
        static int status = 1;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Footerorderser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                string t1 = (GridView2.FooterRow.FindControl("FooterorderID") as DropDownList).SelectedValue;
                string t2 = (GridView2.FooterRow.FindControl("Footerorderser") as DropDownList).SelectedValue;
                DataSet dataSet;
                if ((t1 != "" && t1 != null) && (t2 != "" && t2 != null))
                {
                    sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                    dataSet = sqlConn.SelectCommand("SELECT 品番,商品類別,上代,納期,色番,ｶﾗｰ,ｻｲｽﾞ,訂貨数量,品牌,出貨數量,未出數量,缺貨 FROM data.orderdetail where 訂單編號=" + t1 + " and 流水號=" + t2 + ";");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        ((Label)GridView2.FooterRow.FindControl("FootProductID")).Text = dataSet.Tables[0].Rows[0]["品番"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FootProductType")).Text = dataSet.Tables[0].Rows[0]["商品類別"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FooterJprice")).Text = dataSet.Tables[0].Rows[0]["上代"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FootDeliDate")).Text = dataSet.Tables[0].Rows[0]["納期"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FooterColorNum")).Text = dataSet.Tables[0].Rows[0]["色番"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FooterColor")).Text = dataSet.Tables[0].Rows[0]["ｶﾗｰ"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FooterSize")).Text = dataSet.Tables[0].Rows[0]["ｻｲｽﾞ"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FooterAmount")).Text = dataSet.Tables[0].Rows[0]["訂貨数量"].ToString();
                        ((Label)GridView2.FooterRow.FindControl("FooterBrand")).Text = dataSet.Tables[0].Rows[0]["品牌"].ToString();
                        ((TextBox)GridView2.FooterRow.FindControl("Footershipment")).Text = "0";
                        ((TextBox)GridView2.FooterRow.FindControl("Footeroutofstock")).Text = dataSet.Tables[0].Rows[0]["缺貨"].ToString(); ;
                        ((Label)GridView2.FooterRow.FindControl("Footerunshipment")).Text = dataSet.Tables[0].Rows[0]["未出數量"].ToString();
                    }

                }
            }
        }
        void footerReset()
        {
            if (GridView2.Rows.Count != 0)
            {
                GridView2.FooterRow.FindControl("Footerorderser").Visible = true;
                GridView2.FooterRow.FindControl("FooterorderID").Visible = true;
                GridView2.FooterRow.FindControl("FootProductID").Visible = false;
                ((Label)GridView2.FooterRow.FindControl("FootProductID")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FootProductType")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterJprice")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FootDeliDate")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterColorNum")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterColor")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterSize")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterAmount")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterBrand")).Text = "";
                ((TextBox)GridView2.FooterRow.FindControl("Footershipment")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("Footerunshipment")).Text = "";
                GridView2.FooterRow.FindControl("Footeroutofstock").Visible = true;
                GridView2.FooterRow.FindControl("FootProductID").Visible = false;
                GridView2.FooterRow.FindControl("FooterExchangerate").Visible = true;
                GridView2.FooterRow.FindControl("Footershipment").Visible = true;
                GridView2.FooterRow.FindControl("FooterShippedDate").Visible = true;
                GridView2.FooterRow.FindControl("Footershipped").Visible = true;
                GridView2.FooterRow.FindControl("FooterRemark").Visible = true;
                GridView2.FooterRow.FindControl("FootOther").Visible = false;
            }

        }
        void footerOtherMode()
        {
            if (GridView2.Rows.Count != 0)
            {
                ((Label)GridView2.FooterRow.FindControl("FootProductID")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FootProductType")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterJprice")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FootDeliDate")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterColorNum")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterColor")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterSize")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterAmount")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("FooterBrand")).Text = "";
                ((TextBox)GridView2.FooterRow.FindControl("Footershipment")).Text = "";
                ((Label)GridView2.FooterRow.FindControl("Footerunshipment")).Text = "";
                GridView2.FooterRow.FindControl("Footerorderser").Visible = false;
                GridView2.FooterRow.FindControl("FooterorderID").Visible = false;
                GridView2.FooterRow.FindControl("FootProductID").Visible = false;
                GridView2.FooterRow.FindControl("Footerunshipment").Visible = false;
                GridView2.FooterRow.FindControl("Footershipped").Visible = false;
                GridView2.FooterRow.FindControl("Footeroutofstock").Visible = false;
                GridView2.FooterRow.FindControl("FooterRemark").Visible = true;
                GridView2.FooterRow.FindControl("FootOther").Visible = true;
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                footerReset();
                GridViewRow gridViewRow = GridView1.SelectedRow;
                string s = gridViewRow.Cells[1].Text;
                ReceiptDetailAccessLayer.cond = " where recieptdetail.收貨編號 = " + gridViewRow.Cells[1].Text + ";";
                guestIDt.Text = gridViewRow.Cells[2].Text;
                ObjectDataSource2.DataBind();
                GridView2.DataBind();
                guestID_TextChanged(null, null);
                status = 1;
            }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView3.SelectedRow;
                string s = ((Label)gridViewRow.FindControl("guestID")).Text;
                guestIDt.Text = s;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            recieptDate.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }


        protected void ObjectDataSource2_Updating2(object sender, ObjectDataSourceMethodEventArgs e)
        {
            if (!Foolproof.DoubleFoolproof(e.InputParameters["exchangeRate"].ToString()))
            {
                Response.Write("<script>alert('匯率為小數');</script>");
                e.Cancel = true;
            }
            else if (!Foolproof.IntFoolproof(e.InputParameters["shipment"].ToString()))
            {
                Response.Write("<script>alert('應收數量');</script>");
                e.Cancel = true;
            }
            else if (!Foolproof.IntFoolproof(e.InputParameters["shipped"].ToString()))
            {
                Response.Write("<script>alert('實收數量為整數');</script>");
                e.Cancel = true;
            }
            else if (!Foolproof.DateFoolproof(e.InputParameters["shippedDate"].ToString()))
            {
                Response.Write("<script>alert('出貨日其格式為yyyy/MM/dd');</script>");
                e.Cancel = true;
            }
            else if (e.InputParameters["outofstock"].ToString() != "N" && e.InputParameters["outofstock"].ToString() != "Y")
            {
                Response.Write("<script>alert('缺貨欄只能為N或Y');</script>");
                e.Cancel = true;
            }
        }

        protected void guestID_TextChanged(object sender, EventArgs e)
        {
            string guestID = guestIDt.Text;
            DropDownList dropDownList = GridView2.FooterRow.FindControl("FooterorderID") as DropDownList;
            dropDownList.Items.Clear();
            int k;
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            string cmd;
            if (int.TryParse(guestID, out k))
            {
                cmd =
                "select DISTINCT orderdetail.訂單編號 " +
                "from data.orderdetail " +
                "inner join data.order " +
                "on data.order.訂單編號 = orderdetail.訂單編號 " +
                "where data.order.客戶編號 = " + guestID + " and orderdetail.結單 = 'N';";
            }
            else
            {
                return;
            }
            DataSet dataSet = sqlConn.SelectCommand(cmd);
            int len = dataSet.Tables[0].Rows.Count;
            for (int i = 0; i < len; i++)
            {
                dropDownList.Items.Add(dataSet.Tables[0].Rows[i]["訂單編號"].ToString());
                dropDownList.Items[i].Selected = false;
            }
            DropDownList1_SelectedIndexChanged1(dropDownList, null);
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            DropDownList dropDownList = GridView2.FooterRow.FindControl("Footerorderser") as DropDownList;
            dropDownList.Items.Clear();
            string orderID = ((DropDownList)sender).SelectedValue;
            int k;
            string guestID = guestIDt.Text;
            string cmd;
            if (int.TryParse(orderID, out k))
            {
                cmd =
                "select DISTINCT orderdetail.流水號 " +
                "from data.orderdetail " +
                "inner join data.order " +
                "on data.order.訂單編號 = orderdetail.訂單編號 " +
                "where data.order.客戶編號 = " + guestID + " and orderdetail.結單 = 'N' and orderdetail.訂單編號=" + orderID + ";";
            }
            else
            {
                return;
            }
            DataSet dataSet = sqlConn.SelectCommand(cmd);
            int len = dataSet.Tables[0].Rows.Count;
            for (int i = 0; i < len; i++)
            {
                dropDownList.Items.Add(dataSet.Tables[0].Rows[i]["流水號"].ToString());
            }
            Footerorderser_SelectedIndexChanged(null, null);
        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {

        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            bool flag = true;
            int recieptID = Convert.ToInt32(((Label)GridView2.FooterRow.FindControl("FootrecieptID")).Text);
            string orderID = (GridView2.FooterRow.FindControl("FooterorderID") as DropDownList).SelectedValue;
            string other = ((TextBox)GridView2.FooterRow.FindControl("FootOther")).Text;
            string shippedDate= ((TextBox)GridView2.FooterRow.FindControl("FooterShippedDate")).Text;
            string exchangeRate= ((TextBox)GridView2.FooterRow.FindControl("FooterExchangerate")).Text;
            string recieptser = ((Label)GridView2.FooterRow.FindControl("Footrecieptser")).Text;
            string SERIALNUMBER= (GridView2.FooterRow.FindControl("Footerorderser") as DropDownList).SelectedValue;
            string shipped= ((TextBox)GridView2.FooterRow.FindControl("Footershipped")).Text;
            string tprice = ((Label)GridView2.FooterRow.FindControl("FooterTprice")).Text;
            string shipment = ((TextBox)GridView2.FooterRow.FindControl("Footershipment")).Text;
            string unshipment = ((Label)GridView2.FooterRow.FindControl("Footerunshipment")).Text;
            string remark = ((TextBox)GridView2.FooterRow.FindControl("FooterRemark")).Text;
            string amount = ((Label)GridView2.FooterRow.FindControl("FooterAmount")).Text;
            string outofstock = ((TextBox)GridView2.FooterRow.FindControl("Footeroutofstock")).Text;
            if (orderID != "")
            {
                if (!Foolproof.DateFoolproof(shippedDate))
                {
                    Response.Write("<script>alert('出貨日期格式為yyyy/MM/dd');</script>");
                    flag = false;
                }
                else if (!Foolproof.DoubleFoolproof(exchangeRate))
                {
                    Response.Write("<script>alert('匯率應為小數');</script>");
                    flag = false;
                }
                else if (!Foolproof.IntFoolproof(shipment))
                {
                    Response.Write("<script>alert('應收數量應為整數');</script>");
                    flag = false;
                }
                else if (!Foolproof.IntFoolproof(shipped))
                {
                    Response.Write("<script>alert('實收數量應為整數');</script>");
                    flag = false;
                }
                else if (!Foolproof.IntFoolproof(unshipment))
                {
                    Response.Write("<script>alert('未收數量應為整數');</script>");
                    flag = false;
                }
                else if (Convert.ToInt32(amount) < Convert.ToInt32(shipment))
                {
                    Response.Write("<script>alert('應收數量不得大於訂貨數量');</script>");
                    flag = false;
                }
                else if (Convert.ToInt32(shipment) < Convert.ToInt32(shipped))
                {
                    Response.Write("<script>alert('實收不得大於應收數量');</script>");
                    flag = false;
                }
                else if (Convert.ToInt32(unshipment) < 0)
                {
                    Response.Write("<script>alert('實收不得大於未收數量');</script>");
                    flag = false;
                }
            }
            else
            {
                if (!Foolproof.DoubleFoolproof(exchangeRate))
                {
                    Response.Write("<script>alert('匯率應為小數');</script>");
                    flag = false;
                }
                else if (other == "" || other == null)
                {
                    Response.Write("<script>alert('其他欄不得為空');</script>");
                    flag = false;
                }
            }
            if (flag)
            {
                sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                string cmd;
                if (orderID == "")
                {
                    cmd = "INSERT INTO `data`.`recieptdetail` (`收貨編號`, `收貨流`, `其他`, `出貨日`, `小計`) " +
                        "VALUES (" +
                        "'" + recieptID + "', " +
                        "'" + recieptser + "', " +
                        "'" + other + "', " +
                        "'" + shippedDate + "', " +
                        "'" + exchangeRate + "'" +
                        ");";
                    sqlConn.Command(cmd);
                }
                cmd = "INSERT INTO `data`.`recieptdetail` (`收貨編號`,`收貨流`, `訂單編號`, `流水號`, `匯率`, `實收數量`, `出貨日`, `小計`, `出貨數量`, `未出數量`, `備註`) VALUES (" +
                    "'" + recieptID + "', " +
                    "'" + recieptser + "', " +
                    "'" + orderID + "', " +
                    "'" + SERIALNUMBER + "', " +
                    "'" + exchangeRate + "', " +
                    "'" + shipped + "', " +
                    "'" + shippedDate + "', " +
                    "'" + tprice + "', " +
                    "'" + shipment + "', " +
                    "'" + unshipment + "', " +
                    "'" + remark + "'" +
                    ");";
                sqlConn.Command(cmd);
                int ship = Convert.ToInt32(amount) - Convert.ToInt32(unshipment);
                if (outofstock == "N")
                {
                    cmd = "Update data.orderdetail set 出貨數量=" + ship + ",未出數量=" + unshipment + " where 流水號 = " + SERIALNUMBER + " AND 訂單編號 = " + orderID + ";";
                }
                else if (outofstock == "Y")
                {
                    cmd = "Update data.orderdetail set 出貨數量=" + ship + ",未出數量=" + unshipment + ",缺貨='Y',結單='Y' where 流水號 = " + SERIALNUMBER + " AND 訂單編號 = " + orderID + ";";
                }

                sqlConn.Command(cmd);
            }
            GridView2.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(status==1)
            {
                footerOtherMode();
                status = 2;
            }
            else
            {
                footerReset();
                status = 1;
            }
        }

        protected void FooterExchangerate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string rate = (sender as TextBox).Text;
                double shipment = Convert.ToDouble(((TextBox)GridView2.FooterRow.FindControl("Footershipment")).Text);
                double jprice = Convert.ToDouble(((Label)GridView2.FooterRow.FindControl("FooterJprice")).Text);
                ((TextBox)GridView2.FooterRow.FindControl("Footershipped")).Text = shipment.ToString();
                if (status == 2)
                {
                    (GridView2.FooterRow.FindControl("FooterTprice") as Label).Text = rate;
                }
                else
                {
                    (GridView2.FooterRow.FindControl("FooterTprice") as Label).Text = (Convert.ToDouble(rate) * jprice * shipment).ToString();
                }
            }
            catch { return; }
        }
    }
}