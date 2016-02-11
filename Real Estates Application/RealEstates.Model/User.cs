﻿namespace RealEstates.Model
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class User : IdentityUser
    {
        private ICollection<RealEstate> realEstates;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public User()
        {
            this.realEstates = new HashSet<RealEstate>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        [MaxLength(250)]
        public string ImageURL { get; set; }

        public virtual ICollection<RealEstate> RealEstates
        {
            get { return this.realEstates; }
            set { this.realEstates = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
