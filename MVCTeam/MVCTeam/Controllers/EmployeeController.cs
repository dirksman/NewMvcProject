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
        protected Entities context = new Entities();
        // GET: Employee
        public ActionResult EmployeeList(int? page)
        {
            return View(context.People.OrderBy(a => a.LastName).ToPagedList(page ?? 1, 100));
        }

        // GET: TimeOff
        public ActionResult EmployeeDetail(int ID)
        {
            //var EmpDet = context.GetEmployeeInfo(ID);
            var EmpDet = context.uspUpdateLeaveBalances().Where(e => e.ID == ID).ToList();
            return View(EmpDet);
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