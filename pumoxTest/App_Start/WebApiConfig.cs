using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace pumoxTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

          //  config.Routes.MapHttpRoute(
          //    name: "Search",
          //    routeTemplate: "{controller}/{action}/{Keyword}/{employeeDateOfBirthFrom}/{employeeDateOfBirthTo}",
          //    defaults: new { controller = "company", Keyword = RouteParameter.Optional, employeeDateOfBirthFrom = RouteParameter.Optional, employeeDateOfBirthTo  = RouteParameter.Optional }
          //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
