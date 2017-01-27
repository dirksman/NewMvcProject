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

        // GET: TimeOff
        public ActionResult EmployeeDetail(int ID)
        {
            var EmpDet = context.GetEmployeeInfo(ID);
            return View(EmpDet);
        }
    }
}