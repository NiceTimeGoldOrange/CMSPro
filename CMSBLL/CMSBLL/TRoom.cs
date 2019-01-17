using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BLL
{
    public class TRoom : Controller
    {
        public IActionResult RoomListService()
        {
            List<TRoomInfo> roomlist = null;
            try
            {
                roomlist = SQLServerDAL.TRoom.GetInstance().GetRoomList();
            }
            catch (Exception)
            {
                throw;
            }
            return Json(roomlist);
        }

        public IActionResult DelService(string roomid)
        {
            try
            {
                if (SQLServerDAL.TRoom.GetInstance().DelRoom(roomid) > 0)
                {
                    return Json("ok");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json("error");
        }

        public IActionResult GetRoomByIdService(int roomid)
        {
            TRoomInfo room = null;
            if (roomid <= 0)
            {
                return Json("error");
            }
            try
            {
                room = SQLServerDAL.TRoom.GetInstance().GetRoomById(roomid);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(room);
        }

        public IActionResult AddRoomService(string jsonString)
        {
            TRoomInfo room = JsonConvert.DeserializeObject<TRoomInfo>(jsonString);
            try
            {
                if (SQLServerDAL.TRoom.GetInstance().SaveRoom(room) > 0)
                {
                    return Json("ok");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json("msg:error");
        }

        public IActionResult GetInfoByDateService(string date)
        {
            List<TRoomInfo> roomlist = null;
            try
            {
                roomlist = SQLServerDAL.TRoom.GetInstance().GetRoomByDate(date);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(roomlist);
        }
    }
}
