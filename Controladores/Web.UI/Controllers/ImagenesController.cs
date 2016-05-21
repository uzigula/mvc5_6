using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Web.UI.Utilidades;

namespace Web.UI.Controllers
{
    public class ImagenesController : Controller
    {

        public ActionResult Subir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Subir(HttpPostedFileBase archivo)
        {
            string nombreArchivo =
                archivo.FileName.ObtenerMD5()
                + Path.GetExtension(archivo.FileName);

            if (EsImagen(archivo.ContentType))
                GrabarImagen(archivo, nombreArchivo);
            else
                archivo.SaveAs(
                    Path.Combine(Server.MapPath("~/archivos"),
                               nombreArchivo));

            /// poner el codigo de Grabar el archivo
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Multiples()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Multiples(IEnumerable<HttpPostedFileBase> archivos)
        {
            foreach (var archivo in archivos)
            {
                string nombreArchivo =
                      archivo.FileName.ObtenerMD5()
                      + Path.GetExtension(archivo.FileName);

                if (EsImagen(archivo.ContentType))
                    GrabarImagen(archivo, nombreArchivo);
                else
                    archivo.SaveAs(
                        Path.Combine(Server.MapPath("~/archivos"),
                                   nombreArchivo));
            }
            return RedirectToAction("Index", "Home");
        }

        private bool EsImagen(string contentType)
        {
            return contentType.Contains("image");
        }

        private void GrabarImagen(HttpPostedFileBase archivo, string nombreArchivo)
        {
            MemoryStream ms = new MemoryStream();
            archivo.InputStream.CopyTo(ms);
            Imagen imagen = new Imagen(ms, 
                archivo.FileName, 
                archivo.ContentType, 
                Server.MapPath("~/archivos"));
            imagen.Grabar(nombreArchivo, Server.MapPath("~/archivos/thumbnails"));
        }
    }
}
