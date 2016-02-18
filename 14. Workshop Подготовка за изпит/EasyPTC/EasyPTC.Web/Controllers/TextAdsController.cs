namespace EasyPTC.Web.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using System.Linq;
    using System.Web.Mvc;
    using ViewModels.TextAds;

    public class TextAdsController : BaseController
    {
        public TextAdsController(IEasyPtcData data)
            : base(data)
        {
        }
       
        public ActionResult Index()
        {
            var textAds = this.Data.TextAdvertisements.All()
                               .Where(t => t.AvailableClicks > 0)
                               .Project()
                               .To<TextAdvertisementViewModel>()
                               .ToList();

            return this.View(textAds);
        }
    }
}