using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CookBook
{
    public static class WebApiConfig
    {

        public static void Register(HttpConfiguration config)
        {
            //var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            config.EnableCors();

            //config.EnableCors(new EnableCorsAttribute("*", "*", "GET, PUT, POST, DELETE"));

            // config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("text/html"));


            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
            //config.EnableCors(new EnableCorsAttribute("*","*", "GET, PUT, POST, DELETE"));
            //config.EnableCors(new EnableCorsAttribute(origins:"*", headers:"*", methods:"GET, PUT, POST"));
            //config.EnableCors(new EnableCorsAttribute("*", "*", "GET, PUT, POST, DELETE"));
            //config.Formatters.JsonFormatter.SupportedMediaTypes
            //.Add(new MediaTypeHeaderValue("application/json"));
        
        }
    }
}
