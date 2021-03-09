using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Database
{
    public class ReceiptDetail
    {
        public int receiptID { get; set; }
        public int receiptSERIALNUMBER { get; set; }
        public string orderID { get; set; }
        public string SERIALNUMBER { get; set; }
        public string productID { get; set; }
        public string productType { get; set; }
        public string jprice { get; set; }
        public string DeliveryDate { get; set; }
        public string colorNum { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string amount { get; set; }
        public string exchangeRate { get; set; }
        public string brand { get; set; }
        public string shipment { get; set; }
        public string unshipment { get; set; }
        public string shipped { get; set; }
        public string shippedDate { get; set; }
        public string tprice { get; set; }
        public string outofstock { get; set; }
        public string other { get; set; }
        public string remark { get; set; }
    }

    public class ReceiptDetailAccessLayer
    {
        public static List<ReceiptDetail> details = new List<ReceiptDetail>();
        public static string str = "SELECT recieptdetail.其他,recieptdetail.收貨編號,recieptdetail.收貨流,recieptdetail.訂單編號,recieptdetail.流水號,orderdetail.品番,商品類別,orderdetail.上代,orderdetail.納期,orderdetail.色番,orderdetail.ｶﾗｰ,orderdetail.ｻｲｽﾞ,orderdetail.訂貨数量,recieptdetail.匯率,orderdetail.品牌,recieptdetail.出貨數量,orderdetail.未出數量,recieptdetail.實收數量,recieptdetail.出貨日,recieptdetail.小計,recieptdetail.未出數量,recieptdetail.備註,orderdetail.缺貨 " +
            "FROM data.orderdetail right join data.recieptdetail on recieptdetail.訂單編號= orderdetail.訂單編號 And recieptdetail.流水號 = orderdetail.流水號";
        public static string cond = " where 1=1;";
        public static List<ReceiptDetail> getInsertReceiptDetail()
        {
            if (details.Count == 0)
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
                detail.exchangeRate = "";
                detail.brand = "";
                detail.shipment = "";
                detail.unshipment = "";
                detail.shipped = "";
                detail.shippedDate = "";
                detail.tprice = "";
                detail.other = "";
                detail.remark = "";
                detail.outofstock = "";
                details.Add(detail);
            }
            return details;
        }

        
        public static List<ReceiptDetail> getReceiptDetail()
        {
            List<ReceiptDetail> Receipts = new List<ReceiptDetail>();
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            DataSet dataSet = sqlConn.SelectCommand(str + cond);
            foreach(DataRow i in dataSet.Tables[0].Rows)
            {
                ReceiptDetail detail = new ReceiptDetail();
                detail.receiptID = Convert.ToInt32(i["收貨編號"]);
                detail.receiptSERIALNUMBER = Convert.ToInt32(i["收貨流"]);
                detail.orderID = i["訂單編號"].ToString();
                detail.SERIALNUMBER = i["流水號"].ToString();
                detail.productID = i["品番"].ToString();
                if (detail.productID == "" || detail.productID == null)
                {
                    detail.other = i["其他"].ToString();
                }
                else
                {
                    detail.productType = i["商品類別"].ToString();
                    detail.jprice = i["上代"].ToString();
                    detail.DeliveryDate = i["納期"].ToString();
                    detail.colorNum = i["色番"].ToString();
                    detail.color = i["ｶﾗｰ"].ToString();
                    detail.size = i["ｻｲｽﾞ"].ToString();
                    detail.amount = i["訂貨数量"].ToString();
                    detail.exchangeRate = i["匯率"].ToString();
                    detail.brand = i["品牌"].ToString();
                    detail.shipment = i["出貨數量"].ToString();
                    detail.unshipment = i["未出數量"].ToString();
                    detail.shipped = i["實收數量"].ToString();
                    detail.outofstock = i["缺貨"].ToString();
                }
                detail.shippedDate = i["出貨日"].ToString();
                detail.tprice = i["小計"].ToString();
                detail.remark = i["備註"].ToString();
                Receipts.Add(detail);
            }
            return Receipts;
        }
        public static void deleteinsertRecieptDetail(string orderID ,string SERIALNUMBER)
        {
            foreach(var i in details)
            {
                if (i.orderID == orderID && i.SERIALNUMBER == SERIALNUMBER) 
                {
                    details.Remove(i);
                    break;
                }
            }
        }

        public static string inorderID = "";
        public static string inSERIALNUMBER = "";
        public static DataSet getinquire()
        {
            sqlConn sqlConn =new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            DataSet dataSet;
            if (inorderID != "" && inorderID != null && inSERIALNUMBER != "" && inSERIALNUMBER != null)
            {
                dataSet = sqlConn.SelectCommand("SELECT * FROM data.recieptdetail where 訂單編號 = '" + inorderID + "' and 流水號 ='" + inSERIALNUMBER + "';");
            }
            else
            {
                dataSet = sqlConn.SelectCommand("SELECT * FROM data.recieptdetail where 訂單編號 = '" + inorderID + "' and 流水號 ='" + inSERIALNUMBER + "';");
            }
            return dataSet;
        }

        public static string inquire2cond = "where 1=1";
        public static DataSet getinquire2()
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            DataSet dataSet;
            dataSet = sqlConn.SelectCommand("SELECT * FROM data.recieptdetail left join data.receipt on receipt.receiptID = recieptdetail.收貨編號 " + inquire2cond + ";");
            return dataSet;
        }
        public static void deleteRecieptDetail(string receiptID, string receiptSERIALNUMBER, string orderID, string SERIALNUMBER, string jprice, string amount)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            string cmd = "SELECT 未出數量 FROM data.orderdetail where 訂單編號 =" + orderID + " and 流水號 = " + SERIALNUMBER + ";";
            DataSet dataSet = sqlConn.SelectCommand(cmd);

            int total = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            cmd = "DELETE FROM `data`.`recieptdetail` WHERE(`收貨編號` =  @receiptID ) and(`收貨流` = @receiptSERIALNUMBER );";
            MySqlParameter[] param = new MySqlParameter[] { new MySqlParameter("@receiptSERIALNUMBER", receiptSERIALNUMBER), new MySqlParameter("@receiptID", receiptID) };
            MySqlCommand mcmd = new MySqlCommand(cmd, sqlConn.conn);
            foreach (var i in param)
            {
                mcmd.Parameters.Add(i);
            }
            sqlConn.conn.Open();
            mcmd.ExecuteNonQuery();
            sqlConn.conn.Close();
        }

        public static void updateRecieptDetail(string receiptID, string receiptSERIALNUMBER, string orderID, string SERIALNUMBER, string jprice, string amount, string exchangeRate, string shipment, string shipped, string shippedDate,string other,string outofstock, string remark)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            string cmd = "SELECT 未出數量 FROM data.orderdetail where 訂單編號 =" + orderID + " and 流水號 = " + SERIALNUMBER + ";";
            DataSet dataSet = sqlConn.SelectCommand(cmd);
            cmd = "SELECT 出貨數量 FROM data.recieptdetail where 收貨編號 = " + receiptID + " AND 收貨流 = " + receiptSERIALNUMBER + ";";
            int total = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            dataSet = sqlConn.SelectCommand(cmd);
            total+=Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            int unshipment;
            double tprice;
            if (total>= Convert.ToInt32(shipment))
            {
                unshipment = Convert.ToInt32(total) - Convert.ToInt32(shipment);
                tprice = Convert.ToDouble(shipment) * Convert.ToDouble(exchangeRate) * Convert.ToDouble(jprice);

                cmd = "Update data.recieptdetail set 匯率=" + exchangeRate + ",出貨數量=" + shipment + ",出貨日='" + shippedDate + "',實收數量=" + shipped + ",備註='" + remark + "',小計=" + tprice + ",其他='"+other+"' where 收貨編號 = " + receiptID + " AND 收貨流 = " + receiptSERIALNUMBER + ";";
                sqlConn.Command(cmd);
                cmd = "Update data.orderdetail set 出貨數量=" + (Convert.ToInt32(amount) - Convert.ToInt32(unshipment)) + ",未出數量=" + unshipment + " where 流水號 = " + SERIALNUMBER + " AND 訂單編號 = " + orderID + ";";
                sqlConn.Command(cmd);
            }
            if(outofstock=="Y")
            {
                cmd = "Update data.orderdetail set 結單='Y',缺貨='Y' where 流水號 = " + SERIALNUMBER + " AND 訂單編號 = " + orderID + ";";
            }
        }
    }
}