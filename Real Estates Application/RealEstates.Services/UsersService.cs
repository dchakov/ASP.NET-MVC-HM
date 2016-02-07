﻿namespace RealEstates.Services
{
    using RealEstates.Services.Contracts;
    using System;
    using System.Linq;
    using RealEstates.Model;
    using Data.Repositories;

    public class UsersService : IUsersService
    {
        private readonly IRepository<User> users;
        private readonly IRepository<Rating> ratings;

        public UsersService(IRepository<User> users, IRepository<Rating> ratings)
        {
            this.users = users;
            this.ratings = ratings;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public IQueryable<User> GetByUserName(string username)
        {
            return this.users
                .All()
                .Where(u => u.UserName == username);
        }

        public void Rate(Rating rating)
        {
            rating.CreatedOn = DateTime.Now;
            this.ratings.Add(rating);
            this.ratings.SaveChanges();
        }
    }
}