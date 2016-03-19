using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace VirtualOffice.Web.Areas.Publica.Controllers
{
    [Authorize(Roles = "Cliente")]
    public class PubHomeController : PublicBaseController
    {
        // GET: Publica/Home
        public ActionResult Index(string usuario)
        {
            //var reservaServicio = new Servicios.Reservas.ServicioReserva();
            //reservaServicio.Reservas(User.Usuario);

            return View();
        }

    }
}