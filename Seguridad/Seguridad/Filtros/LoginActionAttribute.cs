using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Seguridad.Filtros
{
    public class LoginActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /// mi codigo

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
                            ? filterContext.HttpContext.User.Identity.Name : "No Autenticado"
            };
            logger.InfoFormat("Registro de Auditoria {6} => Usuario = {0}, Ip={1}, Host={2}, Fecha={3}, Accion={4}.{5}",
                log.Usuario,
                log.Ip,
                log.ClienteHost,
                log.Fecha,
                log.Controller,
                log.Action, "Antes");
            base.OnActionExecuting(filterContext);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
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
                            ? filterContext.HttpContext.User.Identity.Name : "No Autenticado"
            };
            logger.InfoFormat("Registro de Auditoria {6} => Usuario = {0}, Ip={1}, Host={2}, Fecha={3}, Accion={4}.{5}",
                log.Usuario,
                log.Ip,
                log.ClienteHost,
                log.Fecha,
                log.Controller,
                log.Action, "Despues");
            base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

    }
}
