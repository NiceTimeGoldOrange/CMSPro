using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class NciTRoomInfo
    {
        private int _id;
        private string _times;
        private string _room1;
        private string _room2;
        private string _room3;
        private string _room4;
        private string _room5;
        private string _room6;
        private string _room7;

        public int Id { get => _id; set => _id = value; }
        public string Times { get => _times; set => _times = value; }
        public string Room1 { get => _room1; set => _room1 = value; }
        public string Room2 { get => _room2; set => _room2 = value; }
        public string Room3 { get => _room3; set => _room3 = value; }
        public string Room4 { get => _room4; set => _room4 = value; }
        public string Room5 { get => _room5; set => _room5 = value; }
        public string Room6 { get => _room6; set => _room6 = value; }
        public string Room7 { get => _room7; set => _room7 = value; }

        public NciTRoomInfo()
        {

        }
    }
}
