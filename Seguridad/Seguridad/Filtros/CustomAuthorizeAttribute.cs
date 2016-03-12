using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguridad.Filtros
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var logger = LogManager.GetLogger("LogingFilter");
            var log = new
            {
                Controller = filterContext
                                .ActionDescriptor.ControllerDescriptor.ControllerName,
                Action = filterContext.ActionDescriptor.ActionName,
                Ip = filterContext.HttpContext.Request.UserHostAddress,
                ClienteHost = filterContext.HttpContext.Request.UserHostName,
                Fecha = filterContext.HttpContext.Timestamp,
                Usuario = filterContext.HttpContext.User.Identity.IsAuthenticated
                            ?  filterContext.HttpContext.User.Identity.Name : "No Autenticado"
            };
            logger.InfoFormat("Acceso No Autorizado => Usuario = {0}, Ip={1}, Host={2}, Fecha={3}, Accion={4}.{5}",
                log.Usuario,
                log.Ip,
                log.ClienteHost,
                log.Fecha,
                log.Controller,
                log.Action);

            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}
