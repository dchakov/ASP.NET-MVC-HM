namespace Twitter.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Twitter.Data.TwitterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Twitter.Data.TwitterDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole { Name = "Administrator" });
                context.SaveChanges();
            }

            if (!context.Users.Where(u => u.UserName == "admin@site.com").Any())
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@site.com",
                    Email = "admin@site.com",
                    PasswordHash = new PasswordHasher().HashPassword("admin"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                context.Users.Add(admin);

                var role = context.Roles.Where(r => r.Name == "Administrator").FirstOrDefault();
                var adminRole = new IdentityUserRole
                {
                    RoleId = role.Id
                };

                admin.Roles.Add(adminRole);
                context.SaveChanges();
            }

            if (!context.Users.Where(u => u.UserName == "user1@site.com").Any())
            {
                for (int i = 1; i <= 2; i++)
                {
                    var user = new ApplicationUser
                    {
                        UserName = $"user{i}@site.com",
                        Email = $"user{i}@site.com",
                        PasswordHash = new PasswordHasher().HashPassword($"user{i}"),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
