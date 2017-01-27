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
        public Entities db = new Entities();

        // GET: Employee
        public ActionResult EmployeeList(int? page)
        {
            return View(db.People.OrderBy(a => a.LastName).ToPagedList(page ?? 1, 100));
        }

        // GET: TimeOff
        public ActionResult EmployeeDetail(int ID)
        {
            //var EmpDet = context.GetEmployeeInfo(ID);
            var EmpDet = db.uspUpdateLeaveBalances().Where(e => e.ID == ID).ToList();
            return View(EmpDet);
        }

        public ActionResult EmployeeEdit(int id)
        {
            //var Emp = Employees.People.Select(a => new { a.FirstName, a.LastName, a.BusinessEntityID }).ToList();
            //var Emp = Employees.uspUpdateLeaveBalances()
            //    .Select(e => new { e.FirstName, e.LastName, e.ID }).ToList();

            var ds = db.uspUpdateLeaveBalances().SingleOrDefault(c => c.ID == id);
            return View(ds);
        }


        [HttpPost]
        public ActionResult EmployeeEdit(int id, FormCollection form)
        {
            //var Emp = Employees.People.Select(a => new { a.FirstName, a.LastName, a.BusinessEntityID }).ToList();
            //var Emp = Employees.uspUpdateLeaveBalances()
            //    .Select(e => new { e.FirstName, e.LastName, e.ID }).ToList();

            var ds = (from i in db.Employees
                     where i.BusinessEntityID == id
                     select i).Single();

                short sickHrs = short.Parse(form["SickHrs"]);
                short vacHrs = short.Parse(form["VacHrs"]);

                ds.SickLeaveHours = sickHrs;
                ds.VacationHours = vacHrs;

            try
            {
                db.SaveChanges();
            }
            catch (Exception e)
            {
              
            }

            return RedirectToAction("EmployeeList");
          
        }
    }
}