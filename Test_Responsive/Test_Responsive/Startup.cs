using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Responsive.Startup))]
namespace Test_Responsive
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
