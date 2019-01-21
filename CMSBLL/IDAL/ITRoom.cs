using Model;
using System.Collections.Generic;

namespace IDAL
{
    public interface ITRoom
    {
        List<TRoomInfo> GetRoomList();

        TRoomInfo GetRoomById(int roomid);

        int DelRoom(string roomid);

        int SaveRoom(TRoomInfo room);

        List<TRoomInfo> GetRoomByDate(string date);

        TRoomInfo GetRoomByMDSE(string mark, string date, string times);
    }
}
