using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LargeCopies.Startup))]
namespace LargeCopies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
