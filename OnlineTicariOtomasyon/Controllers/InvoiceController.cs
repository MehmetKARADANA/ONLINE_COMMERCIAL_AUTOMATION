using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var Invoices =context.Invoices.ToList();
            return View(Invoices);
        }

        [HttpGet]
        public ActionResult AddInvoice() {
        
            return View();
        }

        [HttpPost]
        public ActionResult  AddInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid) {
            return View("AddInvoice");
            }
            invoice.InvoiceDate = DateTime.Now;
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringInvoice(int id) {
            var invoices=context.Invoices.Find(id);
            
        return View("BringInvoice",invoices);
                }

        public ActionResult UpdateInvoice(Invoice i)
        {
            if (!ModelState.IsValid)
            {
                return View(BringInvoice(i.InvoiceId));
            }
            var invoice = context.Invoices.Find(i.InvoiceId);
           
            invoice.OrderNo = i.OrderNo;
            invoice.SerialNo = i.SerialNo;
            invoice.TaxAdministration = i.TaxAdministration;
            invoice.Deliverer = i.Deliverer;
            invoice.Receiver = i.Receiver;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceItems(int id) {
            var items=context.InvoiceItems.Where(x=>x.InvoiceId==id).ToList();
            ViewBag.invoice = context.Invoices.Find(id);
        return View("InvoiceItems",items);
        }

        [HttpGet]
        public ActionResult AddInvoiceItem(int id) {
            var model = new InvoiceItem();
            model.InvoiceId=id;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddInvoiceItem(InvoiceItem i) { 
            i.SumItemPrice = 0;
            context.InvoiceItems.Add(i);
            context.SaveChanges();
            //faturaya döneceği için viewbag ile sağlanan invoice ı yollamam lazım
            var items = context.InvoiceItems.Where(x => x.InvoiceId == i.InvoiceId).ToList();
            ViewBag.invoice = context.Invoices.Find(i.InvoiceId);
            return View("InvoiceItems", items);

            //ViewBag.invoice=context.Invoices.Find(i.InvoiceId);
            //return RedirectToAction("InvoiceItems",,ViewBag.invoice); 
        }

        public ActionResult BringInvoiceItem(int id) {
            var item = context.InvoiceItems.Find(id);
            return View(item);
        }

        public ActionResult UpdateItem(InvoiceItem i) { 
            var item=context.InvoiceItems.Find(i.InvoiceItemId);
            item.Amount = i.Amount;
            item.Explanation = i.Explanation;
            item.UnitPrice = i.UnitPrice;
        

            context.SaveChanges();

            var items = context.InvoiceItems.Where(x => x.InvoiceId == item.InvoiceId).ToList();
            ViewBag.invoice = context.Invoices.Find(item.InvoiceId);
            return View("InvoiceItems",items);
        }
    }
}