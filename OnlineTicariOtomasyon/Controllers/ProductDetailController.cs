using OnlineTicariOtomasyon.Models;
using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context=new Context();
        public ActionResult Index()
        {
            CustomModel1 cs = new CustomModel1();
             cs.Products= context.Products.Where(x => x.State == true).ToList(); 
             cs.Details = context.ProductsDetail.ToList();
            return View(cs);
        }
    }
}