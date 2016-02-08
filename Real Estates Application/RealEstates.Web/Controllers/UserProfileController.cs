using Microsoft.AspNet.Identity;
using Ninject;
using RealEstates.Model;
using RealEstates.Services.Contracts;
using RealEstates.Web.Models.User;
using System.Linq;
using System.Web.Mvc;

namespace RealEstates.Web.Controllers
{
    public class UserProfileController : Controller
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        [Authorize]
        public ActionResult MyProfile()
        {
            var currentUserId = User.Identity.GetUserId();

            if (currentUserId != null)
            {
                return RedirectToAction("UserPage", new { Id = currentUserId });
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult UserPage(string Id)
        {
            User appUser = this.UsersService.GetByUserId(Id);

            UserPageViewModel vm = new UserPageViewModel()
            {
                ImageURL = appUser.ImageURL,
                Comments = appUser.Comments.OrderByDescending(c => c.RealEstate).ToList(),
                RealEstates = appUser.RealEstates.OrderByDescending(r => r.CreatedOn).ToList(),
                Ratings = appUser.Ratings.ToList()
            };

            return View(vm);
        }

    }
}