using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Database.AccessLayer
{
    public class productType
    {
        public string productTypeID { get; set; }
        public string producttype { get; set; }
    }

    public class productTypeAccessLayer
    {
        public List<string> getProductType()
        {
            List<productType> productTypes = new List<productType>();
            sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            List<string> vs = new List<string>();
            DataSet dataSet = sqlConn.SelectCommand("SELECT * FROM data.producttype;");
            foreach(DataRow i in dataSet.Tables[0].Rows)
            {
                productType productType = new productType();
                productType.productTypeID = i["ID"].ToString();
                productType.producttype = i["productType"].ToString();
                productTypes.Add(productType);
            }
            char c1 = 'a', c2 = 'a';
            foreach(productType i in productTypes)
            {
                c1=Convert.ToChar(Convert.ToInt32(i.productTypeID)-1+(int)'a');
                c2 = Convert.ToChar(Convert.ToInt32(i.productTypeID) % 26 + (int)'a');
                string s = c1 + c2 + " " + i.producttype;
                vs.Add(s);
            }           
            return vs;
        }
    }
}