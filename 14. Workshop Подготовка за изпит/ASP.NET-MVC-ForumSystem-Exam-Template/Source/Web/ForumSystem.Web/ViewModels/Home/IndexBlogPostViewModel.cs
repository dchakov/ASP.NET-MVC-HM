namespace ForumSystem.Web.ViewModels.Home
{
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using AutoMapper;
    using System.Linq;

    public class IndexBlogPostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public int VotesCount { get; set; }

        public IEnumerable<IndexBlogPostTagViewModel> Tags { get; set; }

        public string Url
        {
            get
            {
                return string.Format("/questions/{0}/{1}", this.Id, this.Title.ToLower().Replace(" ", "-"));
            }
        }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Post, IndexBlogPostViewModel>()
                .ForMember(x => x.VotesCount,
                opt => opt.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => (int)v.Type) : 0));
        }
    }
}