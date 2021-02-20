using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database
{
    public partial class editReceipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView1.SelectedRow;
                string s = gridViewRow.Cells[1].Text;
                ReceiptDetailAccessLayer.cond = " where recieptdetail.收貨編號 = " + gridViewRow.Cells[1].Text + ";";
                ObjectDataSource2.DataBind();
                GridView2.DataBind();
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
                guestID.Text = s;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            recieptDate.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }
    }
}