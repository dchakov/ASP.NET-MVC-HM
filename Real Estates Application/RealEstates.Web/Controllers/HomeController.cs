namespace RealEstates.Web.Controllers
{
    using Model;
    using Models.Home;
    using Models.User;
    using Ninject;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class HomeController : BaseController
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        [Inject]
        public ICitiesService CitiesService { get; set; }

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        //[OutputCache(Duration = 15 * 60, Location = System.Web.UI.OutputCacheLocation.Server)]
        public ActionResult Index()
        {
            //TODO automapper
            IEnumerable<CityViewModel> cities = this.CitiesService.GetAll()
                .AsQueryable()
                .Select(c => new CityViewModel()
                {
                    Name = c.Name
                });

            IEnumerable<UserViewModel> users = this.UsersService.GetAll()
                .AsQueryable()
                .Select(user => new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.UserName,
                    ImageUrl = user.ImageURL
                });


            IEnumerable<RealEstatesViewModel> realEstates = this.RealEstatesService.GetAll(0, 10)
                .AsQueryable()
                .Select(r => new RealEstatesViewModel()
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Address = r.Address,
                    Contact = r.Contact,
                    ConstructionYear = r.ConstructionYear,
                    SellingPrice = r.SellingPrice,
                    RentingPrice = r.RentingPrice,
                    Type = ((RealEstateType)r.Type).ToString(),
                    CreatedOn = r.CreatedOn,
                    Bedrooms = r.Bedrooms,
                    SquareMeter = r.SquareMeter,
                    UserId = r.UserId,
                    City = r.City.Name,
                    ImageUrl = r.Images.FirstOrDefault().ImageUrl
                });

            HomePageViewModel vm = new HomePageViewModel()
            {
                Cities = cities,
                Users = users,
                RealEstates = realEstates
            };

            return View();
        }
    }
}