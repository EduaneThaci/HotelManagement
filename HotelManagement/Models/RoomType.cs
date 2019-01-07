using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class RoomType
    {
        public static int TypeID { get; set; }
        public static int MaxGuestNumber { get; set; }
        public static string RoomDescription { get; set; }
        public static double RoomPrice { get; set; }


    }
}