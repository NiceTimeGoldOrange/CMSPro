using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMSPro.Tools;

namespace CMSPro.Models
{
    public class RoomsRepository : DbContext
    {
        public RoomsRepository()
        {
        }

        public RoomsRepository (DbContextOptions<RoomsRepository> options)
            : base(options)
        {
        }

        public DbSet<RoomsModel> Rooms { get; set; }
         
        //添加会议
        #region
        public void Add(RoomsModel room)
        {
            SqlConnection conn = MyConnection.GetConnection();
            SqlCommand cmd = null;
            if (room != null)
            {
                string sql = "INSERT INTO t_room " +
                       "( user_name, start_time, end_time, meeting_subject, meeting_title, meeting_remark )" +
                       "VALUES ('" +
                       room.User_Name + "','" +
                       room.Start_Time + "','" +
                       room.End_Time + "','" +
                       room.Meeting_Subject + "','" +
                       room.Meeting_Title + "','" +
                       room.Meeting_Remark + "')";
                try
                {
                    conn.Open();
                    cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Clone();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
        }
        #endregion

        //删除会议
        #region
        public void Delete(int id)
        {
            SqlConnection conn = MyConnection.GetConnection();
            SqlCommand cmd = null;
            string sql = "DELETE FROM t_room WHERE id=" + id;
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Clone();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
        #endregion

        // 查询
        #region
        public List<RoomsModel> Select(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        // 修改会议的相关信息
        #region
        public void Update(int id, RoomsModel room)
        {
            SqlConnection conn = MyConnection.GetConnection();
            SqlCommand cmd = null;
            string sql = "UPDATE t_room SET " +
                    "user_name = '" + room.User_Name + "'," +
                    "start_time = '" + room.Start_Time + "'," +
                    "end_time = '" + room.End_Time + "'," +
                    "meeting_subject = '" + room.Meeting_Subject + "'," +
                    "meeting_title = '" + room.Meeting_Title + "'," +
                    "meeting_remark = '" + room.Meeting_Remark + "'";
            try
            {
                conn.Open();
                cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Clone();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        #endregion
    }
}
