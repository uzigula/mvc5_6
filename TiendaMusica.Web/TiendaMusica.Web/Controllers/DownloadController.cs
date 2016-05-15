using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TiendaMusica.Logica;

namespace TiendaMusica.Web.Controllers
{
    public class DownloadController : Controller
    {
        private readonly ReporteSimple gestorArchivos;

        public DownloadController()
        {
            gestorArchivos = new ReporteSimple();
        }
        public ActionResult Reporte()
        {
            string archivoExcel = gestorArchivos.Reporte();

            FilePathResult download = new FilePathResult(
                archivoExcel, 
                "application/vnd.ms-excel"
                );

            download.FileDownloadName = "Reporte_2016.xls";

            return download;
        }

        public ActionResult Descarga(string id)
        {
            try {
                ArchivoDescarga archivo = gestorArchivos.TraerArchivo(id);
                FilePathResult download = new FilePathResult(archivo.Ruta, MimeMapping.GetMimeMapping(archivo.Nombre));
                download.FileDownloadName = archivo.Nombre;

                return download;
            }

            catch (IndexOutOfRangeException ex)
            {
                return new HttpNotFoundResult($"Tipo {id} no encontrado");
            }

        }
    }
}
