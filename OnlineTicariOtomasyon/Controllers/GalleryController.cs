using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context context=new Context();
        public ActionResult Index()
        {
            var products=context.Products.Where(x=>x.State==true).ToList();
            return View(products);
        }
    }
}