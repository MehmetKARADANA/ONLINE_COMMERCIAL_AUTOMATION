using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context context=new Context();
        public ActionResult Index()
        {
            var department=context.Departments.Where(x=>x.State==true).ToList();
            return View(department);
        }
        [HttpGet]
        public ActionResult AddDepartman() {
        return View();
        }

        [HttpPost]
        public ActionResult AddDepartman(Department d)
        {
            d.State = true;
            context.Departments.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult RemoveDepartman(int id) {
            var departman = context.Departments.Find(id);
            departman.State = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringDepartman(int id) { 
            var departman=context.Departments.Find(id);

        return View(departman); 
        }

        public ActionResult UpdateDepartman(Department d)
        {
            var departman = context.Departments.Find(d.DepartmentId);
            departman.DepartmentName = d.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id) {
        var departman= context.Departments.Find(id);
        ViewBag.value=departman.DepartmentName;
        var employe =context.Employees.Where(x=>x.DepartmentId==id).ToList();
            return View(employe);
        }

        public ActionResult SalesDepartmentEmploye(int id)
        {
            var employe=context.Employees.Find(id);
            ViewBag.value = employe.EmployeName+" "+employe.EmployeSurname;

            var sales = context.Sales.Where(x => x.EmployeeId == id).ToList();
            return View(sales); 
        }


    }
}