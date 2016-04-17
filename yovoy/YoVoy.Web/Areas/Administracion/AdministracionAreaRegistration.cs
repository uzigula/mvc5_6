using System.Web.Mvc;

namespace YoVoy.Web.Areas.Administracion
{
    public class AdministracionAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administracion";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            //rutas del area

            context.MapRoute(
                name:"Administracion_default",
                url:"Admin/{controller}/{action}/{id}",
                namespaces:new []{"YoVoy.Web.Areas.Administracion.Controllers"},
                defaults:new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}