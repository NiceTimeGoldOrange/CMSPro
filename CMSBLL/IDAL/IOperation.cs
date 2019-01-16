using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace IDAL
{
    public interface IOperation
    {
        SqlConnection GetConnection();

        DataTable GetDataTable(string sql);

        SqlDataReader ExecReader(string sql);

        int ExecNoQuery(string sql);

        void CloseConn();
    }
}
