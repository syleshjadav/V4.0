using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShopFrontEnd.Startup))]
namespace MyShopFrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
