using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(E_Learning_System.Startup))]

namespace E_Learning_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
