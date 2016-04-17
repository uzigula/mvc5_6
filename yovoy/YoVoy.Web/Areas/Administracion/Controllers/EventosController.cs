using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoVoy.Servicios.Dtos;
using YoVoy.Servicios.Impl;
using YoVoy.Web.Filtros;
using YoVoy.Web.Models;

namespace YoVoy.Web.Areas.Administracion.Controllers
{
    [MiAutorizacion]
    public class EventosController : Controller
    {
        private readonly ServicioEventos eventos;
        // GET: Administracion/Eventos
        public EventosController()
        {
            this.eventos = new ServicioEventos();
        }

        
        public ActionResult Lista()
        {
            var lista = eventos.TraerTodos();
            return View(Mapper.Map <IEnumerable<EventoDto>, IList<ListaEventosViewModel>>(lista));
        }
    }
}