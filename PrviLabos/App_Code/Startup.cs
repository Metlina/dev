using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrviLabos.Startup))]
namespace PrviLabos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
