using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context context= new Context();
        public ActionResult Index()
        {
            var categoryies = context.Categories.ToList();
            return View(categoryies);
        }

        [HttpGet]
        public ActionResult AddCategory() {
        return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            context.Categories.Add(c);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveCategory(int id) { 

            var ctg=context.Categories.Find(id);
            context.Categories.Remove(ctg);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var ctg = context.Categories.Find(id);
            return View("UpdateCategory",ctg);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            var ctg = context.Categories.Find(c.CategoryId);
            ctg.CategoryName = c.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}