using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZadnjiLabos.Startup))]
namespace ZadnjiLabos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
