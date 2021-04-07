using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database.Page
{
    public class QueryTag
    {
        public int id { get; set; }
        public string text { get; set; }
    }
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string getResults(string n)
        {
            return "[{ \"id\": \"1\", \"text\": \"test\" }]";
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string t = (sender as TextBox).Text;
            DropDownList dropDownList = GridView1.Controls[0].Controls[0].FindControl("DropDownList2") as DropDownList;
            if(t=="1")
            {
                dropDownList.Items.Clear();
                dropDownList.Items.Add("AAA");
                dropDownList.Items.Add("BBB");
                dropDownList.Items.Add("CCC");

            }
            else
            {
                dropDownList.Items.Clear();
                dropDownList.Items.Add("111");


            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_DataBound(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
/*
 *xZxhKxj
 *zxczxc
 *xczxc
 *bcvbfdg
 *nbvjg
 *hjghj
 *dfghdfgdg
 *xsdfs
 *vccgf
 */