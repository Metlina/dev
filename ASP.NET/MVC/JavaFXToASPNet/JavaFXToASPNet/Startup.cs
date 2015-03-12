using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JavaFXToASPNet.Startup))]
namespace JavaFXToASPNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
