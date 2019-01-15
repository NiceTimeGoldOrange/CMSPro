using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using CMSPro.service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.DbTool;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RoomController : Controller
    {
        private TRoomService service = new TRoomService();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            return service.RoomListService();
        }

        [HttpGet]
        public IActionResult Del(string roomid)
        {
            return service.DelService(roomid);
        }

        [HttpGet]
        public IActionResult GetRoomById(int roomid)
        {
            return service.GetRoomByIdService(roomid);
        }

        [HttpPost]
        public IActionResult AddRoom(string jsonString)
        {
            return service.AddRoomService(jsonString);
        }
    }
}