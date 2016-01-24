using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Printer.Startup))]
namespace Printer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
