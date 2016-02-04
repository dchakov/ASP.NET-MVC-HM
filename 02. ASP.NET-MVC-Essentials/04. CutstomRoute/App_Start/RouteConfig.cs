using _04.CutstomRoute.Constraints;
using System.Web.Mvc;
using System.Web.Routing;

namespace _04.CutstomRoute
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               "Admin",
               "Admin/{action}",
               new { controller = "Admin" },
               new { isLocal = new LocalhostConstraint() }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
