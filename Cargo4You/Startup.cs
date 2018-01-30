using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cargo4You.Startup))]
namespace Cargo4You
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
