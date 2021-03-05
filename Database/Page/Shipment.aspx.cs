using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.html;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Database
{
    public partial class Shipment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //find the nested grid in the current row with findcontrol
                GridView gridView = e.Row.FindControl("GridView2") as GridView;

                //check if it is the first nested gridview and show/hide the header
                if (e.Row.RowIndex == 0)
                {
                    gridView.ShowHeader = true;
                }
                else
                {
                    gridView.ShowHeader = false;
                }
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if(!Foolproof.GuestFoolproof(guestID.Text))
            {
                Response.Write("<script>alert('客戶ID錯誤');</script>");
            }
            else if(!Foolproof.DateFoolproof(shippedDate.Text))
            {
                Response.Write("<script>alert('日期錯誤');</script>");
            }
            else
            {
                GridView1.DataBind();
                GridView2.DataBind();
            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach(GridViewRow i in GridView1.Rows)
            {
                GridView gridView = i.FindControl("GridView2") as GridView;
                foreach(GridViewRow j in gridView.Rows)
                {
                    CheckBox checkBox = j.FindControl("CheckBox1") as CheckBox;
                    if (!checkBox.Checked)
                    {
                        j.FindControl("tpriceLabel").Visible = false;
                        j.FindControl("tpriceLabelempty").Visible = true;
                    }
                    else
                    {
                        j.FindControl("tpriceLabel").Visible = true;
                        j.FindControl("tpriceLabelempty").Visible = false;
                    }
                }
            }
        }

        protected void findguest(object sender, ImageClickEventArgs e)
        {
            Calendar1.Visible = false;
            if (GridView5.Visible == true)
            {
                GridView5.Visible = false;
            }
            else
            {
                GridView5.Visible = true;
            }
        }

        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                GridViewRow gridViewRow = GridView5.SelectedRow;
                string s = ((Label)gridViewRow.FindControl("guestID")).Text;
                guestID.Text = s;
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            GridView5.Visible = false;
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
            shippedDate.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow i in GridView1.Rows)
            {
                GridView gridView = i.FindControl("GridView2") as GridView;
                foreach (GridViewRow j in gridView.Rows)
                {
                    CheckBox checkBox = j.FindControl("CheckBox1") as CheckBox;
                    if (!checkBox.Checked)
                    {
                        j.FindControl("remarkLabel").Visible = false;
                        j.FindControl("remarkLabelempty").Visible = true;
                    }
                    else
                    {
                        j.FindControl("remarkLabel").Visible = true;
                        j.FindControl("remarkLabelempty").Visible = false;
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string FilePath = MapPath("~/File/MyReport.pdf");

            iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20f, 20f, 20f, 20f);
            PdfWriter.GetInstance(pdfDoc, new FileStream(FilePath, FileMode.Create));
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.AllowPaging = false;
            GridView1.HeaderRow.Cells[1].Text = "Message";
            GridView1.HeaderRow.Font.Bold = true;
            GridView1.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();

            Response.Write(pdfDoc);

            Response.ContentType = "Application/pdf";
            Response.WriteFile(FilePath);
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
        }
    }
}