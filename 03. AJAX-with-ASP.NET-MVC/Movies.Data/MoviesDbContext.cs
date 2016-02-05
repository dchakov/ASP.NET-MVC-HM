namespace Movies.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Movies.Models;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class MoviesDbContext : IdentityDbContext<ApplicationUser>
    {
        public MoviesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
