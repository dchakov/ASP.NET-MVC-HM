namespace Twitter.Web.Models
{
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<TagViewModel> Tags { get; set; }
    }
}