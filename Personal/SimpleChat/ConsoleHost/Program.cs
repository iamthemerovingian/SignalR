using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Hosting;

namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("http://localhost:6789"))
            {
                Console.WriteLine("Hubs Running at: " + "http://localhost:6789");
                Console.ReadLine();
            }
        }
    }
}
