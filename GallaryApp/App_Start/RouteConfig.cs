using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gallary
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)   
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Details",
                url: "character/{id}",
                defaults: new { controller = "Home", action = "About" }
            );

            routes.MapRoute(
                name: "NoFound",
                url: "{*url}",
                defaults: new { controller = "Home", action = "NotFound" }
            );

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { 
            //        controller = "Home",
            //        action = "Index",
            //        id = UrlParameter.Optional
            //    }
            //);
        }
    }
}
