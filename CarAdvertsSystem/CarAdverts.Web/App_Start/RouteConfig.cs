using System.Web.Mvc;
using System.Web.Routing;
using System.Xml.XPath;

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
                defaults: new { controller = "Advert", action = "Detail", url = UrlParameter.Optional },
                namespaces: new[] { "CarAdverts.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Adverts list",
                url: "adverts/{model}/{id}",
                defaults: new { controller = "Advert", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "CarAdverts.Web.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new [] { "CarAdverts.Web.Controllers" }
            );
        }
    }
}
