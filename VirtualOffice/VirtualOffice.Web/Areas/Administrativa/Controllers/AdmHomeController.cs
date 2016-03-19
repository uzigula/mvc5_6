using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "Admin,Empleado")]
    public class AdmHomeController : Controller
    {
        // GET: Administrativa/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}