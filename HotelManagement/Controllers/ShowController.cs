using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            return View();
        }

        // GET: Show/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult ShowRooms()
        {
            List<Models.Room> list = new List<Models.Room>();
            list= Models.Room.GetAllRoomPrice();
            foreach (Models.Room item in list)
            {

                switch (item.RoomDescription)
                {
                    case "Bachelor":
                        ViewBag.Bachelor = item.RoomPrice;
                        break;
                    case "Family":
                        ViewBag.Family = item.RoomPrice;
                        break;
                    case "Presidential":
                        ViewBag.Presidential = item.RoomPrice;
                        break;
                    case "Superior":
                        ViewBag.Superior = item.RoomPrice;
                        break;
                    case "Premier":
                        ViewBag.Premier = item.RoomPrice;
                        break;
                    case "Twin":
                        ViewBag.Twin = item.RoomPrice;
                        break;
                    case "Triple":
                        ViewBag.Triple = item.RoomPrice;
                        break;
                    case "King":
                        ViewBag.King = item.RoomPrice;
                        break;
                    case "Deluxe King":
                        ViewBag.Deluxe = item.RoomPrice;
                        break;

                    default:
                        break;
                }
            }
            return View();
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Room/Create
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

        // GET: Room/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Room/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Room/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
