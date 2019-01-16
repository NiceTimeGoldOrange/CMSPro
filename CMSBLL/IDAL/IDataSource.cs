using Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace IDAL
{
    public interface IDataSource
    {
        List<TRoom> GetRoomList();

        TRoom GetRoomById(int roomid);

        int DelRoom(string roomid);

        int SaveRoom(TRoom room);

        IDataSource GetInstance();
    }
}
