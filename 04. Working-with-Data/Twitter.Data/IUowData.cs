namespace Twitter.Data
{
    using System;
    using Twitter.Data.Repositories;
    using Twitter.Models;

    public interface IUowData : IDisposable
    {
        IRepository<Tag> Tags { get; }

        IRepository<ApplicationUser> Users { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}
