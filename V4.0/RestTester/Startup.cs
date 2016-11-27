using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RestTester.Startup))]
namespace RestTester
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
