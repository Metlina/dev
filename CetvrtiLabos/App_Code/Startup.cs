using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CetvrtiLabos.Startup))]
namespace CetvrtiLabos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
