using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.Areas.Publica.Controllers
{
    public class ReservasController : PublicBaseController
    {
        // GET: Publica/Reservas
        public ActionResult Index(string usuario)
        {
            return View();
        }
    }
}