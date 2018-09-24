using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCStudent.Startup))]
namespace MVCStudent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
