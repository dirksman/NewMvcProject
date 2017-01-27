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
        protected Entities context = new Entities();
        // GET: Employee
        public ActionResult EmployeeList(int? page)
        {
            return View(Employees.People.OrderBy(a => a.LastName).ToPagedList(page ?? 1, 100));
        }

        // GET: TimeOff
        public ActionResult EmployeeDetail(int ID)
        {
            //var EmpDet = context.GetEmployeeInfo(ID);
            var EmpDet = context.uspUpdateLeaveBalances().Where(e => e.ID == ID).ToList();
            return View(EmpDet);
        }
    }
}