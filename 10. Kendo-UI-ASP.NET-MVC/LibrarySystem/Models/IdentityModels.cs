using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LibrarySystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static LibraryDbContext Create()
        {
            return new LibraryDbContext();
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Book> Books { get; set; }
    }
}