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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var value = wm.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult WriterAdd()
        {
            var value = wm.GetList();

            return PartialView("WriterAddPopup", value);
        }
        [HttpPost]
        public ActionResult WriterAdd(Writer p)
        {
            wm.WriterAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult WriterDelete(int id)
        {
            var value = wm.GetById(id);
            wm.WriterDelete(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult WriterEdit(int id)
        {
            var value = wm.GetById(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult WriterEdit(Writer p)
        {
            wm.WriterEdit(p);
            return RedirectToAction("Index");
        }

    }
}
