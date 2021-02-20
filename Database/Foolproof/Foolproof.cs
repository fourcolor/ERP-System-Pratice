using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Database
{
    public static class Foolproof
    {
        public static bool DateFoolproof(string Date)
        {
            if(Date==""||Date==null)
            {
                return true;
            }
            try
            {
                CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP"); //日期文化格式
                DateTime d;
                d = DateTime.ParseExact(Date, "yyyy/MM/dd", CultureInfoDateCulture);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static bool GuestFoolproof(string id)
        {
            int i = 0;
            bool result = int.TryParse(id, out i); 
            if(!result)
            {
                return false;
            }
            else
            {
                sqlConn sqlConn = new sqlConn("127.0.0.1", "3306", "root", "a27452840", "data", "utf8");
                DataSet dataSet = sqlConn.SelectCommand("SELECT * FROM data.guest where guestID = "+id+";");
                if(dataSet.Tables[0].Rows.Count==0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool DoubleFoolproof(string num)
        {
            double i = 0;
            bool result = double.TryParse(num, out i);
            if(result)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public static bool IntFoolproof(string num)
        {
            int i = 0;
            bool result = int.TryParse(num, out i);
            if (result)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}