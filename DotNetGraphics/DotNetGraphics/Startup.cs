using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetGraphics.Startup))]
namespace DotNetGraphics
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
