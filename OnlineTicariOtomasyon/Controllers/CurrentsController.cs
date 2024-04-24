using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentsController : Controller
    {
        // GET: Currents
        Context context=new Context();
        public ActionResult Index()
        {
            var currents=context.Currents.Where(x=>x.State==true).ToList();
            return View(currents);
        }


        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCurrent(Current c)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCurrent");
            }
            c.State = true;
            context.Currents.Add(c);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult RemoveCurrent(int id) {
            var current=context.Currents.Find(id);
            current.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCurrent(int id)
        {
            var current = context.Currents.Find(id);
            return View(current);
        }
        public ActionResult UpdateCurrent(Current c) {

            if (!ModelState.IsValid) {
                return View("BringCurrent");
                    
            }
            var current = context.Currents.Find(c.CurrentId);
            current.CurrentName = c.CurrentName;
            current.CurrentSurname = c.CurrentSurname;
            current.CurrentCity = c.CurrentCity;
            current.CurrentMail = c.CurrentMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SalesCurrent(int id)
        {
            var sales=context.Sales.Where(x=>x.CurrentId==id).ToList();
            ViewBag.values = context.Currents.Find(id).CurrentName +" "+ context.Currents.Find(id).CurrentSurname; 
            return View(sales);
        }
    }
}