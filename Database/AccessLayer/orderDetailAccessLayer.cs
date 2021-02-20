using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace Database
{
    public class orderDetail
    {
        public int orderID { get; set; }
        public int SERIALNUMBER { get; set; }
        public int productID { get; set; }
        public string productType { get; set; }
        public double price { get; set; }
        public string DeliveryDate { get; set; }
        public int colorNum { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public int amount { get; set; }
        public string brand { get; set; }
        public int shipment { get; set; }
        public int unshipment { get; set; }
        public string fileMaker { get; set; }
        public string fileDate { get; set; }
        public string statment { get; set; }
        public string outofstock { get; set; }
        public string remark { get; set; }
    }


    public class orderDetailAccessLayer
    {

        public static string str="SELECT * FROM data.orderdetail ";
        public static string cond = "where 1=1;";


        public List<orderDetail> getAllorderDetail()
        {
            List<orderDetail> orders = new List<orderDetail>();
            sqlConn sqlConn=new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            MySqlCommand cmd = new MySqlCommand(str+cond, sqlConn.conn);
            sqlConn.conn.Open();
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                orderDetail orderDetail = new orderDetail();
                orderDetail.orderID = Convert.ToInt32(dataReader["訂單編號"]);
                orderDetail.DeliveryDate = dataReader["納期"].ToString();
                orderDetail.price = Convert.ToDouble(dataReader["上代"]);
                orderDetail.productID = Convert.ToInt32(dataReader["品番"]);
                orderDetail.size = dataReader["ｻｲｽﾞ"].ToString();
                orderDetail.color = dataReader["ｶﾗｰ"].ToString();
                orderDetail.SERIALNUMBER = Convert.ToInt32(dataReader["流水號"]);
                orderDetail.amount = Convert.ToInt32(dataReader["訂貨数量"]);
                orderDetail.shipment = Convert.ToInt32(dataReader["出貨數量"]);
                orderDetail.unshipment = Convert.ToInt32(dataReader["未出數量"]);
                orderDetail.productType = dataReader["商品類別"].ToString();
                orderDetail.fileMaker = dataReader["建檔人"].ToString();
                orderDetail.fileDate = dataReader["建檔日"].ToString();
                orderDetail.brand = dataReader["品牌"].ToString();
                orderDetail.colorNum = Convert.ToInt32(dataReader["色番"]);
                orderDetail.statment = dataReader["結單"].ToString();
                orderDetail.outofstock = dataReader["缺貨"].ToString();
                orderDetail.remark = dataReader["備註"].ToString();
                orders.Add(orderDetail);
            }
            sqlConn.conn.Close();
            return orders;
        }
        public static void DeleteOrderDetail(int orderID, int SERIALNUMBER)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            MySqlCommand cmd = new MySqlCommand("Delete from data.orderdetail where 流水號 = @SERIALNUMBER AND 訂單編號 = @orderID", sqlConn.conn);
            MySqlParameter[] param = new MySqlParameter[]{new MySqlParameter("@SERIALNUMBER", SERIALNUMBER),new MySqlParameter("@orderID", orderID) };
            foreach (var i in param)
            {
                cmd.Parameters.Add(i);
            }
            sqlConn.conn.Open();
            cmd.ExecuteNonQuery();
            sqlConn.conn.Close();
        }
        public static void UpdateOrderDetail(int orderID,int SERIALNUMBER, int productID, string productType, double price, string DeliveryDate, int colorNum, string show1, string color, string show2, string size, int amount, string brand, int shipment, int unshipment, string fileMaker, string fileDate,string statment,string outofstock, string remark)
        {
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            MySqlCommand cmd = new MySqlCommand(
                "Update data.orderdetail set " +
                "品番=@productID," +
                "商品類別=@productType," +
                "上代=@price," +
                "納期=@DeliveryDate," +
                "色番=@colornum," +
                "ｶﾗｰ=@color," +
                "ｻｲｽﾞ=@size," +
                "訂貨数量=@amount," +
                "品牌=@brand," +
                "出貨數量=@shipment," +
                "未出數量=@unshipment," +
                "建檔人=@fileMaker," +
                "建檔日=@fileDate," +
                "結單=@statment," +
                "缺貨=@outofstock," +
                "備註=@remark" +
                " where 流水號 = @SERIALNUMBER AND 訂單編號 = @orderID", sqlConn.conn);
            MySqlParameter[] mySqlParameters = new MySqlParameter[] {
                new MySqlParameter("@orderID",orderID),
                new MySqlParameter("@productID",productID),
                new MySqlParameter("@productType",productType),
                new MySqlParameter("@price",price),
                new MySqlParameter("@DeliveryDate",DeliveryDate),
                new MySqlParameter("@colornum",colorNum),
                new MySqlParameter("@color",color),
                new MySqlParameter("@size",size),
                new MySqlParameter("@amount",amount),
                new MySqlParameter("@brand",brand),
                new MySqlParameter("@shipment",shipment),
                new MySqlParameter("@unshipment",unshipment),
                new MySqlParameter("@fileMaker",fileMaker),
                new MySqlParameter("@fileDate",fileDate),
                new MySqlParameter("@remark",remark),
                new MySqlParameter("@SERIALNUMBER",SERIALNUMBER),
                new MySqlParameter("@statment",statment),
                new MySqlParameter("@outofstock",outofstock)
            };
            foreach(var i in mySqlParameters)
            {
                cmd.Parameters.Add(i);
            }
            sqlConn.conn.Open();
            cmd.ExecuteNonQuery();
            sqlConn.conn.Close();
        }
    }
}