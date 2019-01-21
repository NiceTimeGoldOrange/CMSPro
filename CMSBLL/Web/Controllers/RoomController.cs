using BLL;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class RoomController : Controller
    {
        private TRoom service = new TRoom();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RoomList(string rq)
        {
            return service.RoomListService(rq);
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

        [HttpGet]
        public IActionResult GetRoomByDate(string date)
        {
            return service.GetInfoByDateService(date);
        }

        [HttpGet]
        public IActionResult GetRoomByMDSE(string id,string date,string times)
        {
            return service.GetRoomByMDSE(id, date, times);
        }
    }
}