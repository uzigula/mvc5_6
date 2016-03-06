using Seguridad.Models;
using Seguridad.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Seguridad.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
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

    }
}