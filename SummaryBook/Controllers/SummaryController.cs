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
    public class SummaryController : Controller
    {
        SummaryManager sm = new SummaryManager(new EfSummaryDal());
        UserManager um = new UserManager(new EfUserDal());
        BookManager bm = new BookManager(new EfBookDal());
        // GET: Summary
        public ActionResult SummaryAdd()
        {
            List<SelectListItem> ctg = (from i in bm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.BookName,
                                            Value = i.BookId.ToString()
                                        }
                                    ).ToList();
            ViewBag.book = ctg;

            List<SelectListItem> used = (from i in um.GetList()
                                         select new SelectListItem
                                         {
                                             Text = i.UserName + " " + i.UserSurname,
                                             Value = i.UserId.ToString()
                                         }
                                   ).ToList();
            ViewBag.user = used;
            return View();
        }
        [HttpPost]
        public ActionResult SummaryAdd(Summary p)
        {
            p.SummaryDate= DateTime.Parse(DateTime.Now.ToShortDateString());
            sm.SummaryAdd(p);
            return RedirectToAction("BookUserIndex", "BookUser");
        }
        public ActionResult Summary(int id)//Tüm Kitaplarda Özet görüntüleme sayfası 
        {
            var x = bm.GetById(id);
            var bokname = x.BookName;
            ViewBag.bookName = bokname;
            var value = sm.GetListBookSummary(id);
            return View(value);
        }
        public ActionResult UserSummary()
        {
            return View();
        }
    }
}