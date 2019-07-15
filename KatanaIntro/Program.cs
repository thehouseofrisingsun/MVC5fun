using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;

namespace KatanaIntro
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost:8080";
            using (WebApp.Start<Startup>(uri))
            {
                Console.WriteLine("Started");
                Console.ReadKey();
                Console.WriteLine("Stoped");
            }
        }
    }
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use<HelloWorld>();
        }
    }

    public class HelloWorld
    {
        AppFunc _next;
        public HelloWorld(AppFunc next)
        {
            _next = next;
        }

        public Task Invoke(IDictionary<string, object> env)
        {
            var response = env["owin.ResponseBody"] as Stream;
            using(var writer = new StreamWriter(response))
            {
                return writer.WriteAsync("hi from writer stream writer");
            }
        }
    }
}
