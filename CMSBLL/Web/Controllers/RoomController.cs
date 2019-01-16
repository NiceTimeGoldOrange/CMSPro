using CMSBLL;
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