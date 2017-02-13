using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EthosChronicle.Startup))]
namespace EthosChronicle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
