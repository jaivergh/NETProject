using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SecondWebApp.Startup))]
namespace SecondWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			//Added comment
			//second comment
            ConfigureAuth(app);
        }
    }
}
