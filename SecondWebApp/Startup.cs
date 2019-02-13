using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecondWebApp.Startup))]
namespace SecondWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
