using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using CMSPro.Models;
namespace CMSPro.DbTool
{
    public class DataSource
    {
        string connStr = "Data Source=(local);Initial Catalog=Aecg;Persist Security Info=True;User ID=sa;Password=123";
        private static DataSource instance;
        private DataSource()
        {

        }

        internal List<TRoom> GetRoomList()
        {
            List<TRoom> roomlsit = new List<TRoom>();
            TRoom room;
            try
            {
                string sql = @"SELECT * FROM(
                            SELECT TOP 105 * FROM(
                                SELECT TOP 105 * FROM T_room ORDER BY ID ASC)
                                    AS TEMP1 ORDER BY ID DESC)
                                AS TEMP2 ORDER BY ID ASC ";
                SqlDataReader dr = ExecReader(sql);
                while (dr.Read())
                {
                    room = SetRoom(dr);
                    roomlsit.Add(room);
                }
                dr.Close();
                closeConn();
            }
            catch (Exception)
            {
                throw;
            }
            return roomlsit;
        }

        internal TRoom GetRoomById(int roomid)
        {
            TRoom room = null;
            try
            {
                string sql = string.Format("select * from T_room where id={0}", roomid);
                SqlDataReader dr = ExecReader(sql);
                if (dr.Read())
                {
                    room = SetRoom(dr);

                }
                dr.Close();
                closeConn();
            }
            catch (Exception)
            {
                throw;
            }
            return room;
        }

        internal int delRoom(string roomid)
        {
            int i = 0;
            try
            {
                string sql = "";
                sql = string.Format("delete from t_room where id={0}", roomid);
                i = ExecNoQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
            return i;
        }

        private TRoom SetRoom(SqlDataReader dr)
        {
            TRoom room = new TRoom();
            room.id = int.Parse(dr["id"].ToString());
            room.User_Name = dr["User_Name"].ToString();
            room.Start_Time = dr["Start_Time"].ToString();
            room.End_Time = dr["End_Time"].ToString();
            room.Meeting_Subject = dr["Meeting_Subject"].ToString();
            room.Meeting_Title = dr["Meeting_Title"].ToString();
            room.Meeting_Remark = dr["Meeting_Remark"].ToString();
            return room;
        }

        internal int SaveRoom(TRoom room)
        {
            int i = 0;
            try
            {
                string sql = "";
                if (room.id > 0)
                {
                    sql = string.Format("update t_room set user_name='{0}',Meeting_Title='{1}' where id='{2}'",
                                room.User_Name, room.Meeting_Title, room.id);
                }
                else
                    sql = "INSERT INTO t_room " +
                                "( user_name, start_time, end_time, meeting_subject, meeting_title, meeting_remark )" +
                                "VALUES ('" +
                                room.User_Name + "','" +
                                room.Start_Time + "','" +
                                room.End_Time + "','" +
                                room.Meeting_Subject + "','" +
                                room.Meeting_Title + "','" +
                                room.Meeting_Remark + "')";
                i = ExecNoQuery(sql);
            }
            catch (Exception)
            {

                throw;
            }
            return i;

        }

        public static DataSource getInstance()
        {
            if (instance == null)
                instance = new DataSource();
            return instance;
        }
        public SqlConnection GetConnection()
        {

            SqlConnection conn = null;
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
        public DataTable getDataTable(string sql)
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
        SqlConnection conn = null;
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
                closeConn();
            }
            return i;

        }
        public void closeConn()
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
    }
}