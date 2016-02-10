namespace RealEstates.Web.Models.Home
{
    using RealEstates.Web.Models.User;
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<CityViewModel> Cities { get; set; }

        public IEnumerable<RealEstatesViewModel> RealEstates { get; set; }
    }
}