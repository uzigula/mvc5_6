using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TiendaMusica.Web.Helpers;

namespace TiendaMusica.Web.Controllers
{
    public class UbigeoController : Controller
    {
        // GET: Ubigeo
        private UbigeoHelper ubigeoHelper;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ubigeoHelper = new UbigeoHelper(Path.Combine(Server.MapPath("~/App_data"), "Ubigeo.xml"));

        }

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Departamentos()
        {
            return Json(ubigeoHelper.TraerDepartamentos(), 
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Provincias(string departamento)
        {
            return Json(ubigeoHelper.TraerProvincias(departamento), 
                        JsonRequestBehavior.AllowGet);
        }


        public JsonResult Distritos(string departamento, string provincia)
        {
            return Json(ubigeoHelper.TraerDistritos(departamento, provincia), 
                JsonRequestBehavior.AllowGet);

        }
    }
}