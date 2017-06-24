using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project.Presentation.Startup))]
namespace Project.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
