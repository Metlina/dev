using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PluralSightBookWebsite.Startup))]
namespace PluralSightBookWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
