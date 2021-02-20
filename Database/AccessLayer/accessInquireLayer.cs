using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Database
{
    public class accessInquireLayse
    {
        public static string str =
            "SELECT distinct orderdetail.訂單編號,orderdetail.流水號,data.order.客戶編號,data.order.訂單日期,orderdetail.品番,orderdetail.商品類別,orderdetail.上代,orderdetail.納期,orderdetail.色番,orderdetail.ｶﾗｰ,orderdetail.ｻｲｽﾞ,orderdetail.訂貨数量,orderdetail.品牌,orderdetail.出貨數量,orderdetail.未出數量,orderdetail.建檔人,orderdetail.建檔日,orderdetail.結單,orderdetail.缺貨,orderdetail.備註 " +
            "FROM  data.order " +
            "right join data.orderdetail "+
            "on data.orderdetail.訂單編號 = data.order.訂單編號 "+
            "left join data.recieptdetail "+
            "on recieptdetail.訂單編號= orderdetail.訂單編號 And recieptdetail.流水號 = orderdetail.流水號 "+
            "left join data.receipt "+
            "on receipt.receiptID = recieptdetail.收貨編號 ";

        public static string cond = "where 1=1 ";
        public DataSet getInquireData()
        {
            DataSet dataSet;
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            dataSet = sqlConn.SelectCommand(str + cond );
            return dataSet;
        }
    }
}