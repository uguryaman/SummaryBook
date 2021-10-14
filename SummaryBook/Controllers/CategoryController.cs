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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
       
        public ActionResult Category()
        {
            var value = cm.GetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            var value = cm.GetList();

            return PartialView("Popup", value);
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category p)
        {
            cm.CategoryAdd(p);
            return RedirectToAction("Category");
        }
        public ActionResult CategoryDelete(int id)
        {
            var value = cm.GetById(id);
            cm.CategoryDelete(value);
            return RedirectToAction("Category");
        }
        [HttpGet]
        public ActionResult CategoryEdit(int id)
        {
            var value = cm.GetById(id);

            return View(value);
        }
        [HttpPost]
        public ActionResult CategoryEdit(Category p)
        {
            cm.CategoryEdit(p);
            return RedirectToAction("Category");
        }
    }
}
