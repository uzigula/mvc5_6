using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualOffice.Web.Startup))]
namespace VirtualOffice.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
