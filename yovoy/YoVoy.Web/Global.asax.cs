using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YoVoy.Web.Mapeos;

namespace YoVoy.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapeoConfiguracion.Configuracion();
            Servicios.Mapeos.MapeoConfiguracion.Configura();
            
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}
