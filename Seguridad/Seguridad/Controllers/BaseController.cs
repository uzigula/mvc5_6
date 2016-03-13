using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Seguridad.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["ActualCultura"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Session["ActualCultura"].ToString());
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Session["ActualCultura"].ToString());
                return;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo(requestContext.HttpContext.Request.UserLanguages[0]);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(requestContext.HttpContext.Request.UserLanguages[0]);

            
        }

    }
}