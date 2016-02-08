namespace Twitter.Web.Models
{
    using System.Collections.Generic;
    using Twitter.Models;

    public class UserPageViewModel
    {
        public string Username { get; set; }

        public IEnumerable<Tweet> Tweets { get; set; }

        public Tweet Tweet { get; set; }
    }
}