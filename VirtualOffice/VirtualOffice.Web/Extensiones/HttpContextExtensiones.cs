using System.Web;
using System.Web.Routing;

namespace System.Web
{
    public static class HttpContextExtensiones
    {
        public static string TraerRutaCliente(this HttpContextBase context)
        {
            var routeData = RouteTable.Routes.GetRouteData(context);
            var routeValue = routeData != null ? routeData.Values["usuario"] : null;
            if (routeValue == null)
                routeValue = context.Request["usuario"];
            return routeValue == null ? string.Empty : routeValue.ToString();
        }
 
    }
}