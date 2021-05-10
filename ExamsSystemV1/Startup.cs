using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamsSystemV1.Startup))]
namespace ExamsSystemV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
