namespace VirtualOffice.Web.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Repositorios.DDDContext;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using System.Web;
    using Owin;
    using SimpleInjector.Extensions.ExecutionContextScoping;
    using Microsoft.Owin;
    using System;
    using Microsoft.AspNet.Identity.Owin;
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize(IAppBuilder app)
        {
            var container = new Container();



            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Options.AllowOverridingRegistrations = true;

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            InitializeContainer(container);

            app.CreatePerOwinContext(() => container.GetInstance<ApplicationDbContext>());
            app.CreatePerOwinContext(() => container.GetInstance<ApplicationUserManager>());
            app.CreatePerOwinContext(() => container.GetInstance<ApplicationSignInManager>());

            container.RegisterPerWebRequest(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            });
    
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).
            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<IVirtualOfficeRepository, EFVirtualOfficeRepository>();

            container.Register(() => new ApplicationDbContext());
            container.Register<IAuthenticationManager>(
                    () => container.GetInstance<IOwinContext>().Authentication
                );

            container.Register<IUserStore<ApplicationUser>>
                (
                    () => new UserStore<ApplicationUser>(
                        container.GetInstance<ApplicationDbContext>()
                        )
                    );


        }

     }
}