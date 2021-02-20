using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace Database
{
    public class order
    {
        public int orderID  { get; set; }
        public int guestID { get; set; }
        public string Date { get; set; }
        static DataTable dataTable = new DataTable();
        public static DataTable insert()
        {
            dataTable.Columns.Add("訂單編號");
            dataTable.Columns.Add("客戶編號");
            dataTable.Columns.Add("訂單日期");
            DataRow dr = dataTable.NewRow();
            dr[0] = "1";
            dr[1] = "2";
            dr[2] = "3";
            dataTable.Rows.Add(dr);
            return dataTable;
        }
    }
    public class orderAccessLayer
    {
        public static string str = "SELECT* FROM data.order ";
        public static string cond = "where 1=1 ";
        public List<order> GetAllorder()
        {
            List<order> orders = new List<order>();
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            MySqlCommand cmd = new MySqlCommand(str + cond, sqlConn.conn);
            sqlConn.conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                order order = new order();

                order.orderID = Convert.ToInt32(dataReader["訂單編號"]);
                order.guestID = Convert.ToInt32(dataReader["客戶編號"].ToString());
                order.Date = dataReader["訂單日期"].ToString();
                orders.Add(order);
            }
            sqlConn.conn.Close();
            return orders;
        }

        public DataSet getvalorder(string guestID)
        {
            int i;
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            string cmd;
            if (int.TryParse(guestID, out i))
            {
                cmd =
                "select orderdetail.訂單編號,orderdetail.流水號 " +
                "from data.orderdetail " +
                "inner join data.order " +
                "on data.order.訂單編號 = orderdetail.訂單編號 " +
                "where data.order.客戶編號 = " + guestID + " and orderdetail.結單 = 'N';";
            }
            else
            {
                cmd =
                "select orderdetail.訂單編號,orderdetail.流水號 " +
                "from data.orderdetail " +
                "inner join data.order " +
                "on data.order.訂單編號 = orderdetail.訂單編號 " +
                "where orderdetail.結單 = 'N';";
            }
            DataSet dataSet = sqlConn.SelectCommand(cmd);
            return dataSet;
        }
    }
}