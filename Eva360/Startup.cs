using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eva360.Startup))]
namespace Eva360
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
