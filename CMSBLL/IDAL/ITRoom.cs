using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IDAL
{
    public interface ITRoom
    {
        List<TRoomInfo> GetRoomList();

        TRoomInfo GetRoomById(int roomid);

        int DelRoom(string roomid);

        int SaveRoom(TRoomInfo room);

        TRoomInfo GetRoomByDate(string date);
    }
}
