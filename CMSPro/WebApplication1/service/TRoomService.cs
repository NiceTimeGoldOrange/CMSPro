using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebApplication1.DbTool;
using WebApplication1.Models;

namespace CMSPro.service
{
    public class TRoomService : Controller
    {
        public IActionResult RoomListService()
        {
            List<TRoom> roomlist = null;
            try
            {
                roomlist = DataSource.GetInstance().GetRoomList();
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
                if (DataSource.GetInstance().DelRoom(roomid) > 0)
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
            TRoom room = null;
            if (roomid <= 0)
            {
                return Json("error");
            }
            try
            {
                room = DataSource.GetInstance().GetRoomById(roomid);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(room);
        }

        public IActionResult AddRoomService(string jsonString)
        {
            TRoom room = JsonConvert.DeserializeObject<TRoom>(jsonString);
            try
            {
                if (DataSource.GetInstance().SaveRoom(room) > 0)
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
    }
}
