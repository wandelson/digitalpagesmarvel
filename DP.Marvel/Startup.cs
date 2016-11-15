using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DP.Marvel.Startup))]
namespace DP.Marvel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
