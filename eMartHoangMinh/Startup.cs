using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eMartHoangMinh.Startup))]
namespace eMartHoangMinh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
