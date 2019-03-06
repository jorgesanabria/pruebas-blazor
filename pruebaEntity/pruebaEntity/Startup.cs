using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(pruebaEntity.Startup))]
namespace pruebaEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
