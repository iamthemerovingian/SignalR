using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Reflection;

[assembly: OwinStartup(typeof(ConsoleHost.Startup))]

namespace ConsoleHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var a = Assembly.LoadFrom("Services.dll");
            app.MapHubs(
                new Microsoft.AspNet.SignalR.HubConfiguration
                {
                    EnableCrossDomain = true
                });
        }
    }
}
