using OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context context=new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //login
        [HttpGet]
        public PartialViewResult partial1()
        {
                return PartialView();
        }

        [HttpPost]//login current
        public PartialViewResult partial1(Current c)
        {
            context.Currents.Add(c);
            context.SaveChanges();
            return PartialView();
        }


        //employe login
        public PartialViewResult partial2()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult CurrentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CurrentLogin(Current c)
        {
            var info = context.Currents.FirstOrDefault(x => x.CurrentMail == c.CurrentMail && x.CurrrentPassword==c.CurrrentPassword); ;
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.CurrentMail, false);
                Session["CurrentMail"]=info.CurrentMail.ToString();
                return RedirectToAction("Index","CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }//nesne al kayıt oluştur
    }
}