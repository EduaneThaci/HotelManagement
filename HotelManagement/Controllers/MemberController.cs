using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using HotelManagement.Models;
namespace HotelManagement.Controllers
{
    public class MemberController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            //Models.User.GetAll()
            if (Session["User"]!=null)
            {

                return View(Models.Users.GetAll());
            }
            return RedirectToAction("Login");
        }
        
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Register(Models.Users c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (c.Insert())
                    {
                        if (Session["User"]!=null)
                        {
                            Users u = new Users();
                            Users obj = (Users)Session["User"];
                            c.UserID = Users.GetUserID(c.UserName);
                            c.RoleID = 3;
                            c.UpdateUsersInit(obj.UserID);
                            return RedirectToAction("Index", "Member");
                        }
                        else
                        {
                            TempData["Sukses"] = true;
                            return RedirectToAction("Login");
                        }
                    }
                    TempData["Deshtim"] =true;
                }
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Login(Models.Users c)
        {
            try
            {

                if (c.Login())
                {
                    Session["User"] = c;
                   
                    if (c.RoleID ==3)
                    {
                        return RedirectToAction("Make", "Book");
                    }
                    return RedirectToAction("Choose","Home");
                }
                else
                {
                    TempData["LoginError"] = true;
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

     
        
        [HttpGet]
        public ActionResult CreateGuest()
        {
            return View();
        }
        

        

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Role = Role.GetAll();
            return View(Models.Users.GetUserById(id));
        }

        [HttpPost]
        public ActionResult Edit(Models.Users c,string Role)
        {
            try
            {
                c.RoleID = int.Parse(Role);
                Users obj = (Users)Session["User"];
                if (ModelState.IsValid)
                {
                    if (c.UpdateUsers(obj.UserID))
                    {
                        return RedirectToAction("Index");
                    }
                }
                
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(Models.Users.GetUserById(id));
        }
        

        [HttpPost]
        public ActionResult Delete(Models.Users u,int id)
        {
            try
            {
                if (u.Delete(id))
                {
                    return RedirectToAction("Index","Member");
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            if (Session["User"] != null)
            {
                Session["User"] = null;
            }
           
            return RedirectToAction("Login","Member");
        }

    }
}
