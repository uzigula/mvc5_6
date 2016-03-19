using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace VirtualOffice.Web.Areas.Publica.Controllers
{
    public class PublicBaseController : Controller
    {
        // GET: Publica/PublicBase
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            var rutaDesdeUrl = requestContext.HttpContext.TraerRutaCliente();
            var rutaDesdeSesion = (User as ClaimsPrincipal).TraerRutaCliente();


            if (rutaDesdeSesion == rutaDesdeUrl)
                ViewBag.RutaCliente = rutaDesdeUrl;
            else
                throw new Exception("No esta Autorizado");


        }

    }
}