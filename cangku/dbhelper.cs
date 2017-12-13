using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
namespace cangku
{
     class dbhelper
    {
         //private static string connstring = @"Data Source=.;Initial Catalog=WMS;Integrated Security=True";
     private static string connstring = "Data Source=.;Initial Catalog=FruitWMS;Integrated Security=True";
        public static SqlConnection connection = new SqlConnection(connstring);
       public static string LoginId = "";
       
    }
}