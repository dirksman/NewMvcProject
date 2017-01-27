using MVCTeam.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTeam.Controllers
{
    public class TimeOffController : Controller
    {
        protected Entities context;
        public DbSet<uspUpdateLeaveBalances_Result> Employee { get; set; }


        public IQueryable<uspUpdateLeaveBalances_Result> GetEmployeeInfo(int BSID)
        {
             return Employee.Where(e=>e.ID==BSID);
        }

        
        // GET: TimeOff
        public ActionResult EmployeeDetail()
        {
            var EmpDet = context.
            return View();
        }
    }
}