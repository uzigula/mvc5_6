using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.Areas.Publica.Controllers
{
    public class EstadoCuentaController : PublicBaseController
    {
        // GET: Publica/EstadoCuenta
        public ActionResult Index(string usuario)
        {
            return View();
        }
    }
}