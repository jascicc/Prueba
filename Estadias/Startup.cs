using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Estadias.Startup))]
namespace Estadias
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
