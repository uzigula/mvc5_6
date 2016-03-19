using System.Web.Mvc;

namespace VirtualOffice.Web.Areas.Publica
{
    public class PublicaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Publica";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "userHome",
                url: "{usuario}",
                defaults: new { controller = "PubHome", action = "Index" }
                );

            context.MapRoute(
                name: "userReserva",
                url: "{usuario}/reservas/{action}",
                defaults: new { controller = "Reservas", action = "Index" }
                );

            context.MapRoute(
                name: "userMensajes",
                url: "{usuario}/mensajes/{action}",
                defaults: new { controller = "Mensajes", action = "Index" }
                );

            context.MapRoute(
                name: "userEsCuenta",
                url: "{usuario}/Cuenta/{action}",
                defaults: new { controller = "EstadoCuenta", action = "Index" }
                );

            context.MapRoute(
                "Publica_default",
                "Publica/{controller}/{action}/{id}",
                new { action = "Index", controller = "PubHome", id = UrlParameter.Optional }
            );
        }
    }
}