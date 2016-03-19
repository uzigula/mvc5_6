using System;
using System.Linq;
using System.Web.Mvc;
using VirtualOffice.Web.Filters.Auth.Configuration;

namespace VirtualOffice.Web.Filters.Auth
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerAuthorizationAttribute : MiAuthorizationAttribute
    {
       
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var controllerRoleMappings = AuthorizationConfiguration.Section.ControllerAuthorizationMappings.FirstOrDefault(e => e.Controller == controllerName);

            if (controllerRoleMappings != null && !string.IsNullOrEmpty(controllerRoleMappings.Roles))
            {
                //traer los roles para el controllador -> controllerName
                this.inRoles = controllerRoleMappings.Roles.Split(',');
            }
            base.OnAuthorization(filterContext);
        }
    }
}