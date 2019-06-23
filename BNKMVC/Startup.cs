using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BNKMVC.Startup))]
namespace BNKMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
