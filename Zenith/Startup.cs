using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Zenith.Startup))]
namespace Zenith
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
