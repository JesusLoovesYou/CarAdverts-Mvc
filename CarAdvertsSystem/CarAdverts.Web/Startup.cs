using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarAdverts.Web.Startup))]
namespace CarAdverts.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
