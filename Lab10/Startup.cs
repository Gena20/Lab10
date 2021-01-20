using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab10.Startup))]
namespace Lab10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
