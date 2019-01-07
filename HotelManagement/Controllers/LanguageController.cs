using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Alb()
        {
            Session["Alb"] = true;
            Session["EN"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult En()
        {
            Session["EN"] = true;
            Session["Alb"] = null;

            return RedirectToAction("Index", "Home");
        }
    }
}