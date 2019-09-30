using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBookings.Startup))]
namespace MyBookings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
