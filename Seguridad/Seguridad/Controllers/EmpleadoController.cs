using Seguridad.Models;
using Seguridad.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguridad.Filtros;
using System.Web.Routing;
using System.Threading;
using System.Globalization;

namespace Seguridad.Controllers
{
    [CustomAuthorize]
    public class EmpleadoController : BaseController
    {
        // GET: Empleado
        //onactionexecuting
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Registrar()
        {

            //onresultexecuting
            return View();
            //onactionexecuted    
        }

        //onresultexecuted

        [HttpPost]
        [CustomAuthorize(Roles="Admin")]
        public ActionResult Registrar(EmpleadoRegistrar empleado)
        {
            if (ModelState.IsValid)
            {
                var validador = new EmpleadoRegistrarValidator();
                var results = validador.Validate(empleado);
                if (results.IsValid) return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", results.Errors[0].ErrorMessage);
            }
            return View();
        }


        public ActionResult Ver()
        {
            return View(new EmpleadoRegistrar { Nombre = "Uzi",
                Apellidos = "Mamani",
                Cargo = "Programador",
                Sueldo = 3500,
                Descuentos = 0 });
        }
    }
}