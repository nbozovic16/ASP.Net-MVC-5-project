using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidlyOrg.Startup))]
namespace VidlyOrg
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
