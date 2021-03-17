using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Database
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            if(TextBox1.Text!=""||TextBox1.Text!=null)
            {
                sqlConn.Command("INSERT INTO `data`.`guest` (`guestName`) VALUES('"+ TextBox1.Text+ "');");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            if (TextBox2.Text != "" || TextBox2.Text != null)
            {
                sqlConn.Command("INSERT INTO `data`.`producttype` (`productType`) VALUES ('"+ TextBox2.Text+"');");
            }
        }
    }
}