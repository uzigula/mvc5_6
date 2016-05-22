using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Infraestructura;
using TiendaMusica.Logica;
using TiendaMusica.Logica.Comun;
using TiendaMusica.Logica.ViewModels;

namespace TiendaMusica.Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly TiendaConsultas tienda;

        public AlbumController()
        {
            tienda = ConstructorServicios.TiendaConsultas();
        }

        public ActionResult Editar(string artista, string album)
        {

            return View(tienda.AlbumParaEditar(artista, album));
        }

        [HttpPost]
        public ActionResult Editar(AlbumEditViewModel model, HttpPostedFileBase image)
        {
            string ruta = Server.MapPath("~/imagenes/Albums");
            try
            {
                Imagen imagen = ObtenerImagen(image, ruta);
                tienda.GrabarAlbum(model, imagen);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        private Imagen ObtenerImagen(HttpPostedFileBase image, string ruta)
        {
            if (image == null) return null;
            var stream = new MemoryStream();
            image.InputStream.CopyTo(stream);
            return new Imagen(
                stream,
                image.FileName,
                image.ContentType,
                ruta);
        }
    }
}