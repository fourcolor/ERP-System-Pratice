using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Database.AccessLayer
{
    public class guestAccessLayer
    {
        public static string str = "SELECT * FROM data.guest ";
        public static string cond = " where 1=1 ";
        public static DataSet getguest()
        {
            sqlConn sqlConn= new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
            DataSet dataSet = sqlConn.SelectCommand(str+cond);
            return dataSet;
        }
    }
}