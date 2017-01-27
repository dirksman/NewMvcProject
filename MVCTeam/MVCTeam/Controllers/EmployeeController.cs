using MVCTeam.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTeam.Controllers
{
    public class EmployeeController : Controller
    {
        private Entities Employees = new Entities();
        // GET: Employee
        public ActionResult EmployeeList()
        {
            //var Emp = Employees.People.Select(a => new { a.FirstName, a.LastName, a.BusinessEntityID }).ToList();
            //var Emp = Employees.uspUpdateLeaveBalances()
            //    .Select(e => new { e.FirstName, e.LastName, e.ID }).ToList();

            return View(Employees.uspUpdateLeaveBalances().ToList());
        }

        public ActionResult EmployeeEdit(int id)
        {
            //var Emp = Employees.People.Select(a => new { a.FirstName, a.LastName, a.BusinessEntityID }).ToList();
            //var Emp = Employees.uspUpdateLeaveBalances()
            //    .Select(e => new { e.FirstName, e.LastName, e.ID }).ToList();

            var ds = Employees.uspUpdateLeaveBalances().SingleOrDefault(c => c.ID == id);
            return View(ds);
        }
    }
}