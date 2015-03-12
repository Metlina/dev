using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OutOfTheBox.Startup))]
namespace OutOfTheBox
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
