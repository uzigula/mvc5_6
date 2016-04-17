using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoVoy.Web.Models;
using YoVoy.Servicios.Impl;
using YoVoy.Servicios.Dtos;
using AutoMapper;
using log4net;

namespace YoVoy.Web.Controllers
{
    public class BuscarController : Controller
    {
        private ServicioBusqueda _servicioBusqueda;
        private ILog logger;
        // GET: Buscar
        public BuscarController()
        {
            _servicioBusqueda = new ServicioBusqueda();
            logger = LogManager.GetLogger("BuscaEventos");
        }
        public ActionResult Index()
        {
            return View(new BuscaEventosViewModel());
        }

        //public ActionResult Buscar(string busqueda)
        public PartialViewResult Buscar(string busqueda)
        {
            logger.InfoFormat("Origen [BuscarController.Buscar] Se realizo la busqueda de: {0}", busqueda);
            IEnumerable<EventoDto> eventos;
            if (string.IsNullOrEmpty(busqueda))
                eventos = new List<EventoDto>();
            else
                eventos = _servicioBusqueda.Buscar(busqueda);
            // version del postback
            // return View("Index",
            //     new BuscaEventosViewModel()
            //     {
            //         Busqueda = busqueda,
            //         Eventos = Mapper.Map<IEnumerable<EventoDto>, IList<ListaEventosViewModel>>(eventos)
            //     }
            //);

            return PartialView("_EventosEncontrados", 
                Mapper.Map<IEnumerable<EventoDto>, IList<ListaEventosViewModel>>(eventos));

        }

        public ActionResult Inscribir(int eventoId, string eventoTitulo)
        {
            return PartialView("_Inscripcion",
                new InscripcionEditViewModel
                {
                    Titulo = $"Inscribirse a: {eventoTitulo}",
                    EventoId = eventoId
                });
        }

        public ActionResult Inscripcion(InscripcionEditViewModel modelo)
        {
            return PartialView("_ListaInscritos",
                new ListaInscritosViewModel());
        }

        public ActionResult Exportar (string BusquedaAnterior)
        {
            logger.InfoFormat("Se exporto la busqueda de: {0}", BusquedaAnterior);
            IEnumerable<EventoDto> eventos;
            if (string.IsNullOrEmpty(BusquedaAnterior))
                eventos = new List<EventoDto>();
            else
                eventos = _servicioBusqueda.Buscar(BusquedaAnterior);

            // codigo del Reporte


            return View();

        }
    }
}