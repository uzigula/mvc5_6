using System.Collections.Generic;
using System.Web.Mvc;
using TiendaMusica.Infraestructura;
using TiendaMusica.Logica;
using TiendaMusica.Logica.ViewModels;

namespace TiendaMusica.Web.Controllers
{
    public class ArtistasController : Controller
    {
        private readonly TiendaConsultas tienda;
        public ArtistasController()
        {
            tienda = ConstructorServicios.TiendaConsultas();
        }
        public ActionResult Albums(string artista)
        {
            /// viene el codigo
            /// Logica de Negocio no va en un controlador
            /// 
            IEnumerable<AlbumsPorArtistaViewModel> albums = 
                                                        tienda.Albums(artista);

            return View(albums);
        }
    }
}
