using Database.AccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Database
{
    public class shipmentAccessLayer
    {
        public static string shipmentStr = "" +
            "SELECT orderdetail.品牌,recieptdetail.其他 " +
            "FROM data.orderdetail " +
            "right join data.recieptdetail " +
            "on recieptdetail.訂單編號= orderdetail.訂單編號 And recieptdetail.流水號 = orderdetail.流水號 " +
            "inner join data.receipt " +
            "on receipt.receiptID = recieptdetail.收貨編號 " +
            "inner join data.order " +
            "on data.order.訂單編號= orderdetail.訂單編號";
        public static string shipmentCond = "where 1=1 ";
        public static string shipmentGroup = "group by 品牌";
        public static string shipmentdetailStr =
            "SELECT orderdetail.品番,orderdetail.商品類別,orderdetail.上代,orderdetail.色番,recieptdetail.其他,orderdetail.ｶﾗｰ,orderdetail.未出數量,orderdetail.ｻｲｽﾞ,orderdetail.訂貨数量,recieptdetail.匯率,orderdetail.品牌,sum(recieptdetail.實收數量) as 數量,sum(recieptdetail.小計) as 金額,recieptdetail.匯率,recieptdetail.備註 " +
            "FROM data.orderdetail " +
            "right join data.recieptdetail " +
            "on recieptdetail.訂單編號= orderdetail.訂單編號 And recieptdetail.流水號 = orderdetail.流水號 " +
            "inner join data.receipt " +
            "on receipt.receiptID = recieptdetail.收貨編號 " +
            "inner join data.order " +
            "on data.order.訂單編號= orderdetail.訂單編號 ";
        public static string shipmentdetailCond = "where 1=1 ";
        public static string shipmentdetailGroup = "group by 品番,其他";
        public static List<shipment> getships(string guestID, string shipmentDate,bool o)
        {
            List<shipment> shipments = new List<shipment>();
            DataSet dataSet;
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            if(guestID != null && guestID !="" && shipmentDate != null && shipmentDate !="")
            {
                if(o)
                {
                    shipmentCond = " where data.order.客戶編號 = " + guestID + " and recieptdetail.出貨日 = '" + shipmentDate + "' and orderdetail.缺貨 = 'Y'";
                }
                else
                {
                    shipmentCond = " where data.order.客戶編號 = " + guestID + " and recieptdetail.出貨日 = '" + shipmentDate + "' and orderdetail.缺貨 != 'Y'";
                }
            }
            else
            {
                return shipments;
            }
            dataSet = sqlConn.SelectCommand(shipmentStr + shipmentCond + shipmentGroup);
            foreach (DataRow i in dataSet.Tables[0].Rows)
            {
                shipment shipment = new shipment();
                shipment.guestID = guestID;
                shipment.ShipmentDate = shipmentDate;
                shipment.o = o;
                shipment.brand = i["品牌"].ToString();
                if(o)
                {
                    shipment.o = true;
                }
                else
                {
                    shipment.o = false;
                }
                shipments.Add(shipment);
            }
            return shipments;
        }

        public static List<shipmentdetail> getShipmentdetails(string brand, string guestID, string shipmentDate,bool o)
        {
            List<shipmentdetail> shipmentdetails = new List<shipmentdetail>(); 
            DataSet dataSet;
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            if (guestID != null && guestID != "" && shipmentDate != null && shipmentDate != "" && brand!="" && brand!=null)
            {
                if(o)
                {
                    shipmentdetailCond = " where data.order.客戶編號 = " + guestID + " and recieptdetail.出貨日 = '" + shipmentDate + "' and orderdetail.缺貨 = 'Y' and orderdetail.品牌='"+brand+"' ";
                }
                else
                {
                    shipmentdetailCond = " where data.order.客戶編號 = " + guestID + " and recieptdetail.出貨日 = '" + shipmentDate + "' and orderdetail.缺貨 != 'Y' and orderdetail.品牌='" + brand + "' ";
                }
            }
            else
            {
                return shipmentdetails;
            }
            dataSet = sqlConn.SelectCommand(shipmentdetailStr + shipmentdetailCond + shipmentdetailGroup);
            foreach(DataRow i in dataSet.Tables[0].Rows)
            {
                shipmentdetail shipmentdetail = new shipmentdetail();
                shipmentdetail.productID = i["品番"].ToString();
                if(shipmentdetail.productID==""|| shipmentdetail.productID==null)
                {
                    shipmentdetail.productID = i["其他"].ToString();
                }
                if(o)
                {
                    shipmentdetail.amount = i["未出數量"].ToString();
                }
                else
                {
                    shipmentdetail.amount = i["數量"].ToString();
                }
                shipmentdetail.color = i["ｶﾗｰ"].ToString();
                shipmentdetail.producttype = i["商品類別"].ToString();
                shipmentdetail.jprice = i["上代"].ToString();
                shipmentdetail.tprice ="NT$"+i["金額"].ToString();
                shipmentdetail.size = i["ｻｲｽﾞ"].ToString();
                shipmentdetail.colornum = i["色番"].ToString();
                shipmentdetail.remark = i["備註"].ToString();
                shipmentdetails.Add(shipmentdetail);
            }
            return shipmentdetails;
        }
    }
}