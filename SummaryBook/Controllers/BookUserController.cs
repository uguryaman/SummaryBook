using BusinessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummaryBook.Controllers
{
    public class BookUserController : Controller
    {
        // GET: BookUser
        BookUserManager bum = new BookUserManager(new EfBookUserDal());
        SummaryManager sm = new SummaryManager(new EfSummaryDal());


        public ActionResult BookUserIndex()//kullanıcılarıngönderdiği özetleri görüntüleme sayfası
        {
            var val = bum.GetList();
            string p = (string)Session["UserMail"];
            var sayı = sm.GetListUserSummary(p).Count();
            ViewBag.say = sayı;
            return View(val);
        }
        public ActionResult SummaryPage(int id)//kullanıcıların gönderdiği özetin içerğini görüntüler
        {
            var value = bum.GetById(id);
            return View(value);
        }
    }
}