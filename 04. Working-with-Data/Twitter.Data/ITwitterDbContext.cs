namespace Twitter.Data
{
    using Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface ITwitterDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<Tweet> Tweets { get; set; }

        IDbSet<Tag> Tags { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
