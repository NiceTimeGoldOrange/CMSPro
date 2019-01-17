using IDAL;
using Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SQLServerDAL
{
    class SQLHelper : IDbTool
    {
        readonly string connStr = "Data Source=(local);Initial Catalog=Aecg;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection conn = null;

        public void CloseConn()
        {
            try
            {
                if (conn != null)
                    conn.Close();
            }
            catch (Exception)
            {
            }
        }

        public int ExecNoQuery(string sql)
        {
            int i = 0;
            try
            {
                conn = GetConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConn();
            }
            return i;
        }

        public SqlDataReader ExecReader(string sql)
        {
            try
            {
                conn = GetConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDataTable(string sql)
        {
            SqlConnection conn = null;
            DataTable dt = new DataTable();
            try
            {
                conn = GetConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                try
                {
                    if (conn != null)
                        conn.Close();
                }
                catch (Exception)
                {

                }
            }
            return dt;
        }

        public SqlConnection GetConnection()
        {
            try
            {
                conn = new SqlConnection(connStr);
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                e.Message.ToString();
                return null;
            }
        }

        public TRoomInfo SetRoom(SqlDataReader dr)
        {
            TRoomInfo room = new TRoomInfo();
            string str = dr["Id"].ToString();
            room.Id = int.Parse(dr["Id"].ToString());
            room.User_Name = dr["User_Name"].ToString();
            room.Date = dr["Date"].ToString();
            room.Start_Time = dr["Start_Time"].ToString();
            room.End_Time = dr["End_Time"].ToString();
            room.Meeting_Subject = dr["Meeting_Subject"].ToString();
            room.Meeting_Title = dr["Meeting_Title"].ToString();
            room.Meeting_Remark = dr["Meeting_Remark"].ToString();
            room.Meeting_Attendee = dr["Meeting_Attendee"].ToString();
            return room;
        }
    }
}
