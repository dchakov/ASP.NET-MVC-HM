namespace Twitter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using Twitter.Models;

    public class TwitterDbContext : IdentityDbContext<ApplicationUser>, ITwitterDbContext
    {
        public TwitterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Tag> Tags { get; set; }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }
    }
}
