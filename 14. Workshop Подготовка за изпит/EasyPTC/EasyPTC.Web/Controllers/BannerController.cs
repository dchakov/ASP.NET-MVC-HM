namespace EasyPTC.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using EasyPTC.Common.Extensions;
    using EasyPTC.Data;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.Banners;
    public class BannerController : BaseController
    {
        private const string SuccessfulMessageOnVisitBanner = "You successfully visited the web-site!";

        public BannerController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var banners = this.Data.Banners.All()
                              .Where(b => b.AvailableClicks > 0)
                              .OrderBy(b => b.Id)
                              .Project()
                              .To<BannerViewModel>();

            var numberOfBanners = banners.Count();
            var randomPositionsToSkip = RandomDataGenerator.Instance.GetRandomInt(0, numberOfBanners - 1);

            var randomBanner = banners.Skip(randomPositionsToSkip)
                                      .Take(1)
                                      .FirstOrDefault();

            return this.View(randomBanner);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Visit(BannerViewModel model)
        {
            if (model != null)
            {
                var banner = this.Data.Banners.GetById(model.Id);
                if (banner.AvailableClicks > 0)
                {
                    banner.AvailableClicks--;
                    this.Data.Banners.Update(banner);
                    this.Data.SaveChanges();
                    this.SetSuccessfullMessage(SuccessfulMessageOnVisitBanner);

                    this.Response.Redirect(banner.Url, true);
                }
            }

            return this.RedirectToAction("Index");
        }

        private void SetSuccessfullMessage(string message)
        {
            this.TempData["successfulMessage"] = message;
        }
    }
}
