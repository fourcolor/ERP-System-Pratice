using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database
{
    public partial class inquireOrder : System.Web.UI.Page
    {
        List<CheckBox> checkBoxes = new List<CheckBox>();
        static int status = 0;

        string[] cond = new string[8];
        protected void Page_Load(object sender, EventArgs e)
        {
            checkBoxes.Add(CheckBox1);
            checkBoxes.Add(CheckBox2);
            checkBoxes.Add(CheckBox3);
            checkBoxes.Add(CheckBox4);
            checkBoxes.Add(CheckBox5);
            checkBoxes.Add(CheckBox6);
            checkBoxes.Add(CheckBox7);
            checkBoxes.Add(CheckBox8);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            accessInquireLayse.cond = "where 1=1 ";
            if (CheckBox1.Checked)
            {
                try
                {
                    CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP"); //日期文化格式
                    DateTime d = DateTime.ParseExact(TextBox1.Text, "yyyy/MM/dd", CultureInfoDateCulture);
                    cond[0] = " and data.order.訂單日期 = '" + TextBox1.Text + "'";
                }
                catch
                {
                    Response.Write("<script>alert('日期格式為yyyy/MM/dd');</script>");
                }
            }
            else
            {
                cond[0] = "";
            }
            if (CheckBox2.Checked)
            {
                cond[1] = " and data.order.客戶編號 = " + TextBox2.Text;
            }
            else
            {
                cond[1] = "";
            }
            if (CheckBox3.Checked)
            {
                cond[2] = " and orderdetail.品牌 = '" + TextBox3.Text + "'";
            }
            else
            {
                cond[2] = "";
            }
            if (CheckBox4.Checked)
            {
                cond[3] = " and orderdetail.品牌 = " + TextBox4.Text;
            }
            else
            {
                cond[3] = "";
            }
            if (CheckBox5.Checked)
            {
                cond[4] = " and orderdetail.商品類別 = '" + TextBox5.Text + "'";
            }
            else
            {
                cond[4] = "";
            }
            if (CheckBox6.Checked)
            {
                try
                {
                    CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP"); //日期文化格式
                    DateTime d;
                    d = DateTime.ParseExact(TextBox6.Text, "yyyy/MM/dd", CultureInfoDateCulture);
                    cond[5] = " and recieptdetail.出貨日 = '" + TextBox6.Text + "'";
                }
                catch
                {
                    Response.Write("<script>alert('日期格式為yyyy/MM/dd');</script>");
                }
            }
            else
            {
                cond[5] = "";
            }
            if (CheckBox7.Checked)
            {
                try
                {
                    CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP"); //日期文化格式
                    DateTime d;
                    d = DateTime.ParseExact(TextBox7.Text, "yyyy/MM/dd", CultureInfoDateCulture);
                    cond[6] = " and receipt.收貨日 = '" + TextBox7.Text + "'";
                }
                catch
                {
                    Response.Write("<script>alert('日期格式為yyyy/MM/dd');</script>");
                }
            }
            else
            {
                cond[6] = "";
            }
            if (CheckBox8.Checked)
            {
                if (TextBox8.Text != "N" && TextBox8.Text != "Y" && TextBox8.Text != "n" && TextBox8.Text != "y")
                {
                    Response.Write("<script>alert('結單只能為Y或N');</script>");
                }
                else
                {
                    if (TextBox8.Text == "n")
                    {
                        TextBox8.Text = "N";
                    }
                    if (TextBox8.Text == "y")
                    {
                        TextBox8.Text = "Y";
                    }
                    cond[7] = " and orderdetail.結單 = '" + TextBox8.Text + "'";
                }
            }
            else
            {
                cond[7] = "";
            }
            foreach (var i in cond)
            {
                accessInquireLayse.cond += i;
            }
            GridView1.DataBind();
            GridView1_SelectedIndexChanged(null, null);
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            GridView3.Visible = false;
            if (Calendar1.Visible == false || status !=1)
            {
                Calendar1.Visible = true;
                status = 1;
            }
            else
            {
                Calendar1.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string s = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            switch (status)
            {
                case 1:
                    TextBox1.Text = s;
                    break;
                case 2:
                    TextBox6.Text = s;
                    break;
                case 3:
                    TextBox7.Text = s;
                    break;
            }
        }

        protected void guestButton_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = false;
            if (GridView3.Visible == false)
            {
                GridView3.Visible = true;
            }
            else
            {
                GridView3.Visible = false;
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.IsPostBack)
                {
                    GridViewRow gridViewRow = GridView3.SelectedRow;
                    string s = ((Label)gridViewRow.FindControl("guestID")).Text;
                    TextBox2.Text = s;
                }
            }
            catch
            {

            }
        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.Visible = false;
            if (Calendar1.Visible == false || status!=2)
            {
                Calendar1.Visible = true;
                status = 2;
            }
            else
            {
                Calendar1.Visible = false;
            }
        }

        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            GridView2.Visible = false;
            if (Calendar1.Visible == false || status != 3)
            {
                Calendar1.Visible = true;
                status = 3;
            }
            else
            {
                Calendar1.Visible = false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ReceiptDetailAccessLayer.inorderID = GridView1.SelectedRow.Cells[1].Text;
                ReceiptDetailAccessLayer.inSERIALNUMBER = GridView1.SelectedRow.Cells[2].Text;
                GridView2.DataBind();
            }
            catch
            {
                ReceiptDetailAccessLayer.inorderID = "無";
                ReceiptDetailAccessLayer.inSERIALNUMBER = "無";
                GridView2.DataBind();
            }
        }
    }
}