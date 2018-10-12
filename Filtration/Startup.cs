using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Filtration.Startup))]
namespace Filtration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
