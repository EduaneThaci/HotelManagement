using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HotelManagement.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["User"] != null)
            {
                return View(Models.Booking.GetAll());
            }
            return RedirectToAction("Login", "Member");
        }

        [HttpGet]
        public ActionResult Make()
        {
            ViewBag.RoomDescription = Room.GetAll();
            return View();
        }

        [HttpPost]
        public ActionResult Make(Booking b, string RoomDescription, string UserName)
        {

            int roomID = 0;
            b.RoomDescription = RoomDescription;
            roomID = b.GetRoomID(roomID);

            Users obj = (Users)Session["User"];

            try
            {
                if (ModelState.IsValid)
                {
                   
                    if (Session["User"] != null)
                    {
                        if (obj.RoleID == 3)
                        {
                            if (Booking.GetBookingNumber(obj.UserID) == 0)
                            {
                                HttpCookie objC = new HttpCookie("ClientDetails");
                                objC["UserID"] = obj.UserID.ToString();
                                objC["UserName"] = obj.UserName;
                                objC["BirthDay"] = b.Birthday.ToString();
                                objC["Address"] = b.Address;
                                objC["PhoneNumber"] = b.PhoneNumber;
                                objC["PassportNumber"] = b.PassportNumber;
                                objC["Gender"] = b.Gender.ToString();
                                objC.Expires = DateTime.Now.AddDays(365);
                                b.Insert(obj.UserID, roomID);
                                Response.Cookies.Add(objC);


                                b.SendEmailToClient(obj.Email, obj.UserName, RoomDescription, b.CheckIn, b.CheckOut, b.AdultsNo, b.ChildrenNo);
                                TempData["BookingSuccess3"] = true;
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                b.InsertWhileInCookie(obj.UserID, roomID);
                                b.SendEmailToClient(obj.Email, obj.UserName, RoomDescription, b.CheckIn, b.CheckOut, b.AdultsNo, b.ChildrenNo);
                                TempData["BookingSuccess31"] = true;
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            int id = Users.GetUserID(UserName);
                            if (b.InsertByRole2(obj.UserID, roomID, id))
                            {
                                TempData["BookingSuccess3"] = true;
                                return RedirectToAction("Index", "Book");
                            }
                            TempData["BookingFail3"] = true;
                        }
                    }
                }

                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult MakeForOthers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MakeForOthers(Models.Booking b, string UserName, string MemberUserName, Models.Users u)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["User"] != null)
                    {


                        Users obj = (Users)Session["User"];
                        string address = u.Address;
                        DateTime? birthday = u.Birthday;
                        string phonenumber = u.PhoneNumber;
                        string passportnumber = u.PassportNumber;
                        char gender = u.Gender;

                        int bookingID = Booking.GetBookingIDByUserID(obj.UserID);
                        int UserID = Users.GetUserID(UserName);
                        if (obj.RoleID == 3)
                        {
                            if (b.InsertForOthers(obj.UserID, bookingID, UserID))
                            {
                                Booking.UpdateUserWhileOtherBooking(UserID, address, birthday, phonenumber, passportnumber, gender);
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            int memberID = Users.GetUserID(MemberUserName);
                            int bID = Booking.GetBookingIDByUserID(UserID);
                            if (b.InsertForOthers(obj.UserID, bID, memberID))
                            {

                                Booking.UpdateUserWhileOtherBooking(memberID, address, birthday, phonenumber, passportnumber, gender);
                                return RedirectToAction("Index", "Book");
                            }

                        }


                    }

                }

                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int bookID, Models.Booking obj)
        {
            ViewBag.RoomDescription = Room.GetAll();
            ViewBag.BookingDetails = Booking.GetAll();
            return View(Models.Booking.GetById(bookID));
        }


        [HttpPost]
        public ActionResult Edit(int bookID, Models.Booking obj, string Description, string isConfirmed)
        {
            try
            {
                int roomID = 0;
                obj.RoomDescription = Description;
                obj.isConfirmed = isConfirmed;
                roomID = obj.GetRoomID(roomID);
                if (Session["User"] != null)
                {
                    Users u = (Users)Session["User"];
                    if (obj.Update(bookID, roomID, u.UserID))
                    {
                        return RedirectToAction("Index");
                    }
                    return View();
                }
                return RedirectToAction("Login", "Member");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int bookID)
        {
            return View(Models.Booking.GetById(bookID));
        }


        [HttpPost]
        public ActionResult Delete(int bookID, Models.Booking b)
        {
            try
            {
                if (b.Delete(bookID))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

    }
}
