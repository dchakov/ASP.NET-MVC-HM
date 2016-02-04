using System.Web;
using System.Web.Routing;

namespace _04.CutstomRoute.Constraints
{
    public class LocalhostConstraint : IRouteConstraint
    {
        public bool Match(
            HttpContextBase httpContext, 
            Route route, string parameterName, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            var isAdmin = values["controller"].ToString().StartsWith("Admin");
            return isAdmin;
        }
    }
}