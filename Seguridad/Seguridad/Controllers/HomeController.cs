using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Seguridad.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult CambiarCultura(string culturaSeleccionada)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(culturaSeleccionada);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culturaSeleccionada);
            Session["ActualCultura"] = culturaSeleccionada;
            return View("Index");
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}