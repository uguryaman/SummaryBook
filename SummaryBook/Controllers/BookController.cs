using BusinessLayer.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using Entitylayer.Concreate;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SummaryBook.Controllers
{

    public class BookController : Controller
    {
        BookUserManager bum = new BookUserManager(new EfBookUserDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        UserManager um = new UserManager(new EfUserDal());
        BookManager bm = new BookManager(new EfBookDal());
        SummaryManager sm = new SummaryManager(new EfSummaryDal());



        Context c = new Context();
        // GET: Book
        [AllowAnonymous]
        [HttpGet]
        public ActionResult BookIndex(string k ,int p = 1)//Ana sayfa görünümü
        {
            var deger = bm.GetList();
            // var deger = from d in c.Books select d;
            if (!string.IsNullOrEmpty(k))
            {
                // deger = deger.Where(m => m.BookName.Contains(k));
               deger = bm.GetListSearchBook(k);
            }
            return View(deger.ToPagedList(p, 10));
        
        }
        public ActionResult AdminBookIndex(string k)//Tüm kitaplar sayfası
        {
           // var value = bm.GetList();
            //var deger = from d in c.Books select d;
            var deger = bm.GetList();

            if (!string.IsNullOrEmpty(k))
            {
                //deger = deger.Where(m => m.BookName.Contains(k));
                deger = bm.GetListSearchBook(k);

            }
            return View(deger);
        }
        public ActionResult AddSummary()//Kitap Ekleme sayfası
        {
           

            List<SelectListItem> ctg = (from i in cm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.CategoryName ,
                                            Value = i.CategoryId.ToString()
                                        }
                                     ).ToList();
            ViewBag.categories = ctg;

            List<SelectListItem> DrpWriter = (from i in wm.GetList()
                                        select new SelectListItem
                                        {
                                            Text = i.WriterName+" "+i.WriterSurname,
                                            Value = i.WriterId.ToString()
                                        }
                                    ).ToList();
            ViewBag.writers = DrpWriter;

            List<SelectListItem> user = (from i in um.GetList()
                                         select new SelectListItem
                                         {
                                             Text = i.UserName + " " + i.UserSurname,
                                             Value = i.UserId.ToString()
                                         }
                                  ).ToList();
            ViewBag.users = user;
            return View();
        }
        public ActionResult AddSummery(Book b)
        {
            if (Request.Files.Count > 0)
            {
                string fileName = Path.GetFileName(Request.Files[0].FileName);
                string expansion = Path.GetExtension(Request.Files[0].FileName);
                string path = "/Images/" + fileName;
                Request.Files[0].SaveAs(Server.MapPath(path));
                b.BookPicture = "/Images/" + fileName;
            }
            //string p = (string)Session["UserMail"];
            //var userId = c.Users.Where(x => x.UserMail == p).Select(y => y.UserId).FirstOrDefault();

            //b.UserId = userId;

            bm.BookAdd(b);
            return RedirectToAction("AdminBookIndex");
        }

        public ActionResult AddSummaryUser()//kullanıcı özet gönderme sayfası
        {
            string p = (string)Session["UserMail"];
            var username = c.Users.Where(x => x.UserMail == p).Select(y => y.UserName).FirstOrDefault();
            ViewBag.name = username;
            return View();
        }
        [HttpPost]
        public ActionResult AddSummaryUser(BookUser p)
        {
            string a = (string)Session["UserMail"];
            var value = um.GetByMail(a);
            p.BookUserUser = value.UserName + " " + value.UserSurname;
            p.BookUserAddTime =DateTime.Parse(DateTime.Now.ToShortDateString());
            
            bum.BookAdd(p);
            return RedirectToAction("AdminBookIndex");
        }
        public ActionResult UsersBook()//kullanıcıların özetleri
        {
            string p = (string)Session["UserMail"];
            var user = um.GetByMail(p);
            int id = user.UserId;
            var value = sm.GetListBookSummary(id);
            return View(value);
        }

    }
}
