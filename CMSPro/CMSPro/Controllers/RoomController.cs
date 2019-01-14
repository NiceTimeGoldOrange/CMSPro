using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CMSPro.DbTool;
using CMSPro.Models;


namespace CMSPro.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            //List<TRoom> roomlist = null;
            //try
            //{
            //    roomlist = DataSource.getInstance().GetRoomList();
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //ViewData["roomList"] = roomlist;
            return View();
        }

        [HttpGet]
        public IActionResult RoomList(string pageindex)
        {

            List<TRoom> roomlist = null;
            try
            {
                roomlist = DataSource.getInstance().GetRoomList();

            }
            catch (Exception)
            {
                throw;
            }
            return Json(roomlist);
        }
        [HttpGet]
        public IActionResult del(string roomid)
        {
            try
            {
                if (DataSource.getInstance().delRoom(roomid) > 0)
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
        [HttpGet]
        public IActionResult getRoomByID(int roomid)
        {

            TRoom room = null;
            if (roomid <= 0)
            {
                return Json("error");
            }
            try
            {
                room = DataSource.getInstance().GetRoomById(roomid);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(room);
        }
        [HttpPost]
        public IActionResult addRoom(string jsonString)
        {
            object room = JsonToObject(jsonString, new TRoom());


            try
            {
                if (DataSource.getInstance().SaveRoom((TRoom)room) > 0)
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
        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string json) where T : class
        {
            JsonSerializer serializer = new JsonSerializer();
            StringReader sr = new StringReader(json);
            object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            T t = o as T;
            return t;
        }
        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
        {
            T t = JsonConvert.DeserializeAnonymousType(json, anonymousTypeObject);
            return t;
        }
        /// <summary>
        /// 把JSON字符串还原为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="szJson">JSON字符串</param>
        /// <returns>对象实体</returns>
        public static T ParseFormJson<T>(string szJson)
        {
            T obj = Activator.CreateInstance<T>();
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(szJson)))
            {
                DataContractJsonSerializer dcj = new DataContractJsonSerializer(typeof(T));
                return (T)dcj.ReadObject(ms);
            }
        }
        /// <summary>
        /// 内存对象转换为json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ObjectToJson(object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, obj);
            byte[] dataBytes = new byte[stream.Length];
            stream.Position = 0;
            stream.Read(dataBytes, 0, (int)stream.Length);
            return Encoding.UTF8.GetString(dataBytes);
        }
        /// <summary>
        /// Json字符串转内存对象
        /// </summary>
        /// <param name="jsonString"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object JsonToObject(string jsonString, object obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
            MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            return serializer.ReadObject(mStream);
        }
    }
}