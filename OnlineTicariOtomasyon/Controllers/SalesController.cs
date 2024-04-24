using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context context = new Context();
        public ActionResult Index()
        {
         var sales=context.Sales.ToList();
            return View(sales);
        }

        [HttpGet]
        public ActionResult AddSale() {
            List<SelectListItem> currents= (from current in context.Currents.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = current.CurrentName+" "+current.CurrentSurname,
                                                  Value = current.CurrentId.ToString(),
                                              }).ToList();
            ViewBag.values2 = currents;
            List<SelectListItem> employes = (from employe in context.Employees.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = employe.EmployeName+" "+employe.EmployeSurname,
                                                 Value = employe.EmployeeId.ToString(),
                                             }).ToList();
            ViewBag.values3 = employes;
            List<SelectListItem> products = (from product in context.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = product.ProductName,
                                                 Value = product.ProductId.ToString(),
                                             }).ToList();
            ViewBag.values1 = products;

            return View();
        }

        [HttpPost]
        public ActionResult AddSale(Sale sale) {
            sale.Date = DateTime.Now;
            sale.SumPrice=Convert.ToDecimal(sale.Price)*Convert.ToDecimal(sale.Piece);
        context.Sales.Add(sale);
            context.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult BringSale(int id) {
            var sale = context.Sales.Find(id);
            List<SelectListItem> currents = (from current in context.Currents.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = current.CurrentName + " " + current.CurrentSurname,
                                                 Value = current.CurrentId.ToString(),
                                             }).ToList();
            ViewBag.values2 = currents;
            List<SelectListItem> employes = (from employe in context.Employees.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = employe.EmployeName + " " + employe.EmployeSurname,
                                                 Value = employe.EmployeeId.ToString(),
                                             }).ToList();
            ViewBag.values3 = employes;
            List<SelectListItem> products = (from product in context.Products.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = product.ProductName,
                                                 Value = product.ProductId.ToString(),
                                             }).ToList();
            ViewBag.values1 = products;
            return View(sale);
        }

        public ActionResult UpdateSale(Sale s)
        {
            var sale = context.Sales.Find(s.SalesId);
            sale.ProductId=s.ProductId;
            sale.CurrentId=s.CurrentId;
            sale.EmployeeId=s.EmployeeId;
            sale.Price=s.Price;
            sale.Piece=s.Piece;
            sale.SumPrice = s.Piece * s.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SaleDetails(int id) {  
            
            var sale= context.Sales.Find(id);
            return View(sale); }
    }
}