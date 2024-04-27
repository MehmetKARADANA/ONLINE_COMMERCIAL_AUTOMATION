using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context = new Context();
        public ActionResult Index()
        {
            var value1=context.Currents.Count().ToString();
            ViewBag.d1=value1;

            var value2 = context.Products.Count().ToString();
            ViewBag.d2 = value2;

            var value3 = context.Employees.Count().ToString();
            ViewBag.d3 = value3;

            var value4 = context.Categories.Count().ToString();
            ViewBag.d4 = value4;
            return View();
        }


    }
}