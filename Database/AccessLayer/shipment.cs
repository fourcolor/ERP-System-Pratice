using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database.AccessLayer;

namespace Database.AccessLayer
{
    public class shipment
    {
        public string brand { get; set; }
        public string guestID { get; set; }
        public string ShipmentDate { get; set; }
        public bool o;
        public List<shipmentdetail> content
        {
            get
            {
                return shipmentAccessLayer.getShipmentdetails(this.brand, this.guestID, this.ShipmentDate, this.o);
            }
        }
    }
    public class shipmentdetail
    {
        public string productID { get; set; }
        public string producttype { get; set; }
        public string jprice { get; set; }
        public string colornum { get; set; }
        public string color { get; set; }
        public string size {get;set;}
        public string amount { get; set; }
        public string tprice { get; set; }
        public string remark { get; set; }
    }

}