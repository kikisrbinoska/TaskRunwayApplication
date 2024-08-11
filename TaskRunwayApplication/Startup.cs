using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskRunwayApplication.Startup))]
namespace TaskRunwayApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
