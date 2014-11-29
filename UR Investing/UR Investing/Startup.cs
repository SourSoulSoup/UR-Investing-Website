using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UR_Investing.Startup))]
namespace UR_Investing
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
