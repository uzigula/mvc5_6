using System;
using System.Linq;
using System.Web.Mvc;
using VirtualOffice.Web.Filters.Auth.Configuration;

namespace VirtualOffice.Web.Filters.Auth
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionAuthorizationAttribute : MiAuthorizationAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var  controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            var controllerRoleMappings = AuthorizationConfiguration.Section
                                        .ControllerAuthorizationMappings
                                        .FirstOrDefault(e => e.Controller == controllerName);

            if (controllerRoleMappings != null)
            {
                var actionRoleMappings = controllerRoleMappings.ActionAuthorizationMappings
                                            .FirstOrDefault(e => e.Action == filterContext.ActionDescriptor.ActionName);

                if (actionRoleMappings != null && !string.IsNullOrEmpty(actionRoleMappings.Roles))
                {
                    // aqui pueden cambiar para que traigan los roles del action
                    this.inRoles = actionRoleMappings.Roles.Split(',');
                }
            }
            
            base.OnAuthorization(filterContext);
        }
    }
}