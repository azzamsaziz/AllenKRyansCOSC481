using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AllenKRyansCOSC481.Startup))]
namespace AllenKRyansCOSC481
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
