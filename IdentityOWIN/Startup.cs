using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityOWIN.Startup))]
namespace IdentityOWIN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
