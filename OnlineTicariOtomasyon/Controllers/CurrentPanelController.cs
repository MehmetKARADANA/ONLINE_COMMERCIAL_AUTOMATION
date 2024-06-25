using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        Context context = new Context();
        // GET: CurrentPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = context.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            if (values == null)
            {
                return HttpNotFound("Current user not found.");
            }
            return View(values);
        }

        [Authorize]
        public ActionResult Index2() {
            var mail = (string)Session["CurrentMail"];
            var current = context.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            return View(current); 
        }

        [Authorize]
        public ActionResult UpdateCurrent(Current c) {
            var mail = (string)Session["CurrentMail"];
            var current = context.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            current.CurrentName = c.CurrentName;
            current.CurrentSurname = c.CurrentSurname;
            current.CurrentCity = c.CurrentCity;
            current.CurrrentPassword = c.CurrrentPassword;
            context.SaveChanges();
        return RedirectToAction("Index");
        }

        public ActionResult Orders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = context.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = context.Sales.Where(x => x.CurrentId == id).ToList();
            return View(values);
        }
    }
}