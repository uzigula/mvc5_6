using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using VirtualOffice.Web.XmlHelpers;

namespace VirtualOffice.Web.Controllers
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

        public JsonResult Provincias(string department)
        {
            return Json(_ubigeoHelper.GetProvincias(department).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Distritos(string department, string province)
        {
            return Json(_ubigeoHelper.GetDistritos(department, province).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}