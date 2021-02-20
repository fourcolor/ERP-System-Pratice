using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Database
{
    public class Product
    {
        int id;
        string color;
        string size;
        string deliverDate;
        int amount;
        public Product(int id, string color, string size, string deliver ,int num)
        {
            this.id = id;
            this.color = color;
            this.size = size;
            this.deliverDate = deliver;
            this.amount = num;
        }
        public int getID()
        {
            return id;
        }
        public int getAmount()
        {
            return amount;
        }
        public string getSize()
        {
            return size;
        }
        public string getColor()
        {
            return color;
        }
        public string getdeliverDate()
        {
            return deliverDate;
        }
    }
}