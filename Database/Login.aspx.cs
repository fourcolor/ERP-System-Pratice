using Database;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int count;
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            MySqlCommand cmd = new MySqlCommand("SELECT Count(1) FROM data.useraddress where userName=@user and passward=@password;", sqlConn.conn);
            MySqlParameter[] mySqlParameters = new MySqlParameter[] 
            {
                new MySqlParameter("@user",txtAccount.Text),
                new MySqlParameter("@password",txtPassword.Text) 
            };
            foreach (var i in mySqlParameters)
            {
                cmd.Parameters.Add(i);
            }
            sqlConn.conn.Open();
            count = Convert.ToInt32(cmd.ExecuteScalar());
            sqlConn.conn.Close();
            if (count > 0)
            {
                HttpCookie cookie = new HttpCookie(txtAccount.Text);
                Response.Cookies.Add(cookie);
                FormsAuthentication.RedirectFromLoginPage(txtAccount.Text, chkRememberMe.Checked);

            }
            else
            {

            }
        }
    }
}