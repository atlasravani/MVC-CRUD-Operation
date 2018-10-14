using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductKeys.Startup))]
namespace ProductKeys
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
