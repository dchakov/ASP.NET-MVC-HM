namespace RealEstates.Services
{
    using Contracts;
    using System;
    using System.Linq;
    using Model;
    using Data.Repositories;

    public class RealEstatesService : IRealEstatesService
    {
        private readonly IRepository<RealEstate> realEstates;

        public RealEstatesService(IRepository<RealEstate> realEstates)
        {
            this.realEstates = realEstates;
        }

        public IQueryable<RealEstate> GetAll(int skip, int take)
        {
            return this.realEstates
                 .All()
                 .OrderByDescending(c => c.CreatedOn)
                 .Skip(skip)
                 .Take(take);
        }

        public IQueryable<RealEstate> GetById(int id)
        {
            return this.realEstates
                .All()
                .Where(c => c.Id == id);
        }

        public int AddNew(RealEstate newRealEstate, string userId)
        {
            newRealEstate.CreatedOn = DateTime.Now;
            newRealEstate.UserId = userId;

            this.realEstates.Add(newRealEstate);
            this.realEstates.SaveChanges();

            return newRealEstate.Id;
        }
    }
}
