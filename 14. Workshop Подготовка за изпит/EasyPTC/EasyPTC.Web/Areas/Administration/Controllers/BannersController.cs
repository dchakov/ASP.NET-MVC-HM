using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using EasyPTC.Models;
using EasyPTC.Web.Areas.Administration.Controllers.Base;
using EasyPTC.Data;
using AutoMapper.QueryableExtensions;
using EasyPTC.Web.Areas.Administration.ViewModels.Banners;

namespace EasyPTC.Web.Areas.Administration.Controllers
{
    public class BannersController : AdminController
    {
        public BannersController(IEasyPtcData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Read([DataSourceRequest]
                               DataSourceRequest request)
        {
            var result = this.Data.Banners.All()
                             .Project()
                             .To<BannerViewModel>();

            return this.Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest]DataSourceRequest request, BannerViewModel model)
        {
            var newId = 0;
            if (model != null && this.ModelState.IsValid)
            {
                var banner = new Banner()
                {
                    Name = model.Name,
                    Url = model.Url,
                    ImageUrl = model.ImageUrl,
                    AvailableClicks = model.AvailableClicks
                };

                this.Data.Banners.Add(banner);
                this.Data.SaveChanges();
                newId = banner.Id;
            }
            var bannerToDisplay = this.Data.Banners.All()
                .Project().To<BannerViewModel>()
                .FirstOrDefault(x => x.Id == newId);
            return Json(new[] { bannerToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest]DataSourceRequest request, BannerViewModel model)
        {
            var dbModel = this.Data.Banners.GetById(model.Id);

            if (dbModel != null && this.ModelState.IsValid)
            {
                dbModel.Name = model.Name;
                dbModel.ImageUrl = model.ImageUrl;
                dbModel.AvailableClicks = model.AvailableClicks;
                dbModel.Url = model.Url;
                this.Data.Banners.Update(dbModel);
                this.Data.SaveChanges();
            }

            return this.Json((new[] { dbModel }.ToDataSourceResult(request, this.ModelState)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Destroy([DataSourceRequest]DataSourceRequest request, BannerViewModel model)
        {
            var dbModel = this.Data.Banners.GetById(model.Id);
            this.Data.Banners.Delete(dbModel);
            this.Data.SaveChanges();

            return this.Json(new[] { model }, JsonRequestBehavior.AllowGet);
        }
    }
}

