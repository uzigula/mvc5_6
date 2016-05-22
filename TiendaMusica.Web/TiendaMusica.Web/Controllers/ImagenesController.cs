using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaMusica.Web.Controllers
{
    public class ImagenesController : Controller
    {
        // GET: Imagenes
        [AcceptVerbs(HttpVerbs.Get)]
        [OutputCache(CacheProfile = "AlbumImages")]
        public FileResult Show(string id, string ext)
        {
            var path = Path.Combine(Server.MapPath("~/imagenes/Albums"),id+$".{ext}");
            return new FileStreamResult(new FileStream(path, FileMode.Open), MimeMapping.GetMimeMapping($"{id}.{ext}"));
        }

        [AcceptVerbs(HttpVerbs.Get)]
        [OutputCache(CacheProfile = "AlbumImages")]
        public FileResult NoCover()
        {
            var path = Path.Combine(Server.MapPath("~/imagenes"), "nocover.png");
            return new FileStreamResult(new FileStream(path, FileMode.Open), MimeMapping.GetMimeMapping("nocover.png"));
        }
    }
}