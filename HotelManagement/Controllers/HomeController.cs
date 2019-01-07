using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelManagement.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HotelManagement.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.time = DateTime.Now;
            List<Models.Room> list = new List<Models.Room>();
            list = Models.Room.GetAllRoomPrice();
            foreach (Models.Room item in list)
            {
                if (item.RoomDescription == "Bachelor")
                {
                    ViewBag.Bachelor = item.RoomPrice;
                }
                if (item.RoomDescription == "Family")
                {
                    ViewBag.Family = item.RoomPrice;
                }
                if (item.RoomDescription == "Presidential")
                {
                    ViewBag.Presidential = item.RoomPrice;
                }
                if (item.RoomDescription == "Superior")
                {
                    ViewBag.Superior = item.RoomPrice;
                }
                if (item.RoomDescription == "Premier")
                {
                    ViewBag.Premier = item.RoomPrice;
                }
                if (item.RoomDescription == "Twin")
                {
                    ViewBag.Twin = item.RoomPrice;
                }
                if (item.RoomDescription == "Triple")
                {
                    ViewBag.Triple = item.RoomPrice;
                }
                if (item.RoomDescription == "King")
                {
                    ViewBag.King = item.RoomPrice;
                }
                if (item.RoomDescription == "Deluxe King")
                {
                    ViewBag.Deluxe = item.RoomPrice;
                }


            }
            return View();
        }

        [HttpGet]
        public ActionResult Choose()
        {
            Models.Users obj = new Models.Users();
            if (Session["User"]!=null)
            {
                return View();
            }
            return RedirectToAction("Login", "Member");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
         
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name,string email,string subject,string message)
        {
            try
            {
                MailMessage msg = new MailMessage("lunahotel0@gmail.com", "lunahotel2018@gmail.com");
                msg.Subject = subject;
                string emailBody = @"<html>
                      <body>
                      <p>Hi Hotel Luna,</p>
                      <p><i><b>" + @message + "</b></i></p>" +
                          "<p>Regards,<br><b>" +
                          @name +
                          "</br><b></p>" +
                          "<p><p>" + email + "</p></p>" +
                          "</body></html>";
                msg.Body = emailBody;
                msg.IsBodyHtml = true;

                SmtpClient obj = new SmtpClient();
                obj.Host = "smtp.gmail.com";
                obj.Port = 587;
                obj.Timeout = 10000;
                obj.EnableSsl = true;

                string emailFrom = "lunahotel0@gmail.com";
                string passFrom = "Lunahotel.1";
                obj.Credentials = new NetworkCredential(emailFrom, passFrom);
                obj.Send(msg);
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
           
        }


        [HttpPost]
        public ActionResult Subscribe(string email)
        {
            try
            {
                MailMessage msg = new MailMessage("lunahotel0@gmail.com", "lunahotel2018@gmail.com");
                msg.Subject = "Request for subscription";
                string emailBody = @"<html>
                      <body>
                      <p>Hi Hotel Luna,</p>
                      <p>I am interested to get your promos.</p>"+
                      "<p><p><b>Please, notify me in "+email+".</b></p></p>"+
                          "</body></html>";
                msg.Body = emailBody;
                msg.IsBodyHtml = true;

                SmtpClient obj = new SmtpClient();
                obj.Host = "smtp.gmail.com";
                obj.Port = 587;
                obj.Timeout = 10000;
                obj.EnableSsl = true;

                string emailFrom = "lunahotel0@gmail.com";
                string passFrom = "Lunahotel.1";
                obj.Credentials = new NetworkCredential(emailFrom, passFrom);
                obj.Send(msg);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Contact");
            }

        }
    }
}