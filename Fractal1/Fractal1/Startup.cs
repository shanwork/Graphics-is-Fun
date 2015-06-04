using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fractal1.Startup))]
namespace Fractal1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
