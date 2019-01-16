using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SQLServerDAL
{
    class DataSource : IDataSource
    {
        private static DataSource instance;
        private Operation opt = new Operation();
        private SqlConnection conn = null;

        public DataSource()
        {

        }

        public int DelRoom(string roomid)
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

        public IDataSource GetInstance()
        {
            if (instance == null)
            {
                instance = new DataSource();
            }
            return instance;
        }

        public TRoom GetRoomById(int roomid)
        {
            TRoom room = null;
            try
            {
                string sql = string.Format("select * from T_room where id={0}", roomid);
                SqlDataReader dr = opt.ExecReader(sql);
                if (dr.Read())
                {
                    room = opt.SetRoom(dr);
                }
                dr.Close();
                opt.CloseConn();
            }
            catch (Exception)
            {
                throw;
            }
            return room;
        }

        public List<TRoom> GetRoomList()
        {
            List<TRoom> roomlsit = new List<TRoom>();
            TRoom room;
            try
            {
                string sql = "SELECT * FROM t_room";
                SqlDataReader dr = opt.ExecReader(sql);
                while (dr.Read())
                {
                    room = opt.SetRoom(dr);
                    roomlsit.Add(room);
                }
                dr.Close();
                opt.CloseConn();
            }
            catch (Exception)
            {
                throw;
            }
            return roomlsit;
        }

        public int SaveRoom(TRoom room)
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
                i = opt.ExecNoQuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }
    }
}
