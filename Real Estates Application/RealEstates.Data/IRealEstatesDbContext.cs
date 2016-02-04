namespace RealEstates.Data
{
    using RealEstates.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IRealEstatesDbContext
    {
        IDbSet<User> Users { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}
