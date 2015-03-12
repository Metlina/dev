using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestBundle.Startup))]
namespace TestBundle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
