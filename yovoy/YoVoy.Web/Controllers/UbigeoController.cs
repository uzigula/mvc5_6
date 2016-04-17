using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using YoVoy.Web.XmlHelpers;

namespace YoVoy.Web.Controllers
{
    public class UbigeoController : Controller
    {
        private UbigeoHelper _ubigeoHelper;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _ubigeoHelper = new UbigeoHelper(Path.Combine(Server.MapPath("~/App_Data"), "Ubigeo.xml"));
        }

        // GET: Ubigeo
        public JsonResult Departamentos()
        {
            return Json(_ubigeoHelper.GetDepartamentos(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Provincias(string departamento)
        {
            return Json(_ubigeoHelper.GetProvincias(departamento).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Distritos(string departamento, string provincia)
        {
            return Json(_ubigeoHelper.GetDistritos(departamento, provincia).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}