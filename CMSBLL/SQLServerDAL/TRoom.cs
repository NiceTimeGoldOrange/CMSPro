using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLServerDAL
{
    public class TRoom : ITRoom
    {
        private static TRoom instance;
        private SQLHelper opt = new SQLHelper();

        public TRoom()
        {

        }

        public static TRoom GetInstance()
        {
            if (instance == null)
            {
                instance = new TRoom();
            }
            return instance;
        }

        public int DelRoom(string roomid)
        {
            int i = 0;
            try
            {
                string sql = string.Format("DELETE FROM t_room WHERE id={0}", roomid);
                i = opt.ExecNoQuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
            return i;
        }


        public TRoomInfo GetRoomByDate(string date)
        {
            TRoomInfo room = null;
            try
            {
                string sql = string.Format("SELECT " +
                    " id,user_name,date," +
                    "start_time,end_time," +
                    "meeting_subject," +
                    "meeting_title, meeting_remark," +
                    "meeting_attendee  " +
                    "FROM " +
                    "T_room " +
                    "WHERE " +
                    "date='{0}'", date);
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

        public TRoomInfo GetRoomById(int roomid)
        {
            TRoomInfo room = null;
            try
            {
                string sql = string.Format("SELECT " +
                    " id,user_name,date," +
                    "start_time,end_time," +
                    "meeting_subject," +
                    "meeting_title, meeting_remark," +
                    "meeting_attendee  " +
                    "FROM " +
                    "T_room " +
                    "WHERE " +
                    "id={0}", roomid);
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

        public List<TRoomInfo> GetRoomList()
        {
            List<TRoomInfo> roomlsit = new List<TRoomInfo>();
            TRoomInfo room;
            try
            {
                string sql = "SELECT " +
                    " id, user_name,date," +
                    "start_time,end_time," +
                    "meeting_subject," +
                    "meeting_title, meeting_remark," +
                    "meeting_attendee  " +
                    "FROM " +
                    "T_room ";
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

        public int SaveRoom(TRoomInfo room)
        {
            int i = 0;
            try
            {
                string sql = "";
                if (room.Id > 0)
                {
                    sql = string.Format("UPDATE " +
                                 "t_room " +
                                 "SET " +
                                 "user_name='{0}', " +
                                 "Date='{1}', " +
                                 "start_time='{2}', " +
                                 "end_time='{3}', " +
                                 "meeting_subject='{4}', " +
                                 "meeting_title='{5}', " +
                                 "meeting_remark='{6}', " +
                                 "meeting_attendee='{7}' " +
                                 "WHERE id='{8}'",
                                room.User_Name, room.Date, room.Start_Time,
                                room.End_Time, room.Meeting_Subject,
                                room.Meeting_Title, room.Meeting_Remark,
                                room.Meeting_Attendee, room.Id);
                }
                else
                {
                    sql = "INSERT INTO " +
                          "t_room " +
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
