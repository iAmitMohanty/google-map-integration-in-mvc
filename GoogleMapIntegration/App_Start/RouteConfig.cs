using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoogleMapIntegration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "maplocation",
                url: "show-loaction-on-map",
                defaults: new { controller = "Home", action = "Location", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "locationbyaddress",
                url: "show-loaction-on-map-by-address",
                defaults: new { controller = "Home", action = "LocationByAddress", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
