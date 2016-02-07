﻿namespace RealEstates.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RealEstates.Model;

    public class RealEstatesDbContext : IdentityDbContext<User>, IRealEstatesDbContext
    {
        public RealEstatesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Rating> Ratings { get; set; }

        public IDbSet<RealEstate> RealEstates { get; set; }

        public static RealEstatesDbContext Create()
        {
            return new RealEstatesDbContext();
        }
    }
}