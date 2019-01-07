using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class RoomController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Room obj = new Room();
            ViewBag.price = obj.RoomPrice;
            return View(Models.Room.GetAll());
        }

        [HttpGet]
        public ActionResult Check(DateTime checkIn, DateTime checkOut)
        {  
            return View(Models.Room.CheckAvailability(checkIn, checkOut));
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.RoomDescription = Room.GetAll();
            return View(Models.Room.GetById(id));
        }


        [HttpPost]
        public ActionResult Edit(int id, Models.Room r, string Description, double RoomPrice, int MaxGuestNumber, string Status)
        {
            r.RoomDescription = Description;
            r.RoomPrice = RoomPrice;
            r.MaxGuestNumber = MaxGuestNumber;
            r.Status = Status;
            int typeID = r.GetTypeByDescription(r.RoomDescription, id);
            Users obj = (Users)Session["User"];

            try
            {
                if (Session["User"] != null)
                {
                    if (r.Update(typeID, id, obj.UserID))
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(Models.Room.GetById(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Models.Room r)
        {
            try
            {
                if (r.Delete(id))
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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int FloorNumber, int MaxGuestNumber, string RoomDescription, double RoomPrice)
        {
            try
            {
                Room obj = new Room();
                obj.FloorNumber = FloorNumber;
                obj.MaxGuestNumber = MaxGuestNumber;
                obj.RoomDescription = RoomDescription;
                obj.RoomPrice = RoomPrice;
                Users u = (Users)Session["User"];
                int userID = u.UserID;
                if (Session["User"] != null)
                {
                    if (obj.Insert(userID))
                    {
                        return RedirectToAction("Index");

                    }
                }

                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
