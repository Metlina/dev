using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookDemo.Startup))]
namespace BookDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
