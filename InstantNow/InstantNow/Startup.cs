using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InstantNow.Startup))]
namespace InstantNow
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
