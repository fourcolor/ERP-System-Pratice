using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database
{
    public class inserModeDetail
    {
        public string productID { get; set; }
        public string productType { get; set; }
        public string price { get; set; }
        public string DeliveryDate { get; set; }
        public string colorNum { get; set; }
        public string color { get; set; }
        public string size { get; set; }
        public string amount { get; set; }
        public string brand { get; set; }
        public string shipment { get; set; }
        public string unshipment { get; set; }
        public string outofstock { get; set; }
        public string statement { get; set; }
        public string remark { get; set; }
    }

    public class insertModeDetailAccessLayer
    {
        public static List<inserModeDetail> details = new List<inserModeDetail>();
        public static List<inserModeDetail> getInsertModeDetail()
        {
            if(details.Count==0)
            {
                inserModeDetail detail = new inserModeDetail();
                detail.amount = "";
                detail.brand = "";
                detail.color = "";
                detail.colorNum = "";
                detail.price = "";
                detail.productID = "";
                detail.productType = "";
                detail.remark = "";
                detail.shipment = "";
                detail.size = "";
                detail.unshipment = "";
                detail.DeliveryDate = "";
                detail.statement = "";
                detail.outofstock = "";
                details.Add(detail);
            }
            return details;
        }
        public static void deleteInsertModeDetail(string productID, string productType, string price, string DeliveryDate, string colorNum, string color, string size, string amount, string brand, string shipment, string unshipment, string remark)
        {
            if (productID == null) productID="";
            if (productType == null) productType = "";
            if (price == null) price = "";
            if (DeliveryDate == null) DeliveryDate = "";
            if (colorNum == null) colorNum = "";
            if (color == null) color = "";
            if (size == null) size = "";
            if (amount == null) amount = "";
            if (brand == null) brand = "";
            if (shipment == null) shipment = "";
            if (unshipment == null) unshipment = "";
            if (remark == null) remark = "";
            int len = details.Count;
            for (int i = 0; i < len; i++) 
            {
                if(details[i].productID == productID &&
                    details[i].productType == productType &&
                    details[i].price == price &&
                    details[i].DeliveryDate == DeliveryDate &&
                    details[i].colorNum == colorNum &&
                    details[i].color == color &&
                    details[i].size == size &&
                    details[i].amount == amount &&
                    details[i].brand == brand &&
                    details[i].shipment == shipment &&
                    details[i].unshipment == unshipment &&
                    details[i].remark == remark 
                    )
                {
                    details.RemoveAt(i);
                    break;
                }
            }
        }
    }
}