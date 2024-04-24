using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Classes;

namespace OnlineTicariOtomasyon.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
         Context context=new Context();
        public ActionResult Index()
        {
            var employe=context.Employees.ToList();
            return View(employe);
        }

        [HttpGet]
        public ActionResult AddEmployee() {
            List<SelectListItem> departman = (from dep in context.Departments.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = dep.DepartmentName,
                                                  Value =dep.DepartmentId.ToString(),
                                              }).ToList();
            ViewBag.values1 = departman;
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringEmployee(int id)
        {
            var employe = context.Employees.Find(id);
            List<SelectListItem> departman = (from dep in context.Departments.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = dep.DepartmentName,
                                                  Value = dep.DepartmentId.ToString(),
                                              }).ToList();
            ViewBag.values1 = departman;
            return View(employe);
        }

        public ActionResult UpdateEmployee(Employee employee)
        {
            var emp=context.Employees.Find(employee.EmployeeId);
            emp.EmployeName = employee.EmployeName;
            emp.EmployeSurname= employee.EmployeSurname;
            emp.EmployeImage = employee.EmployeImage;
            emp.DepartmentId = employee.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}