using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(YoVoy.Web.Startup))]
namespace YoVoy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
