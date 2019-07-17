using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(MVC5Fund.Startup))]
namespace MVC5Fund
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}