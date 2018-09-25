using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SR.Web.Startup))]
namespace SR.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
