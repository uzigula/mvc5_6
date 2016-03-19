using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualOffice.Web.Areas.Administrativa.Models;
using VirtualOffice.Web.Models;
using VirtualOffice.Servicios.Reservas;
using VirtualOffice.Servicios.Excepciones;
using VirtualOffice.Servicios.Reservas.Dtos;
using AutoMapper;

namespace VirtualOffice.Web.Areas.Administrativa.Controllers
{
    [Authorize(Roles = "Empleado,Admin")]
    public class ReservasController : Controller
    {
        private readonly ServicioReserva servicioReservas;
        // GET: Administrativa/Reserva
        private ViewModelBuilder builder;
        public ReservasController()
        {
            builder = new ViewModelBuilder();
            servicioReservas = new ServicioReserva();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nueva()
        {

            //TODO: traer data Real
            ReservaViewModel reserva = builder.ReservaViewModel();

            return View(reserva);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nueva(ReservaGrabarViewModel reserva)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Debemos codificar la reserva
                    reserva.ArreglarHoras();
                    ReservaDto reservaDto = 
                        Mapper.Map<ReservaGrabarViewModel, ReservaDto>(reserva);
                    servicioReservas.Reservar(reservaDto);
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                // reconstruir el objeto anterior <ReservaViewModel>
                ModelState.AddModelError("", "Hubo Error en el Modelo");
                return View(builder.ReservaViewModel(reserva));
            }
            catch (ErrorEnReserva ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(builder.ReservaViewModel(reserva));
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}