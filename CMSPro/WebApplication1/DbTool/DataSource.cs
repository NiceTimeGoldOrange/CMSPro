using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DbTool
{
    public class DataSource
    {
        readonly string connStr = "Data Source=(local);Initial Catalog=Aecg;Persist Security Info=True;User ID=sa;Password=123";
        private static DataSource instance;
        SqlConnection conn = null;

        private DataSource()
        {

        }

        // 以集合返回所有TRoom
        internal List<TRoom> GetRoomList()
        {
            List<TRoom> roomlsit = new List<TRoom>();
            TRoom room;
            try
            {
                //string sql = @"SELECT * FROM(
                //            SELECT TOP 105 * FROM(
                //                SELECT TOP 105 * FROM T_room ORDER BY ID ASC)
                //                    AS TEMP1 ORDER BY ID DESC)
                //                AS TEMP2 ORDER BY ID ASC ";
                string sql = "SELECT * FROM t_room";
                SqlDataReader dr = ExecReader(sql);
                while (dr.Read())
                {
                    room = SetRoom(dr);
                    roomlsit.Add(room);
                }
                dr.Close();
                CloseConn();
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
                CloseConn();
            }
            catch (Exception)
            {
                throw;
            }
            return room;
        }

        // 删除预定的会议
        internal int DelRoom(string roomid)
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

        // 设置TRoom的属性
        private TRoom SetRoom(SqlDataReader dr)
        {
            TRoom room = new TRoom();
            room.id = int.Parse(dr["id"].ToString());
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

        internal int SaveRoom(TRoom room)
        {
            int i = 0;
            try
            {
                string sql = "";
                if (room.id > 0)
                {
                    sql = string.Format("update t_room set " +
                                 "user_name='{0}', " +
                                 "Date='{1}', " +
                                 "start_time='{2}', " +
                                 "end_time='{3}', " +
                                 "meeting_subject='{4}', " +
                                 "meeting_title='{5}', " +
                                 "meeting_remark='{6}', " +
                                 "meeting_attendee='{7}' " +
                                 "where id='{8}'",
                                room.User_Name, room.Date, room.Start_Time,
                                room.End_Time, room.Meeting_Subject,
                                room.Meeting_Title, room.Meeting_Remark,
                                room.Meeting_Attendee, room.id);
                }
                else
                {
                    sql = "INSERT INTO t_room " +
                           "( user_name, date, start_time, end_time, meeting_subject, " +
                           "meeting_title, meeting_remark, meeting_attendee )" +
                           "VALUES ('" +
                           room.User_Name + "','" +
                           room.Date + "','" +
                           room.Start_Time + "','" +
                           room.End_Time + "','" +
                           room.Meeting_Subject + "','" +
                           room.Meeting_Title + "','" +
                           room.Meeting_Remark + "','" +
                           room.Meeting_Attendee + "')";
                }
                i = ExecNoQuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }

        // 返回DataSource对象
        public static DataSource GetInstance()
        {
            if (instance == null)
                instance = new DataSource();
            return instance;
        }

        // 数据库连接
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

        //  执行Sql语句，返回DataTable
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

        // 执行Sql语句，读取行的只进流方式
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

        // 执行Sql语句，返回受影响的列数
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

        /// 关闭连接
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
    }
}
