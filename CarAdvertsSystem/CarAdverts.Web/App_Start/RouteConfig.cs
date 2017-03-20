﻿using System.Web.Mvc;
using System.Web.Routing;

namespace CarAdverts.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Display advert",
                url: "adverts/{id}/{url}",
                defaults: new { controller = "Advert", action = "Detail" });

            routes.MapRoute(
                name: "Adverts list",
                url: "adverts/{model}/{id}",
                defaults: new { controller = "Advert", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
