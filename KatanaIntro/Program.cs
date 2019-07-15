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
        public async Task Configuration(IAppBuilder app)
        {
            app.Use(async (env, next) =>
            {
                foreach(var pair in env.Environment)
                {
                    Console.WriteLine($"{pair.Key} : {pair.Value}");
                }

                await next();
            });

            app.Use(async (env, next) =>
            {
                Console.WriteLine($"Requesting: {env.Request.Path}");
                await next();
            });
                

        }
    }

    public static class AppBuilderExtensions
    {
        public static void UseHelloWorld(this IAppBuilder app)
        {
            app.Use<HelloWorldComponent>();
        }
    }
    

    public class HelloWorldComponent
    {
        AppFunc _next;
        public HelloWorldComponent(AppFunc next)
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
