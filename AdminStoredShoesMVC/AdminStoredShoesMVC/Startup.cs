using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminStoredShoesMVC.Startup))]
namespace AdminStoredShoesMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
