using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MediRed.Startup))]
namespace MediRed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
