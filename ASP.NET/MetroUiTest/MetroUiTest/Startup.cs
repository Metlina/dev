using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MetroUiTest.Startup))]
namespace MetroUiTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
