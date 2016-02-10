namespace RealEstates.Web.Controllers
{
    using Microsoft.AspNet.Identity;
    using Ninject;
    using RealEstates.Model;
    using RealEstates.Services.Contracts;
    using RealEstates.Web.Models.User;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class UserProfileController : Controller
    {
        [Inject]
        public IUsersService UsersService { get; set; }

        [Inject]
        public ICitiesService CitiesService { get; set; }

        [Inject]
        public IRealEstatesService RealEstatesService { get; set; }

        [Authorize]
        public ActionResult MyProfile()
        {
            var currentUserId = User.Identity.GetUserId();

            if (currentUserId != null)
            {
                return RedirectToAction("Index", new { Id = currentUserId });
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Index(string Id)
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

        public ActionResult CreateRealEstate()
        {
            ViewBag.Cities = this.CitiesService.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRealEstate([Bind(Include = "Id,Title,Description,Address,Contact,ConstructionYear,SellingPrice,RentingPrice,Type,CreatedOn,Bedrooms,SquareMeter,UserId,CityId")] RealEstate realEstate,
            IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var supportedTypes = new[] { "jpg", "jpeg", "png" };
                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {
                            var fileExt = Path.GetExtension(file.FileName).Substring(1);
                            if (!supportedTypes.Contains(fileExt))
                            {
                                ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                                return View(realEstate);
                            }

                            string fileName = Path.GetFileName(file.FileName);
                            string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                            //Image Service
                            file.SaveAs(path);
                        }
                    }

                    string userID = User.Identity.GetUserId();
                    realEstate.UserId = userID;
                    realEstate.CreatedOn = DateTime.Now;
                    this.RealEstatesService.AddNew(realEstate, userID);
                    return RedirectToAction("MyProfile");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            ViewBag.CityId = new SelectList(this.CitiesService.GetAll(), "Id", "Name", realEstate.CityId);
            return View(realEstate);
        }
    }
}