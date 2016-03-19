using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualOffice.Servicios.Configuracion;

namespace VirtualOffice.Web.Controllers
{
    public class ListasController : Controller
    {
        // GET: Listas
        private ServicioConfiguracion _servicioConfiguracion;
        public ListasController()
        {
            _servicioConfiguracion = new ServicioConfiguracion();
        }
        
        public ActionResult Sucursales()
        {
            return Json(_servicioConfiguracion.Sucursales(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Salas(int sucursal)
        {
            return Json(_servicioConfiguracion.Salas(sucursal), JsonRequestBehavior.AllowGet);
        }

    }
}