using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class BookingDetails
    {
        public int BookingID { get; set; }
        public int GuestID { get; set; }
        public string Description { get; set; }
    }
}