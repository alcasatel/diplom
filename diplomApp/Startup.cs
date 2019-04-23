using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(diplomApp.Startup))]
namespace diplomApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
