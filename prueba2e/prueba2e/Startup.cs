using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prueba2e.Startup))]
namespace prueba2e
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
