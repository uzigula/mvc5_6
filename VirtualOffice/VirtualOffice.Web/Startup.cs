using Microsoft.Owin;
using Owin;
using VirtualOffice.Web.App_Start;

[assembly: OwinStartupAttribute(typeof(VirtualOffice.Web.Startup))]
namespace VirtualOffice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SimpleInjectorInitializer.Initialize(app);
            ConfigureAuth(app);
        }
    }
}
