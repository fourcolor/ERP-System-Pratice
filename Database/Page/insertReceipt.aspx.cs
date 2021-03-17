using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Database
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static int status = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Rows[0].Visible = false;
        }

        void footerReset()
        {
            GridView1.FooterRow.FindControl("SERIALNUMBERBox").Visible = true;
            GridView1.FooterRow.FindControl("orderIDBox").Visible = true;
            GridView1.FooterRow.FindControl("productIDBox").Visible = false;          
            ((Label)GridView1.FooterRow.FindControl("productIDLabel")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("productTypeLabel")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("jpriceBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("DeliveryDateBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("colornumBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("colorBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("sizeBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("amountBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("brandBox")).Text = "";
            ((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("unshipmentBox")).Text = "";
            GridView1.FooterRow.FindControl("exchangeRateBox").Visible = false;
            GridView1.FooterRow.FindControl("shipmentBox").Visible = false;
            GridView1.FooterRow.FindControl("shippedDateBox").Visible = false;
            GridView1.FooterRow.FindControl("remark").Visible = false;
            GridView1.FooterRow.FindControl("shippedBox").Visible = false;
            GridView1.FooterRow.FindControl("outofstock").Visible = true;
            GridView1.FooterRow.FindControl("productIDBox").Visible = false;
            GridView1.FooterRow.FindControl("exchangeRateBox").Visible = true;
            GridView1.FooterRow.FindControl("shipmentBox").Visible = true;
            GridView1.FooterRow.FindControl("shippedDateBox").Visible = true;
            GridView1.FooterRow.FindControl("shippedBox").Visible = true;
            GridView1.FooterRow.FindControl("remark").Visible = true;
            GridView1.FooterRow.FindControl("other").Visible = false;

        }
        void footerOtherMode()
        {
            ((Label)GridView1.FooterRow.FindControl("productIDLabel")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("productTypeLabel")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("jpriceBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("DeliveryDateBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("colornumBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("colorBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("sizeBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("amountBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("brandBox")).Text = "";
            ((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text = "";
            ((Label)GridView1.FooterRow.FindControl("unshipmentBox")).Text = "";
            ((TextBox)GridView1.FooterRow.FindControl("orderIDBox")).Text = "";
            ((TextBox)GridView1.FooterRow.FindControl("SERIALNUMBERBox")).Text = "";
            GridView1.FooterRow.FindControl("SERIALNUMBERBox").Visible = false;
            GridView1.FooterRow.FindControl("orderIDBox").Visible = false;
            GridView1.FooterRow.FindControl("productIDBox").Visible = false;
            GridView1.FooterRow.FindControl("shipmentBox").Visible = false;
            GridView1.FooterRow.FindControl("shippedBox").Visible = false;
            GridView1.FooterRow.FindControl("outofstock").Visible = false;
            GridView1.FooterRow.FindControl("remark").Visible = true;
            GridView1.FooterRow.FindControl("other").Visible = true;
        }
        protected void SERIALNUMBERBox_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Message.Text = "";
                string t1 = ((TextBox)GridView1.FooterRow.FindControl("orderIDBox")).Text;
                string t2 = ((TextBox)GridView1.FooterRow.FindControl("SERIALNUMBERBox")).Text;
                DataSet dataSet;
                if ((t1 != "" && t1 != null) && (t2 != "" && t2 != null))
                {
                    sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                    dataSet = sqlConn.SelectCommand("SELECT 品番,商品類別,上代,納期,色番,ｶﾗｰ,ｻｲｽﾞ,訂貨数量,品牌,出貨數量,未出數量 FROM data.orderdetail where 訂單編號=" + t1 + " and 流水號=" + t2 + ";");
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        ((Label)GridView1.FooterRow.FindControl("productIDLabel")).Text = dataSet.Tables[0].Rows[0]["品番"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("productTypeLabel")).Text = dataSet.Tables[0].Rows[0]["商品類別"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("jpriceBox")).Text = dataSet.Tables[0].Rows[0]["上代"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("DeliveryDateBox")).Text = dataSet.Tables[0].Rows[0]["納期"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("colornumBox")).Text = dataSet.Tables[0].Rows[0]["色番"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("colorBox")).Text = dataSet.Tables[0].Rows[0]["ｶﾗｰ"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("sizeBox")).Text = dataSet.Tables[0].Rows[0]["ｻｲｽﾞ"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("amountBox")).Text = dataSet.Tables[0].Rows[0]["訂貨数量"].ToString();
                        ((Label)GridView1.FooterRow.FindControl("brandBox")).Text = dataSet.Tables[0].Rows[0]["品牌"].ToString();
                        ((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text = "0";
                        ((Label)GridView1.FooterRow.FindControl("unshipmentBox")).Text = dataSet.Tables[0].Rows[0]["未出數量"].ToString();
                    }
                    else
                    {
                        Message.Text = "查無此資料";
                        Message.ForeColor = System.Drawing.Color.Red;
                        footerReset();
                    }

                }
                else if ((t1 == "" || t1 == null) && (t2 == "" || t2 == null))
                {
                    footerReset();
                }
            }
        }

        protected void exchangeRateBox_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Message.Text = "";
                try
                {
                    sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                    string orderID = ((TextBox)GridView1.FooterRow.FindControl("orderIDBox")).Text;
                    string SERIALNUMBER = ((TextBox)GridView1.FooterRow.FindControl("SERIALNUMBERBox")).Text;
                    if (orderID != "" && orderID != null && SERIALNUMBER != "" && orderID != null)
                    {
                        string t1 = ((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text;
                        ((TextBox)GridView1.FooterRow.FindControl("shippedBox")).Text = t1;
                        string t2 = ((TextBox)GridView1.FooterRow.FindControl("exchangeRateBox")).Text;
                        string t3 = ((Label)GridView1.FooterRow.FindControl("unshipmentBox")).Text;
                        string cmd = "SELECT 未出數量 FROM data.orderdetail where 訂單編號 =" + orderID + " and 流水號 = " + SERIALNUMBER + ";";
                        DataSet dataSet = sqlConn.SelectCommand(cmd);
                        if (dataSet.Tables[0].Rows.Count == 0)
                        {
                            Message.Text = "查無此資料";
                            Message.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            int total = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
                            double unshipment = total - Convert.ToDouble(t1);
                            if (t1 != "" && t1 != null)
                            {
                                ((Label)GridView1.FooterRow.FindControl("unshipmentBox")).Text = unshipment.ToString();
                            }
                            if ((t1 != "" && t1 != null) && (t2 != "" && t2 != null))
                            {

                                double jprice = Convert.ToDouble(((Label)GridView1.FooterRow.FindControl("jpriceBox")).Text);
                                ((Label)GridView1.FooterRow.FindControl("tprice")).Text = (jprice * (Convert.ToDouble(t2) * Convert.ToDouble(t1))).ToString();
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (status == 2)
                {
                    if (((TextBox)GridView1.FooterRow.FindControl("other")).Text != "" && ((TextBox)GridView1.FooterRow.FindControl("other")).Text != null)
                    {
                        ReceiptDetail detail = new ReceiptDetail();
                        detail.orderID = "";
                        detail.SERIALNUMBER = "";
                        detail.productID = "";
                        detail.productType = "";
                        detail.jprice = "";
                        detail.DeliveryDate = "";
                        detail.colorNum = "";
                        detail.color = "";
                        detail.size = "";
                        detail.amount = "";
                        detail.exchangeRate = ((TextBox)GridView1.FooterRow.FindControl("exchangeRateBox")).Text;
                        detail.brand = "";
                        detail.shipment = "";
                        detail.unshipment = "";
                        detail.shipped = "";
                        detail.other = ((TextBox)GridView1.FooterRow.FindControl("other")).Text;
                        detail.shippedDate = ((TextBox)GridView1.FooterRow.FindControl("shippedDateBox")).Text; ;
                        detail.tprice = ((TextBox)GridView1.FooterRow.FindControl("exchangeRateBox")).Text;
                        detail.remark = ((TextBox)GridView1.FooterRow.FindControl("remark")).Text;
                        ReceiptDetailAccessLayer.details.Add(detail);
                        GridView1.DataBind();
                        GridView1.Rows[0].Visible = false;
                        status = 1;
                        footerReset();
                    }
                    else
                    {
                        Response.Write("<script>alert('其他欄不得為空')</script>");
                    }
                }
                else
                {
                    string t1 = ((TextBox)GridView1.FooterRow.FindControl("orderIDBox")).Text;
                    string t2 = ((TextBox)GridView1.FooterRow.FindControl("SERIALNUMBERBox")).Text;
                    if ((t1 != "" && t1 != null) && (t2 != "" && t2 != null))
                    {

                        ReceiptDetail receipt = new ReceiptDetail();
                        receipt.amount = ((Label)GridView1.FooterRow.FindControl("amountBox")).Text;
                        receipt.orderID = ((TextBox)GridView1.FooterRow.FindControl("orderIDBox")).Text;
                        receipt.SERIALNUMBER = ((TextBox)GridView1.FooterRow.FindControl("SERIALNUMBERBox")).Text;
                        receipt.productID = ((Label)GridView1.FooterRow.FindControl("productIDLabel")).Text;
                        receipt.productType = ((Label)GridView1.FooterRow.FindControl("productTypeLabel")).Text;
                        receipt.jprice = ((Label)GridView1.FooterRow.FindControl("jpriceBox")).Text;
                        receipt.DeliveryDate = ((Label)GridView1.FooterRow.FindControl("DeliveryDateBox")).Text;
                        receipt.colorNum = ((Label)GridView1.FooterRow.FindControl("colornumBox")).Text;
                        receipt.color = ((Label)GridView1.FooterRow.FindControl("colorBox")).Text;
                        receipt.size = ((Label)GridView1.FooterRow.FindControl("sizeBox")).Text;
                        receipt.exchangeRate = ((TextBox)GridView1.FooterRow.FindControl("exchangeRateBox")).Text;
                        receipt.brand = ((Label)GridView1.FooterRow.FindControl("brandBox")).Text;
                        receipt.shipment = ((TextBox)GridView1.FooterRow.FindControl("shipmentBox")).Text;
                        receipt.unshipment = ((Label)GridView1.FooterRow.FindControl("unshipmentBox")).Text;
                        receipt.shipped = ((TextBox)GridView1.FooterRow.FindControl("shippedBox")).Text;
                        receipt.shippedDate = ((TextBox)GridView1.FooterRow.FindControl("shippedDateBox")).Text;
                        receipt.tprice = ((Label)GridView1.FooterRow.FindControl("tprice")).Text;
                        receipt.remark = ((TextBox)GridView1.FooterRow.FindControl("remark")).Text;
                        receipt.outofstock = ((TextBox)GridView1.FooterRow.FindControl("outofstock")).Text;
                        ReceiptDetailAccessLayer.details.Add(receipt);
                    }
                    else if ((t1 == "" || t1 == null) && (t2 == "" || t2 == null))
                    {
                        Response.Write("<script>alert('訂單編號欄及流水號欄不得為空')</script>");
                    }
                    GridView1.DataBind();
                    GridView1.Rows[0].Visible = false;
                }
            }
        }

        
        protected void exchangeRateChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TextBox curTextBox = (TextBox)sender;
                int index = (curTextBox.NamingContainer as GridViewRow).RowIndex;
                if (ReceiptDetailAccessLayer.details[index].orderID != "")
                {
                    double shipment = Convert.ToDouble(ReceiptDetailAccessLayer.details[index].shipment);
                    double rate = Convert.ToDouble(((TextBox)GridView1.Rows[index].FindControl("Label15")).Text);
                    double jprice = Convert.ToDouble(ReceiptDetailAccessLayer.details[index].jprice);
                    double tprice = shipment * rate * jprice;
                    ReceiptDetailAccessLayer.details[index].exchangeRate = rate.ToString();
                    ReceiptDetailAccessLayer.details[index].tprice = tprice.ToString();
                    GridView1.DataBind();
                }
                else
                {
                    ReceiptDetailAccessLayer.details[index].exchangeRate = ((TextBox)GridView1.Rows[index].FindControl("Label15")).Text;
                    ReceiptDetailAccessLayer.details[index].tprice = ((TextBox)GridView1.Rows[index].FindControl("Label15")).Text;
                    GridView1.DataBind();
                }
            }
        }
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GridView1.Rows[0].Visible = false;
            }
        }

        protected void shipmentChanged(object sender, EventArgs e)
        {
            TextBox curTextBox = (TextBox)sender;
            int index = (curTextBox.NamingContainer as GridViewRow).RowIndex;
            if (ReceiptDetailAccessLayer.details[index].orderID != "")
            {
                sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                string cmd = "SELECT 未出數量 FROM data.orderdetail where 訂單編號 =" + ReceiptDetailAccessLayer.details[index].orderID + " and 流水號 = " + ReceiptDetailAccessLayer.details[index].SERIALNUMBER + ";";
                DataSet dataSet = sqlConn.SelectCommand(cmd);
                int total = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
                double shipment = Convert.ToDouble(((TextBox)GridView1.Rows[index].FindControl("Label2")).Text);
                double unshipment = total - Convert.ToDouble(shipment);
                double rate = Convert.ToDouble(ReceiptDetailAccessLayer.details[index].exchangeRate);
                double jprice = Convert.ToDouble(ReceiptDetailAccessLayer.details[index].jprice);
                double tprice = shipment * rate * jprice;
                ReceiptDetailAccessLayer.details[index].shipped = shipment.ToString();
                ReceiptDetailAccessLayer.details[index].unshipment = unshipment.ToString();
                ReceiptDetailAccessLayer.details[index].shipment = shipment.ToString();
                ReceiptDetailAccessLayer.details[index].tprice = tprice.ToString();
                GridView1.DataBind();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if(IsPostBack)
            { 
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "YES")
            {
                return;
            }
                if (!Foolproof.GuestFoolproof(guestID.Text))
                {
                    Response.Write("<script>alert('客戶編號錯誤');</script>");
                }
                else if (!Foolproof.DateFoolproof(shipDate.Text))
                {
                    Response.Write("<script>alert('收貨日期錯誤');</script>");
                }
                else if(shipDate.Text == null || shipDate.Text == "")
                {
                    Response.Write("<script>alert('收貨日期不得為空');</script>");
                }
                else
                {

                    List<ReceiptDetail> receiptDetails = new List<ReceiptDetail>();
                    foreach (var i in ReceiptDetailAccessLayer.details)
                    {
                        receiptDetails.Add(i);
                    }
                    receiptDetails.RemoveAt(0);
                    bool flag = true;
                    foreach (var i in receiptDetails)
                    {
                        if (i.orderID != "")
                        {
                            if (!Foolproof.DateFoolproof(i.shippedDate))
                            {
                                Response.Write("<script>alert('出貨日期格式為yyyy/MM/dd');</script>");
                                flag = false;
                            }
                            else if (!Foolproof.DoubleFoolproof(i.jprice))
                            {
                                Response.Write("<script>alert('上代應為小數');</script>");
                                flag = false;
                            }
                            else if (!Foolproof.DoubleFoolproof(i.exchangeRate))
                            {
                                Response.Write("<script>alert('匯率應為小數');</script>");
                                flag = false;
                            }
                            else if (!Foolproof.IntFoolproof(i.shipment))
                            {
                                Response.Write("<script>alert('應收數量應為整數');</script>");
                                flag = false;
                            }
                            else if (!Foolproof.IntFoolproof(i.shipped))
                            {
                                Response.Write("<script>alert('實收數量應為整數');</script>");
                                flag = false;
                            }
                            else if (!Foolproof.IntFoolproof(i.unshipment))
                            {
                                Response.Write("<script>alert('未收數量應為整數');</script>");
                                flag = false;
                            }
                            else if (Convert.ToInt32(i.amount) < Convert.ToInt32(i.shipment))
                            {
                                Response.Write("<script>alert('應收數量不得大於訂貨數量');</script>");
                                flag = false;
                            }
                            else if (Convert.ToInt32(i.shipment) < Convert.ToInt32(i.shipped))
                            {
                                Response.Write("<script>alert('實收不得大於應收數量');</script>");
                                flag = false;
                            }
                            else if (Convert.ToInt32(i.unshipment) < 0)
                            {
                                Response.Write("<script>alert('實收不得大於未收數量');</script>");
                                flag = false;
                            }
                        }
                        else
                        {
                            if (!Foolproof.DoubleFoolproof(i.exchangeRate))
                            {
                                Response.Write("<script>alert('匯率應為小數');</script>");
                                flag = false;
                            }
                            else if(i.other==""||i.other==null)
                            {
                                Response.Write("<script>alert('其他欄不得為空');</script>");
                                flag = false;
                            }
                        }
                    }
                    if (flag)
                    {
                        sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                        ReceiptDetailAccessLayer.details.RemoveAt(0);
                        string cmd = "INSERT INTO `data`.`receipt` (`收貨日`, `客戶ID`) VALUES ('" + shipDate.Text + "', '" + guestID.Text + "');";
                        sqlConn.Command(cmd);
                        cmd = "select max(receiptID) from data.receipt;";
                        int recieptID = Convert.ToInt32(sqlConn.SelectCommand(cmd).Tables[0].Rows[0][0]);
                        int num = 1;
                        foreach (var i in ReceiptDetailAccessLayer.details)
                        {
                            if (i.orderID == "")
                            {
                                cmd = "INSERT INTO `data`.`recieptdetail` (`收貨編號`, `收貨流`, `其他`, `出貨日`, `小計`) " +
                                    "VALUES (" +
                                    "'" + recieptID + "', " +
                                    "'" + num + "', " +
                                    "'" + i.other + "', " +
                                    "'" + i.shippedDate + "', " +
                                    "'" + i.exchangeRate + "'" +
                                    ");";
                                sqlConn.Command(cmd);
                            }
                            cmd = "INSERT INTO `data`.`recieptdetail` (`收貨編號`,`收貨流`, `訂單編號`, `流水號`, `匯率`, `實收數量`, `出貨日`, `小計`, `出貨數量`, `未出數量`, `備註`) VALUES (" +
                                "'" + recieptID + "', " +
                                "'" + num + "', " +
                                "'" + i.orderID + "', " +
                                "'" + i.SERIALNUMBER + "', " +
                                "'" + i.exchangeRate + "', " +
                                "'" + i.shipped + "', " +
                                "'" + i.shippedDate + "', " +
                                "'" + i.tprice + "', " +
                                "'" + i.shipment + "', " +
                                "'" + i.unshipment + "', " +
                                "'" + i.remark + "'" +
                                ");";
                            sqlConn.Command(cmd);
                            int ship = Convert.ToInt32(i.amount) - Convert.ToInt32(i.unshipment);
                            if (i.outofstock == "N")
                            {
                                cmd = "Update data.orderdetail set 出貨數量=" + ship + ",未出數量=" + i.unshipment + " where 流水號 = " + i.SERIALNUMBER + " AND 訂單編號 = " + i.orderID + ";";
                            }
                            else if (i.outofstock == "Y")
                            {
                                cmd = "Update data.orderdetail set 出貨數量=" + ship + ",未出數量=" + i.unshipment + ",缺貨='Y',結單='Y' where 流水號 = " + i.SERIALNUMBER + " AND 訂單編號 = " + i.orderID + ";";
                            }

                            sqlConn.Command(cmd);
                            num++;
                        }
                        ReceiptDetailAccessLayer.details.Clear();
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void findguest(object sender, ImageClickEventArgs e)
        {
            if (IsPostBack)
            {
                Calendar1.Visible = false;
                if (GridView2.Visible == true)
                {
                    GridView2.Visible = false;
                }
                else
                {
                    GridView2.Visible = true;
                }
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (IsPostBack)
            {
                GridView2.Visible = false;
                if (Calendar1.Visible)
                {
                    Calendar1.Visible = false;
                }
                else
                {
                    Calendar1.Visible = true;
                }
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                shipDate.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            }
            (sender as Calendar).Visible = false;
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView2.SelectedRow;
                string s = ((Label)gridViewRow.FindControl("guestID")).Text;
                guestID.Text = s;
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (this.IsPostBack)
                {
                    status = 1;
                    footerReset();
                    ((Button)GridView1.FooterRow.FindControl("otherButton")).Text = "其他";
                    GridViewRow gridViewRow = GridView3.SelectedRow;
                    string s = ((Label)gridViewRow.FindControl("orderID")).Text;
                    ((TextBox)GridView1.FooterRow.FindControl("orderIDBox")).Text = s;
                    s = ((Label)gridViewRow.FindControl("ser")).Text;
                    ((TextBox)GridView1.FooterRow.FindControl("SERIALNUMBERBox")).Text = s;
                    this.SERIALNUMBERBox_TextChanged(null, null);
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GridView3.Visible = false;
                Button5.Visible = false;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                GridView3.Visible = true;
                GridView3.DataBind();
                Button5.Visible = true;
            }
        }

        protected void productIDLabel_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Button b = (Button)sender;
                if (b.Text == "其他")
                {
                    status = 2;
                    footerOtherMode();
                    b.Text = "返回";
                }
                else
                {
                    status = 1;
                    footerReset();
                    b.Text = "其他";
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                LinkButton linkButton = (LinkButton)sender;
                int index = (linkButton.NamingContainer as GridViewRow).RowIndex;
                ReceiptDetailAccessLayer.details.RemoveAt(index);
                GridView1.DataBind();
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TextBox t = (TextBox)sender;
                int index = (t.NamingContainer as GridViewRow).RowIndex;
                ReceiptDetailAccessLayer.details[index].other = t.Text;
                GridView1.DataBind();
            }
        }

        protected void Label222_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TextBox t = (TextBox)sender;
                int index = (t.NamingContainer as GridViewRow).RowIndex;
                ReceiptDetailAccessLayer.details[index].outofstock = t.Text;
                GridView1.DataBind();
            }
        }

        protected void Label18_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TextBox t = (TextBox)sender;
                int index = (t.NamingContainer as GridViewRow).RowIndex;
                ReceiptDetailAccessLayer.details[index].shippedDate = t.Text;
                GridView1.DataBind();
            }
        }

        protected void Label17_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                TextBox t = (TextBox)sender;
                int index = (t.NamingContainer as GridViewRow).RowIndex;
                ReceiptDetailAccessLayer.details[index].shipped = t.Text;
                GridView1.DataBind();
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            int index = (((ImageButton)sender).NamingContainer as GridViewRow).RowIndex;
            if(GridView1.Rows[index].FindControl("Calendar2").Visible==false)
            {
                GridView1.Rows[index].FindControl("Calendar2").Visible = true;
            }
            else
            {
                GridView1.Rows[index].FindControl("Calendar2").Visible = false;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            int index = (((Calendar)sender).NamingContainer as GridViewRow).RowIndex;
            (GridView1.Rows[index].FindControl("Label18") as TextBox).Text=(sender as Calendar).SelectedDate.ToString("yyyy/MM/dd");
            (sender as Calendar).Visible = false;
        }

        protected void footerImageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView1.FooterRow.FindControl("footerCalendar").Visible == false)
            {
                GridView1.FooterRow.FindControl("footerCalendar").Visible = true;
            }
            else
            {
                GridView1.FooterRow.FindControl("footerCalendar").Visible = false;
            }
        }

        protected void footerCalendar_SelectionChanged(object sender, EventArgs e)
        {
            (GridView1.FooterRow.FindControl("shippedDateBox") as TextBox).Text = (sender as Calendar).SelectedDate.ToString("yyyy/MM/dd");
            (sender as Calendar).Visible = false;
        }
    }
}