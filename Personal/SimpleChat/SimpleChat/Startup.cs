using Owin;
using Microsoft.Owin;
using System.Reflection;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SimpleChat.Startup))]
namespace SimpleChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //var a = Assembly.LoadFrom("Services.dll");

            app.MapSignalR();
        }
    }
}