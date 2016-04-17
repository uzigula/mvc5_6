using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YoVoy.Web.Models;


namespace YoVoy.Web.Controllers
{
    public class ErroresController : Controller
    {
        // GET: Errores
        public ActionResult NoEncontrado()
        {
            // que pagina pidio
            Response.StatusCode = 404;
            var model = new ErrorViewModel
            {
                Encabezado = "Oooops",
                IrAlHome = "Regresar al Inicio",
                Mensaje = "La pagina que buscabas no fue encontrada"
            };
            return View(model);
        }
        public ActionResult NoAutorizado()
        {
            Response.StatusCode = 403;
            var model = new ErrorViewModel
            {
                Encabezado = "Oooops",
                IrAlHome = "Ingresa...",
                Mensaje = "No tienes acceso",
                Controller = "Account",
                Action = "Login"
            };

            return View(model);
        }

        public ActionResult Inesperado()
        {
            Response.StatusCode = 500;
            var model = new ErrorViewModel
            {
                Encabezado = "Oooops",
                IrAlHome = "Regresar al Inicio",
                Mensaje = "Hicimos algo mal XD"
            };

            return View(model);
        }

    }
}