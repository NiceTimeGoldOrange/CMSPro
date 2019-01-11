using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CMSPro.Tools
{
    public class MyConnection
    {
        public static SqlConnection GetConnection()
        {
            string connStr = "Data Source=(local);Initial Catalog=Aecg;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(connStr);
                return conn;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }
        }
    }
}
