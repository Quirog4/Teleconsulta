using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1_CapaPresentacionGM.Startup))]
namespace _1_CapaPresentacionGM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
