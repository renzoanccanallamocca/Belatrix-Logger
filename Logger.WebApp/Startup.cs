using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Logger.WebApp.Startup))]
namespace Logger.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
