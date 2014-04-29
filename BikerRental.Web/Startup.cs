using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikerRental.Web.Startup))]
namespace BikerRental.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
