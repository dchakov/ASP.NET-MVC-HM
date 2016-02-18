namespace EasyPTC.Web.ViewModels.TextAds
{
    using EasyPTC.Models;
    using Infrastructure.Mapping;

    public class TextAdvertisementViewModel : IMapFrom<TextAdvertisement>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }
    }
}