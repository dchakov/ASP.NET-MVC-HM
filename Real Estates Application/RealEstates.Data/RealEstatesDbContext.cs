namespace RealEstates.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using RealEstates.Model;

    public class RealEstatesDbContext : IdentityDbContext<User>
    {
        public RealEstatesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static RealEstatesDbContext Create()
        {
            return new RealEstatesDbContext();
        }
    }
}
