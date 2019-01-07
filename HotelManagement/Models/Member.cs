using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagement.Models
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday{ get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public char Gender { get; set; }
        
    }
}