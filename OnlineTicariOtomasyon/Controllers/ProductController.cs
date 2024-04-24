using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        Context context=new Context();
        // GET: Product
        public ActionResult Index()
        {
            var products=context.Products.Where(x=>x.State==true).ToList();
            return View(products);
        }

        [HttpGet] 
        public ActionResult AddProduct() {//tabloyu dönerek elemanlarını selectlistitema atıyoruz
            List<SelectListItem> categorys= (from category in context.Categories.ToList() 
                                             select new SelectListItem
            {
                Text=category.CategoryName,
                Value=category.CategoryId.ToString(),
            }).ToList();
            ViewBag.values = categorys;                
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product) { 
        
            product.State = true;
            context.Products.Add(product);
            context.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult RemoveProduct(int id) {

        var product=context.Products.Find(id);
            product.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //bu defa beginform ile yapıcam get post methodu yerine farklı birşeyde tam aklımda kalsınd diye

        public ActionResult BringProduct(int id) {
        var product= context.Products.Find(id);
            List<SelectListItem> categorys = (from category in context.Categories.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = category.CategoryName,
                                                  Value = category.CategoryId.ToString(),
                                              }).ToList();
            ViewBag.values = categorys;
            return View(product);
        }

        public ActionResult UpdateProduct(Product p) {
            var product = context.Products.Find(p.ProductId);
            product.ProductName = p.ProductName;
            product.Brand = p.Brand;
            product.Stock = p.Stock;
            product.PurchasePrice = p.PurchasePrice;
            product.SalePrice = p.SalePrice;
            product.CategoryId = p.CategoryId;
            product.Image = p.Image;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList() { 
            var products = context.Products.ToList();
            return View(products); 
        }

    }
}