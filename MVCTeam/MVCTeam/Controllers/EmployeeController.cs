using MVCTeam.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
     

namespace MVCTeam.Controllers
{
    public class EmployeeController : Controller
    {
        private Entities Employees = new Entities();
        // GET: Employee
        public ActionResult EmployeeList(int? page)
        {
            return View(Employees.People.OrderBy(a => a.LastName).ToPagedList(page ?? 1, 100));
        }
    }
}