namespace Twitter.Data
{
    using System;
    using System.Collections.Generic;
    using Twitter.Data.Repositories;
    using Twitter.Models;

    public class UowData : IUowData
    {
        private readonly TwitterDbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public UowData()
            : this(new TwitterDbContext())
        {
        }

        public UowData(TwitterDbContext context)
        {
            this.context = context;
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
