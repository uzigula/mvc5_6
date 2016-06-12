using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Web.Models;

namespace TiendaMusica.Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View(new UsuarioEditViewModel());
        }

        [HttpPost]
        public ActionResult Grabar(UsuarioEditViewModel modelo)
        {
            return View("Index", new UsuarioEditViewModel());
        }


    }
}