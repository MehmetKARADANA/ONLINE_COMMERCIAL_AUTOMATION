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

            var value5=context.Products.Sum(x=>x.Stock).ToString();
            ViewBag.d5 = value5;

            var value6=(from x in context.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;

            var value7=context.Products.Count(x=>x.Stock <=20).ToString();
            ViewBag.d7 = value7;

            //var value8 = context.Products.Max(x=>x.SalePrice).ToString(); azalan sıra
            var value8 = (from x in context.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;
                                                                           //artan sıra
            var value9 = (from x in context.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;

            var value10 = context.Products.GroupBy(x => x.Brand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();//y.Key, gruplama işlemi sırasında anahtar olarak kullanılan değer
            ViewBag.d10 = value10;

            var value11 = context.Products.Count(x => x.ProductName=="Buzdolabı").ToString();
            ViewBag.d11 = value11;

            var value12 = context.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.d12 = value12;

            var value13 =context.Products.Where (u=>u.ProductId==context.Sales.GroupBy(x => x.ProductId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()).Select(u=>u.ProductName).FirstOrDefault();//y.Key, gruplama işlemi sırasında anahtar olarak kullanılan değer
            ViewBag.d13 = value13;

            var value14 = context.Sales.Sum(x=>x.SumPrice).ToString();
            ViewBag.d14 = value14;

            //DateTime today = DateTime.Today;
            //var value15 = context.Sales.Count(x => x.Date == today).ToString();
            //ViewBag.d15 = value15;

            DateTime today = DateTime.Today;
            var value15 = context.Sales
                                .Count(x => x.Date.Year == today.Year && x.Date.Month == today.Month && x.Date.Day == today.Day)
                                .ToString();
            ViewBag.d15 = value15;

            var value16 = (from x in context.Sales
                           where x.Date.Year == today.Year && x.Date.Month == today.Month && x.Date.Day == today.Day
                           select x.SumPrice)
              .DefaultIfEmpty(0) // Varsayılan değeri 0 olarak ayarlar
              .Sum() // Toplama işlemi
              .ToString();
            ViewBag.d16 = value16;



            return View();
        }


    }
}