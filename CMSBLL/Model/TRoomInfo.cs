using System;

namespace Model
{
    public class TRoomInfo
    {
        private int _id;
        private string _user_Name;
        private string _date;
        private string _start_Time;
        private string _end_Time;
        private string _meeting_Subject;
        private string _meeting_Title;
        private string _meeting_Remark;
        private string _meeting_Attendee;

        public int Id { get => _id; set => _id = value; }
        public string User_Name { get => _user_Name; set => _user_Name = value; }
        public string Date { get => _date; set => _date = value; }
        public string Start_Time { get => _start_Time; set => _start_Time = value; }
        public string End_Time { get => _end_Time; set => _end_Time = value; }
        public string Meeting_Subject { get => _meeting_Subject; set => _meeting_Subject = value; }
        public string Meeting_Title { get => _meeting_Title; set => _meeting_Title = value; }
        public string Meeting_Remark { get => _meeting_Remark; set => _meeting_Remark = value; }
        public string Meeting_Attendee { get => _meeting_Attendee; set => _meeting_Attendee = value; }

        public TRoomInfo()
        {

        }

        public TRoomInfo(int id, string user_Name, string date, string start_Time, string end_Time, string meeting_Subject, string meeting_Title, string meeting_Remark, string meeting_Attendee)
        {
            this._id = id;
            this._user_Name = user_Name;
            this._date = date;
            this._start_Time = start_Time;
            this._end_Time = end_Time;
            this._meeting_Subject = meeting_Subject;
            this._meeting_Title = meeting_Title;
            this._meeting_Remark = meeting_Remark;
            this._meeting_Attendee = meeting_Attendee;
        }
    }
}
