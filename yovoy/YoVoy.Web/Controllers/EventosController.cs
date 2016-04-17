using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoVoy.Servicios.Dtos;
using YoVoy.Servicios.Impl;
using YoVoy.Web.Models;

namespace YoVoy.Web.Controllers
{
    public class EventosController : Controller
    {
        private ServicioEventos servicioEventos;
        public EventosController()
        {
            servicioEventos = new ServicioEventos();
        }
        // GET: Eventos
        public ActionResult Ver(int id)
        {
            EventoDto evento = servicioEventos.Traer(id);

            return View(
                Mapper.Map<EventoDto,EventoDetalleViewModel>(evento)
                );
        }

        public PartialViewResult Inscribirse(int id)
        {
            EventoDto evento = servicioEventos.Traer(id);
            var model = new InscribirseViewModel()
            {
                Titulo = evento.Titulo,
                EventoId = evento.EventoId
            };
            return PartialView("_Inscripcion",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inscribirse(InscribirseViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    servicioEventos.Inscribir(new InscripcionDto()
                    {
                        EventoId = model.EventoId,
                        Asistente = model.NombreAsistente,
                        Entradas = model.NumeroEntradas
                    });
                }
                ModelState.AddModelError("", "Hubo un Error");
            }
            catch (Exception ex)
            {
                throw;
            }

            return RedirectToAction("Ver", "Eventos", new { id = model.EventoId });
        }

        public ActionResult Nuevo()
        {
            return View(new EventoNuevoViewModel());
        }
        [HttpPost]
        public ActionResult Nuevo(EventoNuevoViewModel model)
        {
            if (!ModelState.IsValid) return HttpNotFound();
            return View(new EventoNuevoViewModel());
        }

    }
}