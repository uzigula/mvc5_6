using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;

namespace VirtualOffice.Web.Filters.Auth
{
    public class MiAuthorizationAttribute : AuthorizeAttribute
    {
        private string[] _rolesArray;

        protected HttpSessionStateBase _session;
        protected string loginUrl;
        protected string homeUrl;

        public MiAuthorizationAttribute()
        {
            loginUrl = ConfigurationManager.AppSettings["loginurl"];
            homeUrl = ConfigurationManager.AppSettings["home"];
            
            var deniedController = ConfigurationManager.AppSettings["deniedController"];
            var deniedAction = ConfigurationManager.AppSettings["deniedAction"];
            
            AccessDeniedController = deniedController ?? "Errores";
            AccessDeniedAction = deniedAction ?? "NoAutorizado";
        }
        

        public string AccessDeniedController { get; set; }

        public string AccessDeniedAction { get; set; }

        public string[] inRoles
        {
            get
            {
                return _rolesArray;
            }
            set
            {
                _rolesArray = value;
                this.Roles = string.Join(",", _rolesArray);
            }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            _session = filterContext.HttpContext.Session;
            var userSession = filterContext.HttpContext.User.Usuario();

            if (string.IsNullOrEmpty(userSession))
            {
                if (filterContext.HttpContext.Request.Url == null) return;
                var redirectOnSuccess = filterContext.HttpContext.Request.Url.AbsolutePath;
                var redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);
                loginUrl = loginUrl + redirectUrl;
                filterContext.HttpContext.Response.Redirect(loginUrl, true);

            }
            else
            {
                if (IsAuthorized(userSession, filterContext))
                {
                    var cache = filterContext.HttpContext.Response.Cache;
                    cache.SetProxyMaxAge(new TimeSpan(0));
                    cache.AddValidationCallback((HttpContext context, object data, ref HttpValidationStatus validationStatus) => { validationStatus = OnCacheAuthorization(new HttpContextWrapper(context)); }, null);
                }
                else
                {
                    filterContext.Controller.TempData["error"] = new 
                                                                      {
                                                                          Title = "Perdon! Pero no tienes acceso para ver a esta pagina.",
                                                                          RootUrl = homeUrl,
                                                                          Messages = new List<string> { "Por favor contacte a su administrador de Sistema" }
                                                                      };
                    HandleUnauthorizedRequest(filterContext);
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var routeValueDictionary = new RouteValueDictionary { { "controller", AccessDeniedController }, { "action", AccessDeniedAction } };
            
            filterContext.Result = new RedirectToRouteResult("Default", routeValueDictionary);

        }

        private bool IsAuthorized(string userSession, AuthorizationContext filterContext)
        {
            try
            {
                //var roles = TraeLosPrivilegiosDelUsuario(userSession);
                var roles = new List<string>();

                return inRoles.ToList().Any(r => CheckUser(roles, r));
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool CheckUser(IEnumerable<string> roles, string role)
        {
            return (roles.ToList().Any(r => r == role));
        }

    }
}