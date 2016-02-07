using StructureMap;
using System.Security.Principal;
using System.Web;

namespace RealEstates.Web.Infrastructure.Registries
{
    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            this.For<IIdentity>().Use(() => HttpContext.Current.User.Identity);            
        }
    }
}