using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Airlines.Startup))]
namespace Airlines
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
