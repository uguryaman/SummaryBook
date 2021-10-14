using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SummaryBook.Controllers
{
    public class UsersController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());

        // GET: Users
        [HttpGet]
        public ActionResult AddUser()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            um.UserAdd(p);
            return RedirectToAction("UserIndex");
        }
        [Authorize(Roles = "a")]

        public ActionResult UserIndex()
        {
            var value = um.GetList();
            return View(value);
        }
        public ActionResult DeleteUser(int id)
        {
            var value = um.GetById(id);
            um.UserDelete(value);
            return RedirectToAction("UserIndex");
        }
    }
}