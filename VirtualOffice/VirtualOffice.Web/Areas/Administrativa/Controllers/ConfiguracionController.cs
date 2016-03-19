using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "Admin,Empleado")]
    public class ConfiguracionController : Controller
    {
        // GET: Administrativa/Configuracion
        public ActionResult Index()
        {
            return View();
        }
    }
}