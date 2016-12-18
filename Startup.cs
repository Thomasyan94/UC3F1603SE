using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ys.Startup))]
namespace ys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
