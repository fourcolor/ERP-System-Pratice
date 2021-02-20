using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Database
{
    public class Receipt
    {
        public int receiptID { get; set; }
        public int guestID { get; set; }
        public string receiptDate { get; set; }
    }
    public class ReceiptAccessLayer
    {
        public string str = "SELECT * FROM data.receipt";
        public string cond = " where 1=1";
        public List<Receipt> getReceipts()
        {
            List<Receipt> receipts = new List<Receipt>();
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            DataSet dataSet = sqlConn.SelectCommand(str + cond);
            foreach(DataRow i in dataSet.Tables[0].Rows)
            {
                Receipt receipt = new Receipt();
                receipt.receiptID = Convert.ToInt32(i["receiptID"]);
                receipt.guestID = Convert.ToInt32(i["客戶ID"]);
                receipt.receiptDate = i["收貨日"].ToString();
                receipts.Add(receipt);
            }
            return receipts;
        }
        public List<Receipt> getactuallReceipts(string guestID,string Date)
        {
            List<Receipt> receipts = new List<Receipt>();
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            if (guestID != "" && guestID != null)
            {
                cond += " and 客戶ID= "+guestID;
            }
            if(Date != "" && Date != null)
            {
                cond += " and 收貨日 = '" + Date+"' ";
            }
            DataSet dataSet = sqlConn.SelectCommand(str + cond);
            foreach (DataRow i in dataSet.Tables[0].Rows)
            {
                Receipt receipt = new Receipt();
                receipt.receiptID = Convert.ToInt32(i["receiptID"]);
                receipt.guestID = Convert.ToInt32(i["客戶ID"]);
                receipt.receiptDate = i["收貨日"].ToString();
                receipts.Add(receipt);
            }
            cond = " where 1=1 ";
            return receipts;
        }
    }
}