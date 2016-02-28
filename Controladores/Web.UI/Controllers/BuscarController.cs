using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.UI.Models;
using Web.UI.Servicios;

namespace Web.UI.Controllers
{
    public class BuscarController : Controller
    {
        private readonly ServicioEventos servicioEventos;
        public BuscarController()
        {
            servicioEventos = new ServicioEventos();
        }

        public ActionResult Index()
        {
            return View(new BuscarEventoViewModel());
        }

        [HttpPost]
        public ActionResult Buscar(BuscarEventoViewModel buscar)
        {
            List<EventosListaViewModel> 
                eventos = servicioEventos.Buscar(buscar.Busqueda);

            buscar.Eventos = eventos;
            return View("Index", buscar);
        }

        public ActionResult Partial()
        {
            //return View("IndexSinJs");
            return PartialView("_Index", new List<BuscarEventoViewModel>());
        }

        public ActionResult PartialNoPartial()
        {
            //return View("IndexSinJs");
            return View("_Index", new List<BuscarEventoViewModel>());
        }

    }
}