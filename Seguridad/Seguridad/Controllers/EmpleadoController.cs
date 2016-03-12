using Seguridad.Models;
using Seguridad.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seguridad.Filtros;

namespace Seguridad.Controllers
{
    [CustomAuthorize]
    public class EmpleadoController : Controller
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

    }
}