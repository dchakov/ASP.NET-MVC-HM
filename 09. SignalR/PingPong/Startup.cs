using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PingPong.Startup))]

namespace PingPong
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
