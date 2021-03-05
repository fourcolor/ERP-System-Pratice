using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
namespace Database
{
    public class sqlConn
    {
        public MySqlConnection conn;
        string connString;
        MySqlCommand cmd;
        public sqlConn(string host,string port, string userId, string password,string database,string charset)
        {
            connString = "server="+host+";port="+port+ ";user="+userId+";password="+password+";database="+database+";charset="+charset+";";

            conn = new MySqlConnection(connString);
        }
        public void Command(string scmd)
        {
            conn.Open();
            cmd = new MySqlCommand(scmd, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataSet SelectCommand(string scmd)
        {
            DataSet dataSet = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter(scmd, conn);
            conn.Open();
            adapter.Fill(dataSet);
            conn.Close();
            adapter.Dispose();
            return dataSet;
            
        }
        public void addGuest(string guetName)
        {
            string scmd = "INSERT INTO `data`.`guest` (`guestName`) VALUES ('" + guetName + "');";
            Command(scmd);
        }
        string addOrderDb(string guestID, string Date, string totalPrice)
        {
            string scmd = "INSERT INTO `data`.`order` (`guestID`, `Date`, `Totalprice`) VALUES ('" + guestID + "', '" + Date + "', '" + totalPrice + "');";
            Command(scmd);
            scmd = "SELECT MAX(orderID) FROM data.order;";
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(scmd, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string ans = reader.GetString(0);
            conn.Close();
            return ans;
        }
        void addProductDb(string productType, string productPrice)
        {
            string scmd = "INSERT INTO `data`.`product` (`productType`, `Productprice`) VALUES('" + productType + "', '" + productPrice + "');";
            Command(scmd);
        }
        void addDetailDb(string orderID, string productID, string productColor, string deliveryDate, string amount, string size, string price)
        {
            string scmd = "INSERT INTO `data`.`orderDetail` (`orderID`, `productID`, `color`, `DeliveryDate`, `amount`, `size`, `price`) " +
                "VALUES ('" + orderID + "', '" + productID + "', '" + productColor + "', '" + deliveryDate + "', '" + amount + "', '" + size + "', '" + price + "');";
            Command(scmd);
        }
        public string findguestID(string name)
        {
            string scmd = "SELECT guestID FROM data.guest where guestName = '"+name+"';";
            DataSet data = SelectCommand(scmd);
            if(data.Tables[0].Rows.Count == 0)
            {
                addGuest(name);
                data = SelectCommand(scmd);
            }
            return data.Tables[0].Rows[0][0].ToString();
        }

        public string findProductPrice(string ID)
        {
            string scmd= "SELECT Productprice FROM data.product where productId = "+ID+"; ";
            DataSet data = SelectCommand(scmd);
            return data.Tables[0].Rows[0][0].ToString();
        }



        public string findTotalprice(int orderID)
        {
            string scmd = "SELECT Productprice FROM data.product where SELECT price FROM data.orderdetail where orderId = " + orderID + "; ";
            DataSet data = SelectCommand(scmd);
            return data.Tables[0].Rows[0][0].ToString();
        }
        public void addOrder(string guetName,string Date, List<Product> products)
        {
            double totalPrice = 0;
            foreach(var i in products)
            {
                double price = Convert.ToDouble(findProductPrice(Convert.ToString(i.getID())));
                totalPrice += price;
            }
            string guestID = findguestID(guetName);
            string orderID = addOrderDb(guestID,Date,Convert.ToString(totalPrice));
            foreach(var i in products)
            {
                string productPrice = findProductPrice(Convert.ToString(i.getID()));
                addDetailDb(orderID, Convert.ToString(i.getID()), i.getColor(),i.getdeliverDate(),Convert.ToString(i.getAmount()),i.getSize(),productPrice);
            }
        }
    }
}    