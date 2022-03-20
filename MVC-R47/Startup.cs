using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_R47.Startup))]
namespace MVC_R47
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
