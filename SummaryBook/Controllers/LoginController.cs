using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Entitylayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SummaryBook.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        UserManager um = new UserManager(new EfUserDal());

        // GET: Login
        [HttpGet]
        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginIndex(User p)
        {
            var value = um.IsLoginSuccess(p.UserMail, p.UserPassword);

            if (value == true)
            {
                FormsAuthentication.SetAuthCookie(p.UserMail, false);
                Session["UserMail"] = p.UserMail;
                return RedirectToAction("Category", "Category");
            }
            
            return RedirectToAction("LoginIndex", "Login");
        }
        [HttpGet]
        public ActionResult AddUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User p)
        {
            um.UserAdd(p);
            return RedirectToAction("LoginIndex");
        }

    }
}