using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Cancel
    {
        public int CancelID { get; set; }
        public DateTime CancelDate { get; set; }
        public int BookingID { get; set; }
        public string Description { get; set; }
    }
}