using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace HotelManagement.Models
{
    class Connection
    {
        public static string DefaultConnection
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["FirstConnection"].ConnectionString;
            }
        }
        public string GetCon(string conName)
        {
            return ConfigurationManager.ConnectionStrings[conName].ConnectionString;

        }

    }
}