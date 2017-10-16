using Owin;
using Microsoft.Owin;

[assembly: OwinStartup(typeof(SimpleChat.Startup))]
namespace SimpleChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}