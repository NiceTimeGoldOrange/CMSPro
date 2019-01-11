using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSPro.Models
{
    public class RoomsModel
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string Start_Time { get; set; }
        public string End_Time { get; set; }
        public string Meeting_Subject { get; set; }
        public string Meeting_Title { get; set; }
        public string Meeting_Remark { get; set; }
    }
}
