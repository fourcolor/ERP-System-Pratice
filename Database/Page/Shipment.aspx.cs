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
using iTextSharp.text;
using StringReader = System.IO.StringReader;
using StringWriter = System.IO.StringWriter;

namespace Database
{
    /*
     * public class BorderEvent implements PdfPTableEvent {
        public void tableLayout(PdfPTable table, float[][] widths, float[] heights, int headerRows, int rowStart, PdfContentByte[] canvases) {
            float width[] = widths[0];
            float x1 = width[0];
            float x2 = width[width.length - 1];
            float y1 = heights[0];
            float y2 = heights[heights.length - 1];
            PdfContentByte cb = canvases[PdfPTable.LINECANVAS];
            cb.rectangle(x1, y1, x2 - x1, y2 - y1);
            cb.stroke();
        }
    }
     */
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
            shipmentAccessLayer.shipments.Clear();
            shipmentAccessLayer.unshipments.Clear();
            if (!Foolproof.GuestFoolproof(guestID.Text))
            {
                Response.Write("<script>alert('客戶ID錯誤');</script>");
            }
            else if (!Foolproof.DateFoolproof(shippedDate.Text))
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
            int inum = 0, jnum = 0;
            foreach (GridViewRow i in GridView1.Rows)
            {
                GridView gridView = i.FindControl("GridView2") as GridView;
                jnum = 0;
                foreach (GridViewRow j in gridView.Rows)
                {
                    CheckBox checkBox = j.FindControl("CheckBox1") as CheckBox;
                    if (!checkBox.Checked)
                    {
                        j.FindControl("tpriceLabel").Visible = false;
                        j.FindControl("tpriceLabelempty").Visible = true;
                        shipmentAccessLayer.shipments[inum].content[jnum].showtprice = false;
                    }
                    else
                    {
                        j.FindControl("tpriceLabel").Visible = true;
                        j.FindControl("tpriceLabelempty").Visible = false;
                        shipmentAccessLayer.shipments[inum].content[jnum].showtprice = true;
                    }
                    jnum++;
                }
                inum++;
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
            shipmentAccessLayer.shipments.Clear();
            shipmentAccessLayer.unshipments.Clear();
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
            shipmentAccessLayer.shipments.Clear();
            shipmentAccessLayer.unshipments.Clear();
            shippedDate.Text = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            int inum = 0,jnum = 0;
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
                        shipmentAccessLayer.shipments[inum].content[jnum].showremark = false;
                    }
                    else
                    {
                        j.FindControl("remarkLabel").Visible = true;
                        j.FindControl("remarkLabelempty").Visible = false;
                        shipmentAccessLayer.shipments[inum].content[jnum].showremark = true;
                    }
                    jnum++;
                }
                inum++;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] head = { "品牌", "貨號", "'商品類別", "上代稅", "色番", "顏色", "尺寸", "數量", "金額", "備註" };
                Document document = new Document(PageSize.A4, 50, 50, 80, 50);
                MemoryStream memory = new MemoryStream();
                PdfWriter pdfWriter = PdfWriter.GetInstance(document, memory);
                BaseFont baseFont = BaseFont.CreateFont(@"C:\WINDOWS\Fonts\kaiu.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font font = new Font(baseFont, 12);
                document.Open();
                PdfPTable table1 = new PdfPTable(new float[] { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                table1.TotalWidth = 500f;
                table1.LockedWidth = true;
                PdfPTable table2 = new PdfPTable(new float[] { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
                table2.TotalWidth = 500f;
                table2.LockedWidth = true;
                document.Add(new Paragraph(12f, "已出貨", font));
                foreach (var i in head)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(i, font));
                    table1.AddCell(cell);
                }
                foreach (var i in shipmentAccessLayer.shipments)
                {
                    if (i.brand != "")
                    {
                        int h = i.content.Count;
                        PdfPCell pdfP = new PdfPCell(new Phrase(i.brand, font));
                        pdfP.Colspan = 1;
                        pdfP.Rowspan = h;
                        table1.AddCell(pdfP);
                    }
                    else
                    {
                        int h = i.content.Count;
                        PdfPCell pdfP = new PdfPCell(new Phrase(i.other, font));
                        pdfP.Colspan = 1;
                        pdfP.Rowspan = h;
                        table1.AddCell(pdfP);
                    }
                    foreach (var j in i.content)
                    {
                        PdfPCell pCell = new PdfPCell(new Phrase(j.productID, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.producttype, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.jprice, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.colornum, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.color, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.size, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.amount, font));
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        if(j.showtprice)
                        {
                            pCell = new PdfPCell(new Phrase(j.tprice, font));
                        }
                        else
                        {
                            pCell = new PdfPCell(new Phrase("", font));
                        }
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        if (j.showremark)
                        {
                            pCell = new PdfPCell(new Phrase(j.remark, font));
                        }
                        else
                        {
                            pCell = new PdfPCell(new Phrase("", font));
                        }
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                    }
                }
                document.Add(new Paragraph(12f, "未出貨", font));
                foreach (var i in head)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(i, font));
                    table1.AddCell(cell);
                }
                foreach (var i in shipmentAccessLayer.unshipments)
                {
                    if (i.brand != "")
                    {
                        int h = i.content.Count;
                        PdfPCell pdfP = new PdfPCell(new Phrase(i.brand, font));
                        pdfP.Colspan = 1;
                        pdfP.Rowspan = h;
                        table2.AddCell(pdfP);
                    }
                    else
                    {
                        int h = i.content.Count;
                        PdfPCell pdfP = new PdfPCell(new Phrase(i.other, font));
                        pdfP.Colspan = 1;
                        pdfP.Rowspan = h;
                        table2.AddCell(pdfP);
                    }
                    foreach (var j in i.content)
                    {
                        PdfPCell pCell = new PdfPCell(new Phrase(j.productID, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.producttype, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.jprice, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.colornum, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.color, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.size, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        pCell = new PdfPCell(new Phrase(j.amount, font));
                        pCell.Colspan = 1;
                        table2.AddCell(pCell);
                        if (j.showtprice)
                        {
                            pCell = new PdfPCell(new Phrase(j.tprice, font));
                        }
                        else
                        {
                            pCell = new PdfPCell(new Phrase("", font));
                        }
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                        if (j.showremark)
                        {
                            pCell = new PdfPCell(new Phrase(j.remark, font));
                        }
                        else
                        {
                            pCell = new PdfPCell(new Phrase("", font));
                        }
                        pCell.Colspan = 1;
                        table1.AddCell(pCell);
                    }
                }
                document.Add(table1);
                document.Add(table2);
                document.Close();
                Response.Clear();
                Response.AddHeader("Content-Dispostition", "attachment;filename=pdfExample.pdf");
                Response.ContentType = "application/pdf";
                Response.OutputStream.Write(memory.GetBuffer(), 0, memory.GetBuffer().Length);
                Response.OutputStream.Flush();
                Response.OutputStream.Close();
                Response.Flush();
                Response.End();
            }
            catch
            {

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //處理'GridView' 的控制項 'GridView' 必須置於有 runat=server 的表單標記之中
        }

    } 
}